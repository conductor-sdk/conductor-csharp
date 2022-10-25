using Conductor.Models;
using System;
using System.Collections.Generic;

namespace Conductor.Extensions
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
                callbackAfterSeconds: callbackAfterSeconds.Value
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
