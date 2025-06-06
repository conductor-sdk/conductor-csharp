/*
 * Copyright 2024 Conductor Authors.
 * <p>
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with
 * the License. You may obtain a copy of the License at
 * <p>
 * http://www.apache.org/licenses/LICENSE-2.0
 * <p>
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on
 * an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the
 * specific language governing permissions and limitations under the License.
 */
using Conductor.Api;
using Conductor.Executor;
using Conductor.Client.Authentication;
using System;

namespace Conductor.Client.Extensions
{
    public class ApiExtensions
    {
        private const int REST_CLIENT_REQUEST_TIME_OUT = 30 * 1000;

        private static readonly Lazy<Configuration> _lazyConfiguration =
            new Lazy<Configuration>(() => new Configuration(REST_CLIENT_REQUEST_TIME_OUT)
            {
                BasePath = GetBasePathFromEnv(),
                AuthenticationSettings = GetAuthenticationSettingsFromEnv()
            });

        private static Configuration _customConfiguration;

        public static Configuration Configuration
        {
            get => _customConfiguration ?? _lazyConfiguration.Value;
            set => _customConfiguration = value;
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
            return Configuration.GetClient<T>();
        }

        public static Configuration GetConfiguration()
        {
            return Configuration;
        }

        public static string GetWorkflowExecutionURL(string workflowId)
        {
            var basePath = Configuration.BasePath;
            var prefix = basePath.Remove(basePath.Length - 4);
            return $"{prefix}/execution/{workflowId}";
        }

        private static string GetEnvVariableOrThrow(string variable)
        {
            return Environment.GetEnvironmentVariable(variable) ?? throw new InvalidOperationException($"Environment variable '{variable}' is not set.");
        }

        private static string GetBasePathFromEnv()
        {
            return GetEnvVariableOrThrow("CONDUCTOR_SERVER_URL");
        }

        private static OrkesAuthenticationSettings GetAuthenticationSettingsFromEnv()
        {
            // keeping KEY and SECRET for backwards compatibility
            string keyId = Environment.GetEnvironmentVariable("CONDUCTOR_AUTH_KEY") ?? Environment.GetEnvironmentVariable("KEY");
            string secret = Environment.GetEnvironmentVariable("CONDUCTOR_AUTH_SECRET") ?? Environment.GetEnvironmentVariable("SECRET");
            if (!string.IsNullOrEmpty(keyId) && !string.IsNullOrEmpty(secret))
            {
                return new OrkesAuthenticationSettings(keyId, secret);
            }

            return null;
        }
    }
}
