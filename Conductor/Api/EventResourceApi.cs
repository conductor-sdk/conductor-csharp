using System;
using System.Collections.Generic;
using System.Linq;
using Conductor.Client;
using RestSharp;
using EventHandler = Conductor.Client.Models.EventHandler;

namespace Conductor.Api
{
    /// <summary>
    ///     Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class EventResourceApi : IEventResourceApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EventResourceApi" /> class.
        /// </summary>
        /// <returns></returns>
        public EventResourceApi(string basePath)
        {
            Configuration = new Configuration { BasePath = basePath };

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EventResourceApi" /> class
        /// </summary>
        /// <returns></returns>
        public EventResourceApi()
        {
            Configuration = Configuration.Default;

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EventResourceApi" /> class
        ///     using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public EventResourceApi(Configuration configuration = null)
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
        ///     Add a new event handler.
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns></returns>
        public void AddEventHandler(EventHandler body)
        {
            AddEventHandlerWithHttpInfo(body);
        }

        /// <summary>
        ///     Add a new event handler.
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> AddEventHandlerWithHttpInfo(EventHandler body)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400,
                    "Missing required parameter 'body' when calling EventResourceApi->AddEventHandler");

            var localVarPath = "/event";
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
                var exception = ExceptionFactory("AddEventHandler", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        ///     Delete queue config by name
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="queueType"></param>
        /// <param name="queueName"></param>
        /// <returns></returns>
        public void DeleteQueueConfig(string queueType, string queueName)
        {
            DeleteQueueConfigWithHttpInfo(queueType, queueName);
        }

        /// <summary>
        ///     Delete queue config by name
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="queueType"></param>
        /// <param name="queueName"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> DeleteQueueConfigWithHttpInfo(string queueType, string queueName)
        {
            // verify the required parameter 'queueType' is set
            if (queueType == null)
                throw new ApiException(400,
                    "Missing required parameter 'queueType' when calling EventResourceApi->DeleteQueueConfig");
            // verify the required parameter 'queueName' is set
            if (queueName == null)
                throw new ApiException(400,
                    "Missing required parameter 'queueName' when calling EventResourceApi->DeleteQueueConfig");

            var localVarPath = "/event/queue/config/{queueType}/{queueName}";
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
            };
            var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (queueType != null)
                localVarPathParams.Add("queueType",
                    Configuration.ApiClient.ParameterToString(queueType)); // path parameter
            if (queueName != null)
                localVarPathParams.Add("queueName",
                    Configuration.ApiClient.ParameterToString(queueName)); // path parameter
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
                var exception = ExceptionFactory("DeleteQueueConfig", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        ///     Get all the event handlers
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;EventHandler&gt;</returns>
        public List<EventHandler> GetEventHandlers()
        {
            var localVarResponse = GetEventHandlersWithHttpInfo();
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Get all the event handlers
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;EventHandler&gt;</returns>
        public ApiResponse<List<EventHandler>> GetEventHandlersWithHttpInfo()
        {
            var localVarPath = "/event";
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
                "*/*"
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
                var exception = ExceptionFactory("GetEventHandlers", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<EventHandler>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (List<EventHandler>)Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<EventHandler>)));
        }

        /// <summary>
        ///     Get event handlers for a given event
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="_event"></param>
        /// <param name="activeOnly"> (optional, default to true)</param>
        /// <returns>List&lt;EventHandler&gt;</returns>
        public List<EventHandler> GetEventHandlersForEvent(string _event, bool? activeOnly = null)
        {
            var localVarResponse = GetEventHandlersForEventWithHttpInfo(_event, activeOnly);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Get event handlers for a given event
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="_event"></param>
        /// <param name="activeOnly"> (optional, default to true)</param>
        /// <returns>ApiResponse of List&lt;EventHandler&gt;</returns>
        public ApiResponse<List<EventHandler>> GetEventHandlersForEventWithHttpInfo(string _event,
            bool? activeOnly = null)
        {
            // verify the required parameter '_event' is set
            if (_event == null)
                throw new ApiException(400,
                    "Missing required parameter '_event' when calling EventResourceApi->GetEventHandlersForEvent");

            var localVarPath = "/event/{event}";
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
                "*/*"
            };
            var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (_event != null)
                localVarPathParams.Add("event", Configuration.ApiClient.ParameterToString(_event)); // path parameter
            if (activeOnly != null)
                localVarQueryParams.AddRange(
                    Configuration.ApiClient.ParameterToKeyValuePairs("", "activeOnly", activeOnly)); // query parameter
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
                var exception = ExceptionFactory("GetEventHandlersForEvent", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<EventHandler>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (List<EventHandler>)Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<EventHandler>)));
        }

