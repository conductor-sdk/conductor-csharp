using System.Collections.Generic;

namespace Conductor.Client.Workflow.Def.Task
{
    public abstract class Task
    {
        protected Models.TaskDef taskDef;
        protected string _name { get; set; }

        protected string _taskType { get; set; }

        protected string _description { get; set; }

        protected string _taskReferenceName { get; set; }

        protected bool _optional { get; set; }

        protected int _startDelay { get; set; }

        protected Models.WorkflowTask.WorkflowTaskTypeEnum _workflowTaskType { get; set; }

        protected Dictionary<string, object> _input { get; set; }

        public Task(string taskReferenceName, string taskType)
        {
            _name = taskReferenceName;
            _taskReferenceName = taskReferenceName;
            _taskType = taskType;
        }

        public Models.WorkflowTask ToWorkflowTask()
        {
            Models.WorkflowTask workflowTask = default(Models.WorkflowTask);
            workflowTask.Name = _name;
            workflowTask.TaskReferenceName = _taskReferenceName;
            workflowTask.Type = _taskType;
            workflowTask.InputParameters = _input;
            return workflowTask;
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