using System;

namespace Conductor.Client.Worker
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class WorkerTask : Attribute
    {
        public string TaskType { get; }
        public WorkflowTaskExecutorConfiguration WorkerSettings { get; set; }

        public WorkerTask()
        {
            WorkerSettings = new WorkflowTaskExecutorConfiguration();
        }

        public WorkerTask(string taskType, int batchSize, string domain, int pollIntervalMs, string workerId)
        {
            TaskType = taskType;
            WorkerSettings = new WorkflowTaskExecutorConfiguration
            {
                BatchSize = batchSize,
                Domain = domain,
                PollInterval = TimeSpan.FromMilliseconds(pollIntervalMs),
                WorkerId = workerId,
            };
        }
    }
}
