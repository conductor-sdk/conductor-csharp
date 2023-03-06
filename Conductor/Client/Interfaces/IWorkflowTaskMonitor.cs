using System.Threading;

namespace Conductor.Client.Interfaces
{
    public interface IWorkflowTaskMonitor
    {
        void IncrementRunningWorker();
        int GetRunningWorkers();
        void RunningWorkerDone();
    }
}