using Conductor.Definition;
using Conductor.Definition.TaskType;
using Tests.Util;
using Xunit;

namespace Tests.Definition
{
    public class WorkflowDefTests : IntegrationTest
    {
        private const string WORKFLOW_NAME = "test-sdk-csharp-workflow";
        private const int WORKFLOW_VERSION = 1;
        private const string WORKFLOW_DESCRIPTION = "Test SDK C# Workflow";
        private const string WORKFLOW_OWNER_EMAIL = "test@test";
        private const string TASK_NAME = "test-sdk-csharp-task";

        [Fact]
        public void Test()
        {
            ConductorWorkflow workflow = GetConductorWorkflow();
            _workflowExecutor.RegisterWorkflow(workflow, overwrite: true);
        }

        private ConductorWorkflow GetConductorWorkflow()
        {
            return new ConductorWorkflow()
                .WithName(WORKFLOW_NAME)
                .WithVersion(WORKFLOW_VERSION)
                .WithDescription(WORKFLOW_DESCRIPTION)
                .WithTask(GetTask());
        }

        private Task GetTask()
        {
            return new SimpleTask(TASK_NAME, TASK_NAME);
        }
    }
}
