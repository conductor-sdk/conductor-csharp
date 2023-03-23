using Conductor.Client.Interfaces;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Collections.Generic;

namespace Conductor.Client.Worker
{
    public class WorkflowTaskService : BackgroundService
    {
        private readonly IWorkflowTaskCoordinator _workflowTaskCoordinator;
        private readonly IEnumerable<IWorkflowTask> _workers;

        public WorkflowTaskService(IWorkflowTaskCoordinator workflowTaskCoordinator, IEnumerable<IWorkflowTask> workers)
        {
            _workflowTaskCoordinator = workflowTaskCoordinator;
            _workers = workers;
        }

        protected override System.Threading.Tasks.Task ExecuteAsync(CancellationToken stoppingToken)
        {
            foreach (var worker in _workers)
            {
                _workflowTaskCoordinator.RegisterWorker(worker);
            }
            return _workflowTaskCoordinator.Start();
        }
    }
}
