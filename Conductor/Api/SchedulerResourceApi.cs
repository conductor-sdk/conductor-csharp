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
    public class SchedulerResourceApi : ISchedulerResourceApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SchedulerResourceApi" /> class.
        /// </summary>
        /// <returns></returns>
        public SchedulerResourceApi(string basePath)
        {
            Configuration = new Configuration { BasePath = basePath };

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SchedulerResourceApi" /> class
        /// </summary>
        /// <returns></returns>
        public SchedulerResourceApi()
        {
            Configuration = Configuration.Default;

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SchedulerResourceApi" /> class
        ///     using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public SchedulerResourceApi(Configuration configuration = null)
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
        ///     Deletes an existing workflow schedule by name
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Object</returns>
        public object DeleteSchedule(string name)
        {
            var localVarResponse = DeleteScheduleWithHttpInfo(name);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Deletes an existing workflow schedule by name
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>ApiResponse of Object</returns>
        public ApiResponse<object> DeleteScheduleWithHttpInfo(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400,
                    "Missing required parameter 'name' when calling SchedulerResourceApi->DeleteSchedule");

            var localVarPath = "/scheduler/schedules/{name}";
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
                var exception = ExceptionFactory("DeleteSchedule", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                Configuration.ApiClient.Deserialize(localVarResponse, typeof(object)));
        }

        /// <summary>
        ///     Delete a tag for schedule
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public void DeleteTagForSchedule(List<TagObject> body, string name)
        {
            DeleteTagForScheduleWithHttpInfo(body, name);
        }

        /// <summary>
        ///     Delete a tag for schedule
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> DeleteTagForScheduleWithHttpInfo(List<TagObject> body, string name)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400,
                    "Missing required parameter 'body' when calling SchedulerResourceApi->DeleteTagForSchedule");
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400,
                    "Missing required parameter 'name' when calling SchedulerResourceApi->DeleteTagForSchedule");

            var localVarPath = "/scheduler/schedules/{name}/tags";
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

            if (name != null)
                localVarPathParams.Add("name", Configuration.ApiClient.ParameterToString(name)); // path parameter
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
                var exception = ExceptionFactory("DeleteTagForSchedule", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        ///     Get all existing workflow schedules and optionally filter by workflow name
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowName"> (optional)</param>
        /// <returns>List&lt;WorkflowSchedule&gt;</returns>
        public List<WorkflowSchedule> GetAllSchedules(string workflowName = null)
        {
            var localVarResponse = GetAllSchedulesWithHttpInfo(workflowName);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Get all existing workflow schedules and optionally filter by workflow name
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowName"> (optional)</param>
        /// <returns>ApiResponse of List&lt;WorkflowSchedule&gt;</returns>
        public ApiResponse<List<WorkflowSchedule>> GetAllSchedulesWithHttpInfo(string workflowName = null)
        {
            var localVarPath = "/scheduler/schedules";
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

            if (workflowName != null)
                localVarQueryParams.AddRange(
                    Configuration.ApiClient.ParameterToKeyValuePairs("", "workflowName",
                        workflowName)); // query parameter
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
                var exception = ExceptionFactory("GetAllSchedules", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<WorkflowSchedule>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (List<WorkflowSchedule>)Configuration.ApiClient.Deserialize(localVarResponse,
                    typeof(List<WorkflowSchedule>)));
        }

        /// <summary>
        ///     Get list of the next x (default 3, max 5) execution times for a scheduler
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="cronExpression"></param>
        /// <param name="scheduleStartTime"> (optional)</param>
        /// <param name="scheduleEndTime"> (optional)</param>
        /// <param name="limit"> (optional, default to 3)</param>
        /// <returns>List&lt;long?&gt;</returns>
        public List<long?> GetNextFewSchedules(string cronExpression, long? scheduleStartTime = null,
            long? scheduleEndTime = null, int? limit = null)
        {
            var localVarResponse =
                GetNextFewSchedulesWithHttpInfo(cronExpression, scheduleStartTime, scheduleEndTime, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Get list of the next x (default 3, max 5) execution times for a scheduler
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="cronExpression"></param>
        /// <param name="scheduleStartTime"> (optional)</param>
        /// <param name="scheduleEndTime"> (optional)</param>
        /// <param name="limit"> (optional, default to 3)</param>
        /// <returns>ApiResponse of List&lt;long?&gt;</returns>
        public ApiResponse<List<long?>> GetNextFewSchedulesWithHttpInfo(string cronExpression,
            long? scheduleStartTime = null, long? scheduleEndTime = null, int? limit = null)
        {
            // verify the required parameter 'cronExpression' is set
            if (cronExpression == null)
                throw new ApiException(400,
                    "Missing required parameter 'cronExpression' when calling SchedulerResourceApi->GetNextFewSchedules");

            var localVarPath = "/scheduler/nextFewSchedules";
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

            if (cronExpression != null)
                localVarQueryParams.AddRange(
                    Configuration.ApiClient.ParameterToKeyValuePairs("", "cronExpression",
                        cronExpression)); // query parameter
            if (scheduleStartTime != null)
                localVarQueryParams.AddRange(
                    Configuration.ApiClient.ParameterToKeyValuePairs("", "scheduleStartTime",
                        scheduleStartTime)); // query parameter
            if (scheduleEndTime != null)
                localVarQueryParams.AddRange(
                    Configuration.ApiClient.ParameterToKeyValuePairs("", "scheduleEndTime",
                        scheduleEndTime)); // query parameter
            if (limit != null)
                localVarQueryParams.AddRange(
                    Configuration.ApiClient.ParameterToKeyValuePairs("", "limit", limit)); // query parameter
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
                var exception = ExceptionFactory("GetNextFewSchedules", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<long?>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (List<long?>)Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<long?>)));
        }

        /// <summary>
        ///     Get an existing workflow schedule by name
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>WorkflowSchedule</returns>
        public WorkflowSchedule GetSchedule(string name)
        {
            var localVarResponse = GetScheduleWithHttpInfo(name);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Get an existing workflow schedule by name
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>ApiResponse of WorkflowSchedule</returns>
        public ApiResponse<WorkflowSchedule> GetScheduleWithHttpInfo(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400,
                    "Missing required parameter 'name' when calling SchedulerResourceApi->GetSchedule");

            var localVarPath = "/scheduler/schedules/{name}";
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

            if (name != null)
                localVarPathParams.Add("name", Configuration.ApiClient.ParameterToString(name)); // path parameter
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
                var exception = ExceptionFactory("GetSchedule", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<WorkflowSchedule>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (WorkflowSchedule)Configuration.ApiClient.Deserialize(localVarResponse, typeof(WorkflowSchedule)));
        }

        /// <summary>
        ///     Get tags by schedule
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>List&lt;TagObject&gt;</returns>
        public List<TagObject> GetTagsForSchedule(string name)
        {
            var localVarResponse = GetTagsForScheduleWithHttpInfo(name);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Get tags by schedule
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>ApiResponse of List&lt;TagObject&gt;</returns>
        public ApiResponse<List<TagObject>> GetTagsForScheduleWithHttpInfo(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400,
                    "Missing required parameter 'name' when calling SchedulerResourceApi->GetTagsForSchedule");

            var localVarPath = "/scheduler/schedules/{name}/tags";
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

            if (name != null)
                localVarPathParams.Add("name", Configuration.ApiClient.ParameterToString(name)); // path parameter
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
                var exception = ExceptionFactory("GetTagsForSchedule", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<TagObject>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (List<TagObject>)Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<TagObject>)));
        }

        /// <summary>
        ///     Pause all scheduling in a single conductor server instance (for debugging only)
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Dictionary&lt;string, Object&gt;</returns>
        public Dictionary<string, object> PauseAllSchedules()
        {
            var localVarResponse = PauseAllSchedulesWithHttpInfo();
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Pause all scheduling in a single conductor server instance (for debugging only)
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Dictionary&lt;string, Object&gt;</returns>
        public ApiResponse<Dictionary<string, object>> PauseAllSchedulesWithHttpInfo()
        {
            var localVarPath = "/scheduler/admin/pause";
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
                var exception = ExceptionFactory("PauseAllSchedules", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Dictionary<string, object>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (Dictionary<string, object>)Configuration.ApiClient.Deserialize(localVarResponse,
                    typeof(Dictionary<string, object>)));
        }

        /// <summary>
        ///     Pauses an existing schedule by name
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Object</returns>
        public object PauseSchedule(string name)
        {
            var localVarResponse = PauseScheduleWithHttpInfo(name);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Pauses an existing schedule by name
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>ApiResponse of Object</returns>
        public ApiResponse<object> PauseScheduleWithHttpInfo(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400,
                    "Missing required parameter 'name' when calling SchedulerResourceApi->PauseSchedule");

            var localVarPath = "/scheduler/schedules/{name}/pause";
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

            if (name != null)
                localVarPathParams.Add("name", Configuration.ApiClient.ParameterToString(name)); // path parameter
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
                var exception = ExceptionFactory("PauseSchedule", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                Configuration.ApiClient.Deserialize(localVarResponse, typeof(object)));
        }

        /// <summary>
        ///     Put a tag to schedule
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public void PutTagForSchedule(List<TagObject> body, string name)
        {
            PutTagForScheduleWithHttpInfo(body, name);
        }

        /// <summary>
        ///     Put a tag to schedule
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> PutTagForScheduleWithHttpInfo(List<TagObject> body, string name)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400,
                    "Missing required parameter 'body' when calling SchedulerResourceApi->PutTagForSchedule");
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400,
                    "Missing required parameter 'name' when calling SchedulerResourceApi->PutTagForSchedule");

            var localVarPath = "/scheduler/schedules/{name}/tags";
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

            if (name != null)
                localVarPathParams.Add("name", Configuration.ApiClient.ParameterToString(name)); // path parameter
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
                var exception = ExceptionFactory("PutTagForSchedule", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        ///     Requeue all execution records
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Dictionary&lt;string, Object&gt;</returns>
        public Dictionary<string, object> RequeueAllExecutionRecords()
        {
            var localVarResponse = RequeueAllExecutionRecordsWithHttpInfo();
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Requeue all execution records
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Dictionary&lt;string, Object&gt;</returns>
        public ApiResponse<Dictionary<string, object>> RequeueAllExecutionRecordsWithHttpInfo()
        {
            var localVarPath = "/scheduler/admin/requeue";
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
                var exception = ExceptionFactory("RequeueAllExecutionRecords", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Dictionary<string, object>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (Dictionary<string, object>)Configuration.ApiClient.Deserialize(localVarResponse,
                    typeof(Dictionary<string, object>)));
        }

        /// <summary>
        ///     Resume all scheduling
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Dictionary&lt;string, Object&gt;</returns>
        public Dictionary<string, object> ResumeAllSchedules()
        {
            var localVarResponse = ResumeAllSchedulesWithHttpInfo();
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Resume all scheduling
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Dictionary&lt;string, Object&gt;</returns>
        public ApiResponse<Dictionary<string, object>> ResumeAllSchedulesWithHttpInfo()
        {
            var localVarPath = "/scheduler/admin/resume";
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
                var exception = ExceptionFactory("ResumeAllSchedules", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Dictionary<string, object>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (Dictionary<string, object>)Configuration.ApiClient.Deserialize(localVarResponse,
                    typeof(Dictionary<string, object>)));
        }

        /// <summary>
        ///     Resume a paused schedule by name
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Object</returns>
        public object ResumeSchedule(string name)
        {
            var localVarResponse = ResumeScheduleWithHttpInfo(name);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Resume a paused schedule by name
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>ApiResponse of Object</returns>
        public ApiResponse<object> ResumeScheduleWithHttpInfo(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400,
                    "Missing required parameter 'name' when calling SchedulerResourceApi->ResumeSchedule");

            var localVarPath = "/scheduler/schedules/{name}/resume";
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

            if (name != null)
                localVarPathParams.Add("name", Configuration.ApiClient.ParameterToString(name)); // path parameter
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
                var exception = ExceptionFactory("ResumeSchedule", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                Configuration.ApiClient.Deserialize(localVarResponse, typeof(object)));
        }

        /// <summary>
        ///     Create or update a schedule for a specified workflow with a corresponding start workflow request
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>Object</returns>
        public object SaveSchedule(SaveScheduleRequest body)
        {
            var localVarResponse = SaveScheduleWithHttpInfo(body);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Create or update a schedule for a specified workflow with a corresponding start workflow request
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>ApiResponse of Object</returns>
        public ApiResponse<object> SaveScheduleWithHttpInfo(SaveScheduleRequest body)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400,
                    "Missing required parameter 'body' when calling SchedulerResourceApi->SaveSchedule");

            var localVarPath = "/scheduler/schedules";
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
                var exception = ExceptionFactory("SaveSchedule", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                Configuration.ApiClient.Deserialize(localVarResponse, typeof(object)));
        }

        /// <summary>
        ///     Search for workflows based on payload and other parameters use sort options as sort&#x3D;&lt;field&gt;:ASC|DESC
        ///     e.g. sort&#x3D;name&amp;sort&#x3D;workflowId:DESC. If order is not specified, defaults to ASC.
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start"> (optional, default to 0)</param>
        /// <param name="size"> (optional, default to 100)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="freeText"> (optional, default to *)</param>
        /// <param name="query"> (optional)</param>
        /// <returns>SearchResultWorkflowScheduleExecutionModel</returns>
        public SearchResultWorkflowScheduleExecutionModel SearchV22(int? start = null, int? size = null,
            string sort = null, string freeText = null, string query = null)
        {
            var localVarResponse = SearchV22WithHttpInfo(start, size, sort, freeText, query);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Search for workflows based on payload and other parameters use sort options as sort&#x3D;&lt;field&gt;:ASC|DESC
        ///     e.g. sort&#x3D;name&amp;sort&#x3D;workflowId:DESC. If order is not specified, defaults to ASC.
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start"> (optional, default to 0)</param>
        /// <param name="size"> (optional, default to 100)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="freeText"> (optional, default to *)</param>
        /// <param name="query"> (optional)</param>
        /// <returns>ApiResponse of SearchResultWorkflowScheduleExecutionModel</returns>
        public ApiResponse<SearchResultWorkflowScheduleExecutionModel> SearchV22WithHttpInfo(int? start = null,
            int? size = null, string sort = null, string freeText = null, string query = null)
        {
            var localVarPath = "/scheduler/search/executions";
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

            if (start != null)
                localVarQueryParams.AddRange(
                    Configuration.ApiClient.ParameterToKeyValuePairs("", "start", start)); // query parameter
            if (size != null)
                localVarQueryParams.AddRange(
                    Configuration.ApiClient.ParameterToKeyValuePairs("", "size", size)); // query parameter
            if (sort != null)
                localVarQueryParams.AddRange(
                    Configuration.ApiClient.ParameterToKeyValuePairs("", "sort", sort)); // query parameter
            if (freeText != null)
                localVarQueryParams.AddRange(
                    Configuration.ApiClient.ParameterToKeyValuePairs("", "freeText", freeText)); // query parameter
            if (query != null)
                localVarQueryParams.AddRange(
                    Configuration.ApiClient.ParameterToKeyValuePairs("", "query", query)); // query parameter
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
                var exception = ExceptionFactory("SearchV22", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<SearchResultWorkflowScheduleExecutionModel>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (SearchResultWorkflowScheduleExecutionModel)Configuration.ApiClient.Deserialize(localVarResponse,
                    typeof(SearchResultWorkflowScheduleExecutionModel)));
        }

        /// <summary>
        ///     Test timeout - do not use in production
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns></returns>
        public void TestTimeout()
        {
            TestTimeoutWithHttpInfo();
        }

        /// <summary>
        ///     Test timeout - do not use in production
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> TestTimeoutWithHttpInfo()
        {
            var localVarPath = "/scheduler/test/timeout";
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
                var exception = ExceptionFactory("TestTimeout", localVarResponse);
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