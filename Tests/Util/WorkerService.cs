using Conductor.Client.Interfaces;
using Conductor.Client.Worker;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace Tests.Util
{
    public class WorkerService : BackgroundService
    {
        private readonly IWorkflowTaskCoordinator _workflowTaskCoordinator;
        private readonly IEnumerable<IWorkflowTask> _workers;
        private readonly IWorkflowTaskClient _client;
        private readonly WorkerSettings _workerSettings;

        private readonly ILogger<WorkflowTaskExecutor> _loggerTaskExecutor;
        private readonly ILogger<WorkflowTaskMonitor> _loggerTaskMonitor;

        public WorkerService(
            ILogger<WorkflowTaskExecutor> loggerTaskExecutor,
            ILogger<WorkflowTaskMonitor> loggerTaskMonitor,
            IWorkflowTaskCoordinator workflowTaskCoordinator,
            IEnumerable<IWorkflowTask> workers)
        {
            _workflowTaskCoordinator = workflowTaskCoordinator;
            _workers = workers;
            _workerSettings = new WorkerSettings();

            _loggerTaskExecutor = loggerTaskExecutor;
            _loggerTaskMonitor = loggerTaskMonitor;
        }

        protected override System.Threading.Tasks.Task ExecuteAsync(CancellationToken stoppingToken)
        {
            foreach (var worker in _workers)
            {
                _workflowTaskCoordinator.RegisterWorker(
                    new WorkflowTaskExecutor(
                        _loggerTaskExecutor,
                        _client,
                        worker,
                        _workerSettings,
                        new WorkflowTaskMonitor(_loggerTaskMonitor)
                    ));
            }
            return _workflowTaskCoordinator.Start();
        }
    }
}
