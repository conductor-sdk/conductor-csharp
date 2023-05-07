using Conductor.Client.Extensions;
using Conductor.Client.Models;
using Conductor.Client.Worker;

namespace Tests.Worker
{
    [WorkerTask]
    public class Workers
    {
        // Polls for 1 task every 35ms
        [WorkerTask("test-sdk-csharp-task", 1, "taskDomain", 35, "workerId")]
        public static TaskResult SimpleWorkerStatic(Task task)
        {
            return task.Completed();
        }

        // Polls for 12 tasks every 420ms
        [WorkerTask("test-sdk-csharp-task", 12, "taskDomain", 420, "workerId")]
        public TaskResult SimpleWorker(Task task)
        {
            return task.Completed();
        }
    }
}
