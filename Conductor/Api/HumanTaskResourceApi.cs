using Conductor.Client;
using Conductor.Client.Models;
using conductor_csharp.Api;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using ThreadTask = System.Threading.Tasks;

namespace Conductor.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class HumanTaskResourceApi : IHumanTaskResourceApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="HumanTaskResourceApi"/> class.
        /// </summary>
        /// <returns></returns>
        public HumanTaskResourceApi(String basePath)
        {
            this.Configuration = new Configuration { BasePath = basePath };

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HumanTaskResourceApi"/> class
        /// </summary>
        /// <returns></returns>
        public HumanTaskResourceApi()
        {
            this.Configuration = Configuration.Default;

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HumanTaskResourceApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public HumanTaskResourceApi(Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.Options.BaseUrl.ToString();
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Configuration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public ExceptionFactory ExceptionFactory
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
        /// Claim a task to an external user 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="userId"></param>
        /// <param name="overrideAssignment"> (optional, default to false)</param>
        /// <returns>HumanTaskEntry</returns>
        public HumanTaskEntry AssignAndClaim(string taskId, string userId, bool? overrideAssignment = null)
        {
            ApiResponse<HumanTaskEntry> localVarResponse = AssignAndClaimWithHttpInfo(taskId, userId, overrideAssignment);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Claim a task to an external user 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="userId"></param>
        /// <param name="overrideAssignment"> (optional, default to false)</param>
        /// <returns>ApiResponse of HumanTaskEntry</returns>
        public ApiResponse<HumanTaskEntry> AssignAndClaimWithHttpInfo(string taskId, string userId, bool? overrideAssignment = null)
        {
            // verify the required parameter 'taskId' is set
            if (taskId == null)
                throw new ApiException(400, "Missing required parameter 'taskId' when calling HumanTaskApi->AssignAndClaim");
            // verify the required parameter 'userId' is set
            if (userId == null)
                throw new ApiException(400, "Missing required parameter 'userId' when calling HumanTaskApi->AssignAndClaim");

            var localVarPath = "/api/human/tasks/{taskId}/externalUser/{userId}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (taskId != null) localVarPathParams.Add("taskId", this.Configuration.ApiClient.ParameterToString(taskId)); // path parameter
            if (userId != null) localVarPathParams.Add("userId", this.Configuration.ApiClient.ParameterToString(userId)); // path parameter
            if (overrideAssignment != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "overrideAssignment", overrideAssignment)); // query parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("AssignAndClaim", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<HumanTaskEntry>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (HumanTaskEntry)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(HumanTaskEntry)));
        }

        /// <summary>
        /// Claim a task to an external user 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="userId"></param>
        /// <param name="overrideAssignment"> (optional, default to false)</param>
        /// <returns>Task of HumanTaskEntry</returns>
        public async ThreadTask.Task<HumanTaskEntry> AssignAndClaimAsync(string taskId, string userId, bool? overrideAssignment = null)
        {
            ApiResponse<HumanTaskEntry> localVarResponse = await AssignAndClaimAsyncWithHttpInfo(taskId, userId, overrideAssignment);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Claim a task to an external user 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="userId"></param>
        /// <param name="overrideAssignment"> (optional, default to false)</param>
        /// <returns>Task of ApiResponse (HumanTaskEntry)</returns>
        public async ThreadTask.Task<ApiResponse<HumanTaskEntry>> AssignAndClaimAsyncWithHttpInfo(string taskId, string userId, bool? overrideAssignment = null)
        {
            // verify the required parameter 'taskId' is set
            if (taskId == null)
                throw new ApiException(400, "Missing required parameter 'taskId' when calling HumanTaskApi->AssignAndClaim");
            // verify the required parameter 'userId' is set
            if (userId == null)
                throw new ApiException(400, "Missing required parameter 'userId' when calling HumanTaskApi->AssignAndClaim");

            var localVarPath = "/api/human/tasks/{taskId}/externalUser/{userId}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (taskId != null) localVarPathParams.Add("taskId", this.Configuration.ApiClient.ParameterToString(taskId)); // path parameter
            if (userId != null) localVarPathParams.Add("userId", this.Configuration.ApiClient.ParameterToString(userId)); // path parameter
            if (overrideAssignment != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "overrideAssignment", overrideAssignment)); // query parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
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
                Exception exception = ExceptionFactory("AssignAndClaim", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<HumanTaskEntry>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (HumanTaskEntry)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(HumanTaskEntry)));
        }

        /// <summary>
        /// API for backpopulating index data 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="_100"></param>
        /// <returns>Dictionary&lt;string, Object&gt;</returns>
        public Dictionary<string, Object> BackPopulateFullTextIndex(int? _100)
        {
            ApiResponse<Dictionary<string, Object>> localVarResponse = BackPopulateFullTextIndexWithHttpInfo(_100);
            return localVarResponse.Data;
        }

        /// <summary>
        /// API for backpopulating index data 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="_100"></param>
        /// <returns>ApiResponse of Dictionary&lt;string, Object&gt;</returns>
        public ApiResponse<Dictionary<string, Object>> BackPopulateFullTextIndexWithHttpInfo(int? _100)
        {
            // verify the required parameter '_100' is set
            if (_100 == null)
                throw new ApiException(400, "Missing required parameter '_100' when calling HumanTaskApi->BackPopulateFullTextIndex");

            var localVarPath = "/api/human/tasks/backPopulateFullTextIndex";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (_100 != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "100", _100)); // query parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("BackPopulateFullTextIndex", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Dictionary<string, Object>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (Dictionary<string, Object>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Dictionary<string, Object>)));
        }

        /// <summary>
        /// API for backpopulating index data 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="_100"></param>
        /// <returns>Task of Dictionary&lt;string, Object&gt;</returns>
        public async ThreadTask.Task<Dictionary<string, Object>> BackPopulateFullTextIndexAsync(int? _100)
        {
            ApiResponse<Dictionary<string, Object>> localVarResponse = await BackPopulateFullTextIndexAsyncWithHttpInfo(_100);
            return localVarResponse.Data;

        }

        /// <summary>
        /// API for backpopulating index data 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="_100"></param>
        /// <returns>Task of ApiResponse (Dictionary&lt;string, Object&gt;)</returns>
        public async ThreadTask.Task<ApiResponse<Dictionary<string, Object>>> BackPopulateFullTextIndexAsyncWithHttpInfo(int? _100)
        {
            // verify the required parameter '_100' is set
            if (_100 == null)
                throw new ApiException(400, "Missing required parameter '_100' when calling HumanTaskApi->BackPopulateFullTextIndex");

            var localVarPath = "/api/human/tasks/backPopulateFullTextIndex";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (_100 != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "100", _100)); // query parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
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
                Exception exception = ExceptionFactory("BackPopulateFullTextIndex", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Dictionary<string, Object>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (Dictionary<string, Object>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Dictionary<string, Object>)));
        }

        /// <summary>
        /// Claim a task by authenticated Conductor user 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="overrideAssignment"> (optional, default to false)</param>
        /// <returns>HumanTaskEntry</returns>
        public HumanTaskEntry ClaimTask(string taskId, bool? overrideAssignment = null)
        {
            ApiResponse<HumanTaskEntry> localVarResponse = ClaimTaskWithHttpInfo(taskId, overrideAssignment);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Claim a task by authenticated Conductor user 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="overrideAssignment"> (optional, default to false)</param>
        /// <returns>ApiResponse of HumanTaskEntry</returns>
        public ApiResponse<HumanTaskEntry> ClaimTaskWithHttpInfo(string taskId, bool? overrideAssignment = null)
        {
            // verify the required parameter 'taskId' is set
            if (taskId == null)
                throw new ApiException(400, "Missing required parameter 'taskId' when calling HumanTaskApi->ClaimTask");

            var localVarPath = "/api/human/tasks/{taskId}/claim";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (taskId != null) localVarPathParams.Add("taskId", this.Configuration.ApiClient.ParameterToString(taskId)); // path parameter
            if (overrideAssignment != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "overrideAssignment", overrideAssignment)); // query parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ClaimTask", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<HumanTaskEntry>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (HumanTaskEntry)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(HumanTaskEntry)));
        }

        /// <summary>
        /// Claim a task by authenticated Conductor user 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="overrideAssignment"> (optional, default to false)</param>
        /// <returns>Task of HumanTaskEntry</returns>
        public async ThreadTask.Task<HumanTaskEntry> ClaimTaskAsync(string taskId, bool? overrideAssignment = null)
        {
            ApiResponse<HumanTaskEntry> localVarResponse = await ClaimTaskAsyncWithHttpInfo(taskId, overrideAssignment);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Claim a task by authenticated Conductor user 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="overrideAssignment"> (optional, default to false)</param>
        /// <returns>Task of ApiResponse (HumanTaskEntry)</returns>
        public async ThreadTask.Task<ApiResponse<HumanTaskEntry>> ClaimTaskAsyncWithHttpInfo(string taskId, bool? overrideAssignment = null)
        {
            // verify the required parameter 'taskId' is set
            if (taskId == null)
                throw new ApiException(400, "Missing required parameter 'taskId' when calling HumanTaskApi->ClaimTask");

            var localVarPath = "/api/human/tasks/{taskId}/claim";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (taskId != null) localVarPathParams.Add("taskId", this.Configuration.ApiClient.ParameterToString(taskId)); // path parameter
            if (overrideAssignment != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "overrideAssignment", overrideAssignment)); // query parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
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
                Exception exception = ExceptionFactory("ClaimTask", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<HumanTaskEntry>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (HumanTaskEntry)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(HumanTaskEntry)));
        }

        /// <summary>
        /// Delete all versions of user form template by name 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns></returns>
        public void DeleteTemplateByName(string name)
        {
            DeleteTemplateByNameWithHttpInfo(name);
        }

        /// <summary>
        /// Delete all versions of user form template by name 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> DeleteTemplateByNameWithHttpInfo(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling HumanTaskApi->DeleteTemplateByName");

            var localVarPath = "/api/human/template/{name}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Delete, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("DeleteTemplateByName", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        /// Delete all versions of user form template by name 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of void</returns>
        public async ThreadTask.Task DeleteTemplateByNameAsync(string name)
        {
            await DeleteTemplateByNameAsyncWithHttpInfo(name);

        }

        /// <summary>
        /// Delete all versions of user form template by name 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of ApiResponse</returns>
        public async ThreadTask.Task<ApiResponse<Object>> DeleteTemplateByNameAsyncWithHttpInfo(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling HumanTaskApi->DeleteTemplateByName");

            var localVarPath = "/api/human/template/{name}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
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
                Exception exception = ExceptionFactory("DeleteTemplateByName", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        /// Delete a version of form template by name 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public void DeleteTemplatesByNameAndVersion(string name, int? version)
        {
            DeleteTemplatesByNameAndVersionWithHttpInfo(name, version);
        }

        /// <summary>
        /// Delete a version of form template by name 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> DeleteTemplatesByNameAndVersionWithHttpInfo(string name, int? version)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling HumanTaskApi->DeleteTemplatesByNameAndVersion");
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling HumanTaskApi->DeleteTemplatesByNameAndVersion");

            var localVarPath = "/api/human/template/{name}/{version}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (version != null) localVarPathParams.Add("version", this.Configuration.ApiClient.ParameterToString(version)); // path parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Delete, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("DeleteTemplatesByNameAndVersion", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        /// Delete a version of form template by name 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <returns>Task of void</returns>
        public async ThreadTask.Task DeleteTemplatesByNameAndVersionAsync(string name, int? version)
        {
            await DeleteTemplatesByNameAndVersionAsyncWithHttpInfo(name, version);

        }

        /// <summary>
        /// Delete a version of form template by name 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <returns>Task of ApiResponse</returns>
        public async ThreadTask.Task<ApiResponse<Object>> DeleteTemplatesByNameAndVersionAsyncWithHttpInfo(string name, int? version)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling HumanTaskApi->DeleteTemplatesByNameAndVersion");
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling HumanTaskApi->DeleteTemplatesByNameAndVersion");

            var localVarPath = "/api/human/template/{name}/{version}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (version != null) localVarPathParams.Add("version", this.Configuration.ApiClient.ParameterToString(version)); // path parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
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
                Exception exception = ExceptionFactory("DeleteTemplatesByNameAndVersion", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        /// List all user form templates or get templates by name, or a template by name and version 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"> (optional)</param>
        /// <param name="version"> (optional)</param>
        /// <returns>List&lt;HumanTaskTemplate&gt;</returns>
        public List<HumanTaskTemplate> GetAllTemplates(string name = null, int? version = null)
        {
            ApiResponse<List<HumanTaskTemplate>> localVarResponse = GetAllTemplatesWithHttpInfo(name, version);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List all user form templates or get templates by name, or a template by name and version 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"> (optional)</param>
        /// <param name="version"> (optional)</param>
        /// <returns>ApiResponse of List&lt;HumanTaskTemplate&gt;</returns>
        public ApiResponse<List<HumanTaskTemplate>> GetAllTemplatesWithHttpInfo(string name = null, int? version = null)
        {

            var localVarPath = "/api/human/template";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "name", name)); // query parameter
            if (version != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "version", version)); // query parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetAllTemplates", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<HumanTaskTemplate>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (List<HumanTaskTemplate>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<HumanTaskTemplate>)));
        }

        /// <summary>
        /// List all user form templates or get templates by name, or a template by name and version 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"> (optional)</param>
        /// <param name="version"> (optional)</param>
        /// <returns>Task of List&lt;HumanTaskTemplate&gt;</returns>
        public async ThreadTask.Task<List<HumanTaskTemplate>> GetAllTemplatesAsync(string name = null, int? version = null)
        {
            ApiResponse<List<HumanTaskTemplate>> localVarResponse = await GetAllTemplatesAsyncWithHttpInfo(name, version);
            return localVarResponse.Data;

        }

        /// <summary>
        /// List all user form templates or get templates by name, or a template by name and version 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"> (optional)</param>
        /// <param name="version"> (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;HumanTaskTemplate&gt;)</returns>
        public async ThreadTask.Task<ApiResponse<List<HumanTaskTemplate>>> GetAllTemplatesAsyncWithHttpInfo(string name = null, int? version = null)
        {

            var localVarPath = "/api/human/template";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "name", name)); // query parameter
            if (version != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "version", version)); // query parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
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
                Exception exception = ExceptionFactory("GetAllTemplates", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<HumanTaskTemplate>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (List<HumanTaskTemplate>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<HumanTaskTemplate>)));
        }

        /// <summary>
        /// Get a task 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns>HumanTaskEntry</returns>
        public HumanTaskEntry GetTask1(string taskId)
        {
            ApiResponse<HumanTaskEntry> localVarResponse = GetTask1WithHttpInfo(taskId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get a task 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns>ApiResponse of HumanTaskEntry</returns>
        public ApiResponse<HumanTaskEntry> GetTask1WithHttpInfo(string taskId)
        {
            // verify the required parameter 'taskId' is set
            if (taskId == null)
                throw new ApiException(400, "Missing required parameter 'taskId' when calling HumanTaskApi->GetTask1");

            var localVarPath = "/api/human/tasks/{taskId}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (taskId != null) localVarPathParams.Add("taskId", this.Configuration.ApiClient.ParameterToString(taskId)); // path parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetTask1", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<HumanTaskEntry>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (HumanTaskEntry)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(HumanTaskEntry)));
        }

        /// <summary>
        /// Get a task 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns>Task of HumanTaskEntry</returns>
        public async ThreadTask.Task<HumanTaskEntry> GetTask1Async(string taskId)
        {
            ApiResponse<HumanTaskEntry> localVarResponse = await GetTask1AsyncWithHttpInfo(taskId);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Get a task 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns>Task of ApiResponse (HumanTaskEntry)</returns>
        public async ThreadTask.Task<ApiResponse<HumanTaskEntry>> GetTask1AsyncWithHttpInfo(string taskId)
        {
            // verify the required parameter 'taskId' is set
            if (taskId == null)
                throw new ApiException(400, "Missing required parameter 'taskId' when calling HumanTaskApi->GetTask1");

            var localVarPath = "/api/human/tasks/{taskId}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (taskId != null) localVarPathParams.Add("taskId", this.Configuration.ApiClient.ParameterToString(taskId)); // path parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
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
                Exception exception = ExceptionFactory("GetTask1", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<HumanTaskEntry>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (HumanTaskEntry)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(HumanTaskEntry)));
        }

        /// <summary>
        /// Get list of task display names applicable for the user 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="searchType"></param>
        /// <returns>List&lt;string&gt;</returns>
        public List<string> GetTaskDisplayNames(string searchType)
        {
            ApiResponse<List<string>> localVarResponse = GetTaskDisplayNamesWithHttpInfo(searchType);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get list of task display names applicable for the user 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="searchType"></param>
        /// <returns>ApiResponse of List&lt;string&gt;</returns>
        public ApiResponse<List<string>> GetTaskDisplayNamesWithHttpInfo(string searchType)
        {
            // verify the required parameter 'searchType' is set
            if (searchType == null)
                throw new ApiException(400, "Missing required parameter 'searchType' when calling HumanTaskApi->GetTaskDisplayNames");

            var localVarPath = "/api/human/tasks/getTaskDisplayNames";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (searchType != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "searchType", searchType)); // query parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetTaskDisplayNames", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<string>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (List<string>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<string>)));
        }

        /// <summary>
        /// Get list of task display names applicable for the user 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="searchType"></param>
        /// <returns>Task of List&lt;string&gt;</returns>
        public async ThreadTask.Task<List<string>> GetTaskDisplayNamesAsync(string searchType)
        {
            ApiResponse<List<string>> localVarResponse = await GetTaskDisplayNamesAsyncWithHttpInfo(searchType);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Get list of task display names applicable for the user 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="searchType"></param>
        /// <returns>Task of ApiResponse (List&lt;string&gt;)</returns>
        public async ThreadTask.Task<ApiResponse<List<string>>> GetTaskDisplayNamesAsyncWithHttpInfo(string searchType)
        {
            // verify the required parameter 'searchType' is set
            if (searchType == null)
                throw new ApiException(400, "Missing required parameter 'searchType' when calling HumanTaskApi->GetTaskDisplayNames");

            var localVarPath = "/api/human/tasks/getTaskDisplayNames";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (searchType != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "searchType", searchType)); // query parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
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
                Exception exception = ExceptionFactory("GetTaskDisplayNames", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<string>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (List<string>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<string>)));
        }

        /// <summary>
        /// Get user form template by name and version 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <returns>HumanTaskTemplate</returns>
        public HumanTaskTemplate GetTemplateByNameAndVersion(string name, int? version)
        {
            ApiResponse<HumanTaskTemplate> localVarResponse = GetTemplateByNameAndVersionWithHttpInfo(name, version);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get user form template by name and version 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <returns>ApiResponse of HumanTaskTemplate</returns>
        public ApiResponse<HumanTaskTemplate> GetTemplateByNameAndVersionWithHttpInfo(string name, int? version)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling HumanTaskApi->GetTemplateByNameAndVersion");
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling HumanTaskApi->GetTemplateByNameAndVersion");

            var localVarPath = "/api/human/template/{name}/{version}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (version != null) localVarPathParams.Add("version", this.Configuration.ApiClient.ParameterToString(version)); // path parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetTemplateByNameAndVersion", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<HumanTaskTemplate>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (HumanTaskTemplate)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(HumanTaskTemplate)));
        }

        /// <summary>
        /// Get user form template by name and version 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <returns>Task of HumanTaskTemplate</returns>
        public async ThreadTask.Task<HumanTaskTemplate> GetTemplateByNameAndVersionAsync(string name, int? version)
        {
            ApiResponse<HumanTaskTemplate> localVarResponse = await GetTemplateByNameAndVersionAsyncWithHttpInfo(name, version);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Get user form template by name and version 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <returns>Task of ApiResponse (HumanTaskTemplate)</returns>
        public async ThreadTask.Task<ApiResponse<HumanTaskTemplate>> GetTemplateByNameAndVersionAsyncWithHttpInfo(string name, int? version)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling HumanTaskApi->GetTemplateByNameAndVersion");
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling HumanTaskApi->GetTemplateByNameAndVersion");

            var localVarPath = "/api/human/template/{name}/{version}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null) localVarPathParams.Add("name", this.Configuration.ApiClient.ParameterToString(name)); // path parameter
            if (version != null) localVarPathParams.Add("version", this.Configuration.ApiClient.ParameterToString(version)); // path parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
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
                Exception exception = ExceptionFactory("GetTemplateByNameAndVersion", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<HumanTaskTemplate>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (HumanTaskTemplate)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(HumanTaskTemplate)));
        }

        /// <summary>
        /// Get user form by human task id 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="humanTaskId"></param>
        /// <returns>HumanTaskTemplate</returns>
        public HumanTaskTemplate GetTemplateByTaskId(string humanTaskId)
        {
            ApiResponse<HumanTaskTemplate> localVarResponse = GetTemplateByTaskIdWithHttpInfo(humanTaskId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get user form by human task id 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="humanTaskId"></param>
        /// <returns>ApiResponse of HumanTaskTemplate</returns>
        public ApiResponse<HumanTaskTemplate> GetTemplateByTaskIdWithHttpInfo(string humanTaskId)
        {
            // verify the required parameter 'humanTaskId' is set
            if (humanTaskId == null)
                throw new ApiException(400, "Missing required parameter 'humanTaskId' when calling HumanTaskApi->GetTemplateByTaskId");

            var localVarPath = "/api/human/template/{humanTaskId}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (humanTaskId != null) localVarPathParams.Add("humanTaskId", this.Configuration.ApiClient.ParameterToString(humanTaskId)); // path parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetTemplateByTaskId", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<HumanTaskTemplate>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (HumanTaskTemplate)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(HumanTaskTemplate)));
        }

        /// <summary>
        /// Get user form by human task id 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="humanTaskId"></param>
        /// <returns>Task of HumanTaskTemplate</returns>
        public async ThreadTask.Task<HumanTaskTemplate> GetTemplateByTaskIdAsync(string humanTaskId)
        {
            ApiResponse<HumanTaskTemplate> localVarResponse = await GetTemplateByTaskIdAsyncWithHttpInfo(humanTaskId);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Get user form by human task id 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="humanTaskId"></param>
        /// <returns>Task of ApiResponse (HumanTaskTemplate)</returns>
        public async ThreadTask.Task<ApiResponse<HumanTaskTemplate>> GetTemplateByTaskIdAsyncWithHttpInfo(string humanTaskId)
        {
            // verify the required parameter 'humanTaskId' is set
            if (humanTaskId == null)
                throw new ApiException(400, "Missing required parameter 'humanTaskId' when calling HumanTaskApi->GetTemplateByTaskId");

            var localVarPath = "/api/human/template/{humanTaskId}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (humanTaskId != null) localVarPathParams.Add("humanTaskId", this.Configuration.ApiClient.ParameterToString(humanTaskId)); // path parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
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
                Exception exception = ExceptionFactory("GetTemplateByTaskId", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<HumanTaskTemplate>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (HumanTaskTemplate)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(HumanTaskTemplate)));
        }

        /// <summary>
        /// Release a task without completing it 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public void ReassignTask(List<HumanTaskAssignment> body, string taskId)
        {
            ReassignTaskWithHttpInfo(body, taskId);
        }

        /// <summary>
        /// Release a task without completing it 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="taskId"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> ReassignTaskWithHttpInfo(List<HumanTaskAssignment> body, string taskId)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling HumanTaskApi->ReassignTask");
            // verify the required parameter 'taskId' is set
            if (taskId == null)
                throw new ApiException(400, "Missing required parameter 'taskId' when calling HumanTaskApi->ReassignTask");

            var localVarPath = "/api/human/tasks/{taskId}/reassign";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (taskId != null) localVarPathParams.Add("taskId", this.Configuration.ApiClient.ParameterToString(taskId)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ReassignTask", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        /// Release a task without completing it 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="taskId"></param>
        /// <returns>Task of void</returns>
        public async ThreadTask.Task ReassignTaskAsync(List<HumanTaskAssignment> body, string taskId)
        {
            await ReassignTaskAsyncWithHttpInfo(body, taskId);

        }

        /// <summary>
        /// Release a task without completing it 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="taskId"></param>
        /// <returns>Task of ApiResponse</returns>
        public async ThreadTask.Task<ApiResponse<Object>> ReassignTaskAsyncWithHttpInfo(List<HumanTaskAssignment> body, string taskId)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling HumanTaskApi->ReassignTask");
            // verify the required parameter 'taskId' is set
            if (taskId == null)
                throw new ApiException(400, "Missing required parameter 'taskId' when calling HumanTaskApi->ReassignTask");

            var localVarPath = "/api/human/tasks/{taskId}/reassign";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (taskId != null) localVarPathParams.Add("taskId", this.Configuration.ApiClient.ParameterToString(taskId)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
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
                Exception exception = ExceptionFactory("ReassignTask", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        /// Release a task without completing it 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public void ReleaseTask(string taskId)
        {
            ReleaseTaskWithHttpInfo(taskId);
        }

        /// <summary>
        /// Release a task without completing it 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> ReleaseTaskWithHttpInfo(string taskId)
        {
            // verify the required parameter 'taskId' is set
            if (taskId == null)
                throw new ApiException(400, "Missing required parameter 'taskId' when calling HumanTaskApi->ReleaseTask");

            var localVarPath = "/api/human/tasks/{taskId}/release";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (taskId != null) localVarPathParams.Add("taskId", this.Configuration.ApiClient.ParameterToString(taskId)); // path parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ReleaseTask", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        /// Release a task without completing it 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns>Task of void</returns>
        public async ThreadTask.Task ReleaseTaskAsync(string taskId)
        {
            await ReleaseTaskAsyncWithHttpInfo(taskId);

        }

        /// <summary>
        /// Release a task without completing it 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns>Task of ApiResponse</returns>
        public async ThreadTask.Task<ApiResponse<Object>> ReleaseTaskAsyncWithHttpInfo(string taskId)
        {
            // verify the required parameter 'taskId' is set
            if (taskId == null)
                throw new ApiException(400, "Missing required parameter 'taskId' when calling HumanTaskApi->ReleaseTask");

            var localVarPath = "/api/human/tasks/{taskId}/release";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (taskId != null) localVarPathParams.Add("taskId", this.Configuration.ApiClient.ParameterToString(taskId)); // path parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
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
                Exception exception = ExceptionFactory("ReleaseTask", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        /// Save user form template 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="newVersion"> (optional, default to false)</param>
        /// <returns>HumanTaskTemplate</returns>
        public HumanTaskTemplate SaveTemplate(HumanTaskTemplate body, bool? newVersion = null)
        {
            ApiResponse<HumanTaskTemplate> localVarResponse = SaveTemplateWithHttpInfo(body, newVersion);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Save user form template 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="newVersion"> (optional, default to false)</param>
        /// <returns>ApiResponse of HumanTaskTemplate</returns>
        public ApiResponse<HumanTaskTemplate> SaveTemplateWithHttpInfo(HumanTaskTemplate body, bool? newVersion = null)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling HumanTaskApi->SaveTemplate");

            var localVarPath = "/api/human/template";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (newVersion != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "newVersion", newVersion)); // query parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SaveTemplate", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<HumanTaskTemplate>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (HumanTaskTemplate)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(HumanTaskTemplate)));
        }

        /// <summary>
        /// Save user form template 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="newVersion"> (optional, default to false)</param>
        /// <returns>Task of HumanTaskTemplate</returns>
        public async ThreadTask.Task<HumanTaskTemplate> SaveTemplateAsync(HumanTaskTemplate body, bool? newVersion = null)
        {
            ApiResponse<HumanTaskTemplate> localVarResponse = await SaveTemplateAsyncWithHttpInfo(body, newVersion);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Save user form template 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="newVersion"> (optional, default to false)</param>
        /// <returns>Task of ApiResponse (HumanTaskTemplate)</returns>
        public async ThreadTask.Task<ApiResponse<HumanTaskTemplate>> SaveTemplateAsyncWithHttpInfo(HumanTaskTemplate body, bool? newVersion = null)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling HumanTaskApi->SaveTemplate");

            var localVarPath = "/api/human/template";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (newVersion != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "newVersion", newVersion)); // query parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
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
                Exception exception = ExceptionFactory("SaveTemplate", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<HumanTaskTemplate>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (HumanTaskTemplate)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(HumanTaskTemplate)));
        }

        /// <summary>
        /// Save user form template 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="newVersion"> (optional, default to false)</param>
        /// <returns>List&lt;HumanTaskTemplate&gt;</returns>
        public List<HumanTaskTemplate> SaveTemplates(List<HumanTaskTemplate> body, bool? newVersion = null)
        {
            ApiResponse<List<HumanTaskTemplate>> localVarResponse = SaveTemplatesWithHttpInfo(body, newVersion);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Save user form template 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="newVersion"> (optional, default to false)</param>
        /// <returns>ApiResponse of List&lt;HumanTaskTemplate&gt;</returns>
        public ApiResponse<List<HumanTaskTemplate>> SaveTemplatesWithHttpInfo(List<HumanTaskTemplate> body, bool? newVersion = null)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling HumanTaskApi->SaveTemplates");

            var localVarPath = "/api/human/template/bulk";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (newVersion != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "newVersion", newVersion)); // query parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SaveTemplates", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<HumanTaskTemplate>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (List<HumanTaskTemplate>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<HumanTaskTemplate>)));
        }

        /// <summary>
        /// Save user form template 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="newVersion"> (optional, default to false)</param>
        /// <returns>Task of List&lt;HumanTaskTemplate&gt;</returns>
        public async ThreadTask.Task<List<HumanTaskTemplate>> SaveTemplatesAsync(List<HumanTaskTemplate> body, bool? newVersion = null)
        {
            ApiResponse<List<HumanTaskTemplate>> localVarResponse = await SaveTemplatesAsyncWithHttpInfo(body, newVersion);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Save user form template 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="newVersion"> (optional, default to false)</param>
        /// <returns>Task of ApiResponse (List&lt;HumanTaskTemplate&gt;)</returns>
        public async ThreadTask.Task<ApiResponse<List<HumanTaskTemplate>>> SaveTemplatesAsyncWithHttpInfo(List<HumanTaskTemplate> body, bool? newVersion = null)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling HumanTaskApi->SaveTemplates");

            var localVarPath = "/api/human/template/bulk";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (newVersion != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "newVersion", newVersion)); // query parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
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
                Exception exception = ExceptionFactory("SaveTemplates", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<HumanTaskTemplate>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (List<HumanTaskTemplate>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<HumanTaskTemplate>)));
        }

        /// <summary>
        /// Search human tasks 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>HumanTaskSearchResult</returns>
        public HumanTaskSearchResult Search(HumanTaskSearch body)
        {
            ApiResponse<HumanTaskSearchResult> localVarResponse = SearchWithHttpInfo(body);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Search human tasks 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>ApiResponse of HumanTaskSearchResult</returns>
        public ApiResponse<HumanTaskSearchResult> SearchWithHttpInfo(HumanTaskSearch body)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling HumanTaskApi->Search");

            var localVarPath = "/api/human/tasks/search";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("Search", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<HumanTaskSearchResult>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (HumanTaskSearchResult)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(HumanTaskSearchResult)));
        }

        /// <summary>
        /// Search human tasks 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>Task of HumanTaskSearchResult</returns>
        public async ThreadTask.Task<HumanTaskSearchResult> SearchAsync(HumanTaskSearch body)
        {
            ApiResponse<HumanTaskSearchResult> localVarResponse = await SearchAsyncWithHttpInfo(body);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Search human tasks 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>Task of ApiResponse (HumanTaskSearchResult)</returns>
        public async ThreadTask.Task<ApiResponse<HumanTaskSearchResult>> SearchAsyncWithHttpInfo(HumanTaskSearch body)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling HumanTaskApi->Search");

            var localVarPath = "/api/human/tasks/search";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
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
                Exception exception = ExceptionFactory("Search", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<HumanTaskSearchResult>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (HumanTaskSearchResult)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(HumanTaskSearchResult)));
        }

        /// <summary>
        /// If a task is assigned to a user, this API can be used to skip that assignment and move to the next assignee 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="reason"> (optional)</param>
        /// <returns></returns>
        public void SkipTask(string taskId, string reason = null)
        {
            SkipTaskWithHttpInfo(taskId, reason);
        }

        /// <summary>
        /// If a task is assigned to a user, this API can be used to skip that assignment and move to the next assignee 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="reason"> (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> SkipTaskWithHttpInfo(string taskId, string reason = null)
        {
            // verify the required parameter 'taskId' is set
            if (taskId == null)
                throw new ApiException(400, "Missing required parameter 'taskId' when calling HumanTaskApi->SkipTask");

            var localVarPath = "/api/human/tasks/{taskId}/skip";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (taskId != null) localVarPathParams.Add("taskId", this.Configuration.ApiClient.ParameterToString(taskId)); // path parameter
            if (reason != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "reason", reason)); // query parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SkipTask", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        /// If a task is assigned to a user, this API can be used to skip that assignment and move to the next assignee 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="reason"> (optional)</param>
        /// <returns>Task of void</returns>
        public async ThreadTask.Task SkipTaskAsync(string taskId, string reason = null)
        {
            await SkipTaskAsyncWithHttpInfo(taskId, reason);

        }

        /// <summary>
        /// If a task is assigned to a user, this API can be used to skip that assignment and move to the next assignee 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="reason"> (optional)</param>
        /// <returns>Task of ApiResponse</returns>
        public async ThreadTask.Task<ApiResponse<Object>> SkipTaskAsyncWithHttpInfo(string taskId, string reason = null)
        {
            // verify the required parameter 'taskId' is set
            if (taskId == null)
                throw new ApiException(400, "Missing required parameter 'taskId' when calling HumanTaskApi->SkipTask");

            var localVarPath = "/api/human/tasks/{taskId}/skip";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (taskId != null) localVarPathParams.Add("taskId", this.Configuration.ApiClient.ParameterToString(taskId)); // path parameter
            if (reason != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "reason", reason)); // query parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
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
                Exception exception = ExceptionFactory("SkipTask", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        /// Update task output, optionally complete 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="taskId"></param>
        /// <param name="complete"> (optional, default to false)</param>
        /// <returns></returns>
        public void UpdateTaskOutput(Dictionary<string, Object> body, string taskId, bool? complete = null)
        {
            UpdateTaskOutputWithHttpInfo(body, taskId, complete);
        }

        /// <summary>
        /// Update task output, optionally complete 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="taskId"></param>
        /// <param name="complete"> (optional, default to false)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> UpdateTaskOutputWithHttpInfo(Dictionary<string, Object> body, string taskId, bool? complete = null)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling HumanTaskApi->UpdateTaskOutput");
            // verify the required parameter 'taskId' is set
            if (taskId == null)
                throw new ApiException(400, "Missing required parameter 'taskId' when calling HumanTaskApi->UpdateTaskOutput");

            var localVarPath = "/api/human/tasks/{taskId}/update";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (taskId != null) localVarPathParams.Add("taskId", this.Configuration.ApiClient.ParameterToString(taskId)); // path parameter
            if (complete != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "complete", complete)); // query parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("UpdateTaskOutput", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        /// Update task output, optionally complete 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="taskId"></param>
        /// <param name="complete"> (optional, default to false)</param>
        /// <returns>Task of void</returns>
        public async ThreadTask.Task UpdateTaskOutputAsync(Dictionary<string, Object> body, string taskId, bool? complete = null)
        {
            await UpdateTaskOutputAsyncWithHttpInfo(body, taskId, complete);

        }

        /// <summary>
        /// Update task output, optionally complete 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="taskId"></param>
        /// <param name="complete"> (optional, default to false)</param>
        /// <returns>Task of ApiResponse</returns>
        public async ThreadTask.Task<ApiResponse<Object>> UpdateTaskOutputAsyncWithHttpInfo(Dictionary<string, Object> body, string taskId, bool? complete = null)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling HumanTaskApi->UpdateTaskOutput");
            // verify the required parameter 'taskId' is set
            if (taskId == null)
                throw new ApiException(400, "Missing required parameter 'taskId' when calling HumanTaskApi->UpdateTaskOutput");

            var localVarPath = "/api/human/tasks/{taskId}/update";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (taskId != null) localVarPathParams.Add("taskId", this.Configuration.ApiClient.ParameterToString(taskId)); // path parameter
            if (complete != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "complete", complete)); // query parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
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
                Exception exception = ExceptionFactory("UpdateTaskOutput", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        /// Update task output, optionally complete 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="workflowId"></param>
        /// <param name="taskRefName"></param>
        /// <param name="complete"> (optional, default to false)</param>
        /// <param name="iteration">Populate this value if your task is in a loop and you want to update a specific iteration. If its not in a loop OR if you want to just update the latest iteration, leave this as empty (optional)</param>
        /// <returns></returns>
        public void UpdateTaskOutputByRef(Dictionary<string, Object> body, string workflowId, string taskRefName, bool? complete = null, List<int?> iteration = null)
        {
            UpdateTaskOutputByRefWithHttpInfo(body, workflowId, taskRefName, complete, iteration);
        }

        /// <summary>
        /// Update task output, optionally complete 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="workflowId"></param>
        /// <param name="taskRefName"></param>
        /// <param name="complete"> (optional, default to false)</param>
        /// <param name="iteration">Populate this value if your task is in a loop and you want to update a specific iteration. If its not in a loop OR if you want to just update the latest iteration, leave this as empty (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> UpdateTaskOutputByRefWithHttpInfo(Dictionary<string, Object> body, string workflowId, string taskRefName, bool? complete = null, List<int?> iteration = null)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling HumanTaskApi->UpdateTaskOutputByRef");
            // verify the required parameter 'workflowId' is set
            if (workflowId == null)
                throw new ApiException(400, "Missing required parameter 'workflowId' when calling HumanTaskApi->UpdateTaskOutputByRef");
            // verify the required parameter 'taskRefName' is set
            if (taskRefName == null)
                throw new ApiException(400, "Missing required parameter 'taskRefName' when calling HumanTaskApi->UpdateTaskOutputByRef");

            var localVarPath = "/api/human/tasks/update/taskRef";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (workflowId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "workflowId", workflowId)); // query parameter
            if (taskRefName != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "taskRefName", taskRefName)); // query parameter
            if (complete != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "complete", complete)); // query parameter
            if (iteration != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("multi", "iteration", iteration)); // query parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Post, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("UpdateTaskOutputByRef", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        /// Update task output, optionally complete 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="workflowId"></param>
        /// <param name="taskRefName"></param>
        /// <param name="complete"> (optional, default to false)</param>
        /// <param name="iteration">Populate this value if your task is in a loop and you want to update a specific iteration. If its not in a loop OR if you want to just update the latest iteration, leave this as empty (optional)</param>
        /// <returns>Task of void</returns>
        public async ThreadTask.Task UpdateTaskOutputByRefAsync(Dictionary<string, Object> body, string workflowId, string taskRefName, bool? complete = null, List<int?> iteration = null)
        {
            await UpdateTaskOutputByRefAsyncWithHttpInfo(body, workflowId, taskRefName, complete, iteration);

        }

        /// <summary>
        /// Update task output, optionally complete 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="workflowId"></param>
        /// <param name="taskRefName"></param>
        /// <param name="complete"> (optional, default to false)</param>
        /// <param name="iteration">Populate this value if your task is in a loop and you want to update a specific iteration. If its not in a loop OR if you want to just update the latest iteration, leave this as empty (optional)</param>
        /// <returns>Task of ApiResponse</returns>
        public async ThreadTask.Task<ApiResponse<Object>> UpdateTaskOutputByRefAsyncWithHttpInfo(Dictionary<string, Object> body, string workflowId, string taskRefName, bool? complete = null, List<int?> iteration = null)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling HumanTaskApi->UpdateTaskOutputByRef");
            // verify the required parameter 'workflowId' is set
            if (workflowId == null)
                throw new ApiException(400, "Missing required parameter 'workflowId' when calling HumanTaskApi->UpdateTaskOutputByRef");
            // verify the required parameter 'taskRefName' is set
            if (taskRefName == null)
                throw new ApiException(400, "Missing required parameter 'taskRefName' when calling HumanTaskApi->UpdateTaskOutputByRef");

            var localVarPath = "/api/human/tasks/update/taskRef";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (workflowId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "workflowId", workflowId)); // query parameter
            if (taskRefName != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "taskRefName", taskRefName)); // query parameter
            if (complete != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "complete", complete)); // query parameter
            if (iteration != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("multi", "iteration", iteration)); // query parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
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
                Exception exception = ExceptionFactory("UpdateTaskOutputByRef", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }


        /// <summary>
        /// Get Conductor task by id (for human tasks only) 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns>Task</returns>
        public Task GetConductorTaskById(string taskId)
        {
            ApiResponse<Task> localVarResponse = GetConductorTaskByIdWithHttpInfo(taskId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Conductor task by id (for human tasks only) 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns>ApiResponse of Task</returns>
        public ApiResponse<Task> GetConductorTaskByIdWithHttpInfo(string taskId)
        {
            // verify the required parameter 'taskId' is set
            if (taskId == null)
                throw new ApiException(400, "Missing required parameter 'taskId' when calling HumanTaskResourceApi->GetConductorTaskById");

            var localVarPath = "/api/human/tasks/{taskId}/conductorTask";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (taskId != null) localVarPathParams.Add("taskId", this.Configuration.ApiClient.ParameterToString(taskId)); // path parameter

            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.AccessToken;
            }

            // make the HTTP request
            RestResponse localVarResponse = (RestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.Get, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetConductorTaskById", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Task>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (Task)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Task)));
        }

        /// <summary>
        /// Get Conductor task by id (for human tasks only) 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns>Task of Task</returns>
        public async ThreadTask.Task<Task> GetConductorTaskByIdAsync(string taskId)
        {
            ApiResponse<Task> localVarResponse = await GetConductorTaskByIdAsyncWithHttpInfo(taskId);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Get Conductor task by id (for human tasks only) 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns>Task of ApiResponse (Task)</returns>
        public async ThreadTask.Task<ApiResponse<Task>> GetConductorTaskByIdAsyncWithHttpInfo(string taskId)
        {
            // verify the required parameter 'taskId' is set
            if (taskId == null)
                throw new ApiException(400, "Missing required parameter 'taskId' when calling HumanTaskResourceApi->GetConductorTaskById");

            var localVarPath = "/api/human/tasks/{taskId}/conductorTask";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (taskId != null) localVarPathParams.Add("taskId", this.Configuration.ApiClient.ParameterToString(taskId)); // path parameter

            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
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
                Exception exception = ExceptionFactory("GetConductorTaskById", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Task>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (Task)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Task)));
        }
    }
}
