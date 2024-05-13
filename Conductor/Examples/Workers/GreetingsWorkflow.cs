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
using Conductor.Client.Worker;
using Conductor.Definition;
using Conductor.Definition.TaskType;

namespace Conductor.Examples
{
    public class GreetingsWorkflow
    {
        private const string WorkflowName = "Test_Workflow_Greeting";
        private const string WorkflowDescription = "test description";

        [WorkerTask("greetings_task", 5, "taskDomain", 420, "workerId")]
        public string Greet(string name)
        {
            return $"Hello {name}";
        }

        public ConductorWorkflow CreateGreetingsWorkflow()
        {
            var wf = new ConductorWorkflow()
                .WithName(WorkflowName)
                .WithDescription(WorkflowDescription)
                .WithVersion(1)
                //Here call Greet() instead of creating SimpleTask manually.
                .WithTask(new SimpleTask("greetings_task_test", "greet_ref_test"));
            return wf;
        }
    }
}