using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using Conductor.Client;
using Conductor.Client.Models;
using ThreadTask = System.Threading.Tasks;
using conductor_csharp.Api;

namespace Conductor.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ApplicationResourceApi : IApplicationResourceApi
    {
        private Conductor.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationResourceApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ApplicationResourceApi(String basePath)
        {
            this.Configuration = new Conductor.Client.Configuration { BasePath = basePath };

            ExceptionFactory = Conductor.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationResourceApi"/> class
        /// </summary>
        /// <returns></returns>
        public ApplicationResourceApi()
        {
            this.Configuration = Conductor.Client.Configuration.Default;

            ExceptionFactory = Conductor.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationResourceApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ApplicationResourceApi(Conductor.Client.Configuration configuration = null)
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
        /// Add role to Application User
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="applicationId"></param>
        /// <param name="role"></param>
        /// <returns>Object</returns>
        public Object AddRoleToApplicationUser(string applicationId, string role)
        {
            ApiResponse<object> localVarResponse = AddRoleToApplicationUserWithHttpInfo(applicationId, role);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Asynchronous Add role to Application User
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="applicationId"></param>
        /// <param name="role"></param>
        /// <returns>Object</returns>
        public async ThreadTask.Task<object> AddRoleToApplicationUserAsync(string applicationId, string role)
        {
            ApiResponse<object> localVarResponse = await ThreadTask.Task.FromResult(AddRoleToApplicationUserWithHttpInfo(applicationId, role));
            return localVarResponse.Data;
        }

        /// <summary>
        ///  Add role to Application User
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="applicationId"></param>
        /// <param name="role"></param>
        /// <returns>ApiResponse of Object</returns>
        public ApiResponse<object> AddRoleToApplicationUserWithHttpInfo(string applicationId, string role)
        {
            // verify the required parameter 'applicationId' is set
            if (applicationId == null)
                throw new ApiException(400, "Missing required parameter 'applicationId' when calling ApplicationResourceApi->AddRoleToApplicationUser");
            // verify the required parameter 'role' is set
            if (role == null)
                throw new ApiException(400, "Missing required parameter 'role' when calling ApplicationResourceApi->AddRoleToApplicationUser");

            var localVarPath = "/applications/{applicationId}/roles/{role}";
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

            if (applicationId != null) localVarPathParams.Add("applicationId", this.Configuration.ApiClient.ParameterToString(applicationId)); // path parameter
            if (role != null) localVarPathParams.Add("role", this.Configuration.ApiClient.ParameterToString(role)); // path parameter
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
                Exception exception = ExceptionFactory("AddRoleToApplicationUser", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
             localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
             (Object)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Object)));
        }

        /// <summary>
        /// Create an access key for an application 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        public Object CreateAccessKey(string id)
        {
            ApiResponse<object> localVarResponse = CreateAccessKeyWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Asynchronous Create an access key for an application 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        public async ThreadTask.Task<object> CreateAccessKeyAsync(string id)
        {
            ApiResponse<object> localVarResponse = await ThreadTask.Task.FromResult(CreateAccessKeyWithHttpInfo(id));
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create an access key for an application 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>ApiResponse of Object</returns>
        public ApiResponse<object> CreateAccessKeyWithHttpInfo(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling ApplicationResourceApi->CreateAccessKey");

            var localVarPath = "/applications/{id}/accessKeys";
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

            if (id != null) localVarPathParams.Add("id", this.Configuration.ApiClient.ParameterToString(id)); // path parameter
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
                Exception exception = ExceptionFactory("CreateAccessKey", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
             localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
             (Object)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Object)));
        }

        /// <summary>
        /// Create an application 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>Object</returns>
        public Object CreateApplication(CreateOrUpdateApplicationRequest body)
        {
            ApiResponse<object> localVarResponse = CreateApplicationWithHttpInfo(body);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Asynchronous Create an application 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>Object</returns>
        public async ThreadTask.Task<object> CreateApplicationAsync(CreateOrUpdateApplicationRequest body)
        {
            ApiResponse<object> localVarResponse = await ThreadTask.Task.FromResult(CreateApplicationWithHttpInfo(body));
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create an application 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>ApiResponse of Object</returns>
        public ApiResponse<object> CreateApplicationWithHttpInfo(CreateOrUpdateApplicationRequest body)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling ApplicationResourceApi->CreateApplication");

            var localVarPath = "/applications";
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
                Exception exception = ExceptionFactory("CreateApplication", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
             localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
             (Object)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Object)));
        }

        /// <summary>
        /// Delete an access key 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="applicationId"></param>
        /// <param name="keyId"></param>
        /// <returns>Object</returns>
        public Object DeleteAccessKey(string applicationId, string keyId)
        {
            ApiResponse<object> localVarResponse = DeleteAccessKeyWithHttpInfo(applicationId, keyId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Asynchronous Delete an access key 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="applicationId"></param>
        /// <param name="keyId"></param>
        /// <returns>Object</returns>
        public async ThreadTask.Task<object> DeleteAccessKeyAsync(string applicationId, string keyId)
        {
            ApiResponse<object> localVarResponse = await ThreadTask.Task.FromResult(DeleteAccessKeyWithHttpInfo(applicationId, keyId));
            return localVarResponse.Data;
        }

        /// <summary>
        /// Delete an access key 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="applicationId"></param>
        /// <param name="keyId"></param>
        /// <returns>ApiResponse of Object</returns>
        public ApiResponse<object> DeleteAccessKeyWithHttpInfo(string applicationId, string keyId)
        {
            // verify the required parameter 'applicationId' is set
            if (applicationId == null)
                throw new ApiException(400, "Missing required parameter 'applicationId' when calling ApplicationResourceApi->DeleteAccessKey");
            // verify the required parameter 'keyId' is set
            if (keyId == null)
                throw new ApiException(400, "Missing required parameter 'keyId' when calling ApplicationResourceApi->DeleteAccessKey");

            var localVarPath = "/applications/{applicationId}/accessKeys/{keyId}";
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

            if (applicationId != null) localVarPathParams.Add("applicationId", this.Configuration.ApiClient.ParameterToString(applicationId)); // path parameter
            if (keyId != null) localVarPathParams.Add("keyId", this.Configuration.ApiClient.ParameterToString(keyId)); // path parameter
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
                Exception exception = ExceptionFactory("DeleteAccessKey", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
             localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
             (Object)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Object)));
        }

        /// <summary>
        /// Delete an application 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        public Object DeleteApplication(string id)
        {
            ApiResponse<object> localVarResponse = DeleteApplicationWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Asynchronous Delete an application 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        public async ThreadTask.Task<object> DeleteApplicationAsync(string id)
        {
            ApiResponse<object> localVarResponse = await ThreadTask.Task.FromResult(DeleteApplicationWithHttpInfo(id));
            return localVarResponse.Data;
        }

        /// <summary>
        /// Delete an application 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>ApiResponse of Object</returns>
        public ApiResponse<object> DeleteApplicationWithHttpInfo(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling ApplicationResourceApi->DeleteApplication");

            var localVarPath = "/applications/{id}";
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

            if (id != null) localVarPathParams.Add("id", this.Configuration.ApiClient.ParameterToString(id)); // path parameter
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
                Exception exception = ExceptionFactory("DeleteApplication", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
             localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
             (Object)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Object)));
        }

        /// <summary>
        /// Delete a tag for application 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public void DeleteTagForApplication(List<TagObject> body, string id)
        {
            DeleteTagForApplicationWithHttpInfo(body, id);
        }


        /// <summary>
        /// Asynchronous Delete a tag for application 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async void DeleteTagForApplicationAsync(List<TagObject> body, string id)
        {
            await ThreadTask.Task.FromResult(DeleteTagForApplicationWithHttpInfo(body, id));
        }

        /// <summary>
        /// Delete a tag for application 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="id"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> DeleteTagForApplicationWithHttpInfo(List<TagObject> body, string id)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling ApplicationResourceApi->DeleteTagForApplication");
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling ApplicationResourceApi->DeleteTagForApplication");

            var localVarPath = "/applications/{id}/tags";
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

            if (id != null) localVarPathParams.Add("id", this.Configuration.ApiClient.ParameterToString(id)); // path parameter
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
             Method.Delete, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
             localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("DeleteTagForApplication", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
             localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
             null);
        }

        /// <summary>
        /// Get application&#x27;s access keys 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        public Object GetAccessKeys(string id)
        {
            ApiResponse<object> localVarResponse = GetAccessKeysWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Asynchronous Get application&#x27;s access keys 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        public async ThreadTask.Task<object> GetAccessKeysAsync(string id)
        {
            ApiResponse<object> localVarResponse = await ThreadTask.Task.FromResult(GetAccessKeysWithHttpInfo(id));
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get application&#x27;s access keys 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>ApiResponse of Object</returns>
        public ApiResponse<object> GetAccessKeysWithHttpInfo(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling ApplicationResourceApi->GetAccessKeys");

            var localVarPath = "/applications/{id}/accessKeys";
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

            if (id != null) localVarPathParams.Add("id", this.Configuration.ApiClient.ParameterToString(id)); // path parameter
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
                Exception exception = ExceptionFactory("GetAccessKeys", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
             localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
             (Object)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Object)));
        }

        /// <summary>
        /// Get application id by access key id 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accessKeyId"></param>
        /// <returns>Object</returns>
        public Object GetAppByAccessKeyId(string accessKeyId)
        {
            ApiResponse<object> localVarResponse = GetAppByAccessKeyIdWithHttpInfo(accessKeyId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Asynchronous Get application id by access key id 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accessKeyId"></param>
        /// <returns>Object</returns>
        public async ThreadTask.Task<object> GetAppByAccessKeyIdAsync(string accessKeyId)
        {
            ApiResponse<object> localVarResponse = await ThreadTask.Task.FromResult(GetAppByAccessKeyIdWithHttpInfo(accessKeyId));
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get application id by access key id 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accessKeyId"></param>
        /// <returns>ApiResponse of Object</returns>
        public ApiResponse<object> GetAppByAccessKeyIdWithHttpInfo(string accessKeyId)
        {
            // verify the required parameter 'accessKeyId' is set
            if (accessKeyId == null)
                throw new ApiException(400, "Missing required parameter 'accessKeyId' when calling ApplicationResourceApi->GetAppByAccessKeyId");

            var localVarPath = "/applications/key/{accessKeyId}";
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

            if (accessKeyId != null) localVarPathParams.Add("accessKeyId", this.Configuration.ApiClient.ParameterToString(accessKeyId)); // path parameter
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
                Exception exception = ExceptionFactory("GetAppByAccessKeyId", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
             localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
             (Object)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Object)));
        }

        /// <summary>
        /// Get an application by id 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        public Object GetApplication(string id)
        {
            ApiResponse<object> localVarResponse = GetApplicationWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Asynchronous Get an application by id 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        public async ThreadTask.Task<object> GetApplicationAsync(string id)
        {
            ApiResponse<object> localVarResponse = await ThreadTask.Task.FromResult(GetApplicationWithHttpInfo(id));
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get an application by id 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>ApiResponse of Object</returns>
        public ApiResponse<object> GetApplicationWithHttpInfo(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling ApplicationResourceApi->GetApplication");

            var localVarPath = "/applications/{id}";
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

            if (id != null) localVarPathParams.Add("id", this.Configuration.ApiClient.ParameterToString(id)); // path parameter
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
                Exception exception = ExceptionFactory("GetApplication", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
             localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
             (Object)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Object)));
        }

        /// <summary>
        /// Get tags by application 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>List&lt;TagObject&gt;</returns>
        public List<TagObject> GetTagsForApplication(string id)
        {
            ApiResponse<List<TagObject>> localVarResponse = GetTagsForApplicationWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Asynchronous Get tags by application 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>List&lt;TagObject&gt;</returns>
        public async ThreadTask.Task<List<TagObject>> GetTagsForApplicationAsync(string id)
        {
            ApiResponse<List<TagObject>> localVarResponse = await ThreadTask.Task.FromResult(GetTagsForApplicationWithHttpInfo(id));
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get tags by application 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>ApiResponse of List&lt;TagObject&gt;</returns>
        public ApiResponse<List<TagObject>> GetTagsForApplicationWithHttpInfo(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling ApplicationResourceApi->GetTagsForApplication");

            var localVarPath = "/applications/{id}/tags";
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

            if (id != null) localVarPathParams.Add("id", this.Configuration.ApiClient.ParameterToString(id)); // path parameter
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
                Exception exception = ExceptionFactory("GetTagsForApplication", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<TagObject>>(localVarStatusCode,
             localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
             (List<TagObject>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<TagObject>)));
        }

        /// <summary>
        /// Get all applications 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;ExtendedConductorApplication&gt;</returns>
        public List<ExtendedConductorApplication> ListApplications()
        {
            ApiResponse<List<ExtendedConductorApplication>> localVarResponse = ListApplicationsWithHttpInfo();
            return localVarResponse.Data;
        }

        /// <summary>
        /// Asynchronous Get all applications 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;ExtendedConductorApplication&gt;</returns>
        public async ThreadTask.Task<List<ExtendedConductorApplication>> ListApplicationsAsync()
        {
            ApiResponse<List<ExtendedConductorApplication>> localVarResponse = await ThreadTask.Task.FromResult(ListApplicationsWithHttpInfo());
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get all applications 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;ExtendedConductorApplication&gt;</returns>
        public ApiResponse<List<ExtendedConductorApplication>> ListApplicationsWithHttpInfo()
        {

            var localVarPath = "/applications";
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
                Exception exception = ExceptionFactory("ListApplications", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<ExtendedConductorApplication>>(localVarStatusCode,
             localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
             (List<ExtendedConductorApplication>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<ExtendedConductorApplication>)));
        }

        /// <summary>
        /// Put a tag to application 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public void PutTagForApplication(List<TagObject> body, string id)
        {
            PutTagForApplicationWithHttpInfo(body, id);
        }

        /// <summary>
        /// Asynchronous Put a tag to application 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async void PutTagForApplicationAsync(List<TagObject> body, string id)
        {
            await ThreadTask.Task.FromResult(PutTagForApplicationWithHttpInfo(body, id));
        }

        /// <summary>
        /// Put a tag to application 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="id"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> PutTagForApplicationWithHttpInfo(List<TagObject> body, string id)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling ApplicationResourceApi->PutTagForApplication");
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling ApplicationResourceApi->PutTagForApplication");

            var localVarPath = "/applications/{id}/tags";
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

            if (id != null) localVarPathParams.Add("id", this.Configuration.ApiClient.ParameterToString(id)); // path parameter
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
             Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
             localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PutTagForApplication", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
             localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
             null);
        }

        /// <summary>
        ///  Remove Role from Aplication user
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="applicationId"></param>
        /// <param name="role"></param>
        /// <returns>Object</returns>
        public Object RemoveRoleFromApplicationUser(string applicationId, string role)
        {
            ApiResponse<object> localVarResponse = RemoveRoleFromApplicationUserWithHttpInfo(applicationId, role);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Asynchronous Remove Role from Aplication user
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public async ThreadTask.Task<object> RemoveRoleFromApplicationUserAsync(string applicationId, string role)
        {
            ApiResponse<object> localVarResponse = await ThreadTask.Task.FromResult(RemoveRoleFromApplicationUserWithHttpInfo(applicationId, role));
            return localVarResponse.Data;
        }

        /// <summary>
        ///  Remove Role from Aplication use
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="applicationId"></param>
        /// <param name="role"></param>
        /// <returns>ApiResponse of Object</returns>
        public ApiResponse<object> RemoveRoleFromApplicationUserWithHttpInfo(string applicationId, string role)
        {
            // verify the required parameter 'applicationId' is set
            if (applicationId == null)
                throw new ApiException(400, "Missing required parameter 'applicationId' when calling ApplicationResourceApi->RemoveRoleFromApplicationUser");
            // verify the required parameter 'role' is set
            if (role == null)
                throw new ApiException(400, "Missing required parameter 'role' when calling ApplicationResourceApi->RemoveRoleFromApplicationUser");

            var localVarPath = "/applications/{applicationId}/roles/{role}";
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

            if (applicationId != null) localVarPathParams.Add("applicationId", this.Configuration.ApiClient.ParameterToString(applicationId)); // path parameter
            if (role != null) localVarPathParams.Add("role", this.Configuration.ApiClient.ParameterToString(role)); // path parameter
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
                Exception exception = ExceptionFactory("RemoveRoleFromApplicationUser", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
             localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
             (Object)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Object)));
        }

        /// <summary>
        /// Toggle the status of an access key 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="applicationId"></param>
        /// <param name="keyId"></param>
        /// <returns>Object</returns>
        public Object ToggleAccessKeyStatus(string applicationId, string keyId)
        {
            ApiResponse<object> localVarResponse = ToggleAccessKeyStatusWithHttpInfo(applicationId, keyId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Asynchronous Toggle the status of an access key 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="applicationId"></param>
        /// <param name="keyId"></param>
        /// <returns>Object</returns>
        public async ThreadTask.Task<object> ToggleAccessKeyStatusAsync(string applicationId, string keyId)
        {
            ApiResponse<object> localVarResponse = await ThreadTask.Task.FromResult(ToggleAccessKeyStatusWithHttpInfo(applicationId, keyId));
            return localVarResponse.Data;
        }

        /// <summary>
        /// Toggle the status of an access key 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="applicationId"></param>
        /// <param name="keyId"></param>
        /// <returns>ApiResponse of Object</returns>
        public ApiResponse<object> ToggleAccessKeyStatusWithHttpInfo(string applicationId, string keyId)
        {
            // verify the required parameter 'applicationId' is set
            if (applicationId == null)
                throw new ApiException(400, "Missing required parameter 'applicationId' when calling ApplicationResourceApi->ToggleAccessKeyStatus");
            // verify the required parameter 'keyId' is set
            if (keyId == null)
                throw new ApiException(400, "Missing required parameter 'keyId' when calling ApplicationResourceApi->ToggleAccessKeyStatus");

            var localVarPath = "/applications/{applicationId}/accessKeys/{keyId}/status";
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

            if (applicationId != null) localVarPathParams.Add("applicationId", this.Configuration.ApiClient.ParameterToString(applicationId)); // path parameter
            if (keyId != null) localVarPathParams.Add("keyId", this.Configuration.ApiClient.ParameterToString(keyId)); // path parameter
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
                Exception exception = ExceptionFactory("ToggleAccessKeyStatus", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
             localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
             (Object)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Object)));
        }

        /// <summary>
        /// Update an application 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        public Object UpdateApplication(CreateOrUpdateApplicationRequest body, string id)
        {
            ApiResponse<object> localVarResponse = UpdateApplicationWithHttpInfo(body, id);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Asynchronous Update an application 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        public async ThreadTask.Task<object> UpdateApplicationAsync(CreateOrUpdateApplicationRequest body, string id)
        {
            ApiResponse<object> localVarResponse = await ThreadTask.Task.FromResult(UpdateApplicationWithHttpInfo(body, id));
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update an application 
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="id"></param>
        /// <returns>ApiResponse of Object</returns>
        public ApiResponse<object> UpdateApplicationWithHttpInfo(CreateOrUpdateApplicationRequest body, string id)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling ApplicationResourceApi->UpdateApplication");
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling ApplicationResourceApi->UpdateApplication");

            var localVarPath = "/applications/{id}";
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

            if (id != null) localVarPathParams.Add("id", this.Configuration.ApiClient.ParameterToString(id)); // path parameter
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
             Method.Put, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
             localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("UpdateApplication", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
             localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
             (Object)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Object)));
        }
    }
}
