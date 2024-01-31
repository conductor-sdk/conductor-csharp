using System;
using System.Collections.Generic;
using Conductor.Client;
using Conductor.Client.Models;

namespace Conductor.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ITaskResourceApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get the details about each queue
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Dictionary&lt;string, long?&gt;</returns>
        Dictionary<string, long?> All();

        /// <summary>
        /// Get the details about each queue
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Dictionary&lt;string, long?&gt;</returns>
        ApiResponse<Dictionary<string, long?>> AllWithHttpInfo();
        /// <summary>
        /// Get the details about each queue
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Dictionary&lt;string, Dictionary&lt;string, Dictionary&lt;string, long?&gt;&gt;&gt;</returns>
        Dictionary<string, Dictionary<string, Dictionary<string, long?>>> AllVerbose();

        /// <summary>
        /// Get the details about each queue
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Dictionary&lt;string, Dictionary&lt;string, Dictionary&lt;string, long?&gt;&gt;&gt;</returns>
        ApiResponse<Dictionary<string, Dictionary<string, Dictionary<string, long?>>>> AllVerboseWithHttpInfo();
        /// <summary>
        /// Batch poll for a task of a certain type
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tasktype"></param>
        /// <param name="workerid"> (optional)</param>
        /// <param name="domain"> (optional)</param>
        /// <param name="count"> (optional, default to 1)</param>
        /// <param name="timeout"> (optional, default to 100)</param>
        /// <returns>List&lt;Task&gt;</returns>
        List<Task> BatchPoll(string tasktype, string workerid = null, string domain = null, int? count = null, int? timeout = null);

        /// <summary>
        /// Batch poll for a task of a certain type
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tasktype"></param>
        /// <param name="workerid"> (optional)</param>
        /// <param name="domain"> (optional)</param>
        /// <param name="count"> (optional, default to 1)</param>
        /// <param name="timeout"> (optional, default to 100)</param>
        /// <returns>ApiResponse of List&lt;Task&gt;</returns>
        ApiResponse<List<Task>> BatchPollWithHttpInfo(string tasktype, string workerid = null, string domain = null, int? count = null, int? timeout = null);
        /// <summary>
        /// Get the last poll data for all task types
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workerSize"> (optional)</param>
        /// <param name="workerOpt"> (optional)</param>
        /// <param name="queueSize"> (optional)</param>
        /// <param name="queueOpt"> (optional)</param>
        /// <param name="lastPollTimeSize"> (optional)</param>
        /// <param name="lastPollTimeOpt"> (optional)</param>
        /// <returns>Dictionary&lt;string, Object&gt;</returns>
        Dictionary<string, Object> GetAllPollData(long? workerSize = null, string workerOpt = null, long? queueSize = null, string queueOpt = null, long? lastPollTimeSize = null, string lastPollTimeOpt = null);

        /// <summary>
        /// Get the last poll data for all task types
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workerSize"> (optional)</param>
        /// <param name="workerOpt"> (optional)</param>
        /// <param name="queueSize"> (optional)</param>
        /// <param name="queueOpt"> (optional)</param>
        /// <param name="lastPollTimeSize"> (optional)</param>
        /// <param name="lastPollTimeOpt"> (optional)</param>
        /// <returns>ApiResponse of Dictionary&lt;string, Object&gt;</returns>
        ApiResponse<Dictionary<string, Object>> GetAllPollDataWithHttpInfo(long? workerSize = null, string workerOpt = null, long? queueSize = null, string queueOpt = null, long? lastPollTimeSize = null, string lastPollTimeOpt = null);
        /// <summary>
        /// Get the external uri where the task payload is to be stored
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="path"></param>
        /// <param name="operation"></param>
        /// <param name="payloadType"></param>
        /// <returns>ExternalStorageLocation</returns>
        ExternalStorageLocation GetExternalStorageLocation(string path, string operation, string payloadType);

        /// <summary>
        /// Get the external uri where the task payload is to be stored
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="path"></param>
        /// <param name="operation"></param>
        /// <param name="payloadType"></param>
        /// <returns>ApiResponse of ExternalStorageLocation</returns>
        ApiResponse<ExternalStorageLocation> GetExternalStorageLocationWithHttpInfo(string path, string operation, string payloadType);
        /// <summary>
        /// Get the last poll data for a given task type
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskType"></param>
        /// <returns>List&lt;PollData&gt;</returns>
        List<PollData> GetPollData(string taskType);

        /// <summary>
        /// Get the last poll data for a given task type
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskType"></param>
        /// <returns>ApiResponse of List&lt;PollData&gt;</returns>
        ApiResponse<List<PollData>> GetPollDataWithHttpInfo(string taskType);
        /// <summary>
        /// Get task by Id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns>Task</returns>
        Task GetTask(string taskId);

        /// <summary>
        /// Get task by Id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns>ApiResponse of Task</returns>
        ApiResponse<Task> GetTaskWithHttpInfo(string taskId);
        /// <summary>
        /// Get Task Execution Logs
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns>List&lt;TaskExecLog&gt;</returns>
        List<TaskExecLog> GetTaskLogs(string taskId);

        /// <summary>
        /// Get Task Execution Logs
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns>ApiResponse of List&lt;TaskExecLog&gt;</returns>
        ApiResponse<List<TaskExecLog>> GetTaskLogsWithHttpInfo(string taskId);
        /// <summary>
        /// Log Task Execution Details
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="taskId"></param>
        /// <returns></returns>
        void Log(string body, string taskId);

        /// <summary>
        /// Log Task Execution Details
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="taskId"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> LogWithHttpInfo(string body, string taskId);
        /// <summary>
        /// Poll for a task of a certain type
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tasktype"></param>
        /// <param name="workerid"> (optional)</param>
        /// <param name="domain"> (optional)</param>
        /// <returns>Task</returns>
        Task Poll(string tasktype, string workerid = null, string domain = null);

        /// <summary>
        /// Poll for a task of a certain type
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tasktype"></param>
        /// <param name="workerid"> (optional)</param>
        /// <param name="domain"> (optional)</param>
        /// <returns>ApiResponse of Task</returns>
        ApiResponse<Task> PollWithHttpInfo(string tasktype, string workerid = null, string domain = null);
        /// <summary>
        /// Requeue pending tasks
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskType"></param>
        /// <returns>string</returns>
        string RequeuePendingTask(string taskType);

        /// <summary>
        /// Requeue pending tasks
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskType"></param>
        /// <returns>ApiResponse of string</returns>
        ApiResponse<string> RequeuePendingTaskWithHttpInfo(string taskType);
        /// <summary>
        /// Search for tasks based in payload and other parameters
        /// </summary>
        /// <remarks>
        /// use sort options as sort&#x3D;&lt;field&gt;:ASC|DESC e.g. sort&#x3D;name&amp;sort&#x3D;workflowId:DESC. If order is not specified, defaults to ASC
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start"> (optional, default to 0)</param>
        /// <param name="size"> (optional, default to 100)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="freeText"> (optional, default to *)</param>
        /// <param name="query"> (optional)</param>
        /// <returns>SearchResultTaskSummary</returns>
        SearchResultTaskSummary Search(int? start = null, int? size = null, string sort = null, string freeText = null, string query = null);

        /// <summary>
        /// Search for tasks based in payload and other parameters
        /// </summary>
        /// <remarks>
        /// use sort options as sort&#x3D;&lt;field&gt;:ASC|DESC e.g. sort&#x3D;name&amp;sort&#x3D;workflowId:DESC. If order is not specified, defaults to ASC
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start"> (optional, default to 0)</param>
        /// <param name="size"> (optional, default to 100)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="freeText"> (optional, default to *)</param>
        /// <param name="query"> (optional)</param>
        /// <returns>ApiResponse of SearchResultTaskSummary</returns>
        ApiResponse<SearchResultTaskSummary> SearchWithHttpInfo(int? start = null, int? size = null, string sort = null, string freeText = null, string query = null);
        /// <summary>
        /// Search for tasks based in payload and other parameters
        /// </summary>
        /// <remarks>
        /// use sort options as sort&#x3D;&lt;field&gt;:ASC|DESC e.g. sort&#x3D;name&amp;sort&#x3D;workflowId:DESC. If order is not specified, defaults to ASC
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start"> (optional, default to 0)</param>
        /// <param name="size"> (optional, default to 100)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="freeText"> (optional, default to *)</param>
        /// <param name="query"> (optional)</param>
        /// <returns>SearchResultTask</returns>
        SearchResultTask SearchV2(int? start = null, int? size = null, string sort = null, string freeText = null, string query = null);

        /// <summary>
        /// Search for tasks based in payload and other parameters
        /// </summary>
        /// <remarks>
        /// use sort options as sort&#x3D;&lt;field&gt;:ASC|DESC e.g. sort&#x3D;name&amp;sort&#x3D;workflowId:DESC. If order is not specified, defaults to ASC
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start"> (optional, default to 0)</param>
        /// <param name="size"> (optional, default to 100)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="freeText"> (optional, default to *)</param>
        /// <param name="query"> (optional)</param>
        /// <returns>ApiResponse of SearchResultTask</returns>
        ApiResponse<SearchResultTask> SearchV2WithHttpInfo(int? start = null, int? size = null, string sort = null, string freeText = null, string query = null);
        /// <summary>
        /// Get Task type queue sizes
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskType"> (optional)</param>
        /// <returns>Dictionary&lt;string, int?&gt;</returns>
        Dictionary<string, int?> Size(List<string> taskType = null);

        /// <summary>
        /// Get Task type queue sizes
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskType"> (optional)</param>
        /// <returns>ApiResponse of Dictionary&lt;string, int?&gt;</returns>
        ApiResponse<Dictionary<string, int?>> SizeWithHttpInfo(List<string> taskType = null);
        /// <summary>
        /// Update a task
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>string</returns>
        string UpdateTask(TaskResult body);

        /// <summary>
        /// Update a task
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>ApiResponse of string</returns>
        ApiResponse<string> UpdateTaskWithHttpInfo(TaskResult body);
        /// <summary>
        /// Update a task By Ref Name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="workflowId"></param>
        /// <param name="taskRefName"></param>
        /// <param name="status"></param>
        /// <param name="workerid"> (optional)</param>
        /// <returns>string</returns>
        string UpdateTask(Dictionary<string, Object> body, string workflowId, string taskRefName, string status, string workerid = null);

        /// <summary>
        /// Update a task By Ref Name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="workflowId"></param>
        /// <param name="taskRefName"></param>
        /// <param name="status"></param>
        /// <returns>ApiResponse of string</returns>
        ApiResponse<string> UpdateTaskWithHttpInfo(Dictionary<string, Object> body, string workflowId, string taskRefName, string status, string workerid = null);


        //aa
        /// <summary>
        /// Update a task By Ref Name, evaluates the workflow and returns the updated workflow
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="output"></param>
        /// <param name="workflowId"></param>
        /// <param name="taskRefName"></param>
        /// <param name="status"></param>
        /// <param name="workerid"> (optional)</param>
        /// <returns>Workflow</returns>
        Workflow UpdateTaskSync(Dictionary<string, Object> output, string workflowId, string taskRefName, TaskResult.StatusEnum status, string workerid = null);

        /// <summary>
        /// Update a task By Ref Name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="output"></param>
        /// <param name="workflowId"></param>
        /// <param name="taskRefName"></param>
        /// <param name="status"></param>
        /// <returns>ApiResponse of Workflow</returns>
        ApiResponse<Workflow> UpdateTaskSyncWithHttpInfo(Dictionary<string, Object> output, string workflowId, string taskRefName, TaskResult.StatusEnum status, string workerid = null);
        //aaa
        #endregion Synchronous Operations
    }
}