using System.Threading.Tasks;

namespace Conductor.Client.Interfaces
{
    public interface IWorkflowTaskExecutor
    {
        Task Start();
    }
}
