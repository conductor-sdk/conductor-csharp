using System;
using System.Collections.Generic;
using System.Linq;
using Conductor.Client;
using Conductor.Client.Models;
using RestSharp;

namespace Conductor.Api
{
    /// <summary>
    ///     Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ApplicationResourceApi : IApplicationResourceApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationResourceApi" /> class.
        /// </summary>
        /// <returns></returns>
        public ApplicationResourceApi(string basePath)
        {
            Configuration = new Configuration { BasePath = basePath };

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationResourceApi" /> class
        /// </summary>
        /// <returns></returns>
        public ApplicationResourceApi()
        {
            Configuration = Configuration.Default;

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationResourceApi" /> class
        ///     using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ApplicationResourceApi(Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                Configuration = Configuration.Default;
            else
                Configuration = configuration;

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        ///     Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Configuration Configuration { get; set; }

        /// <summary>
        ///     Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                return _exceptionFactory;
            }
            set => _exceptionFactory = value;
        }

        /// <summary>
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="applicationId"></param>
        /// <param name="role"></param>
        /// <returns>Object</returns>
        public object AddRoleToApplicationUser(string applicationId, string role)
        {
            var localVarResponse = AddRoleToApplicationUserWithHttpInfo(applicationId, role);
            return localVarResponse.Data;
        }

        /// <summary>
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="applicationId"></param>
        /// <param name="role"></param>
        /// <returns>ApiResponse of Object</returns>
        public ApiResponse<object> AddRoleToApplicationUserWithHttpInfo(string applicationId, string role)
        {
            // verify the required parameter 'applicationId' is set
            if (applicationId == null)
                throw new ApiException(400,
                    "Missing required parameter 'applicationId' when calling ApplicationResourceApi->AddRoleToApplicationUser");
            // verify the required parameter 'role' is set
            if (role == null)
                throw new ApiException(400,
                    "Missing required parameter 'role' when calling ApplicationResourceApi->AddRoleToApplicationUser");

            var localVarPath = "/applications/{applicationId}/roles/{role}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =
            {
            };
            var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts =
            {
                "application/json"
            };
            var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (applicationId != null)
                localVarPathParams.Add("applicationId",
                    Configuration.ApiClient.ParameterToString(applicationId)); // path parameter
            if (role != null)
                localVarPathParams.Add("role", Configuration.ApiClient.ParameterToString(role)); // path parameter
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(Configuration.AccessToken))
                localVarHeaderParams["X-Authorization"] = Configuration.AccessToken;

