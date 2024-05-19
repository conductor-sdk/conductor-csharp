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
using System.Collections.Generic;
using EnvironmentInstance = System.Environment;

namespace Conductor.Client.Ai
{
    /// <summary>
    /// Integration configuration abstract base class.
    /// </summary>
    public abstract class IntegrationConfig
    {
        /// <summary>
        /// Converts the configuration to a dictionary.
        /// </summary>
        /// <returns>A dictionary representation of the configuration.</returns>
        public abstract Dictionary<string, object> ToDictionary();
    }

    /// <summary>
    /// Configuration class for Weaviate integration.
    /// </summary>
    public class WeaviateConfig : IntegrationConfig
    {
        /// <summary>
        /// Gets or Sets ApiKey
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or Sets Endpoint
        /// </summary>
        public string Endpoint { get; set; }

        /// <summary>
        /// Gets or Sets Class
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeaviateConfig" /> class
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="endpoint"></param>
        /// <param name="className"></param>
        public WeaviateConfig(string apiKey, string endpoint, string className)
        {
            ApiKey = apiKey;
            Endpoint = endpoint;
            ClassName = className;
        }

        /// <summary>
        /// Inherited method
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>
            {
                { Constants.APIKEY, ApiKey },
                { Constants.ENDPOINT, Endpoint }
            };
        }
    }

    /// <summary>
    /// Configuration class for OpenAIConfig integration.
    /// </summary>
    public class OpenAIConfig : IntegrationConfig
    {
        /// <summary>
        /// Gets or Sets ApiKey
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenAIConfig" /> class
        /// </summary>
        /// <param name="apiKey"></param>
        public OpenAIConfig(string apiKey = null)
        {
            ApiKey = apiKey ?? EnvironmentInstance.GetEnvironmentVariable(Constants.OPENAIAPIKEY);
        }

        /// <summary>
        /// Inherited method
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>
            {
                { Constants.APIKEY, ApiKey }
            };
        }
    }

    /// <summary>
    /// Configuration class for AzureOpenAIConfig integration.
    /// </summary>
    public class AzureOpenAIConfig : IntegrationConfig
    {
        /// <summary>
        /// Gets or Sets ApiKey
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or Sets Endpoint
        /// </summary>
        public string Endpoint { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureOpenAIConfig" /> class
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="endpoint"></param>
        public AzureOpenAIConfig(string apiKey, string endpoint)
        {
            ApiKey = apiKey;
            Endpoint = endpoint;
        }

        /// <summary>
        /// Inherited method
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>
            {
                { Constants.APIKEY, ApiKey },
                { Constants.ENDPOINT, Endpoint }
            };
        }
    }

    /// <summary>
    /// Configuration class for PineconeConfig integration.
    /// </summary>
    public class PineconeConfig : IntegrationConfig
    {
        /// <summary>
        /// Gets or Sets ApiKey
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or Sets Endpoint
        /// </summary>
        public string Endpoint { get; set; }

        /// <summary>
        /// Gets or Sets Environment
        /// </summary>
        public string Environment { get; set; }

        /// <summary>
        /// Gets or Sets ProjectName
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PineconeConfig" /> class
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="endpoint"></param>
        /// <param name="environment"></param>
        /// <param name="projectName"></param>
        public PineconeConfig(string apiKey = null, string endpoint = null, string environment = null, string projectName = null)
        {
            ApiKey = apiKey ?? EnvironmentInstance.GetEnvironmentVariable(Constants.PINECONEAPIKEY);
            Endpoint = endpoint ?? EnvironmentInstance.GetEnvironmentVariable(Constants.PINECONEENDPOINT);
            Environment = environment ?? EnvironmentInstance.GetEnvironmentVariable(Constants.PINECONEENV);
            ProjectName = projectName ?? EnvironmentInstance.GetEnvironmentVariable(Constants.PINECONEPROJECT);
        }

        /// <summary>
        /// Inherited method
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>
            {
                { Constants.APIKEY, ApiKey },
                { Constants.ENDPOINT, Endpoint },
                { Constants.PROJECTNAME, ProjectName },
                { Constants.ENVIRONMENT, Environment }
            };
        }
    }
}