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
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Conductor.Examples
{
    [WorkerTask]
    public class ShellWorker
    {
        private readonly WorkflowResourceApi _workflowClient;
        private readonly MetadataResourceApi _metaDataClient;
        private readonly WorkflowExecutor _workflowExecutor;

        //const
        private const string WorkflowName = "shellWorker";
        private const string WorkflowDescription = "test_shell_worker";

        public ShellWorker()
        {
            Configuration configuration = new Configuration();
            _workflowClient = ApiExtensions.GetClient<WorkflowResourceApi>();
            _metaDataClient = ApiExtensions.GetClient<MetadataResourceApi>();

            //For local testing
            //var _orkesApiClient = new OrkesApiClient(configuration, new OrkesAuthenticationSettings(Constants.KEY_ID, Constants.KEY_SECRET));
            //_workflowClient = _orkesApiClient.GetClient<WorkflowResourceApi>();
            //_metaDataClient = _orkesApiClient.GetClient<MetadataResourceApi>();
        }

        [WorkerTask(taskType: "ExecuteShell1", batchSize: 5, pollIntervalMs: 520, workerId: "workerId")]
        public string Executeshell1(string command, string[] args)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command), "Command cannot be null.");
            }

            if (args == null)
            {
                throw new ArgumentNullException(nameof(args), "Arguments cannot be null.");
            }
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "",     // Add a application fileName based on OS. Ex: cmd.exe
                RedirectStandardOutput = true,
                UseShellExecute = false,
                Arguments = $"/c dir {string.Join(" ", args)}"
            };

            var process = new Process
            {
                StartInfo = processStartInfo
            };

            process.Start();

            StringBuilder output = new StringBuilder();
            while (!process.StandardOutput.EndOfStream)
            {
                output.AppendLine(process.StandardOutput.ReadLine());
            }

            return output.ToString();
        }

        [WorkerTask(taskType: "ExecuteShell", batchSize: 5, pollIntervalMs: 520, workerId: "workerId")]
        public string ExecuteShell()
        {
            return "hello";
        }

        public void ShellWorkerMain()
        {
            ConductorWorkflow workflow = new ConductorWorkflow()
            .WithName(WorkflowName)
            .WithDescription(WorkflowDescription)
            .WithVersion(1);

            var getEmailTask = new SimpleTask("ExecuteShell1", "ExecuteShell1").WithInput("command", workflow.Input("command")).WithInput("args", workflow.Input("args"));
            getEmailTask.Description = ExampleConstants.GetEmailDescription;
            workflow.WithTask(getEmailTask);

            var SendEmailTask = new SimpleTask("ExecuteShell", "ExecuteShell");
            SendEmailTask.Description = ExampleConstants.SendEmailDescription;
            workflow.WithTask(SendEmailTask);
            List<TaskDef> taskDefs = new List<TaskDef>()
{
new TaskDef{Description = "test", Name = ExampleConstants.GetEmail },
new TaskDef{Description = "test", Name = ExampleConstants.SendEmail }

};

            _metaDataClient.RegisterTaskDef(taskDefs);
            _metaDataClient.UpdateWorkflowDefinitions(new List<WorkflowDef>(1) { workflow });
            var testInput = new Dictionary<string, object>
            {
                //{ "command", "ls" }, // uncomment this line and change the command according to the context.
                //{ "args", new[] { "/c", "dir" } } // uncomment this line and change the args according to the given context.
            };

            StartWorkflowRequest startWorkflowRequest = new StartWorkflowRequest()
            {
                Name = workflow.Name,
                Input = testInput,
                Version = workflow.Version,
                WorkflowDef = workflow,
                CreatedBy = Constants.OWNER_EMAIL
            };

            _workflowClient.StartWorkflow(startWorkflowRequest);
            var waitHandle = new ManualResetEvent(false);

            var backgroundTask = System.Threading.Tasks.Task.Run(async () => await Conductor.Examples.Utils.WorkerUtil.StartBackGroundTask(waitHandle));
            waitHandle.WaitOne();
        }
    }
}
