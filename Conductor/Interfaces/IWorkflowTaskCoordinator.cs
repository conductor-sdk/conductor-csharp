using System.Threading.Tasks;

namespace Conductor.Interfaces
{
    public interface IWorkflowTaskCoordinator
    {
        Task Start();
        void RegisterWorker<T>(T task) where T : IWorkflowTask;
    }
}
