using Conductor.Client.Models;
using Conductor.Client.Interfaces;
using Conductor.Client.Extensions;
using System.Threading;
using System.Threading.Tasks;

namespace Tests.Util
{
    public class SimpleWorker : IWorkflowTask
    {
        public string TaskType { get; }
        public int? Priority { get; }

        public SimpleWorker(string taskType = "test-sdk-csharp-task")
        {
            TaskType = taskType;
        }

        public async Task<TaskResult> Execute(Conductor.Client.Models.Task task, CancellationToken token)
        {
            return task.Completed();
        }
    }
}
