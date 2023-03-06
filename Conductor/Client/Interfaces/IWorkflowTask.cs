using Conductor.Client.Models;
using System.Threading;
using Conductor.Client.Worker;

namespace Conductor.Client.Interfaces
{
    public interface IWorkflowTask
    {
        string TaskType { get; }
        WorkflowTaskExecutorConfiguration WorkerSettings { get; }
        TaskResult Execute(Task task);
    }
}
