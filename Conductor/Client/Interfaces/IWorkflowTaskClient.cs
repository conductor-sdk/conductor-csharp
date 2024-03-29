﻿using Conductor.Client.Models;
using System.Collections.Generic;

namespace Conductor.Client.Interfaces
{
    public interface IWorkflowTaskClient
    {
        List<Task> PollTask(string taskType, string workerId, string domain, int count);
        string UpdateTask(TaskResult result);
    }
}
