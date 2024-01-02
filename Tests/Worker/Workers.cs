using Conductor.Client.Extensions;
using Conductor.Client.Interfaces;
using Conductor.Client.Models;
using Conductor.Client.Worker;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tests.Worker
{
    [WorkerTask]
    public class FunctionalWorkers
    {
        private static Random _random;

        static FunctionalWorkers()
        {
            _random = new Random();
        }

        // Polls for 5 task every 200ms
        [WorkerTask("test-sdk-csharp-task", 5, "taskDomain", 200, "workerId")]
        public static TaskResult SimpleWorker(Conductor.Client.Models.Task task)
        {
            return task.Completed();
        }

        // Polls for 12 tasks every 420ms
        [WorkerTask("test-sdk-csharp-task", 12, "taskDomain", 420, "workerId")]
        public TaskResult LazyWorker(Conductor.Client.Models.Task task)
        {
            var timeSpan = System.TimeSpan.FromMilliseconds(_random.Next(128, 2048));
            System.Threading.Tasks.Task.Delay(timeSpan).GetAwaiter().GetResult();
            return task.Completed();
        }
    }

    public class ClassWorker : IWorkflowTask
    {
        public string TaskType { get; }

        public WorkflowTaskExecutorConfiguration WorkerSettings { get; }

        public ClassWorker(string taskType = "random_task_type")
        {
            TaskType = taskType;
            WorkerSettings = new WorkflowTaskExecutorConfiguration();
        }

        public async Task<TaskResult> Execute(Conductor.Client.Models.Task task, CancellationToken token)
        {
            if (token != CancellationToken.None && token.IsCancellationRequested)
                throw new Exception("Token request Cancelled");

            throw new NotImplementedException();
        }

        public TaskResult Execute(Conductor.Client.Models.Task task)
        {
            throw new NotImplementedException();
        }
    }
}
