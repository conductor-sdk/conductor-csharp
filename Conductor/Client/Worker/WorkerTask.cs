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
using System;

namespace Conductor.Client.Worker
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class WorkerTask : Attribute
    {
        public string TaskType { get; set; }
        public WorkflowTaskExecutorConfiguration WorkerSettings { get; set; }

        public WorkerTask()
        {
            WorkerSettings = new WorkflowTaskExecutorConfiguration();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkerTask" /> class.
        /// </summary>
        /// <param name="taskType"></param>
        /// <param name="batchSize"></param>
        /// <param name="domain"></param>
        /// <param name="pollIntervalMs"></param>
        /// <param name="workerId"></param>
        public WorkerTask(string taskType = default, int batchSize = default, string domain = default, int pollIntervalMs = default, string workerId = default)
        {
            TaskType = taskType;
            WorkerSettings = new WorkflowTaskExecutorConfiguration
            {
                BatchSize = batchSize,
                Domain = domain,
                PollInterval = TimeSpan.FromMilliseconds(pollIntervalMs),
                WorkerId = workerId,
            };
        }
    }
}
