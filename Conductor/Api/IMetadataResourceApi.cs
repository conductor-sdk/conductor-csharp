using System;
using System.Collections.Generic;
using Conductor.Client;
using Conductor.Client.Models;

namespace Conductor.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IMetadataResourceApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Create a new workflow definition
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="overwrite"> (optional, default to false)</param>
        /// <returns>Object</returns>
        Object Create(WorkflowDef body, bool? overwrite = null);

        /// <summary>
        /// Create a new workflow definition
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="overwrite"> (optional, default to false)</param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> CreateWithHttpInfo(WorkflowDef body, bool? overwrite = null);
        /// <summary>
        /// Retrieves workflow definition along with blueprint
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="version"> (optional)</param>
        /// <param name="metadata"> (optional, default to false)</param>
        /// <returns>WorkflowDef</returns>
        WorkflowDef Get(string name, int? version = null, bool? metadata = null);

        /// <summary>
        /// Retrieves workflow definition along with blueprint
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="version"> (optional)</param>
        /// <param name="metadata"> (optional, default to false)</param>
        /// <returns>ApiResponse of WorkflowDef</returns>
        ApiResponse<WorkflowDef> GetWithHttpInfo(string name, int? version = null, bool? metadata = null);
        /// <summary>
        /// Retrieves all workflow definition along with blueprint
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="access"> (optional, default to READ)</param>
        /// <param name="metadata"> (optional, default to false)</param>
        /// <param name="tagKey"> (optional)</param>
        /// <param name="tagValue"> (optional)</param>
        /// <param name="_short"> (optional, default to false)</param>
        /// <returns>List&lt;WorkflowDef&gt;</returns>
        List<WorkflowDef> GetAllWorkflows(string access = null, bool? metadata = null, string tagKey = null, string tagValue = null, bool? _short = null);

        /// <summary>
        /// Retrieves all workflow definition along with blueprint
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="access"> (optional, default to READ)</param>
        /// <param name="metadata"> (optional, default to false)</param>
        /// <param name="tagKey"> (optional)</param>
        /// <param name="tagValue"> (optional)</param>
        /// <param name="_short"> (optional, default to false)</param>
        /// <returns>ApiResponse of List&lt;WorkflowDef&gt;</returns>
        ApiResponse<List<WorkflowDef>> GetAllWorkflowsWithHttpInfo(string access = null, bool? metadata = null, string tagKey = null, string tagValue = null, bool? _short = null);
        /// <summary>
        /// Gets the task definition
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tasktype"></param>
        /// <param name="metadata"> (optional, default to false)</param>
        /// <returns>Object</returns>
        TaskDef GetTaskDef(string tasktype, bool? metadata = null);

        /// <summary>
        /// Gets the task definition
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tasktype"></param>
        /// <param name="metadata"> (optional, default to false)</param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<TaskDef> GetTaskDefWithHttpInfo(string tasktype, bool? metadata = null);
        /// <summary>
        /// Gets all task definition
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="access"> (optional, default to READ)</param>
        /// <param name="metadata"> (optional, default to false)</param>
        /// <param name="tagKey"> (optional)</param>
        /// <param name="tagValue"> (optional)</param>
        /// <returns>List&lt;TaskDef&gt;</returns>
        List<TaskDef> GetTaskDefs(string access = null, bool? metadata = null, string tagKey = null, string tagValue = null);

        /// <summary>
        /// Gets all task definition
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="access"> (optional, default to READ)</param>
        /// <param name="metadata"> (optional, default to false)</param>
        /// <param name="tagKey"> (optional)</param>
        /// <param name="tagValue"> (optional)</param>
        /// <returns>ApiResponse of List&lt;TaskDef&gt;</returns>
        ApiResponse<List<TaskDef>> GetTaskDefsWithHttpInfo(string access = null, bool? metadata = null, string tagKey = null, string tagValue = null);
        /// <summary>
        /// Create or update task definition(s)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>Object</returns>
        Object RegisterTaskDef(List<TaskDef> body);

        /// <summary>
        /// Create or update task definition(s)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> RegisterTaskDefWithHttpInfo(List<TaskDef> body);
        /// <summary>
        /// Remove a task definition
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tasktype"></param>
        /// <returns></returns>
        void UnregisterTaskDef(string tasktype);

        /// <summary>
        /// Remove a task definition
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tasktype"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> UnregisterTaskDefWithHttpInfo(string tasktype);
        /// <summary>
        /// Removes workflow definition. It does not remove workflows associated with the definition.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        void UnregisterWorkflowDef(string name, int? version);

        /// <summary>
        /// Removes workflow definition. It does not remove workflows associated with the definition.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> UnregisterWorkflowDefWithHttpInfo(string name, int? version);
        /// <summary>
        /// Create or update workflow definition(s)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="overwrite"> (optional, default to true)</param>
        /// <returns>Object</returns>
        Object UpdateWorkflowDefinitions(List<WorkflowDef> body, bool? overwrite = null);

        /// <summary>
        /// Create or update workflow definition(s)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="overwrite"> (optional, default to true)</param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> UpdateWithHttpInfo(List<WorkflowDef> body, bool? overwrite = null);
        /// <summary>
        /// Update an existing task
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>Object</returns>
        Object UpdateTaskDef(TaskDef body);

        /// <summary>
        /// Update an existing task
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> UpdateTaskDefWithHttpInfo(TaskDef body);
        /// <summary>
        /// Upload all workflows and tasks definitions to S3
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Object</returns>
        Object UploadWorkflowsAndTasksDefinitionsToS3();

        /// <summary>
        /// Upload all workflows and tasks definitions to S3
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> UploadWorkflowsAndTasksDefinitionsToS3WithHttpInfo();
        #endregion Synchronous Operations
    }
}