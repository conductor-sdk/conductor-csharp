using Conductor.Client.Extensions;
using Conductor.Client.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Conductor.Client.Worker
{
    internal class WorkflowTaskExecutor : IWorkflowTaskExecutor
    {
        private List<IWorkflowTask> workers;
        private ILogger<WorkflowTaskExecutor> logger;
        private readonly Configuration configuration;
        private readonly IConductorWorkerRestClient taskClient;
        private readonly string workerId = Environment.MachineName;

        public WorkflowTaskExecutor(
            IServiceProvider serviceProvider,
            ILogger<WorkflowTaskExecutor> logger,
            IOptions<Configuration> configuration)
        {
            this.taskClient = serviceProvider.GetService(typeof(ConductorWorkerRestClient)) as ConductorWorkerRestClient;
            this.logger = logger;
            this.configuration = configuration.Value;
        }

        private string GetWorkerName()
        {
            return $"Worker : {workerId} ";
        }

        public async Task StartPoller(List<IWorkflowTask> workers)
        {
            this.workers = workers;
            if (this.workers is null || this.workers.Count == 0) throw new NullReferenceException("Workers not set");

            while (true)
            {
                await Poll();
            }
        }

        private async Task Poll()
        {
            //TODO: Move to queue based polling to better parallel node worker
            //TODO: Polling failure backoff
            //TODO: Less generic logging - Log only when needed and better context to what is happening
            logger.LogDebug($"{GetWorkerName()} - Poll started");
            foreach (var worker in workers)
            {
                logger.LogDebug($"{GetWorkerName()} - Polling for task type: {worker.TaskType}");
                try
                {
                    var task = await PollForTask(worker.TaskType);

                    if (task != null)
                    {
                        await ProcessTask(task, worker);
                        break;
                    }
                }
                catch (Exception e)
                {
                    logger.LogError(e, $"{GetWorkerName()} -  Polling connection failed for task type: {worker.TaskType}");
                }
            }
            logger.LogDebug($"{GetWorkerName()} - Poll ended");
            await Sleep();
        }

        private async Task Sleep()
        {
            var delay = configuration.SleepInterval;

            logger.LogDebug($"Waiting for {delay}ms");

            await Task.Delay(delay);
        }

        public Task<Models.Task> PollForTask(string taskType)
        {
            return taskClient.PollTask(taskType, workerId, configuration.Domain);
        }

        private async Task ProcessTask(Models.Task task, IWorkflowTask workflowTask)
        {
            logger.LogInformation($"{GetWorkerName()} - Processing task:{task.TaskDefName} id:{task.TaskId}");

            //TODO: handle shutdowns?
            var cts = new CancellationTokenSource();
            try
            {
                Models.TaskResult result = null;

                if (task.ResponseTimeoutSeconds > 0)
                {
                    var timeout = task.ResponseTimeoutSeconds * 1000;
                    cts.CancelAfter(timeout > int.MaxValue ? int.MaxValue : (int)timeout);
                    result = await workflowTask.Execute(task, cts.Token).WaitOrCancel(cts.Token);
                }
                else
                {
                    result = await workflowTask.Execute(task, CancellationToken.None);
                }

                result.WorkerId = workerId;
                await UpdateTask(result);
            }
            catch (OperationCanceledException)
            {
                logger.LogError($"{GetWorkerName()} - Task timed out.");
            }
            catch (Exception e)
            {
                logger.LogError(e, $"{GetWorkerName()} - Failed to execute task");
                await UpdateTask(task.Failed(e.ToString()));
            }
        }

        private async Task UpdateTask(Models.TaskResult taskResult)
        {
            var result = await taskClient.UpdateTask(taskResult);
            logger.LogDebug($"{GetWorkerName()} - Update task response {result}");
        }
    }
}
