using Conductor.Api;
using Conductor.Client.Models;
using System.Collections.Generic;
using Xunit;

namespace Tests.Examples
{
    public class MetadataApiTests : ApiTest<MetadataResourceApi>
    {
        [Fact]
        public override void TestMethods()
        {
            List<TaskDef> taskDefs = GetTaskDefs();
            _client.RegisterTaskDef(taskDefs);
            List<WorkflowDef> workflowDefs = GetWorkflowDefs();
            _client.UpdateWorkflowDefinitions(workflowDefs);
        }

        private List<TaskDef> GetTaskDefs()
        {
            return new List<TaskDef>()
            {
                new TaskDef
                (
                    name: "simple_task_0",
                    ownerEmail: "test@orkes.io",
                    timeoutSeconds: 0
                )
            };
        }

        private List<WorkflowDef> GetWorkflowDefs()
        {
            return new List<WorkflowDef>()
            {
                new WorkflowDef
                (
                    name: "new_load_test",
                    tasks: GetWorkflowTasks(),
                    version: 1,
                    timeoutSeconds: 0,
                    ownerEmail: "test@orkes.io",
                    schemaVersion: 2
                )
            };
        }

        private List<WorkflowTask> GetWorkflowTasks()
        {
            return new List<WorkflowTask>()
            {
                new WorkflowTask
                (
                    name:"simple_task_0",
                    taskReferenceName: "simple_task_0",
                    type: "SIMPLE",
                    inputParameters: new Dictionary<string, object>()
                )
            };
        }
    }
}
