using conductor.csharp.Client.Extensions;
using conductor.Examples;
using Conductor.Api;
using Conductor.Client;
using Conductor.Client.Ai;
using Conductor.Client.Extensions;
using Conductor.Client.Models;
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
using Tasks = Conductor.Definition.TaskType.Task;

namespace Conductor.Examples.Orkes
{
    public class OpenAIChatUserInput
    {
        private readonly Client.Configuration _configuration;
        private readonly Orchestrator _orchestrator;
        private readonly OpenAIConfig _openAIConfig;
        private readonly WorkflowExecutor _workflowExecutor;
        private readonly WorkflowResourceApi _workflowClient;
        private readonly TaskResourceApi _taskClient;
        private readonly ILogger _logger;

        public OpenAIChatUserInput()
        {
            _configuration = new Client.Configuration();
            _openAIConfig = new OpenAIConfig();
            _orchestrator = new Orchestrator(_configuration);
            _workflowExecutor = new WorkflowExecutor(_configuration);
            _workflowClient = ApiExtensions.GetClient<WorkflowResourceApi>();
            _logger = ApplicationLogging.CreateLogger<OpenAIChatGpt>();

            //For local testing
            //var _orkesApiClient = new OrkesApiClient(_configuration, new OrkesAuthenticationSettings(Constants.KEY_ID, Constants.KEY_SECRET));
            //_workflowClient = _orkesApiClient.GetClient<WorkflowResourceApi>();
        }

        public void OpenAIChatGPTTest()
        {
            string llmProvider = ExampleConstants.OPENAITEXT + Environment.UserName;
            string chatCompleteModel = ExampleConstants.OPENAIGPT;
            _orchestrator.AddAIIntegration(llmProvider, Client.Ai.Configuration.LLMProviderEnum.OPEN_AI, new List<string> { chatCompleteModel }, ExampleConstants.OPENAICONFIG, _openAIConfig);
            _orchestrator.AddPromptTemplate(ExampleConstants.OPENAICHATGPT_PROMPTTEXT, ExampleConstants.PROMPTTEMPLATEDESCRIPTION, ExampleConstants.OPENAICHATGPT_PROMPTNAME);
            _orchestrator.AssociatePromptTemplate(llmProvider, new List<string> { chatCompleteModel }, ExampleConstants.OPENAICHATGPT_PROMPTNAME);

            ConductorWorkflow workflow = new ConductorWorkflow()
            .WithName(ExampleConstants.CHATBOT)
            .WithDescription(ExampleConstants.CHATBOTDESCRIPTION)
            .WithVersion(1);

            Tasks userInput = new WaitTask("user_input_ref", new TimeSpan(1));
            string assistantResult = "${chat_complete_ref.output.result}";
            var collectHistoryTask = Workers.ChatWorkers.CollectHistory(userInput: userInput.Output("question"), assistantResponse: assistantResult, history: new List<ChatMessage>(), seedQuestion: "");
            //We have to update the messages parameter to get the value from "collectHistoryTask.output('result')"
            var chatComplete = new LlmChatComplete(taskReferenceName: ExampleConstants.CHATCOMPLETEREF, llmProvider: llmProvider, model: chatCompleteModel, messages: collectHistoryTask, instructionsTemplate: ExampleConstants.OPENAICHATGPT_PROMPTNAME, maxTokens: 2048);

            string collectorJs = ConversationCollector.GetConversation();
            var collect = new JavascriptTask(taskReferenceName: "collect_ref", script: collectorJs);

            //we have to add collector collectHistoryTask once the annotation implementation is done
            WorkflowTask[] loopTasks = new WorkflowTask[] { userInput, chatComplete };
            var chatLoop = new LoopTask(taskReferenceName: "loop", iterations: 5, loopOver: loopTasks);


            workflow.WithTask(chatLoop, collect);
            workflow.WithTimeoutPolicy(WorkflowDef.TimeoutPolicyEnum.TIMEOUTWF, 120);
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
            var workflowRun = _workflowClient.ExecuteWorkflow(startWorkflow, "1234", startWorkflow.Name, 1);
            _logger.LogInformation(ExampleConstants.LOGMESSAGE);
            var workflowId = workflowRun.WorkflowId;
            while (workflowRun.Status != WorkflowRun.StatusEnum.COMPLETED)
            {
                if (workflowRun.CurrentTask.TaskDefName == userInput.TaskReferenceName)
                {
                    var assistantTask = workflowRun.GetTask(taskReferenceName: chatComplete.TaskReferenceName);
                    if (assistantTask != null)
                    {
                        _logger.LogInformation("Assistant", assistantTask.OutputData["result"]);
                    }

                    if (workflowRun.CurrentTask.TaskDefName == userInput.TaskReferenceName)
                    {
                        _logger.LogInformation("Ask a Question: >> ");
                        string question = Console.ReadLine();
                        _taskClient.UpdateTaskSync(output: new Dictionary<string, object> { { "question", question } }, workflowId: workflowId, taskRefName: userInput.TaskReferenceName, status: TaskResult.StatusEnum.COMPLETED);

                    }
                }
                Thread.Sleep(500);
                var workflowResult = _workflowClient.GetWorkflow(workflowId: workflowId, includeTasks: true);
                object result = workflowResult.Output["result"];

                // Convert the 'result' object to JSON with indentation
                string output = JsonConvert.SerializeObject(result, Formatting.Indented);

                // Printing the JSON-formatted output to the console
                _logger.LogInformation($"\n{output}\n");
            }
        }
    }
}
