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
using Conductor.Client.Models;
using System;
using System.Collections.Generic;

namespace Conductor.Client.Extensions
{
    public static class ConductorTaskExtensions
    {
        public static TaskResult InProgress(this Task task, string log = null, long? callbackAfterSeconds = null, Dictionary<string, object> outputData = null)
        {
            return new TaskResult
            (
                workflowInstanceId: task.WorkflowInstanceId,
                taskId: task.TaskId,
                status: TaskResult.StatusEnum.INPROGRESS,
                outputData: outputData,
                logs: new List<TaskExecLog>
                {
                    new TaskExecLog { TaskId = task.TaskId, Log = log, CreatedTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                },
                callbackAfterSeconds: callbackAfterSeconds
            );
        }

        public static TaskResult InProgress(this Task task, Dictionary<string, object> outputData = null, List<TaskExecLog> logs = null)
        {
            return new TaskResult
            (
                workflowInstanceId: task.WorkflowInstanceId,
                taskId: task.TaskId,
                status: TaskResult.StatusEnum.INPROGRESS,
                outputData: outputData,
                logs: logs
            );
        }

        public static TaskResult Completed(this Task task, Dictionary<string, object> outputData = null, List<TaskExecLog> logs = null)
        {
            return new TaskResult
            (
                workflowInstanceId: task.WorkflowInstanceId,
                taskId: task.TaskId,
                status: TaskResult.StatusEnum.COMPLETED,
                outputData: outputData,
                logs: logs
            );
        }

        public static TaskResult Failed(this Task task, string errorMessage, Dictionary<string, object> outputData = null, List<TaskExecLog> logs = null)
        {
            return new TaskResult
            (
                workflowInstanceId: task.WorkflowInstanceId,
                taskId: task.TaskId,
                status: TaskResult.StatusEnum.FAILED,
                reasonForIncompletion: errorMessage,
                outputData: outputData,
                logs: logs
            );
        }

        public static TaskResult FailedWithTerminalError(this Task task, string errorMessage, Dictionary<string, object> outputData = null, List<TaskExecLog> logs = null)
        {
            return new TaskResult
            (
                workflowInstanceId: task.WorkflowInstanceId,
                taskId: task.TaskId,
                status: TaskResult.StatusEnum.FAILEDWITHTERMINALERROR,
                reasonForIncompletion: errorMessage,
                outputData: outputData,
                logs: logs
            );
        }
    }
}
