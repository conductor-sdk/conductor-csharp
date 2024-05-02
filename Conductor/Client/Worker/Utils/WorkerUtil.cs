using Conductor.Client.Models;
using System;

namespace Client.Worker.Utils
{
    public static class WorkerUtil
    {
        public const string TerminalError = "terminal error";
        public const string Fatal = "fatal";

        /// <summary>
        /// Returns the taskResult object
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public static TaskResult GetTaskResult(Task task)
        {
            return new TaskResult(callbackAfterSeconds: task.CallbackAfterSeconds, taskId: task.TaskId,
                externalOutputPayloadStoragePath: task.ExternalOutputPayloadStoragePath, workflowInstanceId: task.WorkflowInstanceId, outputData: task.OutputData, reasonForIncompletion: task.ReasonForIncompletion,
                status: GetStatus(task), subWorkflowId: task.SubWorkflowId, workerId: task.WorkerId);
        }

        /// <summary>
        /// Returns the status based on task result
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static TaskResult.StatusEnum GetStatus(Task task)
        {
            TaskResult.StatusEnum status;
            switch (task.Status)
            {
                case Task.StatusEnum.CANCELED:
                case Task.StatusEnum.COMPLETEDWITHERRORS:
                case Task.StatusEnum.TIMEDOUT:
                case Task.StatusEnum.SKIPPED:
                    status = TaskResult.StatusEnum.FAILED;
                    break;
                case Task.StatusEnum.SCHEDULED:
                    status = TaskResult.StatusEnum.INPROGRESS;
                    break;
                default:
                    if (!Enum.TryParse(task.Status.ToString(), out status))
                    {
                        throw new ArgumentException($"Unknown status: {task.Status}");
                    }
                    break;
            }

            return status;
        }

        /// <summary>
        /// Checks if the exception is a terminal error
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static bool IsTerminalError(Exception exception)
        {
            if (exception.Message.Contains(TerminalError))
            {
                return true;
            }

            if (exception.StackTrace != null && exception.StackTrace.Contains(Fatal))
            {
                return true;
            }

            return false;
        }
    }
}
