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
using Conductor.Client.Extensions;
using Conductor.Client.Interfaces;
using Conductor.Client.Models;
using Conductor.Client.Worker;
using System;
using System.Threading;

namespace Conductor.Examples.Workers
{
    public class DynamicWorker : IWorkflowTask
    {
        public string TaskType { get; }

        public WorkflowTaskExecutorConfiguration WorkerSettings { get; }

        public DynamicWorker(string taskType = "workflow-task")
        {
            TaskType = taskType;
            WorkerSettings = new WorkflowTaskExecutorConfiguration();
        }

        public System.Threading.Tasks.Task<TaskResult> Execute(Client.Models.Task task, CancellationToken token = default)
        {
            return System.Threading.Tasks.Task.FromResult(task.Completed());
        }

        public TaskResult Execute(Client.Models.Task task)
        {
            throw new NotImplementedException();
        }
    }
}
