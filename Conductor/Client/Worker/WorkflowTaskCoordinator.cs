using Conductor.Client.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Conductor.Client.Worker
{
    internal class WorkflowTaskCoordinator : IWorkflowTaskCoordinator
    {
        private readonly ILogger<WorkflowTaskCoordinator> _logger;
        private readonly ILogger<WorkflowTaskExecutor> _loggerWorkflowTaskExecutor;
        private readonly ILogger<WorkflowTaskMonitor> _loggerWorkflowTaskMonitor;
        private readonly HashSet<IWorkflowTaskExecutor> _workers;
        private readonly IWorkflowTaskClient _client;

        public WorkflowTaskCoordinator(IWorkflowTaskClient client, ILogger<WorkflowTaskCoordinator> logger, ILogger<WorkflowTaskExecutor> loggerWorkflowTaskExecutor, ILogger<WorkflowTaskMonitor> loggerWorkflowTaskMonitor)
        {
            _logger = logger;
            _client = client;
            _workers = new HashSet<IWorkflowTaskExecutor>();
            _loggerWorkflowTaskExecutor = loggerWorkflowTaskExecutor;
            _loggerWorkflowTaskMonitor = loggerWorkflowTaskMonitor;
        }

        public async Task Start()
        {
            _logger.LogDebug("Starting workers...");
            DiscoverWorkers();
            var runningWorkers = new List<Task>();
            foreach (var worker in _workers)
            {
                var runningWorker = worker.Start();
                runningWorkers.Add(runningWorker);
            }
            _logger.LogDebug("Started all workers");
            await Task.WhenAll(runningWorkers);
        }

        public void RegisterWorker(IWorkflowTask worker)
        {
            var workflowTaskMonitor = new WorkflowTaskMonitor(_loggerWorkflowTaskMonitor);
            var workflowTaskExecutor = new WorkflowTaskExecutor(
                _loggerWorkflowTaskExecutor,
                _client,
                worker,
                workflowTaskMonitor
            );
            _workers.Add(workflowTaskExecutor);
        }

        private void DiscoverWorkers()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (type.GetCustomAttribute<WorkerTask>() == null)
                    {
                        continue;
                    }
                    foreach (var method in type.GetMethods())
                    {
                        var workerTask = method.GetCustomAttribute<WorkerTask>();
                        if (workerTask == null)
                        {
                            continue;
                        }
                        object workerInstance = null;
                        if (!method.IsStatic)
                        {
                            workerInstance = Activator.CreateInstance(type);
                        }
                        var worker = new GenericWorker(
                            workerTask.TaskType,
                            workerTask.WorkerSettings,
                            method,
                            workerInstance
                        );
                        RegisterWorker(worker);
                    }
                }
            }
        }
    }
}
