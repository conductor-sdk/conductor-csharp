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

