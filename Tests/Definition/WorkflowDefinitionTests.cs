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
        public void TestKitchenSinkWorkflow()
        {
            _workflowExecutor.RegisterWorkflow(
                conductorWorkflow: GetConductorWorkflow(),
                overwrite: true
            );
        }

        private ConductorWorkflow GetConductorWorkflow()
        {
            return new ConductorWorkflow()
                .WithName(WORKFLOW_NAME)
                .WithVersion(WORKFLOW_VERSION)
                .WithDescription(WORKFLOW_DESCRIPTION)
                    .WithTask(GetSimpleTask())
                    .WithTask(GetHttpTask())
                    .WithTask(GetEventTask())
                    .WithTask(GetJQTask())
                    .WithTask(GetTerminateTask())
            ;
        }

        private Task GetSimpleTask()
        {
            return new SimpleTask(TASK_NAME, TASK_NAME);
        }

        private Task GetHttpTask()
        {
            HttpTaskSettings settings = new HttpTaskSettings();
            settings.uri = "https://jsonplaceholder.typicode.com/posts/${workflow.input.queryid}";
            return new HttpTask("http_task_reference_name")
                .WithSettings(settings);
        }

        private Task GetEventTask()
        {
            return new EventTask("event_task_reference_name", "event_sink_name");
        }

        private Task GetJQTask()
        {
            return new JQTask("jq_task_reference_name", "{ key3: (.key1.value1 + .key2.value2) }");
        }

        private Task GetTerminateTask()
        {
            return new TerminateTask("terminate_task_reference_name");
        }
    }
}
