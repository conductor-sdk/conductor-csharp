using Conductor.Client.Models;
using System.Collections.Generic;

namespace Conductor.Definition.TaskType
{
    public abstract class Task : WorkflowTask
    {
        public Task(string taskReferenceName, WorkflowTask.WorkflowTaskTypeEnum taskType) :
            base(
                name: taskReferenceName,
                taskReferenceName: taskReferenceName,
                workflowTaskType: taskType,
                inputParameters: new Dictionary<string, object>()
            )
        { }

        public Task WithInput(string key, object value)
        {
            InputParameters.Add(key, value);
            return this;
        }
    }
}
