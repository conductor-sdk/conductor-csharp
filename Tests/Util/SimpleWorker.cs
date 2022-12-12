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

        public Task<TaskResult> Execute(Conductor.Client.Models.Task task, CancellationToken token)
        {
            return new System.Threading.Tasks.Task<TaskResult>(
                () =>
                {
                    return Execute(task);
                }
            );
        }

        private static TaskResult Execute(Conductor.Client.Models.Task task)
        {
            return ConductorTaskExtensions.Completed(task);
        }
    }
}
