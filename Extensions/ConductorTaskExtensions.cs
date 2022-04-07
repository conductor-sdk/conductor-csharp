using Conductor.Client.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conductor.Client.Extensions
{
    public static class ConductorTaskExtensions
    {
        public static TaskResult InProgress(this Task task, string log = null, long? callbackAfterSeconds = null, Dictionary<string, object> outputData = null)
        {
            return new TaskResult
            {
                WorkflowInstanceId = task.WorkflowInstanceId,
                TaskId = task.TaskId,
                Status = TaskResult.StatusEnum.INPROGRESS,
                OutputData = outputData,
                Logs =  new List<TaskExecLog>
                {
                    new TaskExecLog { TaskId = task.TaskId, Log = log, CreatedTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                },
                CallbackAfterSeconds = callbackAfterSeconds.Value
            };
        }

        public static TaskResult InProgress(this Task task, Dictionary<string, object> outputData = null, List<TaskExecLog> logs = null)
        {
            return new TaskResult
            {
                WorkflowInstanceId = task.WorkflowInstanceId,
                TaskId = task.TaskId,
                Status = TaskResult.StatusEnum.INPROGRESS,
                OutputData = outputData,
                Logs = logs
            };
        }

        public static TaskResult Completed(this Task task, Dictionary<string, object> outputData = null, List<TaskExecLog> logs = null)
        {
            return new TaskResult
            {
                WorkflowInstanceId = task.WorkflowInstanceId,
                TaskId = task.TaskId,
                Status = TaskResult.StatusEnum.COMPLETED,
                OutputData = outputData,
                Logs = logs
            };
        }

        public static TaskResult Failed(this Task task, string errorMessage, Dictionary<string, object> outputData = null, List<TaskExecLog> logs = null)
        {
            return new TaskResult
            {
                WorkflowInstanceId = task.WorkflowInstanceId,
                TaskId = task.TaskId,
                Status = TaskResult.StatusEnum.FAILED,
                ReasonForIncompletion = errorMessage,
                OutputData = outputData,
                Logs = logs
            };
        }

        public static TaskResult FailedWithTerminalError(this Task task, string errorMessage, Dictionary<string, object> outputData = null, List<TaskExecLog> logs = null)
        {
            return new TaskResult
            {
                WorkflowInstanceId = task.WorkflowInstanceId,
                TaskId = task.TaskId,
                Status = TaskResult.StatusEnum.FAILEDWITHTERMINALERROR,
                ReasonForIncompletion = errorMessage,
                OutputData = outputData,
                Logs = logs
            };
        }
    }
}
