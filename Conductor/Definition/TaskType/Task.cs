using Conductor.Models;
using System.Collections.Generic;

namespace Conductor.Definition.TaskType
{
    public abstract class Task
    {
        protected string _name { get; set; }

        protected WorkflowTask.WorkflowTaskTypeEnum _taskType { get; set; }

        protected string _description { get; set; }

        protected string _taskReferenceName { get; set; }

        protected bool _optional { get; set; }

        protected int _startDelay { get; set; }

        protected Dictionary<string, object> _input { get; set; }

        public Task(string taskReferenceName, WorkflowTask.WorkflowTaskTypeEnum taskType)
        {
            _name = taskReferenceName;
            _taskReferenceName = taskReferenceName;
            _taskType = taskType;
            _input = new Dictionary<string, object>();
        }

        public virtual WorkflowTask ToWorkflowTask()
        {
            return new WorkflowTask(
                name: _name,
                description: _description,
                taskReferenceName: _taskReferenceName,
                optional: _optional,
                startDelay: _startDelay,
                type: _taskType.ToString(),
                inputParameters: _input
            );
        }

        public Task Name(string name)
        {
            _name = name;
            return this;
        }

        public Task Description(string description)
        {
            _description = description;
            return this;
        }

        public Task Input(string key, object value)
        {
            _input.Add(key, value);
            return this;
        }
    }
}
