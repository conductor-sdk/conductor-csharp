using Conductor.Client.Worker;
using System.Threading;
using System.Threading.Tasks;

namespace Conductor.Client.Interfaces
{
    public interface IWorkflowTaskCoordinator
    {
        Task Start(CancellationToken token = default);
        void RegisterWorker(IWorkflowTask worker);
    }
}
