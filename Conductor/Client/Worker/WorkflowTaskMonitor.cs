using Microsoft.Extensions.Logging;
using System.Threading;

namespace Conductor.Client.Interfaces
{
    public class WorkflowTaskMonitor : IWorkflowTaskMonitor
    {
        private readonly ILogger<WorkflowTaskMonitor> _logger;
        private readonly ReaderWriterLockSlim _mutex;
        private int _runningWorkerCounter;

        public WorkflowTaskMonitor(ILogger<WorkflowTaskMonitor> logger)
        {
            _logger = logger;
            _runningWorkerCounter = 0;
            _mutex = new ReaderWriterLockSlim();
        }

        public void IncrementRunningWorker()
        {
            _mutex.EnterWriteLock();
            try
            {
                _runningWorkerCounter++;
                _logger.LogTrace($"Updated runningWorkerCounter from {_runningWorkerCounter - 1} to {_runningWorkerCounter}");
            }
            finally
            {
                _mutex.ExitWriteLock();
            }
        }

        public int GetRunningWorkers()
        {
            _mutex.EnterReadLock();
            try
            {
                return _runningWorkerCounter;
            }
            finally
            {
                _mutex.ExitReadLock();
            }
        }

        public void RunningWorkerDone()
        {
            _mutex.EnterWriteLock();
            try
            {
                _runningWorkerCounter--;
                _logger.LogTrace($"Updated runningWorkerCounter from {_runningWorkerCounter + 1} to {_runningWorkerCounter}");
            }
            finally
            {
                _mutex.ExitWriteLock();
            }
        }
    }
}
