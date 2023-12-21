using Conductor.Client.Interfaces;
using Conductor.Client.Models;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

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

        public async Task<TaskResult> Execute(Models.Task task, CancellationToken token)
        {

            if (token.IsCancellationRequested)
                return new TaskResult() { Status = TaskResult.StatusEnum.FAILEDWITHTERMINALERROR, ReasonForIncompletion = "Token Requested Cancel" };

            var taskResult = await System.Threading.Tasks.Task.Run(() => _executeTaskMethod.Invoke(_workerInstance, new object[] { task }));
            return (TaskResult)taskResult;
        }
    }
}
