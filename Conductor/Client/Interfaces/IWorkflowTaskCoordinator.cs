using System.Threading.Tasks;

namespace Conductor.Client.Interfaces
{
    public interface IWorkflowTaskCoordinator
    {
        void Start();
        void RegisterWorker(IWorkflowTask task);
    }
}
