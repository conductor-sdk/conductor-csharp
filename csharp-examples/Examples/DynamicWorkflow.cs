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
using conductor.Examples;
using Conductor.Api;
using Conductor.Client;
using Conductor.Client.Extensions;
using Conductor.Client.Models;
using Conductor.Client.Worker;
using Conductor.Definition;
using Conductor.Definition.TaskType;
using Conductor.Executor;
using System.Collections.Generic;
using System.Threading;

namespace Conductor.Examples
{
    [WorkerTask]
    public class DynamicWorkflow
    {
        private readonly WorkflowResourceApi _workflowClient;
        private readonly MetadataResourceApi _metaDataClient;
        private readonly WorkflowExecutor _workflowExecutor;

        //const
        private const string WorkflowName = "dynamic_workflow";
        private const string WorkflowDescription = "test_dynamic_workflow";

        public DynamicWorkflow()
        {
            var config = new Configuration();
            _workflowExecutor = new WorkflowExecutor(config);
            _workflowClient = ApiExtensions.GetClient<WorkflowResourceApi>();
            _metaDataClient = ApiExtensions.GetClient<MetadataResourceApi>();

            //For local testing
            //var _orkesApiClient = new OrkesApiClient(config, new OrkesAuthenticationSettings(Constants.KEY_ID, Constants.KEY_SECRET));
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

        public void DynamicWorkFlowMain()
        {
            ConductorWorkflow workflow = new ConductorWorkflow()
            .WithName(WorkflowName)
            .WithDescription(WorkflowDescription)
            .WithVersion(1);

            workflow.WithInputParameter("userId");

            var getEmailTask = new SimpleTask(ExampleConstants.GetEmail, ExampleConstants.GetEmail).WithInput("userId", workflow.Input("userId"));
            getEmailTask.Description = ExampleConstants.GetEmailDescription;
            workflow.WithTask(getEmailTask);

            var SendEmailTask = new SimpleTask(ExampleConstants.SendEmail, ExampleConstants.SendEmail).WithInput("email", workflow.Input("email")).WithInput("subject", workflow.Input("subject")).WithInput("body", workflow.Input("body"));
            SendEmailTask.Description = ExampleConstants.SendEmailDescription;
            workflow.WithTask(SendEmailTask);

            List<TaskDef> taskDefs = new List<TaskDef>()
{
new TaskDef{Description = ExampleConstants.GetEmailDescription, Name = ExampleConstants.GetEmail },
new TaskDef{Description = ExampleConstants.SendEmailDescription,Name = ExampleConstants.SendEmail}
};

            _metaDataClient.RegisterTaskDef(taskDefs);
            _metaDataClient.UpdateWorkflowDefinitions(new List<WorkflowDef>(1) { workflow });

            var testInput = new Dictionary<string, object>
{
{ "userId", "Test" },
{ "email", "email@gmail.com" },
{ "subject", "SubjectTest" },
{ "body" , "BodyDescription" }
};

            StartWorkflowRequest startWorkflowRequest = new StartWorkflowRequest()
            {
                Name = workflow.Name,
                Input = testInput,
                Version = workflow.Version,
                WorkflowDef = workflow,
                CreatedBy = Constants.OWNER_EMAIL,
            };

            _workflowClient.StartWorkflow(startWorkflowRequest);
            var waitHandle = new ManualResetEvent(false);

            var backgroundTask = System.Threading.Tasks.Task.Run(async () => await Utils.WorkerUtil.StartBackGroundTask(waitHandle));
            waitHandle.WaitOne();
        }
    }
}
