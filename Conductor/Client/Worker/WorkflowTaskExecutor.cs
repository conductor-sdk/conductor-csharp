using Conductor.Client.Extensions;
using Conductor.Client.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Conductor.Client.Worker
{
    public class WorkflowTaskExecutor : IWorkflowTaskExecutor
    {
        private static int UPDATE_TASK_RETRY_COUNT_LIMIT = 5;

        private readonly ILogger<WorkflowTaskExecutor> _logger;
        private readonly IWorkflowTask _worker;
        private readonly IConductorWorkerRestClient _taskClient;
        private readonly WorkerSettings _workerSettings;

        public WorkflowTaskExecutor(
            IConductorWorkerRestClient restClient,
            IWorkflowTask worker,
            WorkerSettings workerSettings)
        {
            _logger = default;
            _taskClient = restClient;
            _worker = worker;
            _workerSettings = workerSettings;
        }

        public Task Start()
        {
            var thread = Task.Run(() => Work4Ever());
            _logger.LogInformation(
                $"Started worker with"
                + $"taskName: {_worker.TaskType}"
                + $", domain: {_workerSettings.Domain}"
                + $", pollInterval: {_workerSettings.PollInterval}"
                + $", batchSize: {_workerSettings.BatchSize}"
            );
            return thread;
        }

        private async Task Work4Ever()
        {
            while (true)
            {
                try
                {
                    await WorkOnce();
                }
                catch (Exception e)
                {
                    _logger.LogInformation(
                        $"worker error: {e.Message}"
                        + ", taskName: {_worker.TaskType}"
                        + ", domain: {_worker.Domain}"
                    );
                }
            }
        }

        private async Task WorkOnce()
        {
            var tasks = PollTasks();
            if (tasks.Count == 0)
            {
                await Sleep(_workerSettings.PollInterval);
            }
            await ProcessTasks(tasks);
        }

        private List<Models.Task> PollTasks()
        {
            _logger.LogTrace(
                $"[{_workerSettings.WorkerId}] Polling for worker"
                + $", taskType: {_worker.TaskType}"
                + $", domain: {_workerSettings.Domain}"
                + $", batchSize: {_workerSettings.BatchSize}"
            );
            var tasks = _taskClient.PollTask(_worker.TaskType, _workerSettings.WorkerId, _workerSettings.Domain, _workerSettings.BatchSize);
            if (tasks == null)
            {
                tasks = new List<Models.Task>();
            }
            _logger.LogTrace(
                $"[{_workerSettings.WorkerId}] Polled {tasks.Count} for worker"
                + $", taskType: {_worker.TaskType}"
                + $", domain: {_workerSettings.Domain}"
                + $", batchSize: {_workerSettings.BatchSize}"
            );
            return tasks;
        }

        private async Task ProcessTasks(List<Models.Task> tasks)
        {
            if (tasks == null || tasks.Count == 0)
            {
                return;
            }
            List<Task> runningWorkers = new List<Task>();
            foreach (var task in tasks)
            {
                var runningWorker = Task.Run(() => ProcessTask(task));
                runningWorkers.Add(runningWorker);
            }
            await Task.WhenAll(runningWorkers);
        }

        private async Task ProcessTask(Models.Task task)
        {
            _logger.LogTrace(
                $"[{_workerSettings.WorkerId}] Processing task for worker,"
                + $"taskType: {_worker.TaskType}"
                + $"domain: {_workerSettings.Domain}"
                + $"taskId: {task.TaskId}"
                + $"workflowId: {task.WorkflowInstanceId}"
            );
            var taskResult = await _worker.Execute(task, CancellationToken.None);
            taskResult.WorkerId = _workerSettings.WorkerId;
            UpdateTask(taskResult);
            _logger.LogTrace(
                $"[{_workerSettings.WorkerId}] Done processing task for worker,"
                + $"taskType: {_worker.TaskType}"
                + $"domain: {_workerSettings.Domain}"
                + $"taskId: {task.TaskId}"
                + $"workflowId: {task.WorkflowInstanceId}"
            );
        }

        private async void UpdateTask(Models.TaskResult taskResult)
        {
            for (var attemptCounter = 0; attemptCounter < UPDATE_TASK_RETRY_COUNT_LIMIT; attemptCounter += 1)
            {
                try
                {
                    // Retries in increasing time intervals (0s, 2s, 4s, 8s...)
                    if (attemptCounter > 0)
                    {
                        await Sleep(TimeSpan.FromSeconds(attemptCounter << 1));
                    }
                    _taskClient.UpdateTask(taskResult);
                }
                catch (Exception e)
                {
                    _logger.LogTrace(
                        $"Failed to update task, reason: {e.Message}"
                        + $"taskType: {_worker.TaskType}"
                        + $"domain: {_workerSettings.Domain}"
                        + $"taskId: {taskResult.TaskId}"
                        + $"workflowId: {taskResult.WorkflowInstanceId}"
                    );
                }
            }
            throw new Exception("Failed to update task after retries");
        }

        private async Task Sleep(TimeSpan timeSpan)
        {
            _logger.LogDebug($"Sleeping for {timeSpan.Milliseconds}ms");
            await Task.Delay(timeSpan);
        }
    }
}
