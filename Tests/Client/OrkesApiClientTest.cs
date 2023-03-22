using Conductor.Api;
using Conductor.Client;
using Xunit;

namespace Tests.Client
{
    public class OrkesApiClientTest
    {
        [Fact]
        public void TestOrkesApiClient()
        {
            Configuration.Default = new Configuration();
            var orkesApiClient = new OrkesApiClient(Configuration.Default, null);
            var workflowClient = orkesApiClient.GetClient<WorkflowResourceApi>();
            var expectedWorkflowClient = Configuration.Default.GetClient<WorkflowResourceApi>();
            Assert.Equal(expectedWorkflowClient.Configuration.AccessToken, workflowClient.Configuration.AccessToken);
        }
    }
}