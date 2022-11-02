using Tests.Util;
using Xunit;
using Conductor.Models;

namespace Tests.Definition
{
    public class WorkflowDefTests : IntegrationTest
    {
        [Fact]
        public void Test()
        {
            string taskName = "test-sdk-java-task";
            TaskDef task = _metadataClient.GetTaskDef(taskName);
            string createdBy = "46f0bf10-b59d-4fbd-a053-935307c8cb86@apps.orkes.io";
            Xunit.Assert.Equal(task.CreatedBy, createdBy);
        }
    }
}
