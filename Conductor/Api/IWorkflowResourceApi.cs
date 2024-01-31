using System;
using System.Collections.Generic;
using Conductor.Client;
using Conductor.Client.Models;

namespace Conductor.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IWorkflowResourceApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Starts the decision task for a workflow
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <returns></returns>
        void Decide(string workflowId);

        /// <summary>
        /// Starts the decision task for a workflow
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DecideWithHttpInfo(string workflowId);
        /// <summary>
        /// Removes the workflow from the system
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <param name="archiveWorkflow"> (optional, default to true)</param>
        /// <returns></returns>
        void Delete(string workflowId, bool? archiveWorkflow = null);

        /// <summary>
        /// Removes the workflow from the system
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <param name="archiveWorkflow"> (optional, default to true)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DeleteWithHttpInfo(string workflowId, bool? archiveWorkflow = null);
        /// <summary>
        /// Execute a workflow synchronously
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="requestId"></param>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <param name="waitUntilTaskRef"> (optional)</param>
        /// <returns>WorkflowRun</returns>
        WorkflowRun ExecuteWorkflow(StartWorkflowRequest body, string requestId, string name, int? version, string waitUntilTaskRef = null);

        /// <summary>
        /// Update the value of the workflow variables for the given workflow id 
        /// </summary>
        /// <param name="workflowId"></param>
        /// /// <param name="variables"></param>
        /// <returns>Workflow</returns>
        Workflow UpdateWorkflowVariables(string workflowId, Dictionary<string, Object> variables);

        /// <summary>
        /// Update the value of the workflow variables for the given workflow id and return api response
        /// </summary>
        /// <param name="workflowId"></param>
        /// /// <param name="variables"></param>
        /// <returns>Workflow</returns>
        ApiResponse<Workflow> UpdateWorkflowVariablesWithHttpInfo(string workflowId, Dictionary<string, Object> variables);

        /// <summary>
        /// Execute a workflow synchronously
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="requestId"></param>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <param name="waitUntilTaskRef"> (optional)</param>
        /// <returns>ApiResponse of WorkflowRun</returns>
        ApiResponse<WorkflowRun> ExecuteWorkflowWithHttpInfo(StartWorkflowRequest body, string requestId, string name, int? version, string waitUntilTaskRef = null);
        /// <summary>
        /// Gets the workflow by workflow id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <param name="includeTasks"> (optional, default to true)</param>
        /// <param name="summarize"> (optional, default to false)</param>
        /// <returns>Workflow</returns>
        Workflow GetExecutionStatus(string workflowId, bool? includeTasks = null, bool? summarize = null);

        /// <summary>
        /// Gets the workflow by workflow id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <param name="includeTasks"> (optional, default to true)</param>
        /// <param name="summarize"> (optional, default to false)</param>
        /// <returns>ApiResponse of Workflow</returns>
        ApiResponse<Workflow> GetExecutionStatusWithHttpInfo(string workflowId, bool? includeTasks = null, bool? summarize = null);
        /// <summary>
        /// Gets the workflow tasks by workflow id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <param name="start"> (optional, default to 0)</param>
        /// <param name="count"> (optional, default to 15)</param>
        /// <param name="status"> (optional)</param>
        /// <returns>TaskListSearchResultSummary</returns>
        TaskListSearchResultSummary GetExecutionStatusTaskList(string workflowId, int? start = null, int? count = null, string status = null);

        /// <summary>
        /// Gets the workflow tasks by workflow id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <param name="start"> (optional, default to 0)</param>
        /// <param name="count"> (optional, default to 15)</param>
        /// <param name="status"> (optional)</param>
        /// <returns>ApiResponse of TaskListSearchResultSummary</returns>
        ApiResponse<TaskListSearchResultSummary> GetExecutionStatusTaskListWithHttpInfo(string workflowId, int? start = null, int? count = null, string status = null);
        /// <summary>
        /// Get the uri and path of the external storage where the workflow payload is to be stored
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
        /// Get the uri and path of the external storage where the workflow payload is to be stored
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
        /// Retrieve all the running workflows
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="version"> (optional, default to 1)</param>
        /// <param name="startTime"> (optional)</param>
        /// <param name="endTime"> (optional)</param>
        /// <returns>List&lt;string&gt;</returns>
        List<string> GetRunningWorkflow(string name, int? version = null, long? startTime = null, long? endTime = null);

        /// <summary>
        /// Retrieve all the running workflows
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="version"> (optional, default to 1)</param>
        /// <param name="startTime"> (optional)</param>
        /// <param name="endTime"> (optional)</param>
        /// <returns>ApiResponse of List&lt;string&gt;</returns>
        ApiResponse<List<string>> GetRunningWorkflowWithHttpInfo(string name, int? version = null, long? startTime = null, long? endTime = null);
        /// <summary>
        /// Gets the workflow by workflow id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <param name="includeOutput"> (optional, default to false)</param>
        /// <param name="includeVariables"> (optional, default to false)</param>
        /// <returns>WorkflowStatus</returns>
        WorkflowStatus GetWorkflowStatusSummary(string workflowId, bool? includeOutput = null, bool? includeVariables = null);

        /// <summary>
        /// Gets the workflow by workflow id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <param name="includeOutput"> (optional, default to false)</param>
        /// <param name="includeVariables"> (optional, default to false)</param>
        /// <returns>ApiResponse of WorkflowStatus</returns>
        ApiResponse<WorkflowStatus> GetWorkflowStatusSummaryWithHttpInfo(string workflowId, bool? includeOutput = null, bool? includeVariables = null);
        /// <summary>
        /// Lists workflows for the given correlation id list
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="correlationIds"></param>
        /// <param name="name"></param>
        /// <param name="includeClosed"> (optional, default to false)</param>
        /// <param name="includeTasks"> (optional, default to false)</param>
        /// <returns>Dictionary&lt;string, List&lt;Workflow&gt;&gt;</returns>
        Dictionary<string, List<Workflow>> GetWorkflows(List<string> correlationIds, string name, bool? includeClosed = null, bool? includeTasks = null);

        /// <summary>
        /// Lists workflows for the given correlation id list
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="correlationIds"></param>
        /// <param name="name"></param>
        /// <param name="includeClosed"> (optional, default to false)</param>
        /// <param name="includeTasks"> (optional, default to false)</param>
        /// <returns>ApiResponse of Dictionary&lt;string, List&lt;Workflow&gt;&gt;</returns>
        ApiResponse<Dictionary<string, List<Workflow>>> GetWorkflowsWithHttpInfo(List<string> correlationIds, string name, bool? includeClosed = null, bool? includeTasks = null);
        /// <summary>
        /// Lists workflows for the given correlation id list and workflow name list
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <param name="includeClosed"> (optional, default to false)</param>
        /// <param name="includeTasks"> (optional, default to false)</param>
        /// <returns>Dictionary&lt;string, List&lt;Workflow&gt;&gt;</returns>
        Dictionary<string, List<Workflow>> GetWorkflows(CorrelationIdsSearchRequest request, bool? includeClosed = null, bool? includeTasks = null);

        /// <summary>
        /// Lists workflows for the given correlation id list and workflow name list
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <param name="includeClosed"> (optional, default to false)</param>
        /// <param name="includeTasks"> (optional, default to false)</param>
        /// <returns>ApiResponse of Dictionary&lt;string, List&lt;Workflow&gt;&gt;</returns>
        ApiResponse<Dictionary<string, List<Workflow>>> GetWorkflowsWithHttpInfo(CorrelationIdsSearchRequest request, bool? includeClosed = null, bool? includeTasks = null);
        /// <summary>
        /// Lists workflows for the given correlation id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="correlationId"></param>
        /// <param name="includeClosed"> (optional, default to false)</param>
        /// <param name="includeTasks"> (optional, default to false)</param>
        /// <returns>List&lt;Workflow&gt;</returns>
        List<Workflow> GetWorkflows(string name, string correlationId, bool? includeClosed = null, bool? includeTasks = null);

        /// <summary>
        /// Lists workflows for the given correlation id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="correlationId"></param>
        /// <param name="includeClosed"> (optional, default to false)</param>
        /// <param name="includeTasks"> (optional, default to false)</param>
        /// <returns>ApiResponse of List&lt;Workflow&gt;</returns>
        ApiResponse<List<Workflow>> GetWorkflowsWithHttpInfo(string name, string correlationId, bool? includeClosed = null, bool? includeTasks = null);
        /// <summary>
        /// Pauses the workflow
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <returns></returns>
        void PauseWorkflow(string workflowId);

        /// <summary>
        /// Pauses the workflow
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> PauseWorkflowWithHttpInfo(string workflowId);

        /// <summary>
        /// Reruns the workflow from a specific task
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <param name="workflowId"></param>
        /// <returns>string</returns>
        string Rerun(RerunWorkflowRequest request, string workflowId);

        /// <summary>
        /// Reruns the workflow from a specific task
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <param name="workflowId"></param>
        /// <returns>ApiResponse of string</returns>
        ApiResponse<string> RerunWithHttpInfo(RerunWorkflowRequest request, string workflowId);
        /// <summary>
        /// Resets callback times of all non-terminal SIMPLE tasks to 0
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <returns></returns>
        void ResetWorkflow(string workflowId);

        /// <summary>
        /// Resets callback times of all non-terminal SIMPLE tasks to 0
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ResetWorkflowWithHttpInfo(string workflowId);
        /// <summary>
        /// Restarts a completed workflow
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <param name="useLatestDefinitions"> (optional, default to false)</param>
        /// <returns></returns>
        void Restart(string workflowId, bool? useLatestDefinitions = null);

        /// <summary>
        /// Restarts a completed workflow
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <param name="useLatestDefinitions"> (optional, default to false)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> RestartWithHttpInfo(string workflowId, bool? useLatestDefinitions = null);
        /// <summary>
        /// Resumes the workflow
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <returns></returns>
        void ResumeWorkflow(string workflowId);

        /// <summary>
        /// Resumes the workflow
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ResumeWorkflowWithHttpInfo(string workflowId);
        /// <summary>
        /// Retries the last failed task
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <param name="resumeSubworkflowTasks"> (optional, default to false)</param>
        /// <returns></returns>
        void Retry(string workflowId, bool? resumeSubworkflowTasks = null);

        /// <summary>
        /// Retries the last failed task
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <param name="resumeSubworkflowTasks"> (optional, default to false)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> RetryWithHttpInfo(string workflowId, bool? resumeSubworkflowTasks = null);
        /// <summary>
        /// Search for workflows based on payload and other parameters
        /// </summary>
        /// <remarks>
        /// use sort options as sort&#x3D;&lt;field&gt;:ASC|DESC e.g. sort&#x3D;name&amp;sort&#x3D;workflowId:DESC. If order is not specified, defaults to ASC.
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="queryId"> (optional)</param>
        /// <param name="start"> (optional, default to 0)</param>
        /// <param name="size"> (optional, default to 100)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="freeText"> (optional, default to *)</param>
        /// <param name="query"> (optional)</param>
        /// <param name="skipCache"> (optional, default to false)</param>
        /// <returns>ScrollableSearchResultWorkflowSummary</returns>
        ScrollableSearchResultWorkflowSummary Search(string queryId = null, int? start = null, int? size = null, string sort = null, string freeText = null, string query = null, bool? skipCache = null);

        /// <summary>
        /// Search for workflows based on payload and other parameters
        /// </summary>
        /// <remarks>
        /// use sort options as sort&#x3D;&lt;field&gt;:ASC|DESC e.g. sort&#x3D;name&amp;sort&#x3D;workflowId:DESC. If order is not specified, defaults to ASC.
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="queryId"> (optional)</param>
        /// <param name="start"> (optional, default to 0)</param>
        /// <param name="size"> (optional, default to 100)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="freeText"> (optional, default to *)</param>
        /// <param name="query"> (optional)</param>
        /// <param name="skipCache"> (optional, default to false)</param>
        /// <returns>ApiResponse of ScrollableSearchResultWorkflowSummary</returns>
        ApiResponse<ScrollableSearchResultWorkflowSummary> SearchWithHttpInfo(string queryId = null, int? start = null, int? size = null, string sort = null, string freeText = null, string query = null, bool? skipCache = null);
        /// <summary>
        /// Search for workflows based on payload and other parameters
        /// </summary>
        /// <remarks>
        /// use sort options as sort&#x3D;&lt;field&gt;:ASC|DESC e.g. sort&#x3D;name&amp;sort&#x3D;workflowId:DESC. If order is not specified, defaults to ASC.
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start"> (optional, default to 0)</param>
        /// <param name="size"> (optional, default to 100)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="freeText"> (optional, default to *)</param>
        /// <param name="query"> (optional)</param>
        /// <returns>SearchResultWorkflow</returns>
        SearchResultWorkflow SearchV2(int? start = null, int? size = null, string sort = null, string freeText = null, string query = null);

        /// <summary>
        /// Search for workflows based on payload and other parameters
        /// </summary>
        /// <remarks>
        /// use sort options as sort&#x3D;&lt;field&gt;:ASC|DESC e.g. sort&#x3D;name&amp;sort&#x3D;workflowId:DESC. If order is not specified, defaults to ASC.
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start"> (optional, default to 0)</param>
        /// <param name="size"> (optional, default to 100)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="freeText"> (optional, default to *)</param>
        /// <param name="query"> (optional)</param>
        /// <returns>ApiResponse of SearchResultWorkflow</returns>
        ApiResponse<SearchResultWorkflow> SearchV2WithHttpInfo(int? start = null, int? size = null, string sort = null, string freeText = null, string query = null);
        /// <summary>
        /// Search for workflows based on task parameters
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
        /// <returns>SearchResultWorkflowSummary</returns>
        SearchResultWorkflowSummary SearchWorkflowsByTasks(int? start = null, int? size = null, string sort = null, string freeText = null, string query = null);

        /// <summary>
        /// Search for workflows based on task parameters
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
        /// <returns>ApiResponse of SearchResultWorkflowSummary</returns>
        ApiResponse<SearchResultWorkflowSummary> SearchWorkflowsByTasksWithHttpInfo(int? start = null, int? size = null, string sort = null, string freeText = null, string query = null);
        /// <summary>
        /// Search for workflows based on task parameters
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
        /// <returns>SearchResultWorkflow</returns>
        SearchResultWorkflow SearchWorkflowsByTasksV2(int? start = null, int? size = null, string sort = null, string freeText = null, string query = null);

        /// <summary>
        /// Search for workflows based on task parameters
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
        /// <returns>ApiResponse of SearchResultWorkflow</returns>
        ApiResponse<SearchResultWorkflow> SearchWorkflowsByTasksV2WithHttpInfo(int? start = null, int? size = null, string sort = null, string freeText = null, string query = null);
        /// <summary>
        /// Skips a given task from a current running workflow
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <param name="taskReferenceName"></param>
        /// <param name="skipTaskRequest"></param>
        /// <returns></returns>
        void SkipTaskFromWorkflow(string workflowId, string taskReferenceName, SkipTaskRequest skipTaskRequest);

        /// <summary>
        /// Skips a given task from a current running workflow
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <param name="taskReferenceName"></param>
        /// <param name="skipTaskRequest"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> SkipTaskFromWorkflowWithHttpInfo(string workflowId, string taskReferenceName, SkipTaskRequest skipTaskRequest);
        /// <summary>
        /// Start a new workflow with StartWorkflowRequest, which allows task to be executed in a domain
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>string</returns>
        string StartWorkflow(StartWorkflowRequest request);

        /// <summary>
        /// Start a new workflow with StartWorkflowRequest, which allows task to be executed in a domain
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>ApiResponse of string</returns>
        ApiResponse<string> StartWorkflowWithHttpInfo(StartWorkflowRequest request);
        /// <summary>
        /// Start a new workflow. Returns the ID of the workflow instance that can be later used for tracking
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="input"></param>
        /// <param name="name"></param>
        /// <param name="version"> (optional)</param>
        /// <param name="correlationId"> (optional)</param>
        /// <param name="priority"> (optional, default to 0)</param>
        /// <returns>string</returns>
        string StartWorkflow(string name, Dictionary<string, Object> input, int? version = null, string correlationId = null, int? priority = null);

        /// <summary>
        /// Start a new workflow. Returns the ID of the workflow instance that can be later used for tracking
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="input"></param>
        /// <param name="name"></param>
        /// <param name="version"> (optional)</param>
        /// <param name="correlationId"> (optional)</param>
        /// <param name="priority"> (optional, default to 0)</param>
        /// <returns>ApiResponse of string</returns>
        ApiResponse<string> StartWorkflowWithHttpInfo(string name, Dictionary<string, Object> input, int? version = null, string correlationId = null, int? priority = null);
        /// <summary>
        /// Terminate workflow execution
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <param name="reason"> (optional)</param>
        /// <param name="triggerFailureWorkflow"> (optional, default to false)</param>
        /// <returns></returns>
        void Terminate(string workflowId, string reason = null, bool? triggerFailureWorkflow = null);

        /// <summary>
        /// Terminate workflow execution
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <param name="reason"> (optional)</param>
        /// <param name="triggerFailureWorkflow"> (optional, default to false)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> TerminateWithHttpInfo(string workflowId, string reason = null, bool? triggerFailureWorkflow = null);
        /// <summary>
        /// Test workflow execution using mock data
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>Workflow</returns>
        Workflow TestWorkflow(WorkflowTestRequest request);

        /// <summary>
        /// Test workflow execution using mock data
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>ApiResponse of Workflow</returns>
        ApiResponse<Workflow> TestWorkflowWithHttpInfo(WorkflowTestRequest request);

        /// <summary>
        /// Update a workflow state by updating variables or in progress task Updates the workflow variables, tasks and triggers evaluation.
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <param name="workflowId"></param>
        /// <param name="waitUntilTaskRefs"> (optional)</param>
        /// <param name="waitForSeconds"> (optional, default to 10)</param>
        /// <returns>WorkflowRun</returns>
        WorkflowRun UpdateWorkflow(string workflowId, WorkflowStateUpdate request,
            List<string> waitUntilTaskRefs = null, int? waitForSeconds = null);


        /// <summary>
        /// Update a workflow state by updating variables or in progress task Updates the workflow variables, tasks and triggers evaluation.
        /// </summary>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <param name="workflowId"></param>
        /// <param name="waitUntilTaskRefs"> (optional)</param>
        /// <param name="waitForSeconds"> (optional, default to 10)</param>
        /// <returns>WorkflowRun</returns>
        ApiResponse<WorkflowRun> UpdateWorkflowWithHttpInfo(string workflowId, WorkflowStateUpdate request,
            List<string> waitUntilTaskRefs = null, int? waitForSeconds = null);

        /// <summary>
        /// Gets the workflow by workflow id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <param name="includeTasks"> (optional, default to true)</param>
        /// <returns>Workflow</returns>
        Workflow GetWorkflow(string workflowId, bool includeTasks);


        /// <summary>
        /// Gets the workflow by workflow id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowId"></param>
        /// <param name="includeTasks"> (optional, default to true)</param>
        /// <returns>Workflow</returns>
        ApiResponse<Workflow> GetWorkflowWithHttpInfo(string workflowId, bool includeTasks);

        #endregion Synchronous Operations
    }
}