using Conductor.Client.Interfaces;
using Conductor.Client.Models;
using System.Reflection;

namespace Conductor.Client.Worker
{
    public class GenericWorker : IWorkflowTask
    {
        public string TaskType { get; }
        public WorkflowTaskExecutorConfiguration WorkerSettings { get; }

        private readonly object _workerInstance;
        private readonly MethodInfo _executeTaskMethod;

        public GenericWorker(string taskType, WorkflowTaskExecutorConfiguration workerSettings, MethodInfo executeTaskMethod, object workerInstance = null)
        {
            TaskType = taskType;
            WorkerSettings = workerSettings;
            _executeTaskMethod = executeTaskMethod;
            _workerInstance = workerInstance;
        }

        public TaskResult Execute(Task task)
        {
            var taskResult = _executeTaskMethod.Invoke(_workerInstance, new object[] { task });
            return (TaskResult)taskResult;
        }
    }
}
