using System;

namespace Conductor.Client.Worker
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class WorkerTask : Attribute
    {
        public string TaskType { get; set; }
        public WorkflowTaskExecutorConfiguration WorkerSettings { get; set; }

        public WorkerTask()
        {
            WorkerSettings = new WorkflowTaskExecutorConfiguration();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkerTask" /> class.
        /// </summary>
        /// <param name="taskType"></param>
        /// <param name="batchSize"></param>
        /// <param name="domain"></param>
        /// <param name="pollIntervalMs"></param>
        /// <param name="workerId"></param>
        public WorkerTask(string taskType = default, int batchSize = default, string domain = default, int pollIntervalMs = default, string workerId = default)
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
