using Conductor.Client.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Conductor.Client.Worker
{
    internal class WorkflowTaskExecutor : IWorkflowTaskExecutor
    {
        private static TimeSpan SLEEP_FOR_TIME_SPAN_ON_WORKER_ERROR = TimeSpan.FromMilliseconds(5);
        private static int UPDATE_TASK_RETRY_COUNT_LIMIT = 5;

        private readonly ILogger<WorkflowTaskExecutor> _logger;
        private readonly IWorkflowTask _worker;
        private readonly IWorkflowTaskClient _taskClient;
        private readonly WorkflowTaskExecutorConfiguration _workerSettings;
        private readonly WorkflowTaskMonitor _workflowTaskMonitor;

        public WorkflowTaskExecutor(
            ILogger<WorkflowTaskExecutor> logger,
            IWorkflowTaskClient client,
            IWorkflowTask worker,
            WorkflowTaskExecutorConfiguration workflowTaskConfiguration,
            WorkflowTaskMonitor workflowTaskMonitor)
        {
            _logger = logger;
            _taskClient = client;
            _worker = worker;
            _workerSettings = workflowTaskConfiguration;
            _workflowTaskMonitor = workflowTaskMonitor;
        }

        public Task Start()
        {
            var thread = Task.Run(() => Work4Ever());
            _logger.LogInformation(
                $"[{_workerSettings.WorkerId}] Started worker"
                + $", taskName: {_worker.TaskType}"
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
                        $"[{_workerSettings.WorkerId}] worker error: {e.Message}"
                        + ", taskName: {_worker.TaskType}"
                        + ", domain: {_worker.Domain}"
                    );
                    await Sleep(SLEEP_FOR_TIME_SPAN_ON_WORKER_ERROR);
                }
            }
        }

        private async Task WorkOnce()
        {
            var tasks = PollTasks();
            if (tasks.Count == 0)
            {
                await Sleep(_workerSettings.PollInterval);
                return;
            }
            ProcessTasks(tasks);
        }

        private List<Models.Task> PollTasks()
        {
            _logger.LogTrace(
                $"[{_workerSettings.WorkerId}] Polling for worker"
                + $", taskType: {_worker.TaskType}"
                + $", domain: {_workerSettings.Domain}"
                + $", batchSize: {_workerSettings.BatchSize}"
            );
            var availableWorkerCounter = _workerSettings.BatchSize - _workflowTaskMonitor.GetRunningWorkers();
            var tasks = _taskClient.PollTask(_worker.TaskType, _workerSettings.WorkerId, _workerSettings.Domain, availableWorkerCounter);
            if (tasks == null)
            {
                tasks = new List<Models.Task>();
            }
            _logger.LogTrace(
                $"[{_workerSettings.WorkerId}] Polled {tasks.Count} tasks"
                + $", taskType: {_worker.TaskType}"
                + $", domain: {_workerSettings.Domain}"
                + $", batchSize: {_workerSettings.BatchSize}"
            );
            return tasks;
        }

        private void ProcessTasks(List<Models.Task> tasks)
        {
            if (tasks == null || tasks.Count == 0)
            {
                return;
            }
            foreach (var task in tasks)
            {
                _workflowTaskMonitor.IncrementRunningWorker();
                Task.Run(() => ProcessTask(task));
            }
        }

        private async Task ProcessTask(Models.Task task)
        {
            _logger.LogTrace(
                $"[{_workerSettings.WorkerId}] Processing task for worker,"
                + $", taskType: {_worker.TaskType}"
                + $", domain: {_workerSettings.Domain}"
                + $", taskId: {task.TaskId}"
                + $", workflowId: {task.WorkflowInstanceId}"
            );
            try
            {
                var taskResult = await _worker.Execute(task, CancellationToken.None);
                taskResult.WorkerId = _workerSettings.WorkerId;
                UpdateTask(taskResult);
            }
            finally
            {
                _workflowTaskMonitor.RunningWorkerDone();
            }
            _logger.LogTrace(
                $"[{_workerSettings.WorkerId}] Done processing task for worker,"
                + $", taskType: {_worker.TaskType}"
                + $", domain: {_workerSettings.Domain}"
                + $", taskId: {task.TaskId}"
                + $", workflowId: {task.WorkflowInstanceId}"
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
                        await Sleep(TimeSpan.FromSeconds(1 << attemptCounter));
                    }
                    _taskClient.UpdateTask(taskResult);
                    _logger.LogTrace(
                        $"[{_workerSettings.WorkerId}] Done updating task"
                        + $", taskType: {_worker.TaskType}"
                        + $", domain: {_workerSettings.Domain}"
                        + $", taskId: {taskResult.TaskId}"
                        + $", workflowId: {taskResult.WorkflowInstanceId}"
                    );
                    return;
                }
                catch (Exception e)
                {
                    _logger.LogTrace(
                        $"[{_workerSettings.WorkerId}] Failed to update task, reason: {e.Message}"
                        + $", taskType: {_worker.TaskType}"
                        + $", domain: {_workerSettings.Domain}"
                        + $", taskId: {taskResult.TaskId}"
                        + $", workflowId: {taskResult.WorkflowInstanceId}"
                    );
                }
            }
            throw new Exception("Failed to update task after retries");
        }

        private async Task Sleep(TimeSpan timeSpan)
        {
            _logger.LogDebug($"[{_workerSettings.WorkerId}] Sleeping for {timeSpan.Milliseconds}ms");
            await Task.Delay(timeSpan);
        }
    }
}
