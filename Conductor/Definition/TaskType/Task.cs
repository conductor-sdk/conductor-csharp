using Conductor.Models;
using System.Collections.Generic;

namespace Conductor.Definition.TaskType
{
    public abstract class Task : WorkflowTask
    {
        public Task(string taskReferenceName, WorkflowTask.WorkflowTaskTypeEnum taskType)
            : base(
                name: taskReferenceName,
                taskReferenceName: taskReferenceName,
                workflowTaskType: taskType)
        { }

        public Task WithInput(string key, object value)
        {
            if (InputParameters == null)
            {
                InputParameters = new Dictionary<string, object>();
            }
            InputParameters.Add(key, value);
            return this;
        }
    }
}
