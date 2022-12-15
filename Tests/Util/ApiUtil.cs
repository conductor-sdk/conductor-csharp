using Conductor.Api;
using Conductor.Client;
using Conductor.Executor;
using System;
using System.Diagnostics;

namespace Tests.Util
{
    public class ApiUtil
    {
        private const string ENV_ROOT_URI = "SDK_INTEGRATION_TESTS_SERVER_API_URL";
        private const string ENV_KEY_ID = "SDK_INTEGRATION_TESTS_SERVER_KEY_ID";
        private const string ENV_SECRET = "SDK_INTEGRATION_TESTS_SERVER_KEY_SECRET";

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

        public static T GetClient<T>() where T : IApiAccessor, new()
        {
            OrkesApiClient apiClient = new OrkesApiClient(GetConfiguration());
            return apiClient.GetClient<T>();
        }

        public static Configuration GetConfiguration()
        {
            Configuration configuration = new Configuration();
            configuration.keyId = _keyId;
            configuration.keySecret = _keySecret;
            configuration.BasePath = _basePath;
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
