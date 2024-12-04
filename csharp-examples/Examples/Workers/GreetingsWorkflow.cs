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
using Conductor.Client.Extensions;
using Conductor.Client.Models;
using Conductor.Client.Worker;
using Conductor.Definition;
using Conductor.Definition.TaskType;
using System.Collections.Generic;

namespace Conductor.Examples
{
    [WorkerTask]
    public class GreetingsWorkflow
    {
        private readonly MetadataResourceApi _metaDataClient;
        private const string WorkflowName = "Test_Workflow_Greeting";
        private const string WorkflowDescription = "test description";

        public GreetingsWorkflow()
        {
            _metaDataClient = ApiExtensions.GetClient<MetadataResourceApi>();

            //dev local testing
            //Configuration configuration = new Configuration();
            //var _orkesApiClient = new OrkesApiClient(configuration, new OrkesAuthenticationSettings(Constants.KEY_ID, Constants.KEY_SECRET));
            //_metaDataClient = _orkesApiClient.GetClient<MetadataResourceApi>();

        }
        [WorkerTask(taskType: "Greet", batchSize: 5, pollIntervalMs: 420, workerId: "workerId")]
        public string Greet(string name)
        {
            return $"Hello {name}";
        }

        public ConductorWorkflow CreateGreetingsWorkflow()
        {
            var workflow = new ConductorWorkflow()
            .WithName(WorkflowName)
            .WithDescription(WorkflowDescription)
            .WithVersion(1);

            var greetTask = new SimpleTask(ExampleConstants.GreetTask, ExampleConstants.GreetTask).WithInput("name", workflow.Input("name"));
            greetTask.Description = ExampleConstants.GreetDescription;
            workflow.WithTask(greetTask);

            TaskDef taskDefs = new TaskDef()
            {
                Description = "test",
                Name = ExampleConstants.GreetTask
            };

            _metaDataClient.RegisterTaskDef(new List<TaskDef>() { taskDefs });
            return workflow;
        }
    }
}