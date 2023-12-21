using Conductor.Client.Models;
using Conductor.Client.Worker;
using System.Threading;
using System.Threading.Tasks;

namespace Conductor.Client.Interfaces
{
    public interface IWorkflowTask
    {
        string TaskType { get; }
        WorkflowTaskExecutorConfiguration WorkerSettings { get; }
        Task<TaskResult> Execute(Models.Task task, CancellationToken token);
    }
}
