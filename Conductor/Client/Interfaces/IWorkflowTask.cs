using Conductor.Client.Models;
using System.Threading;
using System.Threading.Tasks;
using Conductor.Client.Worker;

namespace Conductor.Client.Interfaces
{
    public interface IWorkflowTask
    {
        string TaskType { get; }
        WorkflowTaskExecutorConfiguration WorkerSettings { get; set; }
        Task<TaskResult> Execute(Models.Task task, CancellationToken token);
    }
}