            // make the HTTP request
            var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
                localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                var exception = ExceptionFactory("AddRoleToApplicationUser", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                Configuration.ApiClient.Deserialize(localVarResponse, typeof(object)));
        }

        /// <summary>
        ///     Create an access key for an application
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        public object CreateAccessKey(string id)
        {
            var localVarResponse = CreateAccessKeyWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Create an access key for an application
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>ApiResponse of Object</returns>
        public ApiResponse<object> CreateAccessKeyWithHttpInfo(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling ApplicationResourceApi->CreateAccessKey");

            var localVarPath = "/applications/{id}/accessKeys";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =
            {
            };
            var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts =
            {
                "application/json"
            };
            var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (id != null)
                localVarPathParams.Add("id", Configuration.ApiClient.ParameterToString(id)); // path parameter
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(Configuration.AccessToken))
                localVarHeaderParams["X-Authorization"] = Configuration.AccessToken;

            // make the HTTP request
            var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
                localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                var exception = ExceptionFactory("CreateAccessKey", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                Configuration.ApiClient.Deserialize(localVarResponse, typeof(object)));
        }

        /// <summary>
        ///     Create an application
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>Object</returns>
        public object CreateApplication(CreateOrUpdateApplicationRequest body)
        {
            var localVarResponse = CreateApplicationWithHttpInfo(body);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Create an application
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>ApiResponse of Object</returns>
        public ApiResponse<object> CreateApplicationWithHttpInfo(CreateOrUpdateApplicationRequest body)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400,
                    "Missing required parameter 'body' when calling ApplicationResourceApi->CreateApplication");

            var localVarPath = "/applications";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =
            {
                "application/json"
            };
            var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts =
            {
                "application/json"
            };
            var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (body != null && body.GetType() != typeof(byte[]))
                localVarPostBody = Configuration.ApiClient.Serialize(body); // http body (model) parameter
            else
                localVarPostBody = body; // byte array
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(Configuration.AccessToken))
                localVarHeaderParams["X-Authorization"] = Configuration.AccessToken;

            // make the HTTP request
            var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
                localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                var exception = ExceptionFactory("CreateApplication", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                Configuration.ApiClient.Deserialize(localVarResponse, typeof(object)));
        }

        /// <summary>
        ///     Delete an access key
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="applicationId"></param>
        /// <param name="keyId"></param>
        /// <returns>Object</returns>
        public object DeleteAccessKey(string applicationId, string keyId)
        {
            var localVarResponse = DeleteAccessKeyWithHttpInfo(applicationId, keyId);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Delete an access key
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="applicationId"></param>
        /// <param name="keyId"></param>
        /// <returns>ApiResponse of Object</returns>
        public ApiResponse<object> DeleteAccessKeyWithHttpInfo(string applicationId, string keyId)
        {
            // verify the required parameter 'applicationId' is set
            if (applicationId == null)
                throw new ApiException(400,
                    "Missing required parameter 'applicationId' when calling ApplicationResourceApi->DeleteAccessKey");
            // verify the required parameter 'keyId' is set
            if (keyId == null)
                throw new ApiException(400,
                    "Missing required parameter 'keyId' when calling ApplicationResourceApi->DeleteAccessKey");

            var localVarPath = "/applications/{applicationId}/accessKeys/{keyId}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =
            {
            };
            var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts =
            {
                "application/json"
            };
            var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (applicationId != null)
                localVarPathParams.Add("applicationId",
                    Configuration.ApiClient.ParameterToString(applicationId)); // path parameter
            if (keyId != null)
                localVarPathParams.Add("keyId", Configuration.ApiClient.ParameterToString(keyId)); // path parameter
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(Configuration.AccessToken))
                localVarHeaderParams["X-Authorization"] = Configuration.AccessToken;

            // make the HTTP request
            var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
                localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                var exception = ExceptionFactory("DeleteAccessKey", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                Configuration.ApiClient.Deserialize(localVarResponse, typeof(object)));
        }

        /// <summary>
        ///     Delete an application
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        public object DeleteApplication(string id)
        {
            var localVarResponse = DeleteApplicationWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Delete an application
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>ApiResponse of Object</returns>
        public ApiResponse<object> DeleteApplicationWithHttpInfo(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling ApplicationResourceApi->DeleteApplication");

            var localVarPath = "/applications/{id}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =
            {
            };
            var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts =
            {
                "application/json"
            };
            var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (id != null)
                localVarPathParams.Add("id", Configuration.ApiClient.ParameterToString(id)); // path parameter
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(Configuration.AccessToken))
                localVarHeaderParams["X-Authorization"] = Configuration.AccessToken;

            // make the HTTP request
            var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
                localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                var exception = ExceptionFactory("DeleteApplication", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                Configuration.ApiClient.Deserialize(localVarResponse, typeof(object)));
        }

        /// <summary>
        ///     Delete a tag for application
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
        ///     Delete a tag for application
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="id"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> DeleteTagForApplicationWithHttpInfo(List<TagObject> body, string id)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400,
                    "Missing required parameter 'body' when calling ApplicationResourceApi->DeleteTagForApplication");
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling ApplicationResourceApi->DeleteTagForApplication");

            var localVarPath = "/applications/{id}/tags";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =
            {
                "application/json"
            };
            var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts =
            {
            };
            var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (id != null)
                localVarPathParams.Add("id", Configuration.ApiClient.ParameterToString(id)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
                localVarPostBody = Configuration.ApiClient.Serialize(body); // http body (model) parameter
            else
                localVarPostBody = body; // byte array
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(Configuration.AccessToken))
                localVarHeaderParams["X-Authorization"] = Configuration.AccessToken;

            // make the HTTP request
            var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
                localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                var exception = ExceptionFactory("DeleteTagForApplication", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        ///     Get application&#x27;s access keys
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        public object GetAccessKeys(string id)
        {
            var localVarResponse = GetAccessKeysWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Get application&#x27;s access keys
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>ApiResponse of Object</returns>
        public ApiResponse<object> GetAccessKeysWithHttpInfo(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling ApplicationResourceApi->GetAccessKeys");

            var localVarPath = "/applications/{id}/accessKeys";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =
            {
            };
            var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts =
            {
                "application/json"
            };
            var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (id != null)
                localVarPathParams.Add("id", Configuration.ApiClient.ParameterToString(id)); // path parameter
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(Configuration.AccessToken))
                localVarHeaderParams["X-Authorization"] = Configuration.AccessToken;

            // make the HTTP request
            var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
                localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                var exception = ExceptionFactory("GetAccessKeys", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                Configuration.ApiClient.Deserialize(localVarResponse, typeof(object)));
        }

        /// <summary>
        ///     Get application id by access key id
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accessKeyId"></param>
        /// <returns>Object</returns>
        public object GetAppByAccessKeyId(string accessKeyId)
        {
            var localVarResponse = GetAppByAccessKeyIdWithHttpInfo(accessKeyId);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Get application id by access key id
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accessKeyId"></param>
        /// <returns>ApiResponse of Object</returns>
        public ApiResponse<object> GetAppByAccessKeyIdWithHttpInfo(string accessKeyId)
        {
            // verify the required parameter 'accessKeyId' is set
            if (accessKeyId == null)
                throw new ApiException(400,
                    "Missing required parameter 'accessKeyId' when calling ApplicationResourceApi->GetAppByAccessKeyId");

            var localVarPath = "/applications/key/{accessKeyId}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =
            {
            };
            var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts =
            {
                "application/json"
            };
            var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (accessKeyId != null)
                localVarPathParams.Add("accessKeyId",
                    Configuration.ApiClient.ParameterToString(accessKeyId)); // path parameter
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(Configuration.AccessToken))
                localVarHeaderParams["X-Authorization"] = Configuration.AccessToken;

            // make the HTTP request
            var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
                localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                var exception = ExceptionFactory("GetAppByAccessKeyId", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                Configuration.ApiClient.Deserialize(localVarResponse, typeof(object)));
        }

        /// <summary>
        ///     Get an application by id
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        public object GetApplication(string id)
        {
            var localVarResponse = GetApplicationWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Get an application by id
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>ApiResponse of Object</returns>
        public ApiResponse<object> GetApplicationWithHttpInfo(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling ApplicationResourceApi->GetApplication");

            var localVarPath = "/applications/{id}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =
            {
            };
            var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts =
            {
                "application/json"
            };
            var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (id != null)
                localVarPathParams.Add("id", Configuration.ApiClient.ParameterToString(id)); // path parameter
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(Configuration.AccessToken))
                localVarHeaderParams["X-Authorization"] = Configuration.AccessToken;

            // make the HTTP request
            var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
                localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                var exception = ExceptionFactory("GetApplication", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                Configuration.ApiClient.Deserialize(localVarResponse, typeof(object)));
        }

        /// <summary>
        ///     Get tags by application
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>List&lt;TagObject&gt;</returns>
        public List<TagObject> GetTagsForApplication(string id)
        {
            var localVarResponse = GetTagsForApplicationWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Get tags by application
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>ApiResponse of List&lt;TagObject&gt;</returns>
        public ApiResponse<List<TagObject>> GetTagsForApplicationWithHttpInfo(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling ApplicationResourceApi->GetTagsForApplication");

            var localVarPath = "/applications/{id}/tags";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =
            {
            };
            var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts =
            {
                "application/json"
            };
            var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (id != null)
                localVarPathParams.Add("id", Configuration.ApiClient.ParameterToString(id)); // path parameter
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(Configuration.AccessToken))
                localVarHeaderParams["X-Authorization"] = Configuration.AccessToken;

            // make the HTTP request
            var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
                localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                var exception = ExceptionFactory("GetTagsForApplication", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<TagObject>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (List<TagObject>)Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<TagObject>)));
        }

        /// <summary>
        ///     Get all applications
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;ExtendedConductorApplication&gt;</returns>
        public List<ExtendedConductorApplication> ListApplications()
        {
            var localVarResponse = ListApplicationsWithHttpInfo();
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Get all applications
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;ExtendedConductorApplication&gt;</returns>
        public ApiResponse<List<ExtendedConductorApplication>> ListApplicationsWithHttpInfo()
        {
            var localVarPath = "/applications";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =
            {
            };
            var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts =
            {
                "application/json"
            };
            var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // authentication (api_key) required
            if (!string.IsNullOrEmpty(Configuration.AccessToken))
                localVarHeaderParams["X-Authorization"] = Configuration.AccessToken;

            // make the HTTP request
            var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
                localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                var exception = ExceptionFactory("ListApplications", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<ExtendedConductorApplication>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (List<ExtendedConductorApplication>)Configuration.ApiClient.Deserialize(localVarResponse,
                    typeof(List<ExtendedConductorApplication>)));
        }

        /// <summary>
        ///     Put a tag to application
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
        ///     Put a tag to application
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="id"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> PutTagForApplicationWithHttpInfo(List<TagObject> body, string id)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400,
                    "Missing required parameter 'body' when calling ApplicationResourceApi->PutTagForApplication");
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling ApplicationResourceApi->PutTagForApplication");

            var localVarPath = "/applications/{id}/tags";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =
            {
                "application/json"
            };
            var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts =
            {
            };
            var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (id != null)
                localVarPathParams.Add("id", Configuration.ApiClient.ParameterToString(id)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
                localVarPostBody = Configuration.ApiClient.Serialize(body); // http body (model) parameter
            else
                localVarPostBody = body; // byte array
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(Configuration.AccessToken))
                localVarHeaderParams["X-Authorization"] = Configuration.AccessToken;

            // make the HTTP request
            var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
                localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                var exception = ExceptionFactory("PutTagForApplication", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="applicationId"></param>
        /// <param name="role"></param>
        /// <returns>Object</returns>
        public object RemoveRoleFromApplicationUser(string applicationId, string role)
        {
            var localVarResponse = RemoveRoleFromApplicationUserWithHttpInfo(applicationId, role);
            return localVarResponse.Data;
        }

        /// <summary>
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="applicationId"></param>
        /// <param name="role"></param>
        /// <returns>ApiResponse of Object</returns>
        public ApiResponse<object> RemoveRoleFromApplicationUserWithHttpInfo(string applicationId, string role)
        {
            // verify the required parameter 'applicationId' is set
            if (applicationId == null)
                throw new ApiException(400,
                    "Missing required parameter 'applicationId' when calling ApplicationResourceApi->RemoveRoleFromApplicationUser");
            // verify the required parameter 'role' is set
            if (role == null)
                throw new ApiException(400,
                    "Missing required parameter 'role' when calling ApplicationResourceApi->RemoveRoleFromApplicationUser");

            var localVarPath = "/applications/{applicationId}/roles/{role}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =
            {
            };
            var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts =
            {
                "application/json"
            };
            var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (applicationId != null)
                localVarPathParams.Add("applicationId",
                    Configuration.ApiClient.ParameterToString(applicationId)); // path parameter
            if (role != null)
                localVarPathParams.Add("role", Configuration.ApiClient.ParameterToString(role)); // path parameter
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(Configuration.AccessToken))
                localVarHeaderParams["X-Authorization"] = Configuration.AccessToken;

            // make the HTTP request
            var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
                localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                var exception = ExceptionFactory("RemoveRoleFromApplicationUser", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                Configuration.ApiClient.Deserialize(localVarResponse, typeof(object)));
        }

        /// <summary>
        ///     Toggle the status of an access key
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="applicationId"></param>
        /// <param name="keyId"></param>
        /// <returns>Object</returns>
        public object ToggleAccessKeyStatus(string applicationId, string keyId)
        {
            var localVarResponse = ToggleAccessKeyStatusWithHttpInfo(applicationId, keyId);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Toggle the status of an access key
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="applicationId"></param>
        /// <param name="keyId"></param>
        /// <returns>ApiResponse of Object</returns>
        public ApiResponse<object> ToggleAccessKeyStatusWithHttpInfo(string applicationId, string keyId)
        {
            // verify the required parameter 'applicationId' is set
            if (applicationId == null)
                throw new ApiException(400,
                    "Missing required parameter 'applicationId' when calling ApplicationResourceApi->ToggleAccessKeyStatus");
            // verify the required parameter 'keyId' is set
            if (keyId == null)
                throw new ApiException(400,
                    "Missing required parameter 'keyId' when calling ApplicationResourceApi->ToggleAccessKeyStatus");

            var localVarPath = "/applications/{applicationId}/accessKeys/{keyId}/status";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =
            {
            };
            var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts =
            {
                "application/json"
            };
            var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (applicationId != null)
                localVarPathParams.Add("applicationId",
                    Configuration.ApiClient.ParameterToString(applicationId)); // path parameter
            if (keyId != null)
                localVarPathParams.Add("keyId", Configuration.ApiClient.ParameterToString(keyId)); // path parameter
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(Configuration.AccessToken))
                localVarHeaderParams["X-Authorization"] = Configuration.AccessToken;

            // make the HTTP request
            var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
                localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                var exception = ExceptionFactory("ToggleAccessKeyStatus", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                Configuration.ApiClient.Deserialize(localVarResponse, typeof(object)));
        }

        /// <summary>
        ///     Update an application
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        public object UpdateApplication(CreateOrUpdateApplicationRequest body, string id)
        {
            var localVarResponse = UpdateApplicationWithHttpInfo(body, id);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Update an application
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="id"></param>
        /// <returns>ApiResponse of Object</returns>
        public ApiResponse<object> UpdateApplicationWithHttpInfo(CreateOrUpdateApplicationRequest body, string id)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400,
                    "Missing required parameter 'body' when calling ApplicationResourceApi->UpdateApplication");
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling ApplicationResourceApi->UpdateApplication");

            var localVarPath = "/applications/{id}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =
            {
                "application/json"
            };
            var localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts =
            {
                "application/json"
            };
            var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (id != null)
                localVarPathParams.Add("id", Configuration.ApiClient.ParameterToString(id)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
                localVarPostBody = Configuration.ApiClient.Serialize(body); // http body (model) parameter
            else
                localVarPostBody = body; // byte array
            // authentication (api_key) required
            if (!string.IsNullOrEmpty(Configuration.AccessToken))
                localVarHeaderParams["X-Authorization"] = Configuration.AccessToken;

            // make the HTTP request
            var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
                localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                var exception = ExceptionFactory("UpdateApplication", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                Configuration.ApiClient.Deserialize(localVarResponse, typeof(object)));
        }

        /// <summary>
        ///     Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }
    }
}