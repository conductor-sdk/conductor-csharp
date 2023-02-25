using Conductor.Client.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Conductor.Client.Worker
{
    public class WorkflowTaskCoordinator : IWorkflowTaskCoordinator
    {
        private readonly ILogger<WorkflowTaskCoordinator> _logger;
        private readonly HashSet<IWorkflowTask> _workerDefinitions;
        private readonly IWorkflowTaskExecutor _workflowTaskExecutor;
        private readonly Dictionary<string, Task> _runningWorkers;

        public WorkflowTaskCoordinator(IWorkflowTaskExecutor workflowTaskExecutor, ILogger<WorkflowTaskCoordinator> logger = default)
        {
            _logger = logger;
            _workerDefinitions = new HashSet<IWorkflowTask>();
            _runningWorkers = new Dictionary<string, Task>();
            _workflowTaskExecutor = workflowTaskExecutor;
        }

        public void Start()
        {
            _logger.LogDebug("Starting workers...");
            foreach (var worker in _workerDefinitions)
            {
                var runningWorker = _workflowTaskExecutor.StartPoller(worker);
                _runningWorkers[worker.TaskType] = runningWorker;
            }
            _logger.LogDebug("Started all workers");
        }

        public void RegisterWorker(IWorkflowTask task)
        {
            _workerDefinitions.Add(task);
        }

        public void Stop(string taskName)
        {
            if (!_runningWorkers.ContainsKey(taskName))
            {
                throw new Exception($"worker not found for {taskName}");
            }
            _runningWorkers[taskName].
        }
    }
}
