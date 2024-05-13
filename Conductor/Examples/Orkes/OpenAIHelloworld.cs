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
using Conductor.Executor;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Conductor.Examples.Orkes
{
    public class OpenAIHelloworld
    {
        private readonly Client.Configuration _configuration;
        private readonly Orchestrator _orchestrator;
        private readonly OpenAIConfig _openAIConfig;
        private readonly WorkflowExecutor _workflowExecutor;
        private readonly WorkflowResourceApi _workflowClient;
        private readonly ILogger logger;

        //const
        private const string TEXTEMBEDDINGCOMPLETEMODEL = "text-embedding-ada-002";
        private const string WORKFLOWNAME = "say_hi_to_the_friend";
        private const string WORKFLOWDESCRIPTION = "test_ai_chatgpt";

        public OpenAIHelloworld()
        {
            _configuration = new Client.Configuration();
            _openAIConfig = new OpenAIConfig();
            _orchestrator = new Orchestrator(_configuration);
            _workflowExecutor = new WorkflowExecutor(_configuration);
            logger = ApplicationLogging.CreateLogger<OpenAIHelloworld>();
            _workflowClient = ApiExtensions.GetClient<WorkflowResourceApi>();

            //For local testing
            //var _orkesApiClient = new OrkesApiClient(_configuration, new OrkesAuthenticationSettings(Constants.KEY_ID, Constants.KEY_SECRET));
            //_workflowClient = _orkesApiClient.GetClient<WorkflowResourceApi>();
        }

        [WorkerTask("get_friends_name", 5, "taskDomain", 200, "workerId")]
        public string GetFriendName()
        {
            string name = Environment.UserName;
            return (string.IsNullOrEmpty(name.Trim())) ? "anonymous" : name;
        }

        public void OpenAIHelloworldTest()
        {
            string llmProvider = ExampleConstants.OPENAITEXT + GetFriendName();
            string textCompleteModel = ExampleConstants.OPENAIGPT;
            _orchestrator.AddAIIntegration(llmProvider, Client.Ai.Configuration.LLMProviderEnum.OPEN_AI, new List<string> { textCompleteModel, TEXTEMBEDDINGCOMPLETEMODEL }, "openai config", _openAIConfig);
            _orchestrator.AddPromptTemplate(ExampleConstants.OPENAIPROMPTNAME, ExampleConstants.OPENAIPROMPTTEXT, "test prompt");
            _orchestrator.AssociatePromptTemplate(llmProvider, new List<string> { textCompleteModel }, ExampleConstants.OPENAIPROMPTNAME);

            PromptTemplateTestRequest promptTemplateTestRequest = new PromptTemplateTestRequest();
            promptTemplateTestRequest.PromptVariables = new Dictionary<string, object> { { "friend_name", "Orkes" } };
            promptTemplateTestRequest.LlmProvider = llmProvider;
            promptTemplateTestRequest.Model = textCompleteModel;
            promptTemplateTestRequest.Prompt = ExampleConstants.OPENAIPROMPTTEXT;
            _orchestrator.TestPromptTemplate(promptTemplateTestRequest);

            //Update this logic to use GetFriendName() once the annotaion is in place
            var getName = new SimpleTask("get_friends_name", "get_friends_name_ref");
            var textComplete = new LlmTextComplete(taskRefName: "say_hi_ref", llmProvider: llmProvider, model: textCompleteModel, promptName: ExampleConstants.OPENAIPROMPTNAME);
            textComplete.PromptVariable("friend_name", getName.Output("result"));
            ConductorWorkflow workflow = new ConductorWorkflow()
            .WithName(WORKFLOWNAME)
            .WithDescription(WORKFLOWDESCRIPTION)
            .WithVersion(1);
            workflow.WithTask(getName);
            workflow.WithTask(textComplete);
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
            logger.LogInformation($"{ExampleConstants.OPENAI_LOGMESSAGE}: {workflowRun.Output["result"]}\n\n");
        }
    }
}
