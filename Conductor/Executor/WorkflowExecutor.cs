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
using Conductor.Api;
using Conductor.Client;
using Conductor.Client.Models;
using Conductor.Definition;
using System.Collections.Generic;

namespace Conductor.Executor
{
    public class WorkflowExecutor
    {
        private WorkflowResourceApi _workflowClient;
        private MetadataResourceApi _metadataClient;

        public WorkflowExecutor(Configuration configuration)
        {
            _workflowClient = configuration.GetClient<WorkflowResourceApi>();
            _metadataClient = configuration.GetClient<MetadataResourceApi>();
        }

        public WorkflowExecutor(WorkflowResourceApi workflowClient, MetadataResourceApi metadataClient)
        {
            _workflowClient = workflowClient;
            _metadataClient = metadataClient;
        }

        public void RegisterWorkflow(WorkflowDef workflow, bool overwrite)
        {
            if (overwrite)
            {
                _metadataClient.UpdateWorkflowDefinitions(new List<WorkflowDef>(1) { workflow });
            }
            else
            {
                _metadataClient.Create(workflow);
            }
        }

        public string StartWorkflow(ConductorWorkflow conductorWorkflow)
        {
            return StartWorkflow(conductorWorkflow.GetStartWorkflowRequest());
        }

        public string StartWorkflow(StartWorkflowRequest startWorkflowRequest)
        {
            return _workflowClient.StartWorkflow(startWorkflowRequest);
        }
    }
}
