using Conductor.Exceptions;
using Conductor.Client.Extensions;
using Conductor.Client.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Conductor.Client.Worker
{
    internal class WorkflowTaskExecutor : IWorkflowTaskExecutor
    {
        private List<Type> workers;
        private ILogger<WorkflowTaskExecutor> logger;
        private readonly ConductorClientSettings conductorClientSettings;
        private readonly IConductorRestClient taskClient;
        private readonly IServiceProvider serviceProvider;
        private readonly static int epoch = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;

        //TODO: better worker ids?
        private readonly string workerId = Environment.MachineName + "_" + new Random(epoch).Next();

        public WorkflowTaskExecutor(
            IConductorRestClient taskClient,
            IServiceProvider serviceProvider,
            ILogger<WorkflowTaskExecutor> logger,
            IOptions<ConductorClientSettings> conductorClientSettings)
        {
            this.taskClient = taskClient;
            this.serviceProvider = serviceProvider;
            this.logger = logger;
            this.conductorClientSettings = conductorClientSettings.Value;
        }

        private string GetWorkerName()
        {
            return $"Worker : {workerId} ";
        }

        public async Task StartPoller(List<Type> workers)
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
            var workersToBePolled = DetermineOrderOfPolling(workers);
            foreach (var workerToBePolled in workersToBePolled)
            {
                logger.LogDebug($"{GetWorkerName()} - Polling for task type: {workerToBePolled.TaskType}");

                try
                {
                    var task = await PollForTask(workerToBePolled.TaskType);

                    if (task != null)
                    {
                        await ProcessTask(task, workerToBePolled);
                        break;
                    }
                }
                catch (Exception e)
                {
                    logger.LogError(e, $"{GetWorkerName()} -  Polling connection failed for task type: {workerToBePolled.TaskType}");
                }
            }
            logger.LogDebug($"{GetWorkerName()} - Poll ended");
            await Sleep();
        }

        private async Task Sleep()
        {
            var delay = conductorClientSettings.SleepInterval;   

            logger.LogDebug($"Waiting for {delay}ms");

            await Task.Delay(delay);
        }

        private List<IWorkflowTask> DetermineOrderOfPolling(List<Type> workersToBePolled)
        {
            var workflowTasks = new List<IWorkflowTask>();

            foreach (var taskType in workersToBePolled)
            {
                var worklfowTask = serviceProvider.GetService(taskType) as IWorkflowTask;
                if (worklfowTask is null)
                    throw new WorkerNotFoundException(taskType.GetType().Name);
                workflowTasks.Add(worklfowTask);
            }

            var prio =  workflowTasks.Where(p => p.Priority != null).OrderByDescending(p => p.Priority).ToList();
            var random = workflowTasks.Where(p => p.Priority == null).ToList();
            ShuffleList(random);
            return prio.Concat(random).ToList();
        }

        public Task<Models.Task> PollForTask(string taskType)
        {
            return taskClient.PollTask(taskType, workerId, conductorClientSettings.Domain);
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
            logger.LogDebug($"{GetWorkerName()} - Update task respone {result}");
        }

        private void ShuffleList<T>(List<T> list)
        {
            var rng = new Random();
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
