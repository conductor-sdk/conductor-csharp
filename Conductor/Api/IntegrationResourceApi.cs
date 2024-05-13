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
using Conductor.Client.Models;
using conductor_csharp.Api;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Conductor.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class IntegrationResourceApi : IIntegrationResourceApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegrationResourceApi"/> class.
        /// </summary>
        /// <returns></returns>
        public IntegrationResourceApi(string basePath)
        {
            this.Configuration = new Conductor.Client.Configuration { BasePath = basePath };

            ExceptionFactory = Conductor.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegrationResourceApi"/> class
        /// </summary>
        /// <returns></returns>
        public IntegrationResourceApi()
        {
            this.Configuration = Conductor.Client.Configuration.Default;

            ExceptionFactory = Conductor.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegrationResourceApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public IntegrationResourceApi(Conductor.Client.Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = Conductor.Client.Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = Conductor.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.Options.BaseUrl.ToString();
        }


        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Conductor.Client.Configuration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public Conductor.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Associate a Prompt Template with an Integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="integrationProvider"></param>
        /// <param name="integrationName"></param>
        /// <param name="promptName"></param>
        /// <returns></returns>
        public void AssociatePromptWithIntegration(string integrationProvider, string integrationName, string promptName)
        {
            AssociatePromptWithIntegrationWithHttpInfo(integrationProvider, integrationName, promptName);
        }

        /// <summary>
        /// Associate a Prompt Template with an Integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="integrationProvider"></param>
        /// <param name="integrationName"></param>
        /// <param name="promptName"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> AssociatePromptWithIntegrationWithHttpInfo(string integrationProvider, string integrationName, string promptName)
        {
            // verify the required parameter 'integrationProvider' is set
            if (integrationProvider == null)
                throw new ApiException(400, "Missing required parameter 'integrationProvider' when calling IntegrationResourceApi->AssociatePromptWithIntegration");
            // verify the required parameter 'integrationName' is set
            if (integrationName == null)
                throw new ApiException(400, "Missing required parameter 'integrationName' when calling IntegrationResourceApi->AssociatePromptWithIntegration");
            // verify the required parameter 'promptName' is set
            if (promptName == null)
                throw new ApiException(400, "Missing required parameter 'promptName' when calling IntegrationResourceApi->AssociatePromptWithIntegration");

            var localVarPath = "/integrations/provider/{integration_provider}/integration/{integration_name}/prompt/{prompt_name}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (integrationProvider != null) localVarPathParams.Add("integration_provider", this.Configuration.ApiClient.ParameterToString(integrationProvider)); // path parameter
            if (integrationName != null) localVarPathParams.Add("integration_name", this.Configuration.ApiClient.ParameterToString(integrationName)); // path parameter
            if (promptName != null) localVarPathParams.Add("prompt_name", this.Configuration.ApiClient.ParameterToString(promptName)); // path parameter
                                                                                                                                       // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
            Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType, this.Configuration);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("AssociatePromptWithIntegration", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)), null);
        }

        /// <summary>
        /// Associate a Prompt Template with an Integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="integrationProvider"></param>
        /// <param name="integrationName"></param>
        /// <param name="promptName"></param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task AssociatePromptWithIntegrationAsync(string integrationProvider, string integrationName, string promptName)
        {
            await AssociatePromptWithIntegrationAsyncWithHttpInfo(integrationProvider, integrationName, promptName);

        }

        /// <summary>
        /// Associate a Prompt Template with an Integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="integrationProvider"></param>
        /// <param name="integrationName"></param>
        /// <param name="promptName"></param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<object>> AssociatePromptWithIntegrationAsyncWithHttpInfo(string integrationProvider, string integrationName, string promptName)
        {
            // verify the required parameter 'integrationProvider' is set
            if (integrationProvider == null)
                throw new ApiException(400, "Missing required parameter 'integrationProvider' when calling IntegrationResourceApi->AssociatePromptWithIntegration");
            // verify the required parameter 'integrationName' is set
            if (integrationName == null)
                throw new ApiException(400, "Missing required parameter 'integrationName' when calling IntegrationResourceApi->AssociatePromptWithIntegration");
            // verify the required parameter 'promptName' is set
            if (promptName == null)
                throw new ApiException(400, "Missing required parameter 'promptName' when calling IntegrationResourceApi->AssociatePromptWithIntegration");

            var localVarPath = "/integrations/provider/{integration_provider}/integration/{integration_name}/prompt/{prompt_name}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (integrationProvider != null) localVarPathParams.Add("integration_provider", this.Configuration.ApiClient.ParameterToString(integrationProvider)); // path parameter
            if (integrationName != null) localVarPathParams.Add("integration_name", this.Configuration.ApiClient.ParameterToString(integrationName)); // path parameter
            if (promptName != null) localVarPathParams.Add("prompt_name", this.Configuration.ApiClient.ParameterToString(promptName)); // path parameter
                                                                                                                                       // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
            Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("AssociatePromptWithIntegration", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            null);
        }

        /// <summary>
        /// Delete an Integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns></returns>
        public void DeleteIntegrationApi(string name, string integrationName)
        {
            DeleteIntegrationApiWithHttpInfo(name, integrationName);
        }

        /// <summary>
        /// Delete an Integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> DeleteIntegrationApiWithHttpInfo(string name, string integrationName)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->DeleteIntegrationApi");
            // verify the required parameter 'integrationName' is set
            if (integrationName == null)
                throw new ApiException(400, "Missing required parameter 'integrationName' when calling IntegrationResourceApi->DeleteIntegrationApi");

            var localVarPath = "/integrations/provider/{name}/integration/{integration_name}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (integrationName != null) localVarPathParams.Add("integration_name", this.Configuration.ApiClient.ParameterToString(integrationName)); // path parameter
                                                                                                                                                      // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
            Method.Delete, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType, Configuration);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("DeleteIntegrationApi", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            null);
        }

        /// <summary>
        /// Delete an Integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteIntegrationApiAsync(string name, string integrationName)
        {
            await DeleteIntegrationApiAsyncWithHttpInfo(name, integrationName);

        }

        /// <summary>
        /// Delete an Integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<object>> DeleteIntegrationApiAsyncWithHttpInfo(string name, string integrationName)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->DeleteIntegrationApi");
            // verify the required parameter 'integrationName' is set
            if (integrationName == null)
                throw new ApiException(400, "Missing required parameter 'integrationName' when calling IntegrationResourceApi->DeleteIntegrationApi");

            var localVarPath = "/integrations/provider/{name}/integration/{integration_name}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (integrationName != null) localVarPathParams.Add("integration_name", this.Configuration.ApiClient.ParameterToString(integrationName)); // path parameter
                                                                                                                                                      // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
            Method.Delete, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("DeleteIntegrationApi", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            null);
        }

        /// <summary>
        /// Delete an Integration Provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns></returns>
        public void DeleteIntegrationProvider(string name)
        {
            DeleteIntegrationProviderWithHttpInfo(name);
        }

        /// <summary>
        /// Delete an Integration Provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> DeleteIntegrationProviderWithHttpInfo(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->DeleteIntegrationProvider");

            var localVarPath = "/integrations/provider/{name}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
                                                                                                                    // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
            Method.Delete, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType, Configuration);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("DeleteIntegrationProvider", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            null);
        }

        /// <summary>
        /// Delete an Integration Provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteIntegrationProviderAsync(string name)
        {
            await DeleteIntegrationProviderAsyncWithHttpInfo(name);

        }

        /// <summary>
        /// Delete an Integration Provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<object>> DeleteIntegrationProviderAsyncWithHttpInfo(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->DeleteIntegrationProvider");

            var localVarPath = "/integrations/provider/{name}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
                                                                                                                    // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
            Method.Delete, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("DeleteIntegrationProvider", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            null);
        }

        /// <summary>
        /// Delete a tag for Integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">The list of tags to be deleted.</param>
        /// <param name="name">The name of the integration associated with the tag</param>
        /// <param name="integrationName">The name of the model associated with the tag.</param>
        /// <returns></returns>
        public void DeleteTagForIntegration(List<Tag> body, string name, string integrationName)
        {
            DeleteTagForIntegrationWithHttpInfo(body, name, integrationName);
        }

        /// <summary>
        /// Delete a tag for Integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">The list of tags to be deleted.</param>
        /// <param name="name">The name of the integration associated with the tag</param>
        /// <param name="integrationName">The name of the model associated with the tag.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> DeleteTagForIntegrationWithHttpInfo(List<Tag> body, string name, string integrationName)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling IntegrationResourceApi->DeleteTagForIntegration");
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->DeleteTagForIntegration");
            // verify the required parameter 'integrationName' is set
            if (integrationName == null)
                throw new ApiException(400, "Missing required parameter 'integrationName' when calling IntegrationResourceApi->DeleteTagForIntegration");

            var localVarPath = "/integrations/provider/{name}/integration/{integration_name}/tags";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { "application/json" };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (integrationName != null) localVarPathParams.Add("integration_name", this.Configuration.ApiClient.ParameterToString(integrationName)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
            Method.Delete, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType, Configuration);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("DeleteTagForIntegration", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            null);
        }

        /// <summary>
        /// Delete a tag for Integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">The list of tags to be deleted.</param>
        /// <param name="name">The name of the integration associated with the tag</param>
        /// <param name="integrationName">The name of the model associated with the tag.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteTagForIntegrationAsync(List<Tag> body, string name, string integrationName)
        {
            await DeleteTagForIntegrationAsyncWithHttpInfo(body, name, integrationName);

        }

        /// <summary>
        /// Delete a tag for Integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">The list of tags to be deleted.</param>
        /// <param name="name">The name of the integration associated with the tag</param>
        /// <param name="integrationName">The name of the model associated with the tag.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<object>> DeleteTagForIntegrationAsyncWithHttpInfo(List<Tag> body, string name, string integrationName)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling IntegrationResourceApi->DeleteTagForIntegration");
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->DeleteTagForIntegration");
            // verify the required parameter 'integrationName' is set
            if (integrationName == null)
                throw new ApiException(400, "Missing required parameter 'integrationName' when calling IntegrationResourceApi->DeleteTagForIntegration");

            var localVarPath = "/integrations/provider/{name}/integration/{integration_name}/tags";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { "application/json" };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (integrationName != null) localVarPathParams.Add("integration_name", this.Configuration.ApiClient.ParameterToString(integrationName)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
            Method.Delete, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("DeleteTagForIntegration", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            null);
        }

        /// <summary>
        /// Delete a tag for Integration Provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">The list of tags to be deleted.</param>
        /// <param name="name">The name of the integration associated with the tag</param>
        /// <returns></returns>
        public void DeleteTagForIntegrationProvider(List<Tag> body, string name)
        {
            DeleteTagForIntegrationProviderWithHttpInfo(body, name);
        }

        /// <summary>
        /// Delete a tag for Integration Provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">The list of tags to be deleted.</param>
        /// <param name="name">The name of the integration associated with the tag</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> DeleteTagForIntegrationProviderWithHttpInfo(List<Tag> body, string name)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling IntegrationResourceApi->DeleteTagForIntegrationProvider");
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->DeleteTagForIntegrationProvider");

            var localVarPath = "/integrations/provider/{name}/tags";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { "application/json" };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
            Method.Delete, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType, Configuration);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("DeleteTagForIntegrationProvider", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            null);
        }

        /// <summary>
        /// Delete a tag for Integration Provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">The list of tags to be deleted.</param>
        /// <param name="name">The name of the integration associated with the tag</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteTagForIntegrationProviderAsync(List<Tag> body, string name)
        {
            await DeleteTagForIntegrationProviderAsyncWithHttpInfo(body, name);

        }

        /// <summary>
        /// Delete a tag for Integration Provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">The list of tags to be deleted.</param>
        /// <param name="name">The name of the integration associated with the tag</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<object>> DeleteTagForIntegrationProviderAsyncWithHttpInfo(List<Tag> body, string name)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling IntegrationResourceApi->DeleteTagForIntegrationProvider");
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->DeleteTagForIntegrationProvider");

            var localVarPath = "/integrations/provider/{name}/tags";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { "application/json" };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
            Method.Delete, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("DeleteTagForIntegrationProvider", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            null);
        }

        /// <summary>
        /// Get Integration details
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>IntegrationApi</returns>
        public IntegrationApi GetIntegrationApi(string name, string integrationName)
        {
            ApiResponse<IntegrationApi> localVarResponse = GetIntegrationApiWithHttpInfo(name, integrationName);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Integration details
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>ApiResponse of IntegrationApi</returns>
        public ApiResponse<IntegrationApi> GetIntegrationApiWithHttpInfo(string name, string integrationName)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->GetIntegrationApi");
            // verify the required parameter 'integrationName' is set
            if (integrationName == null)
                throw new ApiException(400, "Missing required parameter 'integrationName' when calling IntegrationResourceApi->GetIntegrationApi");

            var localVarPath = "/integrations/provider/{name}/integration/{integration_name}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { "application/json" };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (integrationName != null) localVarPathParams.Add("integration_name", this.Configuration.ApiClient.ParameterToString(integrationName)); // path parameter
                                                                                                                                                      // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
            Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType, Configuration);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetIntegrationApi", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<IntegrationApi>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            (IntegrationApi)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(IntegrationApi)));
        }

        /// <summary>
        /// Get Integration details
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>Task of IntegrationApi</returns>
        public async System.Threading.Tasks.Task<IntegrationApi> GetIntegrationApiAsync(string name, string integrationName)
        {
            ApiResponse<IntegrationApi> localVarResponse = await GetIntegrationApiAsyncWithHttpInfo(name, integrationName);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Get Integration details
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>Task of ApiResponse (IntegrationApi)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<IntegrationApi>> GetIntegrationApiAsyncWithHttpInfo(string name, string integrationName)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->GetIntegrationApi");
            // verify the required parameter 'integrationName' is set
            if (integrationName == null)
                throw new ApiException(400, "Missing required parameter 'integrationName' when calling IntegrationResourceApi->GetIntegrationApi");

            var localVarPath = "/integrations/provider/{name}/integration/{integration_name}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { "application/json" };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (integrationName != null) localVarPathParams.Add("integration_name", this.Configuration.ApiClient.ParameterToString(integrationName)); // path parameter
                                                                                                                                                      // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
            Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetIntegrationApi", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<IntegrationApi>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            (IntegrationApi)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(IntegrationApi)));
        }

        /// <summary>
        /// Get Integrations of an Integration Provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="activeOnly"> (optional, default to true)</param>
        /// <returns>List<IntegrationApi></returns>
        public List<IntegrationApi> GetIntegrationApis(string name, bool? activeOnly = null)
        {
            ApiResponse<List<IntegrationApi>> localVarResponse = GetIntegrationApisWithHttpInfo(name, activeOnly);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Integrations of an Integration Provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="activeOnly"> (optional, default to true)</param>
        /// <returns>ApiResponse of List<IntegrationApi></returns>
        public ApiResponse<List<IntegrationApi>> GetIntegrationApisWithHttpInfo(string name, bool? activeOnly = null)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->GetIntegrationApis");

            var localVarPath = "/integrations/provider/{name}/integration";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { "application/json" };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (activeOnly != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "activeOnly", activeOnly)); // query parameter
                                                                                                                                                       // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
            Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType, Configuration);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetIntegrationApis", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<IntegrationApi>>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            (List<IntegrationApi>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<IntegrationApi>)));
        }

        /// <summary>
        /// Get Integrations of an Integration Provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="activeOnly"> (optional, default to true)</param>
        /// <returns>Task of List<IntegrationApi></returns>
        public async System.Threading.Tasks.Task<List<IntegrationApi>> GetIntegrationApisAsync(string name, bool? activeOnly = null)
        {
            ApiResponse<List<IntegrationApi>> localVarResponse = await GetIntegrationApisAsyncWithHttpInfo(name, activeOnly);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Get Integrations of an Integration Provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="activeOnly"> (optional, default to true)</param>
        /// <returns>Task of ApiResponse (List<IntegrationApi>)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<IntegrationApi>>> GetIntegrationApisAsyncWithHttpInfo(string name, bool? activeOnly = null)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->GetIntegrationApis");

            var localVarPath = "/integrations/provider/{name}/integration";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { "application/json" };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (activeOnly != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "activeOnly", activeOnly)); // query parameter
                                                                                                                                                       // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
            Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetIntegrationApis", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<IntegrationApi>>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            (List<IntegrationApi>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<IntegrationApi>)));
        }

        /// <summary>
        /// Get Integrations Available for an Integration Provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>List<string></returns>
        public List<string> GetIntegrationAvailableApis(string name)
        {
            ApiResponse<List<string>> localVarResponse = GetIntegrationAvailableApisWithHttpInfo(name);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Integrations Available for an Integration Provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>ApiResponse of List<string></returns>
        public ApiResponse<List<string>> GetIntegrationAvailableApisWithHttpInfo(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->GetIntegrationAvailableApis");

            var localVarPath = "/integrations/provider/{name}/integration/all";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { "application/json" };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
                                                                                                                    // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
            Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType, Configuration);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetIntegrationAvailableApis", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<string>>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            (List<string>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<string>)));
        }

        /// <summary>
        /// Get Integrations Available for an Integration Provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of List<string></returns>
        public async System.Threading.Tasks.Task<List<string>> GetIntegrationAvailableApisAsync(string name)
        {
            ApiResponse<List<string>> localVarResponse = await GetIntegrationAvailableApisAsyncWithHttpInfo(name);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Get Integrations Available for an Integration Provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of ApiResponse (List<string>)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<string>>> GetIntegrationAvailableApisAsyncWithHttpInfo(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->GetIntegrationAvailableApis");

            var localVarPath = "/integrations/provider/{name}/integration/all";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { "application/json" };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
                                                                                                                    // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
            Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetIntegrationAvailableApis", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<string>>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            (List<string>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<string>)));
        }

        /// <summary>
        /// Get Integration provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Integration</returns>
        public Integration GetIntegrationProvider(string name)
        {
            ApiResponse<Integration> localVarResponse = GetIntegrationProviderWithHttpInfo(name);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Integration provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>ApiResponse of Integration</returns>
        public ApiResponse<Integration> GetIntegrationProviderWithHttpInfo(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->GetIntegrationProvider");

            var localVarPath = "/integrations/provider/{name}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { "application/json" };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
                                                                                                                    // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
            Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType, Configuration);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetIntegrationProvider", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Integration>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            (Integration)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Integration)));
        }

        /// <summary>
        /// Get Integration provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of Integration</returns>
        public async System.Threading.Tasks.Task<Integration> GetIntegrationProviderAsync(string name)
        {
            ApiResponse<Integration> localVarResponse = await GetIntegrationProviderAsyncWithHttpInfo(name);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Get Integration provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of ApiResponse (Integration)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Integration>> GetIntegrationProviderAsyncWithHttpInfo(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->GetIntegrationProvider");

            var localVarPath = "/integrations/provider/{name}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { "application/json" };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
                                                                                                                    // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
            Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetIntegrationProvider", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Integration>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            (Integration)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Integration)));
        }

        /// <summary>
        /// Get Integration provider definitions
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List<IntegrationDef></returns>
        public List<IntegrationDef> GetIntegrationProviderDefs()
        {
            ApiResponse<List<IntegrationDef>> localVarResponse = GetIntegrationProviderDefsWithHttpInfo();
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Integration provider definitions
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List<IntegrationDef></returns>
        public ApiResponse<List<IntegrationDef>> GetIntegrationProviderDefsWithHttpInfo()
        {

            var localVarPath = "/integrations/def";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { "application/json" };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
            Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType, Configuration);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetIntegrationProviderDefs", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<IntegrationDef>>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            (List<IntegrationDef>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<IntegrationDef>)));
        }

        /// <summary>
        /// Get Integration provider definitions
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List<IntegrationDef></returns>
        public async System.Threading.Tasks.Task<List<IntegrationDef>> GetIntegrationProviderDefsAsync()
        {
            ApiResponse<List<IntegrationDef>> localVarResponse = await GetIntegrationProviderDefsAsyncWithHttpInfo();
            return localVarResponse.Data;

        }

        /// <summary>
        /// Get Integration provider definitions
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (List<IntegrationDef>)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<IntegrationDef>>> GetIntegrationProviderDefsAsyncWithHttpInfo()
        {

            var localVarPath = "/integrations/def";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { "application/json" };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
            Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetIntegrationProviderDefs", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<IntegrationDef>>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            (List<IntegrationDef>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<IntegrationDef>)));
        }

        /// <summary>
        /// Get all Integrations Providers
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="category"> (optional)</param>
        /// <param name="activeOnly"> (optional, default to true)</param>
        /// <returns>List<Integration></returns>
        public List<Integration> GetIntegrationProviders(string category = null, bool? activeOnly = null)
        {
            ApiResponse<List<Integration>> localVarResponse = GetIntegrationProvidersWithHttpInfo(category, activeOnly);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get all Integrations Providers
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="category"> (optional)</param>
        /// <param name="activeOnly"> (optional, default to true)</param>
        /// <returns>ApiResponse of List<Integration></returns>
        public ApiResponse<List<Integration>> GetIntegrationProvidersWithHttpInfo(string category = null, bool? activeOnly = null)
        {

            var localVarPath = "/integrations/provider";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { "application/json" };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (category != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "category", category)); // query parameter
            if (activeOnly != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "activeOnly", activeOnly)); // query parameter
                                                                                                                                                       // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
            Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType, Configuration);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetIntegrationProviders", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<Integration>>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            (List<Integration>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Integration>)));
        }

        /// <summary>
        /// Get all Integrations Providers
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="category"> (optional)</param>
        /// <param name="activeOnly"> (optional, default to true)</param>
        /// <returns>Task of List<Integration></returns>
        public async System.Threading.Tasks.Task<List<Integration>> GetIntegrationProvidersAsync(string category = null, bool? activeOnly = null)
        {
            ApiResponse<List<Integration>> localVarResponse = await GetIntegrationProvidersAsyncWithHttpInfo(category, activeOnly);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Get all Integrations Providers
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="category"> (optional)</param>
        /// <param name="activeOnly"> (optional, default to true)</param>
        /// <returns>Task of ApiResponse (List<Integration>)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<Integration>>> GetIntegrationProvidersAsyncWithHttpInfo(string category = null, bool? activeOnly = null)
        {

            var localVarPath = "/integrations/provider";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { "application/json" };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (category != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "category", category)); // query parameter
            if (activeOnly != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "activeOnly", activeOnly)); // query parameter
                                                                                                                                                       // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
            Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetIntegrationProviders", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<Integration>>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            (List<Integration>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Integration>)));
        }

        /// <summary>
        /// Get the list of prompt templates associated with an integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="integrationProvider"></param>
        /// <param name="integrationName"></param>
        /// <returns>List<MessageTemplate></returns>
        public List<MessageTemplate> GetPromptsWithIntegration(string integrationProvider, string integrationName)
        {
            ApiResponse<List<MessageTemplate>> localVarResponse = GetPromptsWithIntegrationWithHttpInfo(integrationProvider, integrationName);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get the list of prompt templates associated with an integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="integrationProvider"></param>
        /// <param name="integrationName"></param>
        /// <returns>ApiResponse of List<MessageTemplate></returns>
        public ApiResponse<List<MessageTemplate>> GetPromptsWithIntegrationWithHttpInfo(string integrationProvider, string integrationName)
        {
            // verify the required parameter 'integrationProvider' is set
            if (integrationProvider == null)
                throw new ApiException(400, "Missing required parameter 'integrationProvider' when calling IntegrationResourceApi->GetPromptsWithIntegration");
            // verify the required parameter 'integrationName' is set
            if (integrationName == null)
                throw new ApiException(400, "Missing required parameter 'integrationName' when calling IntegrationResourceApi->GetPromptsWithIntegration");

            var localVarPath = "/integrations/provider/{integration_provider}/integration/{integration_name}/prompt";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { "application/json" };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (integrationProvider != null) localVarPathParams.Add("integration_provider", this.Configuration.ApiClient.ParameterToString(integrationProvider)); // path parameter
            if (integrationName != null) localVarPathParams.Add("integration_name", this.Configuration.ApiClient.ParameterToString(integrationName)); // path parameter
                                                                                                                                                      // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
            Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType, Configuration);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetPromptsWithIntegration", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<MessageTemplate>>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            (List<MessageTemplate>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<MessageTemplate>)));
        }

        /// <summary>
        /// Get the list of prompt templates associated with an integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="integrationProvider"></param>
        /// <param name="integrationName"></param>
        /// <returns>Task of List<MessageTemplate></returns>
        public async System.Threading.Tasks.Task<List<MessageTemplate>> GetPromptsWithIntegrationAsync(string integrationProvider, string integrationName)
        {
            ApiResponse<List<MessageTemplate>> localVarResponse = await GetPromptsWithIntegrationAsyncWithHttpInfo(integrationProvider, integrationName);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Get the list of prompt templates associated with an integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="integrationProvider"></param>
        /// <param name="integrationName"></param>
        /// <returns>Task of ApiResponse (List<MessageTemplate>)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<MessageTemplate>>> GetPromptsWithIntegrationAsyncWithHttpInfo(string integrationProvider, string integrationName)
        {
            // verify the required parameter 'integrationProvider' is set
            if (integrationProvider == null)
                throw new ApiException(400, "Missing required parameter 'integrationProvider' when calling IntegrationResourceApi->GetPromptsWithIntegration");
            // verify the required parameter 'integrationName' is set
            if (integrationName == null)
                throw new ApiException(400, "Missing required parameter 'integrationName' when calling IntegrationResourceApi->GetPromptsWithIntegration");

            var localVarPath = "/integrations/provider/{integration_provider}/integration/{integration_name}/prompt";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { "application/json" };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (integrationProvider != null) localVarPathParams.Add("integration_provider", this.Configuration.ApiClient.ParameterToString(integrationProvider)); // path parameter
            if (integrationName != null) localVarPathParams.Add("integration_name", this.Configuration.ApiClient.ParameterToString(integrationName)); // path parameter
                                                                                                                                                      // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
            Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetPromptsWithIntegration", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<MessageTemplate>>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            (List<MessageTemplate>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<MessageTemplate>)));
        }

        /// <summary>
        /// Get Integrations Providers and Integrations combo
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="type"> (optional)</param>
        /// <param name="activeOnly"> (optional, default to true)</param>
        /// <returns>List<string></returns>
        public List<string> GetProvidersAndIntegrations(string type = null, bool? activeOnly = null)
        {
            ApiResponse<List<string>> localVarResponse = GetProvidersAndIntegrationsWithHttpInfo(type, activeOnly);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Integrations Providers and Integrations combo
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="type"> (optional)</param>
        /// <param name="activeOnly"> (optional, default to true)</param>
        /// <returns>ApiResponse of List<string></returns>
        public ApiResponse<List<string>> GetProvidersAndIntegrationsWithHttpInfo(string type = null, bool? activeOnly = null)
        {

            var localVarPath = "/integrations/all";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { " application/json " };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (type != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "type", type)); // query parameter
            if (activeOnly != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "activeOnly", activeOnly)); // query parameter
                                                                                                                                                       // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
            Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType, Configuration);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetProvidersAndIntegrations", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<string>>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            (List<string>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<string>)));
        }

        /// <summary>
        /// Get Integrations Providers and Integrations combo
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="type"> (optional)</param>
        /// <param name="activeOnly"> (optional, default to true)</param>
        /// <returns>Task of List<string></returns>
        public async System.Threading.Tasks.Task<List<string>> GetProvidersAndIntegrationsAsync(string type = null, bool? activeOnly = null)
        {
            ApiResponse<List<string>> localVarResponse = await GetProvidersAndIntegrationsAsyncWithHttpInfo(type, activeOnly);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Get Integrations Providers and Integrations combo
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="type"> (optional)</param>
        /// <param name="activeOnly"> (optional, default to true)</param>
        /// <returns>Task of ApiResponse (List<string>)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<string>>> GetProvidersAndIntegrationsAsyncWithHttpInfo(string type = null, bool? activeOnly = null)
        {

            var localVarPath = "/integrations/all";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { "application/json" };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (type != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "type", type)); // query parameter
            if (activeOnly != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "activeOnly", activeOnly)); // query parameter
                                                                                                                                                       // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
            Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetProvidersAndIntegrations", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<string>>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            (List<string>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<string>)));
        }

        /// <summary>
        /// Get tags by Integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>List<Tag></returns>
        public List<Tag> GetTagsForIntegration(string name, string integrationName)
        {
            ApiResponse<List<Tag>> localVarResponse = GetTagsForIntegrationWithHttpInfo(name, integrationName);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get tags by Integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>ApiResponse of List<Tag></returns>
        public ApiResponse<List<Tag>> GetTagsForIntegrationWithHttpInfo(string name, string integrationName)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->GetTagsForIntegration");
            // verify the required parameter 'integrationName' is set
            if (integrationName == null)
                throw new ApiException(400, "Missing required parameter 'integrationName' when calling IntegrationResourceApi->GetTagsForIntegration");

            var localVarPath = "/integrations/provider/{name}/integration/{integration_name}/tags";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { "application/json" };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (integrationName != null) localVarPathParams.Add("integration_name", this.Configuration.ApiClient.ParameterToString(integrationName)); // path parameter
                                                                                                                                                      // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
            Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType, Configuration);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetTagsForIntegration", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<Tag>>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            (List<Tag>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Tag>)));
        }

        /// <summary>
        /// Get tags by Integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>Task of List<Tag></returns>
        public async System.Threading.Tasks.Task<List<Tag>> GetTagsForIntegrationAsync(string name, string integrationName)
        {
            ApiResponse<List<Tag>> localVarResponse = await GetTagsForIntegrationAsyncWithHttpInfo(name, integrationName);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Get tags by Integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>Task of ApiResponse (List<Tag>)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<Tag>>> GetTagsForIntegrationAsyncWithHttpInfo(string name, string integrationName)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->GetTagsForIntegration");
            // verify the required parameter 'integrationName' is set
            if (integrationName == null)
                throw new ApiException(400, "Missing required parameter 'integrationName' when calling IntegrationResourceApi->GetTagsForIntegration");

            var localVarPath = "/integrations/provider/{name}/integration/{integration_name}/tags";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { "application/json" };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (integrationName != null) localVarPathParams.Add("integration_name", this.Configuration.ApiClient.ParameterToString(integrationName)); // path parameter
                                                                                                                                                      // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
            Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetTagsForIntegration", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<Tag>>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            (List<Tag>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Tag>)));
        }

        /// <summary>
        /// Get tags by Integration Provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>List<Tag></returns>
        public List<Tag> GetTagsForIntegrationProvider(string name)
        {
            ApiResponse<List<Tag>> localVarResponse = GetTagsForIntegrationProviderWithHttpInfo(name);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get tags by Integration Provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>ApiResponse of List<Tag></returns>
        public ApiResponse<List<Tag>> GetTagsForIntegrationProviderWithHttpInfo(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->GetTagsForIntegrationProvider");

            var localVarPath = "/integrations/provider/{name}/tags";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { "application/json" };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
                                                                                                                    // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
            Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType, Configuration);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetTagsForIntegrationProvider", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<Tag>>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            (List<Tag>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Tag>)));
        }

        /// <summary>
        /// Get tags by Integration Provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of List<Tag></returns>
        public async System.Threading.Tasks.Task<List<Tag>> GetTagsForIntegrationProviderAsync(string name)
        {
            ApiResponse<List<Tag>> localVarResponse = await GetTagsForIntegrationProviderAsyncWithHttpInfo(name);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Get tags by Integration Provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of ApiResponse (List<Tag>)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<Tag>>> GetTagsForIntegrationProviderAsyncWithHttpInfo(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->GetTagsForIntegrationProvider");

            var localVarPath = "/integrations/provider/{name}/tags";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { "application/json" };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
                                                                                                                    // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
            Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetTagsForIntegrationProvider", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<Tag>>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            (List<Tag>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Tag>)));
        }

        /// <summary>
        /// Get Token Usage by Integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>int?</returns>
        public int? GetTokenUsageForIntegration(string name, string integrationName)
        {
            ApiResponse<int?> localVarResponse = GetTokenUsageForIntegrationWithHttpInfo(name, integrationName);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Token Usage by Integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>ApiResponse of int?</returns>
        public ApiResponse<int?> GetTokenUsageForIntegrationWithHttpInfo(string name, string integrationName)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->GetTokenUsageForIntegration");
            // verify the required parameter 'integrationName' is set
            if (integrationName == null)
                throw new ApiException(400, "Missing required parameter 'integrationName' when calling IntegrationResourceApi->GetTokenUsageForIntegration");

            var localVarPath = "/integrations/provider/{name}/integration/{integration_name}/metrics";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { "application/json" };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (integrationName != null) localVarPathParams.Add("integration_name", this.Configuration.ApiClient.ParameterToString(integrationName)); // path parameter
                                                                                                                                                      // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
            Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType, Configuration);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetTokenUsageForIntegration", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<int?>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            (int?)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(int?)));
        }

        /// <summary>
        /// Get Token Usage by Integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>Task of int?</returns>
        public async System.Threading.Tasks.Task<int?> GetTokenUsageForIntegrationAsync(string name, string integrationName)
        {
            ApiResponse<int?> localVarResponse = await GetTokenUsageForIntegrationAsyncWithHttpInfo(name, integrationName);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Get Token Usage by Integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>Task of ApiResponse (int?)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<int?>> GetTokenUsageForIntegrationAsyncWithHttpInfo(string name, string integrationName)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->GetTokenUsageForIntegration");
            // verify the required parameter 'integrationName' is set
            if (integrationName == null)
                throw new ApiException(400, "Missing required parameter 'integrationName' when calling IntegrationResourceApi->GetTokenUsageForIntegration");

            var localVarPath = "/integrations/provider/{name}/integration/{integration_name}/metrics";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { "application/json" };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (integrationName != null) localVarPathParams.Add("integration_name", this.Configuration.ApiClient.ParameterToString(integrationName)); // path parameter
                                                                                                                                                      // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
            Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetTokenUsageForIntegration", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<int?>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            (int?)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(int?)));
        }

        /// <summary>
        /// Get Token Usage by Integration Provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Dictionary<string, string></returns>
        public Dictionary<string, string> GetTokenUsageForIntegrationProvider(string name)
        {
            ApiResponse<Dictionary<string, string>> localVarResponse = GetTokenUsageForIntegrationProviderWithHttpInfo(name);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Token Usage by Integration Provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>ApiResponse of Dictionary<string, string></returns>
        public ApiResponse<Dictionary<string, string>> GetTokenUsageForIntegrationProviderWithHttpInfo(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->GetTokenUsageForIntegrationProvider");

            var localVarPath = "/integrations/provider/{name}/metrics";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { "application/json" };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
                                                                                                                    // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
            Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType, Configuration);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetTokenUsageForIntegrationProvider", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Dictionary<string, string>>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            (Dictionary<string, string>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Dictionary<string, string>)));
        }

        /// <summary>
        /// Get Token Usage by Integration Provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of Dictionary<string, string></returns>
        public async System.Threading.Tasks.Task<Dictionary<string, string>> GetTokenUsageForIntegrationProviderAsync(string name)
        {
            ApiResponse<Dictionary<string, string>> localVarResponse = await GetTokenUsageForIntegrationProviderAsyncWithHttpInfo(name);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Get Token Usage by Integration Provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of ApiResponse (Dictionary<string, string>)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Dictionary<string, string>>> GetTokenUsageForIntegrationProviderAsyncWithHttpInfo(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->GetTokenUsageForIntegrationProvider");

            var localVarPath = "/integrations/provider/{name}/metrics";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { "application/json" };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
                                                                                                                    // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
            Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetTokenUsageForIntegrationProvider", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Dictionary<string, string>>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            (Dictionary<string, string>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Dictionary<string, string>)));
        }

        /// <summary>
        /// Put a tag to Integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">The list of tags to be updated.</param>
        /// <param name="name">The name of the integration to associate the tag with.</param>
        /// <param name="integrationName">The name of the model to associate the tag with.</param>
        /// <returns></returns>
        public void PutTagForIntegration(List<Tag> body, string name, string integrationName)
        {
            PutTagForIntegrationWithHttpInfo(body, name, integrationName);
        }

        /// <summary>
        /// Put a tag to Integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">The list of tags to be updated.</param>
        /// <param name="name">The name of the integration to associate the tag with.</param>
        /// <param name="integrationName">The name of the model to associate the tag with.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> PutTagForIntegrationWithHttpInfo(List<Tag> body, string name, string integrationName)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling IntegrationResourceApi->PutTagForIntegration");
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->PutTagForIntegration");
            // verify the required parameter 'integrationName' is set
            if (integrationName == null)
                throw new ApiException(400, "Missing required parameter 'integrationName' when calling IntegrationResourceApi->PutTagForIntegration");

            var localVarPath = "/integrations/provider/{name}/integration/{integration_name}/tags";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { "application/json" };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (integrationName != null) localVarPathParams.Add("integration_name", this.Configuration.ApiClient.ParameterToString(integrationName)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
            Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType, Configuration);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PutTagForIntegration", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            null);
        }

        /// <summary>
        /// Put a tag to Integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">The list of tags to be updated.</param>
        /// <param name="name">The name of the integration to associate the tag with.</param>
        /// <param name="integrationName">The name of the model to associate the tag with.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task PutTagForIntegrationAsync(List<Tag> body, string name, string integrationName)
        {
            await PutTagForIntegrationAsyncWithHttpInfo(body, name, integrationName);

        }

        /// <summary>
        /// Put a tag to Integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">The list of tags to be updated.</param>
        /// <param name="name">The name of the integration to associate the tag with.</param>
        /// <param name="integrationName">The name of the model to associate the tag with.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<object>> PutTagForIntegrationAsyncWithHttpInfo(List<Tag> body, string name, string integrationName)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling IntegrationResourceApi->PutTagForIntegration");
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->PutTagForIntegration");
            // verify the required parameter 'integrationName' is set
            if (integrationName == null)
                throw new ApiException(400, "Missing required parameter 'integrationName' when calling IntegrationResourceApi->PutTagForIntegration");

            var localVarPath = "/integrations/provider/{name}/integration/{integration_name}/tags";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { "application/json" };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (integrationName != null) localVarPathParams.Add("integration_name", this.Configuration.ApiClient.ParameterToString(integrationName)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
            Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PutTagForIntegration", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            null);
        }

        /// <summary>
        /// Put a tag to Integration Provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">The list of tags to be updated.</param>
        /// <param name="name">The name of the integration to associate the tag with.</param>
        /// <returns></returns>
        public void PutTagForIntegrationProvider(List<Tag> body, string name)
        {
            PutTagForIntegrationProviderWithHttpInfo(body, name);
        }

        /// <summary>
        /// Put a tag to Integration Provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">The list of tags to be updated.</param>
        /// <param name="name">The name of the integration to associate the tag with.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> PutTagForIntegrationProviderWithHttpInfo(List<Tag> body, string name)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling IntegrationResourceApi->PutTagForIntegrationProvider");
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->PutTagForIntegrationProvider");

            var localVarPath = "/integrations/provider/{name}/tags";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { "application/json" };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
            Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType, Configuration);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PutTagForIntegrationProvider", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            null);
        }

        /// <summary>
        /// Put a tag to Integration Provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">The list of tags to be updated.</param>
        /// <param name="name">The name of the integration to associate the tag with.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task PutTagForIntegrationProviderAsync(List<Tag> body, string name)
        {
            await PutTagForIntegrationProviderAsyncWithHttpInfo(body, name);

        }

        /// <summary>
        /// Put a tag to Integration Provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">The list of tags to be updated.</param>
        /// <param name="name">The name of the integration to associate the tag with.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<object>> PutTagForIntegrationProviderAsyncWithHttpInfo(List<Tag> body, string name)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling IntegrationResourceApi->PutTagForIntegrationProvider");
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->PutTagForIntegrationProvider");

            var localVarPath = "/integrations/provider/{name}/tags";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { "application/json" };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
            Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PutTagForIntegrationProvider", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            null);
        }

        /// <summary>
        /// Record Event Stats
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public void RecordEventStats(List<EventLog> body, string type)
        {
            RecordEventStatsWithHttpInfo(body, type);
        }

        /// <summary>
        /// Record Event Stats
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="type"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> RecordEventStatsWithHttpInfo(List<EventLog> body, string type)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling IntegrationResourceApi->RecordEventStats");
            // verify the required parameter 'type' is set
            if (type == null)
                throw new ApiException(400, "Missing required parameter 'type' when calling IntegrationResourceApi->RecordEventStats");

            var localVarPath = "/integrations/eventStats/{type}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { "application/json" };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (type != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "type", type)); // query parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
            Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType, Configuration);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("RecordEventStats", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            null);
        }

        /// <summary>
        /// Record Event Stats
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="type"></param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task RecordEventStatsAsync(List<EventLog> body, string type)
        {
            await RecordEventStatsAsyncWithHttpInfo(body, type);

        }

        /// <summary>
        /// Record Event Stats
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="type"></param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<object>> RecordEventStatsAsyncWithHttpInfo(List<EventLog> body, string type)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling IntegrationResourceApi->RecordEventStats");
            // verify the required parameter 'type' is set
            if (type == null)
                throw new ApiException(400, "Missing required parameter 'type' when calling IntegrationResourceApi->RecordEventStats");

            var localVarPath = "/integrations/eventStats/{type}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { "application/json" };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (type != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "type", type)); // query parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
            Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("RecordEventStats", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            null);
        }

        /// <summary>
        /// Register Token usage
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns></returns>
        public void RegisterTokenUsage(int? body, string name, string integrationName)
        {
            RegisterTokenUsageWithHttpInfo(body, name, integrationName);
        }

        /// <summary>
        /// Register Token usage
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> RegisterTokenUsageWithHttpInfo(int? body, string name, string integrationName)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling IntegrationResourceApi->RegisterTokenUsage");
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->RegisterTokenUsage");
            // verify the required parameter 'integrationName' is set
            if (integrationName == null)
                throw new ApiException(400, "Missing required parameter 'integrationName' when calling IntegrationResourceApi->RegisterTokenUsage");

            var localVarPath = "/integrations/provider/{name}/integration/{integration_name}/metrics";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { "application/json" };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (integrationName != null) localVarPathParams.Add("integration_name", this.Configuration.ApiClient.ParameterToString(integrationName)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
            Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType, Configuration);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("RegisterTokenUsage", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            null);
        }

        /// <summary>
        /// Register Token usage
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task RegisterTokenUsageAsync(int? body, string name, string integrationName)
        {
            await RegisterTokenUsageAsyncWithHttpInfo(body, name, integrationName);

        }

        /// <summary>
        /// Register Token usage
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<object>> RegisterTokenUsageAsyncWithHttpInfo(int? body, string name, string integrationName)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling IntegrationResourceApi->RegisterTokenUsage");
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->RegisterTokenUsage");
            // verify the required parameter 'integrationName' is set
            if (integrationName == null)
                throw new ApiException(400, "Missing required parameter 'integrationName' when calling IntegrationResourceApi->RegisterTokenUsage");

            var localVarPath = "/integrations/provider/{name}/integration/{integration_name}/metrics";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { "application/json" };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (integrationName != null) localVarPathParams.Add("integration_name", this.Configuration.ApiClient.ParameterToString(integrationName)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
            Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("RegisterTokenUsage", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            null);
        }

        /// <summary>
        /// Create or Update Integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns></returns>
        public void SaveIntegrationApi(IntegrationApiUpdate body, string name, string integrationName)
        {
            SaveIntegrationApiWithHttpInfo(body, name, integrationName);
        }

        /// <summary>
        /// Create or Update Integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> SaveIntegrationApiWithHttpInfo(IntegrationApiUpdate body, string name, string integrationName)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling IntegrationResourceApi->SaveIntegrationApi");
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->SaveIntegrationApi");
            // verify the required parameter 'integrationName' is set
            if (integrationName == null)
                throw new ApiException(400, "Missing required parameter 'integrationName' when calling IntegrationResourceApi->SaveIntegrationApi");

            var localVarPath = "/integrations/provider/{name}/integration/{integration_name}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { "application/json" };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (integrationName != null) localVarPathParams.Add("integration_name", this.Configuration.ApiClient.ParameterToString(integrationName)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
            Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType, Configuration);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SaveIntegrationApi", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            null);
        }

        /// <summary>
        /// Create or Update Integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task SaveIntegrationApiAsync(IntegrationApiUpdate body, string name, string integrationName)
        {
            await SaveIntegrationApiAsyncWithHttpInfo(body, name, integrationName);

        }

        /// <summary>
        /// Create or Update Integration
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<object>> SaveIntegrationApiAsyncWithHttpInfo(IntegrationApiUpdate body, string name, string integrationName)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling IntegrationResourceApi->SaveIntegrationApi");
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->SaveIntegrationApi");
            // verify the required parameter 'integrationName' is set
            if (integrationName == null)
                throw new ApiException(400, "Missing required parameter 'integrationName' when calling IntegrationResourceApi->SaveIntegrationApi");

            var localVarPath = "/integrations/provider/{name}/integration/{integration_name}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { "application/json" };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (integrationName != null) localVarPathParams.Add("integration_name", this.Configuration.ApiClient.ParameterToString(integrationName)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
            Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SaveIntegrationApi", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            null);
        }

        /// <summary>
        /// Create or Update Integration provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public void SaveIntegrationProvider(IntegrationUpdate body, string name)
        {
            SaveIntegrationProviderWithHttpInfo(body, name);
        }

        /// <summary>
        /// Create or Update Integration provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> SaveIntegrationProviderWithHttpInfo(IntegrationUpdate body, string name)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling IntegrationResourceApi->SaveIntegrationProvider");
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->SaveIntegrationProvider");

            var localVarPath = "/integrations/provider/{name}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { "application/json" };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
            Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType, Configuration);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SaveIntegrationProvider", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            null);
        }

        /// <summary>
        /// Create or Update Integration provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task SaveIntegrationProviderAsync(IntegrationUpdate body, string name)
        {
            await SaveIntegrationProviderAsyncWithHttpInfo(body, name);

        }

        /// <summary>
        /// Create or Update Integration provider
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<object>> SaveIntegrationProviderAsyncWithHttpInfo(IntegrationUpdate body, string name)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling IntegrationResourceApi->SaveIntegrationProvider");
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling IntegrationResourceApi->SaveIntegrationProvider");

            var localVarPath = "/integrations/provider/{name}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = new string[] { "application/json" };
            string localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = new string[] { };
            string localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
            Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
            localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SaveIntegrationProvider", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
            localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
            null);
        }
    }
}
