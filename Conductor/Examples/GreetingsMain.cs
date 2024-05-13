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
using Conductor.Client;
using Conductor.Definition;
using Conductor.Examples.Workers;
using Conductor.Executor;
using System.Threading;

namespace Conductor.Examples
{
    public class GreetingsMain
    {
        private readonly Configuration _configuration;
        public GreetingsMain()
        {
            _configuration = new Client.Configuration();
        }
        public (ConductorWorkflow, string workflowId) RegisterWorkflow(WorkflowExecutor workflowExecutor)
        {
            GreetingsWorkflow greetingsWorkflow = new GreetingsWorkflow();
            var workflow = greetingsWorkflow.CreateGreetingsWorkflow();
            workflowExecutor.RegisterWorkflow(workflow, true);
            var workflowId = workflowExecutor.StartWorkflow(workflow);
            return (workflow, workflowId);
        }

        public void GreetingsMainMethod()
        {
            WorkflowExecutor workflowExecutor = new WorkflowExecutor(_configuration);
            (ConductorWorkflow workflow, string workflowId) = RegisterWorkflow(workflowExecutor);

            var waitHandle = new ManualResetEvent(false);
            //Remove DynamicWorker once the annotation is in place
            var backgroundTask = System.Threading.Tasks.Task.Run(async () => await Utils.WorkerUtil.StartBackGroundTask(waitHandle, new DynamicWorker("greetings_task_test")));
            waitHandle.WaitOne();
        }
    }
}