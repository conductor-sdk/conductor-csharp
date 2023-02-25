using System;

namespace Conductor.Client.Worker
{
    public class WorkerSettings
    {
        public int BatchSize { get; set; } = 1;
        public string Domain { get; set; } = "";
        public TimeSpan PollInterval { get; set; } = TimeSpan.FromMilliseconds(100);
        public string WorkerId { get; set; } = Environment.MachineName;
    }
}