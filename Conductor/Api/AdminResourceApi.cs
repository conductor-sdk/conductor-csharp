
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using Conductor.Client;
using Conductor.Models;

namespace Conductor.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IAdminResourceApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get details of redis usage
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Dictionary&lt;string, Object&gt;</returns>
        Dictionary<string, Object> GetRedisUsage();

        /// <summary>
        /// Get details of redis usage
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Dictionary&lt;string, Object&gt;</returns>
        ApiResponse<Dictionary<string, Object>> GetRedisUsageWithHttpInfo();
        /// <summary>
        /// Queue up all the running workflows for sweep
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <returns>string</returns>
        string RequeueSweep(string workflowId);

        /// <summary>
        /// Queue up all the running workflows for sweep
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <returns>ApiResponse of string</returns>
        ApiResponse<string> RequeueSweepWithHttpInfo(string workflowId);
        /// <summary>
        /// Verify and repair workflow consistency
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <returns>string</returns>
        string VerifyAndRepairWorkflowConsistency(string workflowId);

        /// <summary>
        /// Verify and repair workflow consistency
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <returns>ApiResponse of string</returns>
        ApiResponse<string> VerifyAndRepairWorkflowConsistencyWithHttpInfo(string workflowId);
        /// <summary>
        /// Get the list of pending tasks for a given task type
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tasktype"></param>
        /// <param name="start"> (optional, default to 0)</param>
        /// <param name="count"> (optional, default to 100)</param>
        /// <returns>List&lt;Task&gt;</returns>
        List<Task> View(string tasktype, int? start = null, int? count = null);

        /// <summary>
        /// Get the list of pending tasks for a given task type
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tasktype"></param>
        /// <param name="start"> (optional, default to 0)</param>
        /// <param name="count"> (optional, default to 100)</param>
        /// <returns>ApiResponse of List&lt;Task&gt;</returns>
        ApiResponse<List<Task>> ViewWithHttpInfo(string tasktype, int? start = null, int? count = null);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Get details of redis usage
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of Dictionary&lt;string, Object&gt;</returns>
        System.Threading.Tasks.Task<Dictionary<string, Object>> GetRedisUsageAsync();

        /// <summary>
        /// Get details of redis usage
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (Dictionary&lt;string, Object&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<Dictionary<string, Object>>> GetRedisUsageAsyncWithHttpInfo();
        /// <summary>
        /// Queue up all the running workflows for sweep
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <returns>Task of string</returns>
        System.Threading.Tasks.Task<string> RequeueSweepAsync(string workflowId);

        /// <summary>
        /// Queue up all the running workflows for sweep
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <returns>Task of ApiResponse (string)</returns>
        System.Threading.Tasks.Task<ApiResponse<string>> RequeueSweepAsyncWithHttpInfo(string workflowId);
        /// <summary>
        /// Verify and repair workflow consistency
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <returns>Task of string</returns>
        System.Threading.Tasks.Task<string> VerifyAndRepairWorkflowConsistencyAsync(string workflowId);

        /// <summary>
        /// Verify and repair workflow consistency
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <returns>Task of ApiResponse (string)</returns>
        System.Threading.Tasks.Task<ApiResponse<string>> VerifyAndRepairWorkflowConsistencyAsyncWithHttpInfo(string workflowId);
        /// <summary>
        /// Get the list of pending tasks for a given task type
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tasktype"></param>
        /// <param name="start"> (optional, default to 0)</param>
        /// <param name="count"> (optional, default to 100)</param>
        /// <returns>Task of List&lt;Task&gt;</returns>
        System.Threading.Tasks.Task<List<Task>> ViewAsync(string tasktype, int? start = null, int? count = null);

        /// <summary>
        /// Get the list of pending tasks for a given task type
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tasktype"></param>
        /// <param name="start"> (optional, default to 0)</param>
        /// <param name="count"> (optional, default to 100)</param>
        /// <returns>Task of ApiResponse (List&lt;Task&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<Task>>> ViewAsyncWithHttpInfo(string tasktype, int? start = null, int? count = null);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class AdminResourceApi : IAdminResourceApi
    {
        private Conductor.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminResourceApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AdminResourceApi(String basePath)
        {
            this.Configuration = new Conductor.Client.Configuration { BasePath = basePath };

            ExceptionFactory = Conductor.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminResourceApi"/> class
        /// </summary>
        /// <returns></returns>
        public AdminResourceApi()
        {
            this.Configuration = Conductor.Client.Configuration.Default;

            ExceptionFactory = Conductor.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminResourceApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public AdminResourceApi(Conductor.Client.Configuration configuration = null)
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
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
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
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public IDictionary<String, String> DefaultHeader()
        {
            return new ReadOnlyDictionary<string, string>(this.Configuration.DefaultHeader);
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// Get details of redis usage 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Dictionary&lt;string, Object&gt;</returns>
        public Dictionary<string, Object> GetRedisUsage()
        {
            ApiResponse<Dictionary<string, Object>> localVarResponse = GetRedisUsageWithHttpInfo();
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get details of redis usage 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Dictionary&lt;string, Object&gt;</returns>
        public ApiResponse<Dictionary<string, Object>> GetRedisUsageWithHttpInfo()
        {

            var localVarPath = "/admin/redisUsage";
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
                "*/*"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Authorization")))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.GetApiKeyWithPrefix("X-Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetRedisUsage", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Dictionary<string, Object>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (Dictionary<string, Object>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Dictionary<string, Object>)));
        }

        /// <summary>
        /// Get details of redis usage 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of Dictionary&lt;string, Object&gt;</returns>
        [Obsolete]
        public async System.Threading.Tasks.Task<Dictionary<string, Object>> GetRedisUsageAsync()
        {
            ApiResponse<Dictionary<string, Object>> localVarResponse = await GetRedisUsageAsyncWithHttpInfo();
            return localVarResponse.Data;

        }

        /// <summary>
        /// Get details of redis usage 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (Dictionary&lt;string, Object&gt;)</returns>
        [Obsolete]
        public async System.Threading.Tasks.Task<ApiResponse<Dictionary<string, Object>>> GetRedisUsageAsyncWithHttpInfo()
        {

            var localVarPath = "/admin/redisUsage";
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
                "*/*"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Authorization")))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.GetApiKeyWithPrefix("X-Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetRedisUsage", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Dictionary<string, Object>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (Dictionary<string, Object>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Dictionary<string, Object>)));
        }

        /// <summary>
        /// Queue up all the running workflows for sweep 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <returns>string</returns>
        public string RequeueSweep(string workflowId)
        {
            ApiResponse<string> localVarResponse = RequeueSweepWithHttpInfo(workflowId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Queue up all the running workflows for sweep 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <returns>ApiResponse of string</returns>
        public ApiResponse<string> RequeueSweepWithHttpInfo(string workflowId)
        {
            // verify the required parameter 'workflowId' is set
            if (workflowId == null)
                throw new ApiException(400, "Missing required parameter 'workflowId' when calling AdminResourceApi->RequeueSweep");

            var localVarPath = "/admin/sweep/requeue/{workflowId}";
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
                "text/plain"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (workflowId != null) localVarPathParams.Add("workflowId", this.Configuration.ApiClient.ParameterToString(workflowId)); // path parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Authorization")))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.GetApiKeyWithPrefix("X-Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("RequeueSweep", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<string>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (string)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(string)));
        }

        /// <summary>
        /// Queue up all the running workflows for sweep 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <returns>Task of string</returns>
        [Obsolete]
        public async System.Threading.Tasks.Task<string> RequeueSweepAsync(string workflowId)
        {
            ApiResponse<string> localVarResponse = await RequeueSweepAsyncWithHttpInfo(workflowId);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Queue up all the running workflows for sweep 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <returns>Task of ApiResponse (string)</returns>
        [Obsolete]
        public async System.Threading.Tasks.Task<ApiResponse<string>> RequeueSweepAsyncWithHttpInfo(string workflowId)
        {
            // verify the required parameter 'workflowId' is set
            if (workflowId == null)
                throw new ApiException(400, "Missing required parameter 'workflowId' when calling AdminResourceApi->RequeueSweep");

            var localVarPath = "/admin/sweep/requeue/{workflowId}";
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
                "text/plain"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (workflowId != null) localVarPathParams.Add("workflowId", this.Configuration.ApiClient.ParameterToString(workflowId)); // path parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Authorization")))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.GetApiKeyWithPrefix("X-Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("RequeueSweep", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<string>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (string)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(string)));
        }

        /// <summary>
        /// Verify and repair workflow consistency 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <returns>string</returns>
        public string VerifyAndRepairWorkflowConsistency(string workflowId)
        {
            ApiResponse<string> localVarResponse = VerifyAndRepairWorkflowConsistencyWithHttpInfo(workflowId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Verify and repair workflow consistency 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <returns>ApiResponse of string</returns>
        public ApiResponse<string> VerifyAndRepairWorkflowConsistencyWithHttpInfo(string workflowId)
        {
            // verify the required parameter 'workflowId' is set
            if (workflowId == null)
                throw new ApiException(400, "Missing required parameter 'workflowId' when calling AdminResourceApi->VerifyAndRepairWorkflowConsistency");

            var localVarPath = "/admin/consistency/verifyAndRepair/{workflowId}";
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
                "text/plain"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (workflowId != null) localVarPathParams.Add("workflowId", this.Configuration.ApiClient.ParameterToString(workflowId)); // path parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Authorization")))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.GetApiKeyWithPrefix("X-Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("VerifyAndRepairWorkflowConsistency", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<string>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (string)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(string)));
        }

        /// <summary>
        /// Verify and repair workflow consistency 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <returns>Task of string</returns>
        [Obsolete]
        public async System.Threading.Tasks.Task<string> VerifyAndRepairWorkflowConsistencyAsync(string workflowId)
        {
            ApiResponse<string> localVarResponse = await VerifyAndRepairWorkflowConsistencyAsyncWithHttpInfo(workflowId);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Verify and repair workflow consistency 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <returns>Task of ApiResponse (string)</returns>
        [Obsolete]
        public async System.Threading.Tasks.Task<ApiResponse<string>> VerifyAndRepairWorkflowConsistencyAsyncWithHttpInfo(string workflowId)
        {
            // verify the required parameter 'workflowId' is set
            if (workflowId == null)
                throw new ApiException(400, "Missing required parameter 'workflowId' when calling AdminResourceApi->VerifyAndRepairWorkflowConsistency");

            var localVarPath = "/admin/consistency/verifyAndRepair/{workflowId}";
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
                "text/plain"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (workflowId != null) localVarPathParams.Add("workflowId", this.Configuration.ApiClient.ParameterToString(workflowId)); // path parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Authorization")))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.GetApiKeyWithPrefix("X-Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("VerifyAndRepairWorkflowConsistency", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<string>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (string)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(string)));
        }

        /// <summary>
        /// Get the list of pending tasks for a given task type 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tasktype"></param>
        /// <param name="start"> (optional, default to 0)</param>
        /// <param name="count"> (optional, default to 100)</param>
        /// <returns>List&lt;Task&gt;</returns>
        public List<Task> View(string tasktype, int? start = null, int? count = null)
        {
            ApiResponse<List<Task>> localVarResponse = ViewWithHttpInfo(tasktype, start, count);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get the list of pending tasks for a given task type 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tasktype"></param>
        /// <param name="start"> (optional, default to 0)</param>
        /// <param name="count"> (optional, default to 100)</param>
        /// <returns>ApiResponse of List&lt;Task&gt;</returns>
        public ApiResponse<List<Task>> ViewWithHttpInfo(string tasktype, int? start = null, int? count = null)
        {
            // verify the required parameter 'tasktype' is set
            if (tasktype == null)
                throw new ApiException(400, "Missing required parameter 'tasktype' when calling AdminResourceApi->View");

            var localVarPath = "/admin/task/{tasktype}";
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
                "*/*"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (tasktype != null) localVarPathParams.Add("tasktype", this.Configuration.ApiClient.ParameterToString(tasktype)); // path parameter
            if (start != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "start", start)); // query parameter
            if (count != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "count", count)); // query parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Authorization")))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.GetApiKeyWithPrefix("X-Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("View", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<Task>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (List<Task>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Task>)));
        }

        /// <summary>
        /// Get the list of pending tasks for a given task type 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tasktype"></param>
        /// <param name="start"> (optional, default to 0)</param>
        /// <param name="count"> (optional, default to 100)</param>
        /// <returns>Task of List&lt;Task&gt;</returns>
        [Obsolete]
        public async System.Threading.Tasks.Task<List<Task>> ViewAsync(string tasktype, int? start = null, int? count = null)
        {
            ApiResponse<List<Task>> localVarResponse = await ViewAsyncWithHttpInfo(tasktype, start, count);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Get the list of pending tasks for a given task type 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tasktype"></param>
        /// <param name="start"> (optional, default to 0)</param>
        /// <param name="count"> (optional, default to 100)</param>
        /// <returns>Task of ApiResponse (List&lt;Task&gt;)</returns>
        [Obsolete]
        public async System.Threading.Tasks.Task<ApiResponse<List<Task>>> ViewAsyncWithHttpInfo(string tasktype, int? start = null, int? count = null)
        {
            // verify the required parameter 'tasktype' is set
            if (tasktype == null)
                throw new ApiException(400, "Missing required parameter 'tasktype' when calling AdminResourceApi->View");

            var localVarPath = "/admin/task/{tasktype}";
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
                "*/*"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (tasktype != null) localVarPathParams.Add("tasktype", this.Configuration.ApiClient.ParameterToString(tasktype)); // path parameter
            if (start != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "start", start)); // query parameter
            if (count != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "count", count)); // query parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Authorization")))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.GetApiKeyWithPrefix("X-Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("View", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<Task>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (List<Task>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Task>)));
        }

    }
}
