using Conductor.Api;
using Conductor.Client;
using Conductor.Client.Extensions;
using Xunit;

namespace Tests.Client;

public class OrkesApiClientTest
{
    [Fact]
    public void TestOrkesApiClient()
    {
        var configuration = ApiExtensions.GetConfiguration();
        var orkesApiClient = new OrkesApiClient(configuration, null);
        var workflowClient = orkesApiClient.GetClient<WorkflowResourceApi>();
        var expectedWorkflowClient = configuration.GetClient<WorkflowResourceApi>();
        var token = workflowClient.Configuration.AccessToken;
        var expectedToken = expectedWorkflowClient.Configuration.AccessToken;
        Assert.Equal(expectedToken, token);
    }
}