using System;
using System.Collections.Generic;
using Conductor.Client;
using Conductor.Client.Models;

namespace Conductor.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ISchedulerResourceApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Deletes an existing workflow schedule by name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Object</returns>
        Object DeleteSchedule(string name);

        /// <summary>
        /// Deletes an existing workflow schedule by name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> DeleteScheduleWithHttpInfo(string name);
        /// <summary>
        /// Delete a tag for schedule
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        void DeleteTagForSchedule(List<TagObject> body, string name);

        /// <summary>
        /// Delete a tag for schedule
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DeleteTagForScheduleWithHttpInfo(List<TagObject> body, string name);
        /// <summary>
        /// Get all existing workflow schedules and optionally filter by workflow name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowName"> (optional)</param>
        /// <returns>List&lt;WorkflowSchedule&gt;</returns>
        List<WorkflowSchedule> GetAllSchedules(string workflowName = null);

        /// <summary>
        /// Get all existing workflow schedules and optionally filter by workflow name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="workflowName"> (optional)</param>
        /// <returns>ApiResponse of List&lt;WorkflowSchedule&gt;</returns>
        ApiResponse<List<WorkflowSchedule>> GetAllSchedulesWithHttpInfo(string workflowName = null);
        /// <summary>
        /// Get list of the next x (default 3, max 5) execution times for a scheduler
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="cronExpression"></param>
        /// <param name="scheduleStartTime"> (optional)</param>
        /// <param name="scheduleEndTime"> (optional)</param>
        /// <param name="limit"> (optional, default to 3)</param>
        /// <returns>List&lt;long?&gt;</returns>
        List<long?> GetNextFewSchedules(string cronExpression, long? scheduleStartTime = null, long? scheduleEndTime = null, int? limit = null);

        /// <summary>
        /// Get list of the next x (default 3, max 5) execution times for a scheduler
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="cronExpression"></param>
        /// <param name="scheduleStartTime"> (optional)</param>
        /// <param name="scheduleEndTime"> (optional)</param>
        /// <param name="limit"> (optional, default to 3)</param>
        /// <returns>ApiResponse of List&lt;long?&gt;</returns>
        ApiResponse<List<long?>> GetNextFewSchedulesWithHttpInfo(string cronExpression, long? scheduleStartTime = null, long? scheduleEndTime = null, int? limit = null);
        /// <summary>
        /// Get an existing workflow schedule by name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>WorkflowSchedule</returns>
        WorkflowSchedule GetSchedule(string name);

        /// <summary>
        /// Get an existing workflow schedule by name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>ApiResponse of WorkflowSchedule</returns>
        ApiResponse<WorkflowSchedule> GetScheduleWithHttpInfo(string name);
        /// <summary>
        /// Get tags by schedule
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>List&lt;TagObject&gt;</returns>
        List<TagObject> GetTagsForSchedule(string name);

        /// <summary>
        /// Get tags by schedule
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>ApiResponse of List&lt;TagObject&gt;</returns>
        ApiResponse<List<TagObject>> GetTagsForScheduleWithHttpInfo(string name);
        /// <summary>
        /// Pause all scheduling in a single conductor server instance (for debugging only)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Dictionary&lt;string, Object&gt;</returns>
        Dictionary<string, Object> PauseAllSchedules();

        /// <summary>
        /// Pause all scheduling in a single conductor server instance (for debugging only)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Dictionary&lt;string, Object&gt;</returns>
        ApiResponse<Dictionary<string, Object>> PauseAllSchedulesWithHttpInfo();
        /// <summary>
        /// Pauses an existing schedule by name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Object</returns>
        Object PauseSchedule(string name);

        /// <summary>
        /// Pauses an existing schedule by name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> PauseScheduleWithHttpInfo(string name);
        /// <summary>
        /// Put a tag to schedule
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        void PutTagForSchedule(List<TagObject> body, string name);

        /// <summary>
        /// Put a tag to schedule
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> PutTagForScheduleWithHttpInfo(List<TagObject> body, string name);
        /// <summary>
        /// Requeue all execution records
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Dictionary&lt;string, Object&gt;</returns>
        Dictionary<string, Object> RequeueAllExecutionRecords();

        /// <summary>
        /// Requeue all execution records
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Dictionary&lt;string, Object&gt;</returns>
        ApiResponse<Dictionary<string, Object>> RequeueAllExecutionRecordsWithHttpInfo();
        /// <summary>
        /// Resume all scheduling
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Dictionary&lt;string, Object&gt;</returns>
        Dictionary<string, Object> ResumeAllSchedules();

        /// <summary>
        /// Resume all scheduling
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Dictionary&lt;string, Object&gt;</returns>
        ApiResponse<Dictionary<string, Object>> ResumeAllSchedulesWithHttpInfo();
        /// <summary>
        /// Resume a paused schedule by name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Object</returns>
        Object ResumeSchedule(string name);

        /// <summary>
        /// Resume a paused schedule by name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> ResumeScheduleWithHttpInfo(string name);
        /// <summary>
        /// Create or update a schedule for a specified workflow with a corresponding start workflow request
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>Object</returns>
        Object SaveSchedule(SaveScheduleRequest body);

        /// <summary>
        /// Create or update a schedule for a specified workflow with a corresponding start workflow request
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> SaveScheduleWithHttpInfo(SaveScheduleRequest body);
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
        /// <returns>SearchResultWorkflowScheduleExecutionModel</returns>
        SearchResultWorkflowScheduleExecutionModel SearchV22(int? start = null, int? size = null, string sort = null, string freeText = null, string query = null);

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
        /// <returns>ApiResponse of SearchResultWorkflowScheduleExecutionModel</returns>
        ApiResponse<SearchResultWorkflowScheduleExecutionModel> SearchV22WithHttpInfo(int? start = null, int? size = null, string sort = null, string freeText = null, string query = null);
        /// <summary>
        /// Test timeout - do not use in production
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns></returns>
        void TestTimeout();

        /// <summary>
        /// Test timeout - do not use in production
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> TestTimeoutWithHttpInfo();
        #endregion Synchronous Operations
    }
}