        /// <summary>
        ///     Get queue config by name
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="queueType"></param>
        /// <param name="queueName"></param>
        /// <returns>Dictionary&lt;string, Object&gt;</returns>
        public Dictionary<string, object> GetQueueConfig(string queueType, string queueName)
        {
            var localVarResponse = GetQueueConfigWithHttpInfo(queueType, queueName);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Get queue config by name
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="queueType"></param>
        /// <param name="queueName"></param>
        /// <returns>ApiResponse of Dictionary&lt;string, Object&gt;</returns>
        public ApiResponse<Dictionary<string, object>> GetQueueConfigWithHttpInfo(string queueType, string queueName)
        {
            // verify the required parameter 'queueType' is set
            if (queueType == null)
                throw new ApiException(400,
                    "Missing required parameter 'queueType' when calling EventResourceApi->GetQueueConfig");
            // verify the required parameter 'queueName' is set
            if (queueName == null)
                throw new ApiException(400,
                    "Missing required parameter 'queueName' when calling EventResourceApi->GetQueueConfig");

            var localVarPath = "/event/queue/config/{queueType}/{queueName}";
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
                "*/*"
            };
            var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (queueType != null)
                localVarPathParams.Add("queueType",
                    Configuration.ApiClient.ParameterToString(queueType)); // path parameter
            if (queueName != null)
                localVarPathParams.Add("queueName",
                    Configuration.ApiClient.ParameterToString(queueName)); // path parameter
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
                var exception = ExceptionFactory("GetQueueConfig", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Dictionary<string, object>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (Dictionary<string, object>)Configuration.ApiClient.Deserialize(localVarResponse,
                    typeof(Dictionary<string, object>)));
        }

        /// <summary>
        ///     Get all queue configs
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Dictionary&lt;string, string&gt;</returns>
        public Dictionary<string, string> GetQueueNames()
        {
            var localVarResponse = GetQueueNamesWithHttpInfo();
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Get all queue configs
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Dictionary&lt;string, string&gt;</returns>
        public ApiResponse<Dictionary<string, string>> GetQueueNamesWithHttpInfo()
        {
            var localVarPath = "/event/queue/config";
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
                "*/*"
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
                var exception = ExceptionFactory("GetQueueNames", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Dictionary<string, string>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (Dictionary<string, string>)Configuration.ApiClient.Deserialize(localVarResponse,
                    typeof(Dictionary<string, string>)));
        }

        /// <summary>
        ///     Create or update queue config by name
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="queueType"></param>
        /// <param name="queueName"></param>
        /// <returns></returns>
        public void PutQueueConfig(string body, string queueType, string queueName)
        {
            PutQueueConfigWithHttpInfo(body, queueType, queueName);
        }

        /// <summary>
        ///     Create or update queue config by name
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="queueType"></param>
        /// <param name="queueName"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> PutQueueConfigWithHttpInfo(string body, string queueType, string queueName)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400,
                    "Missing required parameter 'body' when calling EventResourceApi->PutQueueConfig");
            // verify the required parameter 'queueType' is set
            if (queueType == null)
                throw new ApiException(400,
                    "Missing required parameter 'queueType' when calling EventResourceApi->PutQueueConfig");
            // verify the required parameter 'queueName' is set
            if (queueName == null)
                throw new ApiException(400,
                    "Missing required parameter 'queueName' when calling EventResourceApi->PutQueueConfig");

            var localVarPath = "/event/queue/config/{queueType}/{queueName}";
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

            if (queueType != null)
                localVarPathParams.Add("queueType",
                    Configuration.ApiClient.ParameterToString(queueType)); // path parameter
            if (queueName != null)
                localVarPathParams.Add("queueName",
                    Configuration.ApiClient.ParameterToString(queueName)); // path parameter
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
                var exception = ExceptionFactory("PutQueueConfig", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        ///     Remove an event handler
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns></returns>
        public void RemoveEventHandlerStatus(string name)
        {
            RemoveEventHandlerStatusWithHttpInfo(name);
        }

        /// <summary>
        ///     Remove an event handler
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> RemoveEventHandlerStatusWithHttpInfo(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400,
                    "Missing required parameter 'name' when calling EventResourceApi->RemoveEventHandlerStatus");

            var localVarPath = "/event/{name}";
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
            };
            var localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (name != null)
                localVarPathParams.Add("name", Configuration.ApiClient.ParameterToString(name)); // path parameter
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
                var exception = ExceptionFactory("RemoveEventHandlerStatus", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        ///     Update an existing event handler.
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns></returns>
        public void UpdateEventHandler(EventHandler body)
        {
            UpdateEventHandlerWithHttpInfo(body);
        }

        /// <summary>
        ///     Update an existing event handler.
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> UpdateEventHandlerWithHttpInfo(EventHandler body)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400,
                    "Missing required parameter 'body' when calling EventResourceApi->UpdateEventHandler");

            var localVarPath = "/event";
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
                var exception = ExceptionFactory("UpdateEventHandler", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
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