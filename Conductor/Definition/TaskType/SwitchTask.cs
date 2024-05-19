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

namespace Conductor.Definition.TaskType
{
    public class SwitchTask : Task
    {
        private const string VALUE_PARAM_NAME = "value-param";
        private const string SWITCH_CASE_PARAM_NAME = "switchCaseValue";

        private const string JAVASCRIPT_PARAM_NAME = "javascript";

        public SwitchTask(string taskReferenceName, string caseExpression, bool useJavascript = false) : base(taskReferenceName, WorkflowTask.WorkflowTaskTypeEnum.SWITCH)
        {
            DecisionCases = new Dictionary<string, List<WorkflowTask>>();
            DefaultCase = new List<WorkflowTask>();
            Expression = caseExpression;
            if (useJavascript)
            {
                EvaluatorType = JAVASCRIPT_PARAM_NAME;
            }
            else
            {
                EvaluatorType = VALUE_PARAM_NAME;
                Expression = SWITCH_CASE_PARAM_NAME;
                WithInput(SWITCH_CASE_PARAM_NAME, caseExpression);
            }
        }

        public SwitchTask WithDefaultCase(params WorkflowTask[] tasks)
        {
            foreach (WorkflowTask task in tasks)
            {
                DefaultCase.Add(task);
            }
            return this;
        }

        public SwitchTask WithDecisionCase(string key, params WorkflowTask[] tasks)
        {
            if (!DecisionCases.ContainsKey(key))
            {
                DecisionCases[key] = new List<WorkflowTask>();
            }
            foreach (WorkflowTask task in tasks)
            {
                DecisionCases[key].Add(task);
            }
            return this;
        }
    }
}
