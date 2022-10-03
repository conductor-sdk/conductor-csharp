using Conductor.Client.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Conductor.Client.Interfaces
{
    public interface IWorkflowTask
    {
        string TaskType { get; }
        int? Priority { get; }
        Task<TaskResult> Execute(Models.Task task, CancellationToken token);
    }
}
