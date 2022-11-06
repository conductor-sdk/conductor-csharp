using Conductor.Models;

namespace Conductor.Definition.TaskType
{
    public class TerminateTask : Task
    {
        private static string WORKFLOW_ID_PARAMETER = "workflowId";
        private static string TERMINATION_REASON_PARAMETER = "terminationReason";
        private static string TERMINATION_STATUS_PARAMETER = "terminationStatus";

        public TerminateTask(string taskReferenceName, WorkflowStatus.StatusEnum terminationStatus = WorkflowStatus.StatusEnum.FAILED, string workflowId = null, string terminationReason = null) : base(taskReferenceName, WorkflowTask.WorkflowTaskTypeEnum.TERMINATE)
        {
            Input(TERMINATION_STATUS_PARAMETER, terminationStatus);
            if (workflowId != null)
            {
                Input(WORKFLOW_ID_PARAMETER, workflowId);
            }
            if (terminationReason != null)
            {
                Input(TERMINATION_REASON_PARAMETER, terminationReason);
            }
        }
    }
}
