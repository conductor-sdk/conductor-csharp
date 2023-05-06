using Conductor.Client.Interfaces;
using Conductor.Client.Models;
using System.Reflection;

namespace Conductor.Client.Worker
{
    public class GenericWorker : IWorkflowTask
    {
        public string TaskType { get; }
        public WorkflowTaskExecutorConfiguration WorkerSettings { get; }

        private readonly MethodInfo _executeTaskMethod;

        public GenericWorker(string taskType, WorkflowTaskExecutorConfiguration workerSettings, MethodInfo executeTaskMethod)
        {
            TaskType = taskType;
            WorkerSettings = workerSettings;
            _executeTaskMethod = executeTaskMethod;
        }

        public TaskResult Execute(Task task)
        {
            var taskResult = _executeTaskMethod.Invoke(null, new object[] { task });
            return (TaskResult)taskResult;
        }
    }
}
