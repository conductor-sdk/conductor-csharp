using Conductor.Client.Interfaces;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Logging;

namespace Conductor.Client.Worker
{
    public class WorkflowTaskService : BackgroundService
    {
        private readonly IWorkflowTaskCoordinator _workflowTaskCoordinator;
        private readonly IEnumerable<IWorkflowTask> _workers;
        private readonly ILogger<WorkflowTaskService> _logger;

        public WorkflowTaskService(IWorkflowTaskCoordinator workflowTaskCoordinator, IEnumerable<IWorkflowTask> workers, ILogger<WorkflowTaskService> logger)
        {
            _workflowTaskCoordinator = workflowTaskCoordinator;
            _workers = workers;
            _logger = logger;
        }

        protected override System.Threading.Tasks.Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                _logger.LogTrace($"Task Service execution started.....");
                foreach (var worker in _workers)
                {
                    _workflowTaskCoordinator.RegisterWorker(worker);
                }
                return _workflowTaskCoordinator.Start(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Task Service execution error out.....Message: {ex.Message}, Exception Stack trace: {ex.StackTrace}");
                StopAsync(stoppingToken);
                throw ex;
            }
        }
    }
}
