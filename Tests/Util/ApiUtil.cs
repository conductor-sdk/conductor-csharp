using Conductor.Api;
using Conductor.Client.Authentication;
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
            OrkesApiClient apiClient = GetApiClient();
            return new WorkflowExecutor(
                workflowClient: apiClient.GetClient<WorkflowResourceApi>(),
                metadataClient: apiClient.GetClient<MetadataResourceApi>()
            );
        }

        public static OrkesApiClient GetApiClient()
        {
            Configuration configuration = new Configuration();
            configuration.BasePath = _basePath;
            return GetApiClient(configuration);
        }

        private static OrkesApiClient GetApiClient(Configuration configuration)
        {
            return new OrkesApiClient
            (
                configuration: configuration,
                authenticationSettings: new OrkesAuthenticationSettings
                (
                    keyId: _keyId,
                    keySecret: _keySecret
                )
            );
        }


        private static string GetEnvironmentVariable(string variable)
        {
            string value = Environment.GetEnvironmentVariable(variable);
            Debug.Assert(value != null);
            return value;
        }
    }
}
