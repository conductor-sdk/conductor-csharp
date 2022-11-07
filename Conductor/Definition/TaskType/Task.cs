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
        {
            InputParameters = new Dictionary<string, object>();
        }

        public Task WithName(string name)
        {
            Name = name;
            return this;
        }

        public Task WithDescription(string description)
        {
            Description = description;
            return this;
        }

        public Task WithInput(string key, object value)
        {
            InputParameters.Add(key, value);
            return this;
        }
    }
}
