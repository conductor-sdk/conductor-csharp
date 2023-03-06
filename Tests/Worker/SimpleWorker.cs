using Conductor.Client.Interfaces;
using Conductor.Client.Extensions;
using Conductor.Client.Models;
using Conductor.Client.Worker;

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
        }

        public TaskResult Execute(Task task)
        {
            return task.Completed();
        }
    }
}
