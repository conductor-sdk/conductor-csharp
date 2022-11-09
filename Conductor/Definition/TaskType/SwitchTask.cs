using Conductor.Models;
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
