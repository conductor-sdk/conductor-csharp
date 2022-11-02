
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using Conductor.Client;

namespace Conductor.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
        public interface IMigrationResourceApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Migrate Workflow Index t o the sharded table
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>int?</returns>
        int? MigrateIndex ();

        /// <summary>
        /// Migrate Workflow Index t o the sharded table
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of int?</returns>
        ApiResponse<int?> MigrateIndexWithHttpInfo ();
        /// <summary>
        /// Migrate Workflow and Task Definitions to Postgres
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns></returns>
        void MigrateMetadata ();

        /// <summary>
        /// Migrate Workflow and Task Definitions to Postgres
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> MigrateMetadataWithHttpInfo ();
        /// <summary>
        /// Migrate workflows from Redis to Postgres
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="batchSize"></param>
        /// <param name="startFromTimestamp"></param>
        /// <returns>Dictionary&lt;string, Object&gt;</returns>
        Dictionary<string, Object> MigrateWorkflows (int? batchSize, long? startFromTimestamp);

        /// <summary>
        /// Migrate workflows from Redis to Postgres
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="batchSize"></param>
        /// <param name="startFromTimestamp"></param>
        /// <returns>ApiResponse of Dictionary&lt;string, Object&gt;</returns>
        ApiResponse<Dictionary<string, Object>> MigrateWorkflowsWithHttpInfo (int? batchSize, long? startFromTimestamp);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Migrate Workflow Index t o the sharded table
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of int?</returns>
        System.Threading.Tasks.Task<int?> MigrateIndexAsync ();

        /// <summary>
        /// Migrate Workflow Index t o the sharded table
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (int?)</returns>
        System.Threading.Tasks.Task<ApiResponse<int?>> MigrateIndexAsyncWithHttpInfo ();
        /// <summary>
        /// Migrate Workflow and Task Definitions to Postgres
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task MigrateMetadataAsync ();

        /// <summary>
        /// Migrate Workflow and Task Definitions to Postgres
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> MigrateMetadataAsyncWithHttpInfo ();
        /// <summary>
        /// Migrate workflows from Redis to Postgres
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="batchSize"></param>
        /// <param name="startFromTimestamp"></param>
        /// <returns>Task of Dictionary&lt;string, Object&gt;</returns>
        System.Threading.Tasks.Task<Dictionary<string, Object>> MigrateWorkflowsAsync (int? batchSize, long? startFromTimestamp);

        /// <summary>
        /// Migrate workflows from Redis to Postgres
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="batchSize"></param>
        /// <param name="startFromTimestamp"></param>
        /// <returns>Task of ApiResponse (Dictionary&lt;string, Object&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<Dictionary<string, Object>>> MigrateWorkflowsAsyncWithHttpInfo (int? batchSize, long? startFromTimestamp);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
        public partial class MigrationResourceApi : IMigrationResourceApi
    {
        private Conductor.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="MigrationResourceApi"/> class.
        /// </summary>
        /// <returns></returns>
        public MigrationResourceApi(String basePath)
        {
            this.Configuration = new Conductor.Client.Configuration { BasePath = basePath };

            ExceptionFactory = Conductor.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MigrationResourceApi"/> class
        /// </summary>
        /// <returns></returns>
        public MigrationResourceApi()
        {
            this.Configuration = Conductor.Client.Configuration.Default;

            ExceptionFactory = Conductor.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MigrationResourceApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public MigrationResourceApi(Conductor.Client.Configuration configuration = null)
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
        public Conductor.Client.Configuration Configuration {get; set;}

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
        /// Migrate Workflow Index t o the sharded table 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>int?</returns>
        public int? MigrateIndex ()
        {
             ApiResponse<int?> localVarResponse = MigrateIndexWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Migrate Workflow Index t o the sharded table 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of int?</returns>
        public ApiResponse< int? > MigrateIndexWithHttpInfo ()
        {

            var localVarPath = "/api/admin/migrate_index";
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
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("MigrateIndex", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<int?>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (int?) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(int?)));
        }

        /// <summary>
        /// Migrate Workflow Index t o the sharded table 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of int?</returns>
        public async System.Threading.Tasks.Task<int?> MigrateIndexAsync ()
        {
             ApiResponse<int?> localVarResponse = await MigrateIndexAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        /// Migrate Workflow Index t o the sharded table 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (int?)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<int?>> MigrateIndexAsyncWithHttpInfo ()
        {

            var localVarPath = "/api/admin/migrate_index";
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
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("MigrateIndex", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<int?>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (int?) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(int?)));
        }

        /// <summary>
        /// Migrate Workflow and Task Definitions to Postgres 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns></returns>
        public void MigrateMetadata ()
        {
             MigrateMetadataWithHttpInfo();
        }

        /// <summary>
        /// Migrate Workflow and Task Definitions to Postgres 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> MigrateMetadataWithHttpInfo ()
        {

            var localVarPath = "/api/admin/migrate_metadata";
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

            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Authorization")))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.GetApiKeyWithPrefix("X-Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("MigrateMetadata", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        /// Migrate Workflow and Task Definitions to Postgres 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task MigrateMetadataAsync ()
        {
             await MigrateMetadataAsyncWithHttpInfo();

        }

        /// <summary>
        /// Migrate Workflow and Task Definitions to Postgres 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> MigrateMetadataAsyncWithHttpInfo ()
        {

            var localVarPath = "/api/admin/migrate_metadata";
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

            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Authorization")))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.GetApiKeyWithPrefix("X-Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("MigrateMetadata", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        /// Migrate workflows from Redis to Postgres 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="batchSize"></param>
        /// <param name="startFromTimestamp"></param>
        /// <returns>Dictionary&lt;string, Object&gt;</returns>
        public Dictionary<string, Object> MigrateWorkflows (int? batchSize, long? startFromTimestamp)
        {
             ApiResponse<Dictionary<string, Object>> localVarResponse = MigrateWorkflowsWithHttpInfo(batchSize, startFromTimestamp);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Migrate workflows from Redis to Postgres 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="batchSize"></param>
        /// <param name="startFromTimestamp"></param>
        /// <returns>ApiResponse of Dictionary&lt;string, Object&gt;</returns>
        public ApiResponse< Dictionary<string, Object> > MigrateWorkflowsWithHttpInfo (int? batchSize, long? startFromTimestamp)
        {
            // verify the required parameter 'batchSize' is set
            if (batchSize == null)
                throw new ApiException(400, "Missing required parameter 'batchSize' when calling MigrationResourceApi->MigrateWorkflows");
            // verify the required parameter 'startFromTimestamp' is set
            if (startFromTimestamp == null)
                throw new ApiException(400, "Missing required parameter 'startFromTimestamp' when calling MigrationResourceApi->MigrateWorkflows");

            var localVarPath = "/api/admin/migrate_workflow";
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

            if (batchSize != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "batchSize", batchSize)); // query parameter
            if (startFromTimestamp != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "startFromTimestamp", startFromTimestamp)); // query parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Authorization")))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.GetApiKeyWithPrefix("X-Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("MigrateWorkflows", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Dictionary<string, Object>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (Dictionary<string, Object>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Dictionary<string, Object>)));
        }

        /// <summary>
        /// Migrate workflows from Redis to Postgres 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="batchSize"></param>
        /// <param name="startFromTimestamp"></param>
        /// <returns>Task of Dictionary&lt;string, Object&gt;</returns>
        public async System.Threading.Tasks.Task<Dictionary<string, Object>> MigrateWorkflowsAsync (int? batchSize, long? startFromTimestamp)
        {
             ApiResponse<Dictionary<string, Object>> localVarResponse = await MigrateWorkflowsAsyncWithHttpInfo(batchSize, startFromTimestamp);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Migrate workflows from Redis to Postgres 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="batchSize"></param>
        /// <param name="startFromTimestamp"></param>
        /// <returns>Task of ApiResponse (Dictionary&lt;string, Object&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Dictionary<string, Object>>> MigrateWorkflowsAsyncWithHttpInfo (int? batchSize, long? startFromTimestamp)
        {
            // verify the required parameter 'batchSize' is set
            if (batchSize == null)
                throw new ApiException(400, "Missing required parameter 'batchSize' when calling MigrationResourceApi->MigrateWorkflows");
            // verify the required parameter 'startFromTimestamp' is set
            if (startFromTimestamp == null)
                throw new ApiException(400, "Missing required parameter 'startFromTimestamp' when calling MigrationResourceApi->MigrateWorkflows");

            var localVarPath = "/api/admin/migrate_workflow";
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

            if (batchSize != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "batchSize", batchSize)); // query parameter
            if (startFromTimestamp != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "startFromTimestamp", startFromTimestamp)); // query parameter
            // authentication (api_key) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("X-Authorization")))
            {
                localVarHeaderParams["X-Authorization"] = this.Configuration.GetApiKeyWithPrefix("X-Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("MigrateWorkflows", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Dictionary<string, Object>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (Dictionary<string, Object>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Dictionary<string, Object>)));
        }

    }
}
