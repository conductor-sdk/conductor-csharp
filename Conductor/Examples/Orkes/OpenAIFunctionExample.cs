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
using Conductor.Examples.Orkes.Workers;
using Conductor.Executor;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Conductor.Examples.Orkes
{
    public class OpenAIFunctionExample
    {
        private readonly Client.Configuration _configuration;
        private readonly Orchestrator _orchestrator;
        private readonly OpenAIConfig _openAIConfig;
        private readonly WorkflowExecutor _workflowExecutor;
        private readonly WorkflowResourceApi _workflowClient;
        private readonly TaskResourceApi _taskClient;
        private readonly MetadataResourceApi _metadataClient;
        private readonly ILogger _logger;

        //const
        private const string TASKDEFINITIONDESCRIPTION = "Get Weather Description";
        private const string TASKDEFDESCRIPTION = "Get price from Amazon Description";
        private const string FUNCTIONAICHATBOT = "my_function_chatbot";
        private const string TESTAIFUNCTION = "test_AI_Function";

        public OpenAIFunctionExample()
        {
            _configuration = new Client.Configuration();
            _openAIConfig = new OpenAIConfig();
            _orchestrator = new Orchestrator(_configuration);
            _workflowExecutor = new WorkflowExecutor(_configuration);
            _workflowClient = ApiExtensions.GetClient<WorkflowResourceApi>();
            _metadataClient = ApiExtensions.GetClient<MetadataResourceApi>();
            _logger = ApplicationLogging.CreateLogger<OpenAIChatGpt>();

            //For local testing
            //var _orkesApiClient = new OrkesApiClient(_configuration, new OrkesAuthenticationSettings(Constants.KEY_ID, Constants.KEY_SECRET));
            //_workflowClient = _orkesApiClient.GetClient<WorkflowResourceApi>();
            //_metadataClient = _orkesApiClient.GetClient<MetadataResourceApi>();

        }

        [WorkerTask(taskType: "getWeather", batchSize: 5, domain: "taskDomain", pollIntervalMs: 200, workerId: "workerId")]
        public string GetWeather(string city)
        {
            return $"Weather in {city} today is rainy";
        }

        [WorkerTask(taskType: "getPriceFromAmazon", batchSize: 5, domain: "taskDomain", pollIntervalMs: 200, workerId: "workerId")]
        public float GetPriceFromAmazon(string products)
        {
            return 42.42F;
        }

        public void OpenAIFunctionExampleTest()
        {
            string llmProvider = ExampleConstants.OPENAITEXT + Environment.UserName;
            string chatCompleteModel = ExampleConstants.OPENAIGPT;
            List<TaskDef> taskDefs = new List<TaskDef>()
{
new TaskDef() { Name = ExampleConstants.OPENAITASKDEFINITIONNAME, Description = TASKDEFINITIONDESCRIPTION},
new TaskDef() { Name = ExampleConstants.OPENAITASKDEFNAME, Description = TASKDEFDESCRIPTION}
};

            _metadataClient.RegisterTaskDef(taskDefs);
            _orchestrator.AddAIIntegration(llmProvider, Client.Ai.Configuration.LLMProviderEnum.OPEN_AI, new List<string> { chatCompleteModel }, "openai config", _openAIConfig);
            _orchestrator.AddPromptTemplate(ExampleConstants.OPENAI_PROMPTNAME, ExampleConstants.OPENAI_FUNCTION_PROMPTTEXT, ExampleConstants.PROMPTTEMPLATEDESCRIPTION);
            _orchestrator.AssociatePromptTemplate(llmProvider, new List<string> { chatCompleteModel }, ExampleConstants.OPENAI_PROMPTNAME);

            var workflow = new ConductorWorkflow()
            .WithName(FUNCTIONAICHATBOT)
            .WithDescription(TESTAIFUNCTION)
            .WithVersion(1);

            var user_input = new WaitTask("get_user_input", new TimeSpan(1));
            var Message = "${chat_complete_ref.input.messages}";

            var collectHistoryTask = ChatWorkers.CollectHistory(
            userInput: user_input.Output("question"),
            assistantResponse: "${chat_complete_ref.output.result}",
            history: JsonConvert.DeserializeObject<List<ChatMessage>>(Message),
            seedQuestion: null);

            var chatComplete = new LlmChatComplete(
            taskReferenceName: ExampleConstants.CHATCOMPLETEREF,
            llmProvider: llmProvider,
            model: chatCompleteModel,
            instructionsTemplate: Constants.PROMPTNAME,
            //We have to update the messages parameter to get the value from "collectHistoryTask.output('result')"
            messages: collectHistoryTask
            );

            var functionCall = new DynamicTask(
            taskRefName: "fn_call_ref",
            dynamicTask: chatComplete.Output("function")
            );

            functionCall.InputParameters["inputs"] = chatComplete.Output("function_parameters");
            functionCall.InputParameters[ExampleConstants.DYNAMICTASKINPUTPARAM] = ExampleConstants.INPUTS;

            //we have to add collectHistoryTask once the annotation implementation is done
            WorkflowTask[] loop_tasks = new WorkflowTask[] { user_input, chatComplete, functionCall };
            var chat_loop = new LoopTask("loop", 3, loop_tasks);

            workflow.WithTask(chat_loop);

            workflow.WithTimeoutPolicy(WorkflowDef.TimeoutPolicyEnum.TIMEOUTWF, 120);
            _logger.LogInformation(ExampleConstants.OPENAI_MESSAGE);
            _workflowExecutor.RegisterWorkflow(workflow, true);
            var waitHandle = new ManualResetEvent(false);
            var backgroundTask = System.Threading.Tasks.Task.Run(async () => await Utils.WorkerUtil.StartBackGroundTask(waitHandle));
            waitHandle.WaitOne();
            StartWorkflowRequest startWorkflow = new StartWorkflowRequest()
            {
                Name = workflow.Name,
                Version = workflow.Version,
                WorkflowDef = workflow,
                CreatedBy = Constants.OWNER_EMAIL
            };

            var workflowRun = _workflowClient.ExecuteWorkflow(startWorkflow, "1234", user_input.TaskReferenceName, 1);
            var workflowId = workflowRun.WorkflowId;

            while (workflowRun.Status != WorkflowRun.StatusEnum.COMPLETED)
            {
                if (workflowRun.CurrentTask.TaskDefName == user_input.TaskReferenceName)
                {
                    var function_call_task = workflowRun.GetTask("fn_call_ref");
                    if (function_call_task != null)
                    {
                        var assistant = function_call_task.OutputData["result"];
                        _logger.LogInformation($"assistant: {assistant}");
                    }

                    if (workflowRun.CurrentTask.TaskDefName == user_input.TaskReferenceName)
                    {
                        _logger.LogInformation("Question: >> ");
                        string question = Console.ReadLine();
                        _taskClient.UpdateTaskSync(new Dictionary<string, object> { { "question", question } }, workflowId, user_input.TaskReferenceName, TaskResult.StatusEnum.COMPLETED);
                    }
                }

                Thread.Sleep(500);
                var workflowResult = _workflowClient.GetWorkflow(workflowId: workflowId, includeTasks: true);
                var result = workflowResult.Output["result"];
                string output = JsonConvert.SerializeObject(result, Formatting.Indented);
                _logger.LogInformation($"\n{output}\n");
            }
        }
    }
}