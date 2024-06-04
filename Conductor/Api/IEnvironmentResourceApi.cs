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
using Conductor.Client;
using System;
using System.Collections.Generic;

namespace Conductor.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IEnvironmentResourceApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Create or update an environment variable (requires metadata or admin role)
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        void CreateOrUpdateEnvVariable(string body, string key);

        /// <summary>
        /// Create or update an environment variable (requires metadata or admin role)
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="key"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> CreateOrUpdateEnvVariableWithHttpInfo(string body, string key);
        /// <summary>
        /// Delete an environment variable (requires metadata or admin role)
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="key"></param>
        /// <returns>string</returns>
        string DeleteEnvVariable(string key);

        /// <summary>
        /// Delete an environment variable (requires metadata or admin role)
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="key"></param>
        /// <returns>ApiResponse of string</returns>
        ApiResponse<string> DeleteEnvVariableWithHttpInfo(string key);
        /// <summary>
        /// Get the environment value by key
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="key"></param>
        /// <returns>string</returns>
        string Get1(string key);

        /// <summary>
        /// Get the environment value by key
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="key"></param>
        /// <returns>ApiResponse of string</returns>
        ApiResponse<string> Get1WithHttpInfo(string key);
        /// <summary>
        /// List all the environment variables
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Dictionary&lt;string, string&gt;</returns>
        Dictionary<string, string> GetAll();

        /// <summary>
        /// List all the environment variables
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Dictionary&lt;string, string&gt;</returns>
        ApiResponse<Dictionary<string, string>> GetAllWithHttpInfo();
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Create or update an environment variable (requires metadata or admin role)
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="key"></param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task CreateOrUpdateEnvVariableAsync(string body, string key);

        /// <summary>
        /// Create or update an environment variable (requires metadata or admin role)
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="key"></param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> CreateOrUpdateEnvVariableAsyncWithHttpInfo(string body, string key);
        /// <summary>
        /// Delete an environment variable (requires metadata or admin role)
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="key"></param>
        /// <returns>Task of string</returns>
        System.Threading.Tasks.Task<string> DeleteEnvVariableAsync(string key);

        /// <summary>
        /// Delete an environment variable (requires metadata or admin role)
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="key"></param>
        /// <returns>Task of ApiResponse (string)</returns>
        System.Threading.Tasks.Task<ApiResponse<string>> DeleteEnvVariableAsyncWithHttpInfo(string key);
        /// <summary>
        /// Get the environment value by key
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="key"></param>
        /// <returns>Task of string</returns>
        System.Threading.Tasks.Task<string> Get1Async(string key);

        /// <summary>
        /// Get the environment value by key
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="key"></param>
        /// <returns>Task of ApiResponse (string)</returns>
        System.Threading.Tasks.Task<ApiResponse<string>> Get1AsyncWithHttpInfo(string key);
        /// <summary>
        /// List all the environment variables
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of Dictionary&lt;string, string&gt;</returns>
        System.Threading.Tasks.Task<Dictionary<string, string>> GetAllAsync();

        /// <summary>
        /// List all the environment variables
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (Dictionary&lt;string, string&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<Dictionary<string, string>>> GetAllAsyncWithHttpInfo();
        #endregion Asynchronous Operations
    }
}
