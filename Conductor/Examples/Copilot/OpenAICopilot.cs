/*
 * Copyright 2024 Conductor Authors.
 * <p>
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with
 * the License. You may obtain a copy of the License at
 * <p>
 * http://www.apache.org/licenses/LICENSE-2.0
 * <p>
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on
 * an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the
 * specific language governing permissions and limitations under the License.
 */
using conductor.csharp.Client.Extensions;
using conductor.Examples;
using Conductor.Api;
using Conductor.Client;
using Conductor.Client.Ai;
using Conductor.Client.Extensions;
using Conductor.Client.Models;
using Conductor.Client.Worker;
using Conductor.Definition;
using Conductor.Definition.TaskType;
using Conductor.Definition.TaskType.LlmTasks;
using Conductor.Examples.Workers;
using Conductor.Executor;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Tasks = Conductor.Definition.TaskType.Task;

namespace Conductor.Examples.Copilot
{
    public class OpenAICopilot
    {
        private readonly WorkflowResourceApi _workflowClient;
        private readonly MetadataResourceApi _metaDataClient;
        private readonly WorkflowExecutor _workflowExecutor;
        private readonly Client.Configuration _configuration;
        private readonly ILogger _logger;

        //consts

        public const string FUNCTIONCHATBOX = "my_function_chatbot";
        public const string FUNCTIONCHATBOXDESCRIPTION = "test_function_chatbot";

        public OpenAICopilot()
        {
            _configuration = new Client.Configuration();
            _workflowExecutor = new WorkflowExecutor(_configuration);
            _workflowClient = ApiExtensions.GetClient<WorkflowResourceApi>();
            _metaDataClient = ApiExtensions.GetClient<MetadataResourceApi>();
            _logger = ApplicationLogging.CreateLogger<OpenAICopilot>();

            //For local testing
            //var _orkesApiClient = new OrkesApiClient(_configuration, new OrkesAuthenticationSettings(Constants.KEY_ID, Constants.KEY_SECRET));
            //_workflowClient = _orkesApiClient.GetClient<WorkflowResourceApi>();
            //_metaDataClient = _orkesApiClient.GetClient<MetadataResourceApi>();
        }

        [WorkerTask("get_customer_list", 5, "taskDomain", 200, "workerId")]
        public List<Customer> GetCustomerList()
        {
            var customers = new List<Customer>();
            var random = new Random();
            for (int i = 0; i < 100; i++)
            {
                var customerName = GenerateRandomString(random, ExampleConstants.RANDOMCHARACTERS, 5);
                var spend = random.Next(100000, 9000000);
                customers.Add(new Customer
                {
                    Id = i,
                    Name = "Customer " + customerName,
                    AnnualSpend = spend,
                    Country = "US"
                });
            }
            return customers;
        }

        [WorkerTask("get_top_n", 5, "taskDomain", 200, "workerId")]
        public List<Customer> GetTopNCustomers(int n, List<Customer> customers)
        {
            var sortedCustomers = customers.OrderByDescending(c => c.AnnualSpend).ToList();
            var end = Math.Min(n + 1, sortedCustomers.Count);
            return sortedCustomers.GetRange(1, end - 1);
        }

        [WorkerTask("generate_promo_code", 5, "taskDomain", 200, "workerId")]
        public string GeneratePromoCode()
        {
            var random = new Random();
            var promoCode = GenerateRandomString(random, ExampleConstants.RANDOMCHARACTERS, 5);
            return promoCode;
        }

        [WorkerTask("send_email", 5, "taskDomain", 200, "workerId")]
        public string SendEmail(List<Customer> customers, string promoCode)
        {
            return $"Sent {promoCode} to {customers.Count} customers";
        }

        [WorkerTask(taskType: "create_workflow", 5, "taskDomain", 520, "workerId")]
        public Dictionary<string, object> CreateWorkflow(List<string> steps, Dictionary<string, object> inputs)
        {
            var workflow = new ConductorWorkflow()
            .WithName(ExampleConstants.COPILOTEXECUTION)
            .WithDescription(ExampleConstants.COPILOTDESCRIPTION)
            .WithVersion(1);
            for (int i = 0; i < steps.Count; i++)
            {
                if (steps[i] != "review")
                {
                    Tasks task = new HumanTask(taskRefName: "review", displayName: "review email", formVersion: 0, formTemplate: "email_review");
                    var inputValue = inputs["step"];
                    task.InputParameters.Add("step", inputValue);
                    workflow.WithTask(task);
                }
                else
                {
                    Tasks task = new SimpleTask(taskName: steps[i], taskReferenceName: steps[i]);
                    var inputValue = inputs["step"];
                    task.InputParameters.Add("step", inputValue);
                    workflow.WithTask(task);
                }
            }

            _workflowExecutor.RegisterWorkflow(workflow, true);
            _logger.LogInformation($"\n\n\nRegistered workflow by name {workflow.Name}\n");
            return workflow.ToDictionary();
        }

