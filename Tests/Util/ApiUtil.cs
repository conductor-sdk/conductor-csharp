using Conductor.Api;
using Conductor.Client;
using Conductor.Executor;
using Conductor.Client.Authentication;
using System;
using System.Diagnostics;

namespace Tests.Util
{
    public class ApiUtil
    {
        private const string ENV_ROOT_URI = "CONDUCTOR_SERVER_URL";
        private const string ENV_KEY_ID = "KEY";
        private const string ENV_SECRET = "SECRET";

        static ApiUtil()
        {
            var configuration = new Configuration();
            configuration.BasePath = GetEnvironmentVariable(ENV_ROOT_URI);
            configuration.Timeout = 5000;
            configuration.AuthenticationSettings = new OrkesAuthenticationSettings(
                GetEnvironmentVariable(ENV_KEY_ID),
                GetEnvironmentVariable(ENV_SECRET));
            Configuration.Default = configuration;
        }

        public static WorkflowExecutor GetWorkflowExecutor()
        {
            return new WorkflowExecutor(
                metadataClient: GetClient<MetadataResourceApi>(),
                workflowClient: GetClient<WorkflowResourceApi>()
            );
        }

        public static T GetClient<T>() where T : IApiAccessor, new()
        {
            return Configuration.Default.GetClient<T>();
        }

        private static string GetEnvironmentVariable(string variable)
        {
            string value = Environment.GetEnvironmentVariable(variable);
            Debug.Assert(value != null);
            return value;
        }
    }
}
