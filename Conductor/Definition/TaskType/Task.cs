using Conductor.Client.Models;
using System.Collections.Generic;

namespace Conductor.Definition.TaskType
{
    public abstract class Task : WorkflowTask
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Task" /> class.
        /// </summary>
        /// <param name="taskReferenceName"></param>
        /// <param name="taskType"></param>
        public Task(string taskReferenceName, WorkflowTask.WorkflowTaskTypeEnum taskType) :
            base(
                name: taskReferenceName,
                taskReferenceName: taskReferenceName,
                workflowTaskType: taskType,
                inputParameters: new Dictionary<string, object>()
            )
        { }

        /// <summary>
        /// Adds the task parameters to InputParameters
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task WithInput(string key, object value)
        {
            // Updates or adds key-value pair
            InputParameters[key] = value;
            return this;
        }

        /// <summary>
        /// creates a json path for output parameters
        /// </summary>
        /// <param name="jsonPath"></param>
        /// <returns></returns>
        public string Output(string jsonPath = null)
        {
            if (jsonPath == null)
            {
                return "${" + $"{this.TaskReferenceName}.output" + "}";
            }
            else
            {
                return "${" + $"{this.TaskReferenceName}.output.{jsonPath}" + "}";
            }
        }
    }
}
