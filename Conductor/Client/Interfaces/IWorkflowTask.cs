﻿/*
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
using Conductor.Client.Models;
using Conductor.Client.Worker;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Conductor.Client.Interfaces
{
    public interface IWorkflowTask
    {
        string TaskType { get; }
        WorkflowTaskExecutorConfiguration WorkerSettings { get; }
        Task<TaskResult> Execute(Models.Task task, CancellationToken token = default);
        [Obsolete("Execute is going to be deprecated. Instead of TaskResult Execute method use the overloaded Task<TaskResult> Execute method going forward")]
        TaskResult Execute(Models.Task task);
    }
}
