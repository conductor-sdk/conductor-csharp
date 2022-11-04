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
        private bool _restartable { get; set; } = true;
        private Dictionary<string, object> _variables { get; set; }
        private List<Definition.TaskType.Task> _tasks { get; set; }

        public ConductorWorkflow()
        {
            _workflowOutput = new Dictionary<string, object>();
            _restartable = false;
            _tasks = new List<TaskType.Task>();
            _timeoutSeconds = 0;
        }

        public WorkflowDef ToWorkflowDef()
        {
            return new WorkflowDef(
                name: _name,
                tasks: GetWorkflowTasks(),
                description: _description,
                version: _version,
                failureWorkflow: _failureWorkflow,
                ownerEmail: _ownerEmail,
                timeoutPolicy: _timeoutPolicy,
                timeoutSeconds: _timeoutSeconds,
                restartable: _restartable,
                outputParameters: _workflowOutput,
                variables: _variables
            );
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

        public ConductorWorkflow WithOutputParameter(string key, object value)
        {
            _workflowOutput.Add(key, value);
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
            List<WorkflowTask> workflowTasks = new List<WorkflowTask>();
            for (int i = 0; i < _tasks.Count; i += 1)
            {
                workflowTasks.Add(_tasks[i].ToWorkflowTask());
            }
            return workflowTasks;
        }
    }
}