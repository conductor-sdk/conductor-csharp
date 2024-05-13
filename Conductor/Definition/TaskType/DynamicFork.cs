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
using Conductor.Definition.TaskType;
using Task = Conductor.Definition.TaskType.Task;

namespace Definition.TaskType
{
    public class DynamicFork : Task
    {
        public string ForkTasksParameter { get; set; }

        public string ForkTasksInputsParameter { get; set; }

        public JoinTask Join { get; set; }

        public const string FORK_TASK_PARAM = "forkedTasks";
        public const string FORK_TASK_INPUT_PARAM = "forkedTasksInputs";

        public DynamicFork(string taskReferenceName, string forkTasksParameter, string forkTasksInputsParameter) : base(taskReferenceName, WorkflowTaskTypeEnum.FORKJOINDYNAMIC)
        {
            this.Join = new JoinTask(taskReferenceName + "_join");
            this.ForkTasksParameter = forkTasksParameter;
            this.ForkTasksInputsParameter = forkTasksInputsParameter;
            base.InputParameters.Add(FORK_TASK_PARAM, forkTasksParameter);
            base.InputParameters.Add(FORK_TASK_INPUT_PARAM, forkTasksInputsParameter);
        }

        public override void UpdateWorkflowTask(WorkflowTask task)
        {
            task.SetDynamicForkJoinTasksParam("forkedTasks");
            task.SetDynamicForkTasksInputParamName("forkedTasksInputs");
        }
    }
}