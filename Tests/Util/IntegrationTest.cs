using Conductor.Executor;

namespace Tests.Util
{
    public abstract class IntegrationTest
    {
        protected static WorkflowExecutor _workflowExecutor;

        static IntegrationTest()
        {
            _workflowExecutor = ApiUtil.GetWorkflowExecutor();
        }
    }
}