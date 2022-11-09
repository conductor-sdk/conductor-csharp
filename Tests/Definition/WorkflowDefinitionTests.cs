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
            _workflowExecutor.RegisterWorkflow
            (
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
                .WithInputParameter("number")
                    .WithTask(GetSimpleTask())
                    .WithTask(GetSubWorkflowTask())
                    .WithTask(GetHttpTask())
                    .WithTask(GetForkJoinTask())
                    .WithTask(GetJavascriptTask())
                    .WithTask(GetDoWhileTask())
                    .WithTask(GetEventTask())
                    .WithTask(GetJQTask())
                    .WithTask(GetSwitchTask())
                    .WithTask(GetWaitTask())
                    .WithTask(GetSetVariableTask())
                    .WithTask(GetTerminateTask())
            ;
        }

        private WorkflowTask GetSimpleTask(string taskReferenceName = TASK_NAME)
        {
            return new SimpleTask(taskReferenceName, taskReferenceName);
        }

        private WorkflowTask GetHttpTask(string taskReferenceName = "http_task_reference_name")
        {
            HttpTaskSettings settings = new HttpTaskSettings();
            settings.uri = "https://jsonplaceholder.typicode.com/posts/${workflow.input.queryid}";
            return new HttpTask(taskReferenceName, settings);
        }

        private WorkflowTask GetEventTask(string taskReferenceName = "event_task_reference_name")
        {
            return new EventTask(taskReferenceName, "event_sink_name");
        }

        private WorkflowTask GetJQTask(string taskReferenceName = "jq_task_reference_name")
        {
            return new JQTask(taskReferenceName, "{ key3: (.key1.value1 + .key2.value2) }");
        }

        private WorkflowTask GetTerminateTask(string taskReferenceName = "terminate_task_reference_name")
        {
            return new TerminateTask(taskReferenceName);
        }

        private WorkflowTask GetWaitTask(string taskReferenceName = "wait_task_reference_name")
        {
            return new WaitTask(taskReferenceName, new TimeSpan(1));
        }

        private WorkflowTask GetSetVariableTask(string taskReferenceName = "set_variable_task_reference_name")
        {
            return new SetVariableTask(taskReferenceName)
                .WithInput("variable_name", "variable_content");
        }

        private WorkflowTask GetDoWhileTask(string taskReferenceName = "do_while_task_reference_name")
        {
            return new LoopTask
            (
                taskReferenceName: taskReferenceName,
                iterations: 5,
                GetWaitTask("do_while_wait_inner_task_reference_name")
            );
        }

        private WorkflowTask GetSubWorkflowTask(string taskReferenceName = "sub_workflow_task_reference_name")
        {
            return new SubWorkflowTask
            (
                taskReferenceName: taskReferenceName,
                subWorkflowParams: new SubWorkflowParams
                (
                    name: "test-sdk-java-workflow"
                )
            );
        }

        private WorkflowTask[] GetForkJoinTask(string taskReferenceName = "fork_join_task_reference_name")
        {
            return new WorkflowTask[]
            {
                new ForkJoinTask
                (
                    taskReferenceName: taskReferenceName,
                    new WorkflowTask[]
                    {
                        GetSetVariableTask("fork_join_set_variable_inner_task_reference_name"),
                        GetTerminateTask("fork_join_terminate_inner_task_reference_name")
                    },
                    new WorkflowTask[]
                    {
                        GetWaitTask("fork_join_wait_inner_task_reference_name")
                    }
                ),
                new JoinTask
                (
                    taskReferenceName: taskReferenceName + "_join",
                    GetWaitTask("fork_join_wait_inner_task_reference_name")
                )
            };
        }

        private WorkflowTask GetJavascriptTask(string taskReferenceName = "javascript_task_reference_name")
        {
            return new JavascriptTask(
                taskReferenceName: taskReferenceName,
                script: "{ key3: (.key1.value1 + .key2.value2) }"
            );
        }

        private WorkflowTask GetSwitchTask(string taskReferenceName = "switch_task_reference_name")
        {
            return new SwitchTask
            (
                taskReferenceName: taskReferenceName,
                caseExpression: "$.number < 15 ? 'LONG':'LONG'",
                useJavascript: true
            ).WithDecisionCase
            (
                key: "LONG",
                GetWaitTask("switch_wait_inner_task_reference_name")
            ).WithDecisionCase
            (
                key: "SHORT",
                GetTerminateTask("switch_terminate_inner_task_reference_name")
            ).WithDefaultCase
            (
                GetHttpTask("switch_http_inner_task_reference_name")
            ).WithInput
            (
                "number", "${workflow.input.number}"
            );
        }
    }
}
