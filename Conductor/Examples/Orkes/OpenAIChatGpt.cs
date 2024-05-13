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
    public class OpenAIChatGpt
    {
        private readonly Client.Configuration _configuration;
        private readonly Orchestrator _orchestrator;
        private readonly OpenAIConfig _openAIConfig;
        private readonly WorkflowExecutor _workflowExecutor;
        private readonly WorkflowResourceApi _workflowClient;
        private readonly ILogger _logger;

        //Const
        private const string QUESTIONREF = "gen_question_ref";
        private const string FOLLOWUPQUESTIONREF = "followup_question_ref";
        private const string PROMPTTEMPLATEDESCRIPTION = "Generates a question";
        private const string PROMPTTEMPLATEDESC = "Generates a question about the context";

        public OpenAIChatGpt()
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
            _orchestrator.AddPromptTemplate(ExampleConstants.OPENAICHATGPT_QUESTIONGENERATOR_PROMPT, PROMPTTEMPLATEDESCRIPTION, ExampleConstants.OPENAICHATGPT_Q_PROMPTNAME);
            _orchestrator.AddPromptTemplate(ExampleConstants.OPENAICHATGPT_QUESTIONGENERATOR, PROMPTTEMPLATEDESC, ExampleConstants.OPENAICHATGPT_FOLLOWUP_PROMPTNAME);

            _orchestrator.AssociatePromptTemplate(llmProvider, new List<string> { chatCompleteModel }, ExampleConstants.OPENAICHATGPT_PROMPTNAME);
            _orchestrator.AssociatePromptTemplate(llmProvider, new List<string> { chatCompleteModel }, ExampleConstants.OPENAICHATGPT_Q_PROMPTNAME);
            _orchestrator.AssociatePromptTemplate(llmProvider, new List<string> { chatCompleteModel }, ExampleConstants.OPENAICHATGPT_FOLLOWUP_PROMPTNAME);

            ConductorWorkflow workflow = new ConductorWorkflow()
            .WithName(ExampleConstants.CHATBOT)
            .WithDescription(ExampleConstants.CHATBOTDESCRIPTION)
            .WithVersion(1);
            var questionGen = new LlmChatComplete(taskReferenceName: QUESTIONREF, llmProvider: llmProvider, model: chatCompleteModel, instructionsTemplate: ExampleConstants.OPENAICHATGPT_Q_PROMPTNAME, messages: new List<ChatMessage>(), temperature: 1);
            var followUpGen = new LlmChatComplete(taskReferenceName: FOLLOWUPQUESTIONREF, llmProvider: llmProvider, model: chatCompleteModel, instructionsTemplate: ExampleConstants.OPENAICHATGPT_FOLLOWUP_PROMPTNAME, messages: new List<ChatMessage>());
            ChatMessage chatMessage = new ChatMessage(message: "${chat_complete_ref.input.messages}", role: "user");
            string assistantResult = "${chat_complete_ref.output.result}";
            var collectHistoryTask = Workers.ChatWorkers.CollectHistory(userInput: followUpGen.Output("result"), seedQuestion: questionGen.Output("result"), assistantResponse: assistantResult, history: new List<ChatMessage>() { chatMessage });
            //We have to update the messages parameter to get the value from "collectHistoryTask.output('result')"
            var chatComplete = new LlmChatComplete(taskReferenceName: ExampleConstants.CHATCOMPLETEREF, llmProvider: llmProvider, model: chatCompleteModel, messages: collectHistoryTask, instructionsTemplate: ExampleConstants.OPENAICHATGPT_PROMPTNAME, maxTokens: 2048);
            followUpGen.PromptVariable("context", chatComplete.Output("result"));
            followUpGen.PromptVariable("past_questions", "${collect_history_ref.input.history[?(@.role=='user')].message}");

            string collectorJs = ConversationCollector.GetConversation();
            var collect = new JavascriptTask(taskReferenceName: "collect_ref", script: collectorJs);

            //we have to add collector collectHistoryTask once the annotation implementation is done
            WorkflowTask[] loopTasks = new WorkflowTask[] { chatComplete, followUpGen };
            var chatLoop = new LoopTask(taskReferenceName: "loop", iterations: 3, loopOver: loopTasks);

            workflow.WithTask(questionGen, chatLoop, collect);
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
            _logger.LogInformation($"{workflowRun.GetTask(taskReferenceName: questionGen.TaskReferenceName).OutputData["result"]}");

            string workflowId = workflowRun.WorkflowId;
            while (workflowRun.Status != WorkflowRun.StatusEnum.COMPLETED)
            {
                var workflowResult = _workflowClient.GetWorkflow(workflowId: workflowId, includeTasks: true);
                var followUpQ = workflowResult.GetTask(taskReferenceName: followUpGen.TaskReferenceName);
                if (followUpQ != null && followUpQ.Status == Client.Models.Task.StatusEnum.FAILEDWITHTERMINALERROR)
                {
                    _logger.LogInformation($"\t>> Thinking about... {followUpQ.OutputData["result"].ToString().Trim()}");
                }
                Thread.Sleep(500);
            }

            object result = workflowRun.Output["result"];

            // Convert the 'result' object to JSON with indentation
            string output = JsonConvert.SerializeObject(result, Formatting.Indented);

            // Printing the JSON-formatted output to the console
            _logger.LogInformation($"\n{output}\n");
        }
    }
}
