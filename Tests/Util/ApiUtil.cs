using Conductor.Api;
using Conductor.Client;
using Conductor.Executor;
using System;
using System.Diagnostics;

namespace Tests.Util
{
    public class ApiUtil
    {
        private const string ENV_ROOT_URI = "CONDUCTOR_SERVER_URL";
        private const string ENV_KEY_ID = "KEY";
        private const string ENV_SECRET = "SECRET";

        private static string _basePath = null;
        private static string _keyId = null;
        private static string _keySecret = null;

        static ApiUtil()
        {
            _basePath = GetEnvironmentVariable(ENV_ROOT_URI);
            _keyId = GetEnvironmentVariable(ENV_KEY_ID);
            _keySecret = GetEnvironmentVariable(ENV_SECRET);
        }

        public static WorkflowExecutor GetWorkflowExecutor()
        {
            return new WorkflowExecutor(
                metadataClient: GetClient<MetadataResourceApi>(),
                workflowClient: GetClient<WorkflowResourceApi>()
            );
        }

        public static OrkesApiClient GetApiClient()
        {
            return new OrkesApiClient(GetConfiguration());
        }

        public static T GetClient<T>() where T : IApiAccessor, new()
        {
            var apiClient = GetApiClient();
            return apiClient.GetClient<T>();
        }

        public static Configuration GetConfiguration()
        {
            Configuration configuration = new Configuration();
            configuration.keyId = _keyId;
            configuration.keySecret = _keySecret;
            configuration.BasePath = _basePath;
            configuration.Timeout = 5000;
            return configuration;
        }

        private static string GetEnvironmentVariable(string variable)
        {
            string value = Environment.GetEnvironmentVariable(variable);
            Debug.Assert(value != null);
            return value;
        }
    }
}
