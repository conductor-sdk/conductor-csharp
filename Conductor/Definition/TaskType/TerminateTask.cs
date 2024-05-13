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

namespace Conductor.Definition.TaskType
{
    public class TerminateTask : Task
    {
        private static string WORKFLOW_ID_PARAMETER = "workflowId";
        private static string TERMINATION_REASON_PARAMETER = "terminationReason";
        private static string TERMINATION_STATUS_PARAMETER = "terminationStatus";

        public TerminateTask(string taskReferenceName, WorkflowStatus.StatusEnum terminationStatus = WorkflowStatus.StatusEnum.FAILED, string workflowId = null, string terminationReason = null) : base(taskReferenceName, WorkflowTask.WorkflowTaskTypeEnum.TERMINATE)
        {
            WithInput(TERMINATION_STATUS_PARAMETER, terminationStatus);
            if (workflowId != null)
            {
                WithInput(WORKFLOW_ID_PARAMETER, workflowId);
            }
            if (terminationReason != null)
            {
                WithInput(TERMINATION_REASON_PARAMETER, terminationReason);
            }
        }
    }
}
