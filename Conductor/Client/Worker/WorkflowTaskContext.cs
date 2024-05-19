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
using Client.Worker.Utils;
using Conductor.Client.Models;
using System.Threading;

namespace Conductor.Client.Worker
{
    public class WorkflowTaskContext
    {
        private static readonly ThreadLocal<WorkflowTaskContext> TASK_CONTEXT_INHERITABLE_THREAD_LOCAL =
        new ThreadLocal<WorkflowTaskContext>(() => null);

        private readonly Task task;
        private readonly TaskResult taskResult;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowTaskContext" /> class.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="taskResult"></param>
        public WorkflowTaskContext(Task task, TaskResult taskResult)
        {
            this.task = task;
            this.taskResult = taskResult;
        }

        /// <summary>
        /// Method to get the value of WorkflowTaskContext
        /// </summary>
        /// <returns></returns>
        public static WorkflowTaskContext Get()
        {
            return TASK_CONTEXT_INHERITABLE_THREAD_LOCAL.Value;
        }

        /// <summary>
        /// Method to set the WorkflowTaskContext
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public static WorkflowTaskContext Set(Task task)
        {
            TaskResult result = WorkerUtil.GetTaskResult(task);
            WorkflowTaskContext context = new WorkflowTaskContext(task, result);
            TASK_CONTEXT_INHERITABLE_THREAD_LOCAL.Value = context;
            return context;
        }

        /// <summary>
        /// Method to get the WorkflowInstanceId
        /// </summary>
        /// <returns></returns>
        public string GetWorkflowInstanceId()
        {
            return task.WorkflowInstanceId;
        }

        /// <summary>
        /// Method to get the TaskId
        /// </summary>
        /// <returns></returns>
        public string GetTaskId()
        {
            return task.TaskId;
        }

        /// <summary>
        /// Method to get the RetryCount
        /// </summary>
        /// <returns></returns>
        public int? GetRetryCount()
        {
            return task.RetryCount;
        }

        /// <summary>
        /// Method to get the PollCount
        /// </summary>
        /// <returns></returns>
        public int? GetPollCount()
        {
            return task.PollCount;
        }

        /// <summary>
        /// Method to get the CallbackAfterSeconds value
        /// </summary>
        /// <returns></returns>
        public long? GetCallbackAfterSeconds()
        {
            return task.CallbackAfterSeconds;
        }

        /// <summary>
        /// Method to get the task
        /// </summary>
        /// <returns></returns>
        public Task GetTask()
        {
            return task;
        }

        /// <summary>
        /// Method to get the taskResult
        /// </summary>
        /// <returns></returns>
        public TaskResult GetTaskResult()
        {
            return taskResult;
        }

        /// <summary>
        /// Method to set the SetCallbackAfterSeconds variable
        /// </summary>
        /// <param name="seconds"></param>
        public void SetCallbackAfter(int seconds)
        {
            taskResult.SetCallbackAfterSeconds(seconds);
        }
    }
}

