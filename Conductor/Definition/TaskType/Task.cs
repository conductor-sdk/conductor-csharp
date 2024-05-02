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

        /// <summary>
        /// Returns work flow tasks
        /// </summary>
        /// <returns></returns>
        public List<WorkflowTask> GetWorkflowDefTasks()
        {
            List<WorkflowTask> workflowTasks = new List<WorkflowTask>();
            workflowTasks.AddRange(GetParentTasks());
            workflowTasks.Add(ToWorkflowTask());
            workflowTasks.AddRange(GetChildrenTasks());
            return workflowTasks;
        }

        /// <summary>
        /// Returns a Work flow task
        /// </summary>
        /// <returns></returns>
        protected WorkflowTask ToWorkflowTask()
        {
            WorkflowTask workflowTask = new WorkflowTask();
            workflowTask.Name = Name;
            workflowTask.Description = Description;
            workflowTask.TaskReferenceName = TaskReferenceName;
            workflowTask.WorkflowTaskType = WorkflowTaskType;
            workflowTask.InputParameters = InputParameters;
            workflowTask.StartDelay = StartDelay;
            workflowTask.Optional = Optional;

            // Let the sub-classes enrich the workflow task before returning back
            UpdateWorkflowTask(workflowTask);
            return workflowTask;
        }

        /// <summary>
        /// Override this method when the sub-class should update the default WorkflowTask
        /// </summary>
        /// <param name="workflowTask"></param>
        public virtual void UpdateWorkflowTask(WorkflowTask workflowTask) { }

        /// <summary>
        /// Override this method when sub-classes will generate multiple workflow tasks. Used by tasks
        /// which have children tasks such as do_while, fork, etc.
        /// </summary>
        /// <returns></returns>
        protected virtual List<WorkflowTask> GetChildrenTasks()
        {
            return new List<WorkflowTask>();
        }

        /// <summary>
        /// Override this method when sub-classes will generate multiple workflow tasks. Used by tasks
        /// which have children tasks such as do_while, fork, etc.
        /// </summary>
        /// <returns></returns>
        protected virtual List<WorkflowTask> GetParentTasks()
        {
            return new List<WorkflowTask>();
        }
    }
}
