using Conductor.Client.Models;
using System.Collections.Generic;

namespace Conductor.Definition
{
	public class ConductorWorkflow : WorkflowDef
	{
		public ConductorWorkflow() : base(name: "", tasks: new List<WorkflowTask>(), timeoutSeconds: 0)
		{
			InputParameters = new List<string>();
		}

		public ConductorWorkflow WithName(string name)
		{
			Name = name;
			return this;
		}

		public ConductorWorkflow WithVersion(int version)
		{
			Version = version;
			return this;
		}

		public ConductorWorkflow WithDescription(string description)
		{
			Description = description;
			return this;
		}

		public ConductorWorkflow WithTimeoutPolicy(WorkflowDef.TimeoutPolicyEnum timeoutPolicy, int timeoutSeconds)
		{
			TimeoutPolicy = timeoutPolicy;
			TimeoutSeconds = timeoutSeconds;
			return this;
		}

		public ConductorWorkflow WithTask(params WorkflowTask[] tasks)
		{
			foreach (WorkflowTask task in tasks)
			{
				Tasks.Add(task);
			}
			return this;
		}

		public ConductorWorkflow WithFailureWorkflow(string failureWorkflow)
		{
			FailureWorkflow = failureWorkflow;
			return this;
		}

		public ConductorWorkflow WithRestartable(bool restartable)
		{
			Restartable = restartable;
			return this;
		}

		public ConductorWorkflow WithOutputParameter(string key, object value)
		{
			OutputParameters.Add(key, value);
			return this;
		}

		public ConductorWorkflow WithVariable(string key, object value)
		{
			if (Variables == null) // if workflow does not have any variables, initialize with empty collection
				Variables = new Dictionary<string, object>();
			Variables.Add(key, value);
			return this;
		}

		public ConductorWorkflow WithOwner(string ownerEmail)
		{
			OwnerEmail = ownerEmail;
			return this;
		}

		public ConductorWorkflow WithInputParameter(string key)
		{
			InputParameters.Add(key);
			return this;
		}

		public StartWorkflowRequest GetStartWorkflowRequest()
		{
			return new StartWorkflowRequest(
				name: Name,
				version: Version
			);
		}
	}
}
