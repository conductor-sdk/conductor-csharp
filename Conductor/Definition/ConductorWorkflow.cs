using System.Collections.Generic;
using Conductor.Models;

namespace Conductor.Definition
{
    public class ConductorWorkflow
    {
        private string _name { get; set; }
        private string _description { get; set; }
        private int _version { get; set; }
        private string _failureWorkflow { get; set; }
        private string _ownerEmail { get; set; }
        private Models.WorkflowDef.TimeoutPolicyEnum _timeoutPolicy { get; set; }
        private Dictionary<string, object> _workflowOutput { get; set; }
        private long _timeoutSeconds { get; set; }
        private bool _restartable { get; set; }
        private Dictionary<string, object> _variables { get; set; }
        private List<Definition.TaskType.Task> _tasks { get; set; }

        public WorkflowDef ToWorkflowDef()
        {
            WorkflowDef workflowDef = new WorkflowDef(
                name: _name,
                tasks: GetWorkflowTasks()
            );
            workflowDef.Description = _description;
            workflowDef._Version = _version;
            workflowDef.FailureWorkflow = _failureWorkflow;
            workflowDef.OwnerEmail = _ownerEmail;
            workflowDef.TimeoutPolicy = _timeoutPolicy;
            workflowDef.TimeoutSeconds = _timeoutSeconds;
            workflowDef.Restartable = _restartable;
            workflowDef.OutputParameters = _workflowOutput;
            workflowDef.Variables = _variables;
            return workflowDef;
        }

        public ConductorWorkflow WithName(string name)
        {
            _name = name;
            return this;
        }

        public ConductorWorkflow WithVersion(int version)
        {
            _version = version;
            return this;
        }

        public ConductorWorkflow WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public ConductorWorkflow WithTimeoutPolicy(WorkflowDef.TimeoutPolicyEnum timeoutPolicy, int timeoutSeconds)
        {
            _timeoutPolicy = timeoutPolicy;
            _timeoutSeconds = timeoutSeconds;
            return this;
        }

        public ConductorWorkflow WithTask(Definition.TaskType.Task task)
        {
            _tasks.Add(task);
            return this;
        }

        public ConductorWorkflow WithFailureWorkflow(string failureWorkflow)
        {
            _failureWorkflow = failureWorkflow;
            return this;
        }

        public ConductorWorkflow WithRestartable(bool restartable)
        {
            _restartable = restartable;
            return this;
        }

        public ConductorWorkflow WithOutputParameters(Dictionary<string, object> workflowOutput)
        {
            _workflowOutput = workflowOutput;
            return this;
        }

        public ConductorWorkflow WithOwner(string ownerEmail)
        {
            _ownerEmail = ownerEmail;
            return this;
        }

        public StartWorkflowRequest GetStartWorkflowRequest()
        {
            return new StartWorkflowRequest(
                name: _name,
                version: _version
            );
        }

        private List<WorkflowTask> GetWorkflowTasks()
        {
            List<WorkflowTask> workflowTasks = new List<WorkflowTask>(_tasks.Count);
            for (int i = 0; i < _tasks.Count; i += 1)
            {
                workflowTasks[i] = _tasks[i].ToWorkflowTask();
            }
            return workflowTasks;
        }
    }
}