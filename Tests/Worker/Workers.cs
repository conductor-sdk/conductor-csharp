using Conductor.Client.Extensions;
using Conductor.Client.Models;
using Conductor.Client.Worker;

namespace Tests.Worker
{
    [WorkerTask]
    public class Workers
    {
        [WorkerTask("test-sdk-csharp-task", 10, null, 100, "workerId")]
        public static TaskResult SimpleWorker(Task task)
        {
            return task.Completed();
        }
    }
}
