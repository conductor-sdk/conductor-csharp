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
using Conductor.Client.Extensions;
using Conductor.Client.Models;
using Conductor.Definition;
using Conductor.Executor;
using System.Collections.Generic;
using System.Threading;

namespace Conductor.Examples
{
    public class GreetingsMain
    {
        private readonly Configuration _configuration;
        private readonly WorkflowResourceApi workflowClient;
        private readonly MetadataResourceApi _metaDataClient;

        public GreetingsMain()
        {
            _metaDataClient = ApiExtensions.GetClient<MetadataResourceApi>();

            //dev local testing
            //_configuration = new Client.Configuration();
            //var _orkesApiClient = new OrkesApiClient(_configuration, new OrkesAuthenticationSettings(Constants.KEY_ID, Constants.KEY_SECRET));
            //_metaDataClient = _orkesApiClient.GetClient<MetadataResourceApi>();
        }
        public (ConductorWorkflow, string workflowId) RegisterWorkflow(WorkflowExecutor workflowExecutor)
        {
            GreetingsWorkflow greetingsWorkflow = new GreetingsWorkflow();
            var workflow = greetingsWorkflow.CreateGreetingsWorkflow();
            _metaDataClient.UpdateWorkflowDefinitions(new List<WorkflowDef>(1) { workflow });
            var testInput = new Dictionary<string, object>
{
{ "name","test" }
};
            StartWorkflowRequest startWorkflowRequest = new StartWorkflowRequest()
            {
                Name = workflow.Name,
                Input = testInput,
                Version = workflow.Version,
                WorkflowDef = workflow,
                CreatedBy = Constants.OWNER_EMAIL
            };
            var workflowId = workflowExecutor.StartWorkflow(startWorkflowRequest);
            return (workflow, workflowId);
        }

        public void GreetingsMainMethod()
        {
            WorkflowExecutor workflowExecutor = new WorkflowExecutor(_configuration);
            (ConductorWorkflow workflow, string workflowId) = RegisterWorkflow(workflowExecutor);

            var waitHandle = new ManualResetEvent(false);
            var backgroundTask = System.Threading.Tasks.Task.Run(async () => await Utils.WorkerUtil.StartBackGroundTask(waitHandle));
            waitHandle.WaitOne();
        }
    }
}