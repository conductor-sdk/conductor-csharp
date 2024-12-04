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
using Conductor.Examples.Orkes;
using Conductor.Examples.Workers;
using Conductor.Executor;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;

namespace Conductor.Examples
{
    [WorkerTask]
    public class WaitForWebhook
    {
        private readonly Client.Configuration _configuration;
        private readonly Orchestrator _orchestrator;
        private readonly OpenAIConfig _openAIConfig;
        private readonly WorkflowExecutor _workflowExecutor;
        private readonly WorkflowResourceApi _workflowClient;
        private readonly MetadataResourceApi _metadataClient;
        private readonly ILogger _logger;

        //Const
        private const string WORKFLOWNAME = "wait_for_webHook";
        private const string WORKFLOWDESC = "test_wait for webhook";

        public WaitForWebhook()
        {
            _configuration = new Client.Configuration();
            _workflowExecutor = new WorkflowExecutor(_configuration);
            _workflowClient = ApiExtensions.GetClient<WorkflowResourceApi>();
            _metadataClient = ApiExtensions.GetClient<MetadataResourceApi>();
            _logger = ApplicationLogging.CreateLogger<OpenAIChatGpt>();

            //For local testing
            //var _orkesApiClient = new OrkesApiClient(_configuration, new OrkesAuthenticationSettings(Constants.KEY_ID, Constants.KEY_SECRET));
            //_workflowClient = _orkesApiClient.GetClient<WorkflowResourceApi>();
            //_metaDataClient = _orkesApiClient.GetClient<MetadataResourceApi>();
        }

        [WorkerTask(taskType: ExampleConstants.GetEmail, batchSize: 5, pollIntervalMs: 520, workerId: "workerId")]
        public string GetUserEmail(string userId)
        {
            return $"{userId}@example.com";
        }

        [WorkerTask(taskType: ExampleConstants.SendEmail, batchSize: 5, pollIntervalMs: 520, workerId: "workerId")]
        public string SendEmail(string email, string subject, string body)
        {
            return $"sending email to {email} with subject {subject} and body {body}";
        }

        public void WaitForWebhookTest()
        {
            ConductorWorkflow workflow = new ConductorWorkflow()
            .WithName(WORKFLOWNAME)
            .WithDescription(WORKFLOWDESC)
            .WithVersion(1);

            workflow.WithInputParameter("userId");

            var getEmailTask = new SimpleTask(ExampleConstants.GetEmail, ExampleConstants.GetEmail).WithInput("userId", workflow.Input("userId"));
            getEmailTask.Description = "Test Get email";

            workflow.WithTask(getEmailTask);

            var SendEmailTask = new SimpleTask("SendEmail", "SendEmail")
            .WithInput("email", workflow.Input("email"))
            .WithInput("subject", workflow.Input("subject"))
            .WithInput("body", workflow.Input("body"));

            workflow.WithTask(SendEmailTask);

            var WaitForWebhookTask = new WaitForWebHookTask("wait_ref", new Dictionary<string, object> { { "type", "customer" }, { "id", workflow.Input("userId") } });
            workflow.WithTask(WaitForWebhookTask);


            var testInput = new Dictionary<string, object>
{
{ "userId", "Test" },
{"email","email test" },
{"body","body test" },
{"subject","subject test" }
};

            StartWorkflowRequest startWorkflowRequest = new StartWorkflowRequest()
            {
                Name = workflow.Name,
                Input = testInput,
                Version = workflow.Version,
                WorkflowDef = workflow,
                CreatedBy = Constants.OWNER_EMAIL
            };

            var workflowRun = _workflowClient.ExecuteWorkflow(startWorkflowRequest, "1234", startWorkflowRequest.Name, 1);
            var waitHandle = new ManualResetEvent(false);
            var backgroundTask = System.Threading.Tasks.Task.Run(async () => await Utils.WorkerUtil.StartBackGroundTask(waitHandle));
            waitHandle.WaitOne();
            _logger.LogInformation($"\nworkflow execution {workflowRun.WorkflowId}\n");
        }
    }
}