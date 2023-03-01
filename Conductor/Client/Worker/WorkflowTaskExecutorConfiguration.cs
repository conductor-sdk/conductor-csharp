using System;

namespace Conductor.Client.Worker
{
    public class WorkflowTaskExecutorConfiguration
    {
        public int BatchSize { get; set; } = 1;
        public string Domain { get; set; } = null;
        public TimeSpan PollInterval { get; set; } = TimeSpan.FromMilliseconds(100);
        public string WorkerId { get; set; } = Environment.MachineName;
    }
}