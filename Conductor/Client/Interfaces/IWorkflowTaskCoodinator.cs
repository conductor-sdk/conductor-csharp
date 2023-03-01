using Conductor.Client.Worker;
using System.Threading.Tasks;

namespace Conductor.Client.Interfaces
{
    public interface IWorkflowTaskCoordinator
    {
        Task Start();
        void RegisterWorker(IWorkflowTask worker, WorkflowTaskExecutorConfiguration workerSettings);
    }
}
