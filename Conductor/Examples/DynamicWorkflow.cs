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
using Conductor.Api;
using Conductor.Client;
using Conductor.Client.Extensions;
using Conductor.Client.Models;
using Conductor.Client.Worker;
using Conductor.Definition;
using Conductor.Definition.TaskType;
using Conductor.Examples.Workers;
using Conductor.Executor;
using System.Collections.Generic;
using System.Threading;

namespace Conductor.Examples
{
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

        [WorkerTask(taskType: "GetEmail", 5, "taskDomain", 520, "workerId")]
        public string GetUserEmail(string userId)
        {
            return $"{userId}@example.com";
        }

        [WorkerTask(taskType: "SendEmail", 5, "taskDomain", 520, "workerId")]
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

            //Once the annotator is ready we have to remove this piece of code as the task creation will be taken care inside the wrapper method
            var getEmailTask = new SimpleTask("GetEmail", "GetEmail").WithInput("InputVaraible", workflow.Input("userId"));
            getEmailTask.Description = "Test Get email";
            workflow.WithTask(getEmailTask);

            var SendEmailTask = new SimpleTask("SendEmail", "Send_Email_refTask").WithInput("InputVaraible", workflow.Input("userId"));
            SendEmailTask.Description = "Test Get email";
            workflow.WithTask(SendEmailTask);

            TaskDef taskDef = new TaskDef() { Description = "test", Name = "dynamic_workflow-task" };

            _metaDataClient.RegisterTaskDef(new List<TaskDef>() { taskDef });
            _workflowExecutor.RegisterWorkflow(workflow, true);

            var testInput = new Dictionary<string, object>
{
{ "userId", "Test" }
};

            StartWorkflowRequest startWorkflow = new StartWorkflowRequest()
            {
                Name = workflow.Name,
                Input = testInput,
                Version = workflow.Version,
                WorkflowDef = workflow,
                CreatedBy = Constants.OWNER_EMAIL
            };

            var workflowTask = _workflowExecutor.StartWorkflow(startWorkflow);
            var waitHandle = new ManualResetEvent(false);

            //For testing purpose the worker is created manually for now. Once the annotation logic is in place we can getrid of this
            var backgroundTask = System.Threading.Tasks.Task.Run(async () => await Utils.WorkerUtil.StartBackGroundTask(waitHandle, new DynamicWorker("GetEmail")));
            waitHandle.WaitOne();
        }
    }
}
