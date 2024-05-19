/*
 * Copyright 2024 Conductor Authors.
 * <p>
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with
 * the License. You may obtain a copy of the License at
 * <p>
 * http://www.apache.org/licenses/LICENSE-2.0
 * <p>
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on
 * an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the
 * specific language governing permissions and limitations under the License.
 */
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

        /// <summary>
        /// creates a json path for input parameters
        /// </summary>
        /// <param name="jsonPath"></param>
        /// <returns></returns>
        public string Input(string jsonPath)
        {
            if (jsonPath == null)
            {
                return "${" + "workflow.input" + "}";
            }
            else
            {
                return "${" + $"workflow.input.{jsonPath}" + "}";
            }
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
                return "${" + "workflow.output" + "}";
            }
            else
            {
                return "${" + $"workflow.output.{jsonPath}" + "}";
            }
        }
    }
}
