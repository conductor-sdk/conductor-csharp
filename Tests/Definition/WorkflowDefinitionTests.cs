using Conductor.Definition;
using Conductor.Models;
using Conductor.Definition.TaskType;
using System;
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
                workflow: GetConductorWorkflow(),
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
                    .WithTask(GetSubWorkflowTask())
                    .WithTask(GetHttpTask())
                    .WithTask(GetDoWhileTask())
                    .WithTask(GetEventTask())
                    .WithTask(GetJQTask())
                    .WithTask(GetWaitTask())
                    .WithTask(GetSetVariableTask())
                    .WithTask(GetTerminateTask())
            ;
        }

        private WorkflowTask GetSimpleTask()
        {
            return new SimpleTask(TASK_NAME, TASK_NAME);
        }

        private WorkflowTask GetHttpTask()
        {
            HttpTaskSettings settings = new HttpTaskSettings();
            settings.uri = "https://jsonplaceholder.typicode.com/posts/${workflow.input.queryid}";
            return new HttpTask("http_task_reference_name", settings);
        }

        private WorkflowTask GetEventTask()
        {
            return new EventTask("event_task_reference_name", "event_sink_name");
        }

        private WorkflowTask GetJQTask()
        {
            return new JQTask("jq_task_reference_name", "{ key3: (.key1.value1 + .key2.value2) }");
        }

        private WorkflowTask GetTerminateTask()
        {
            return new TerminateTask("terminate_task_reference_name");
        }

        private WorkflowTask GetWaitTask()
        {
            return new WaitTask("wait_task_reference_name", new TimeSpan(1));
        }

        private WorkflowTask GetSetVariableTask()
        {
            return new SetVariableTask("set_variable_task_reference_name")
                .WithInput("variable_name", "variable_content");
        }

        private WorkflowTask GetDoWhileTask()
        {
            return new LoopTask(
                taskReferenceName: "do_while_task_reference_name",
                iterations: 5,
                loopOver: new SimpleTask(
                    "do_while_inner_task_reference_name",
                    "do_while_inner_task_reference_name"
                )
            );
        }

        private WorkflowTask GetSubWorkflowTask()
        {
            return new SubWorkflowTask(
                taskReferenceName: "sub_workflow_task_reference_name",
                subWorkflowParams: new SubWorkflowParams(
                    name: "test-sdk-java-workflow"
                )
            );
        }
    }
}