        public static string GenerateRandomString(Random random, string characters, int length)
        {
            return new string(Enumerable.Repeat(characters, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void OpenAICopilotTest()
        {
            string llmProvider = ExampleConstants.OPENAITEXT + Environment.UserName;
            string chatCompleteModel = ExampleConstants.OPENAIGPT;
            string promtName = ExampleConstants.OPENAI_PROMPTNAME;
            var openAIConfig = new OpenAIConfig();
            var orchestrator = new Orchestrator(_configuration);
            var taskDefs = new List<TaskDef>()
{
new TaskDef() { Description = "test", Name = ExampleConstants.OPENAITASKDEFINITIONNAME },
new TaskDef() { Description = "test", Name = ExampleConstants.OPENAITASKDEFNAME }
};

            _metaDataClient.RegisterTaskDef(taskDefs);
            orchestrator.AddAIIntegration(llmProvider, Client.Ai.Configuration.LLMProviderEnum.OPEN_AI, new List<string> { chatCompleteModel }, ExampleConstants.OPENAICONFIG, openAIConfig);
            orchestrator.AddPromptTemplate(ExampleConstants.PROMPT_TEXT, ExampleConstants.PROMPTTEMPLATEDESCRIPTION, promtName);
            orchestrator.AssociatePromptTemplate(llmProvider, new List<string> { chatCompleteModel }, promtName);
            ConductorWorkflow workflow = new ConductorWorkflow()
            .WithName(FUNCTIONCHATBOX)
            .WithDescription(FUNCTIONCHATBOXDESCRIPTION)
            .WithVersion(1);
            Tasks userInput = new WaitTask("get_user_input", new TimeSpan(1));
            var chatComplete = new LlmChatComplete(taskReferenceName: ExampleConstants.CHATCOMPLETEREF, llmProvider: llmProvider, model: chatCompleteModel, messages: new List<ChatMessage> { new ChatMessage("user", userInput.Output("query")) }, instructionsTemplate: promtName, maxTokens: 2048);
            Tasks functionCall = new DynamicTask("SUB_WORKFLOW", "fn_call_ref");
            functionCall.WithInput("steps", chatComplete.Output("function_parameters.steps"));
            functionCall.WithInput(ExampleConstants.INPUTS, chatComplete.Output("function_parameters.inputs"));
            functionCall.WithInput("subWorkflowName", ExampleConstants.COPILOTEXECUTION);
            functionCall.WithInput("subWorkflowVersion", 1);

            Tasks subWorkFlow = new SubWorkflowTask("execute_workflow", new SubWorkflowParams(ExampleConstants.COPILOTEXECUTION));

            //Pass task reference name once the annotation is in place
            var registerWorkFlow = CreateWorkflow(steps: new List<string> { chatComplete.Output("function_parameters.steps") }, inputs: new Dictionary<string, object>
{
{ "step", "function_parameters.inputs" }
});
            var callFunction = new SwitchTask("to_call_or_not", chatComplete.Output("function"));
            callFunction.WithDecisionCase(ExampleConstants.CREATEWORKFLOW, new WorkflowTask[] { (WorkflowTask)registerWorkFlow["Tasks"], subWorkFlow });
            Tasks defaultFunc = new DynamicTask(chatComplete.Output("function"), "call_one_fun_ref");
            defaultFunc.WithInput(ExampleConstants.INPUTS, chatComplete.Output("function_parameters"));
            defaultFunc.WithInput(ExampleConstants.DYNAMICTASKINPUTPARAM, ExampleConstants.INPUTS);
            callFunction.WithDefaultCase(defaultFunc);

            workflow.WithTask(userInput);
            workflow.WithTask(chatComplete);
            workflow.WithTask(callFunction);
            workflow.WithTimeoutPolicy(WorkflowDef.TimeoutPolicyEnum.TIMEOUTWF, 120);

            var waitHandle = new ManualResetEvent(false);
            var backgroundTask = System.Threading.Tasks.Task.Run(async () => await Utils.WorkerUtil.StartBackGroundTask(waitHandle, new DynamicWorker("get_user_input"), new DynamicWorker("chat_complete_ref"), new DynamicWorker("to_call_or_not")));
            waitHandle.WaitOne();
            StartWorkflowRequest startWorkflow = new StartWorkflowRequest()
            {
                Name = workflow.Name,
                Version = workflow.Version,
                WorkflowDef = workflow,
                CreatedBy = Constants.OWNER_EMAIL
            };
            var workflowRun = _workflowClient.ExecuteWorkflow(startWorkflow, "1234", startWorkflow.Name, 1, userInput.TaskReferenceName);
            string workFlowId = workflowRun.WorkflowId;
            _logger.LogInformation(ExampleConstants.USEROPTIONS);
            string query = Console.ReadLine();
            var inputTask = workflowRun.GetTask(taskReferenceName: userInput.TaskReferenceName);

            WorkflowStateUpdate workflowStateUpdate = new WorkflowStateUpdate()
            {
                TaskReferenceName = userInput.TaskReferenceName,
                TaskResult = new TaskResult
                {
                    TaskId = inputTask.TaskId,
                    OutputData = new Dictionary<string, object>
{
{"query", query }
},
                    Status = TaskResult.StatusEnum.COMPLETED
                }
            };
            workflowRun = _workflowClient.UpdateWorkflow(workflowId: workFlowId, request: workflowStateUpdate, waitForSeconds: 30);
            object result = workflowRun.Output["result"];

            // Convert the 'result' object to JSON with indentation
            string output = JsonConvert.SerializeObject(result, Formatting.Indented);

            // Printing the JSON-formatted output to the console
            _logger.LogInformation($"\n{output}\n");
        }
    }
}
