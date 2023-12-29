using Conductor.Client.Models;
using Conductor.Client.Worker;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Conductor.Client.Interfaces
{
    public interface IWorkflowTask
    {
        string TaskType { get; }
        WorkflowTaskExecutorConfiguration WorkerSettings { get; }
        Task<TaskResult> ExecuteAsync(Models.Task task, CancellationToken token = default);
        [Obsolete("Execute is going to be deprecated. Instead of Execute method use ExecuteAsync method going forward")]
        TaskResult Execute(Models.Task task);
    }
}
