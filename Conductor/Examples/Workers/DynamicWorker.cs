using Conductor.Client.Extensions;
using Conductor.Client.Interfaces;
using Conductor.Client.Models;
using Conductor.Client.Worker;
using System;
using System.Threading;

namespace Conductor.Examples.Workers
{
    public class DynamicWorker : IWorkflowTask
    {
        public string TaskType { get; }

        public WorkflowTaskExecutorConfiguration WorkerSettings { get; }

        public DynamicWorker(string taskType = "workflow-task")
        {
            TaskType = taskType;
            WorkerSettings = new WorkflowTaskExecutorConfiguration();
        }

        public System.Threading.Tasks.Task<TaskResult> Execute(Client.Models.Task task, CancellationToken token = default)
        {
            return System.Threading.Tasks.Task.FromResult(task.Completed());
        }

        public TaskResult Execute(Client.Models.Task task)
        {
            throw new NotImplementedException();
        }
    }
}
