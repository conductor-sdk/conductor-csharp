using Conductor.Client.Interfaces;
using Conductor.Client.Extensions;
using Conductor.Client.Models;
using Conductor.Client.Worker;
using System;

namespace Tests.Worker
{
    public class SimpleWorker : IWorkflowTask
    {
        public string TaskType { get; }
        public WorkflowTaskExecutorConfiguration WorkerSettings { get; }

        public SimpleWorker(string taskType = "test-sdk-csharp-task")
        {
            TaskType = taskType;
            WorkerSettings = new WorkflowTaskExecutorConfiguration();
            WorkerSettings.BatchSize = Math.Max(10, Environment.ProcessorCount * 2);
            WorkerSettings.PollInterval = TimeSpan.FromMilliseconds(350);
        }

        public TaskResult Execute(Task task)
        {
            return task.Completed();
        }
    }
}
