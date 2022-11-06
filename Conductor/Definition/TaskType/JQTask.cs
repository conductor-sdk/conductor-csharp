using Conductor.Models;

namespace Conductor.Definition.TaskType
{
    public class JQTask : Task
    {
        private static string QUERY_EXPRESSION_PARAMETER = "queryExpression";

        public JQTask(string taskReferenceName, string queryExpression) : base(taskReferenceName, WorkflowTask.WorkflowTaskTypeEnum.JSONJQTRANSFORM)
        {
            Input(QUERY_EXPRESSION_PARAMETER, queryExpression);
        }
    }
}
