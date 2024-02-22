using Conductor.Client;
using Conductor.Client.Models;
using System;
using System.Collections.Generic;

namespace conductor_csharp.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IHumanTaskResourceApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Claim a task to an external user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="userId"></param>
        /// <param name="overrideAssignment"> (optional, default to false)</param>
        /// <returns>HumanTaskEntry</returns>
        HumanTaskEntry AssignAndClaim(string taskId, string userId, bool? overrideAssignment = null);

        /// <summary>
        /// Claim a task by authenticated Conductor user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="overrideAssignment"> (optional, default to false)</param>
        /// <returns>HumanTaskEntry</returns>
        HumanTaskEntry ClaimTask(string taskId, bool? overrideAssignment = null);

        /// <summary>
        /// Delete all versions of user form template by name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns></returns>
        void DeleteTemplateByName(string name);

        /// <summary>
        /// Delete a version of form template by name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        void DeleteTemplatesByNameAndVersion(string name, int? version);

        /// <summary>
        /// List all user form templates or get templates by name, or a template by name and version
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"> (optional)</param>
        /// <param name="version"> (optional)</param>
        /// <returns>List&lt;HumanTaskTemplate&gt;</returns>
        List<HumanTaskTemplate> GetAllTemplates(string name = null, int? version = null);

        /// <summary>
        /// Get a task
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns>HumanTaskEntry</returns>
        HumanTaskEntry GetTask(string taskId);

        /// <summary>
        /// Get list of task display names applicable for the user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="searchType"></param>
        /// <returns>List&lt;string&gt;</returns>
        List<string> GetTaskDisplayNames(string searchType);

        /// <summary>
        /// Get user form template by name and version
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <returns>HumanTaskTemplate</returns>
        HumanTaskTemplate GetTemplateByNameAndVersion(string name, int? version);

        /// <summary>
        /// Get user form by human task id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="humanTaskId"></param>
        /// <returns>HumanTaskTemplate</returns>
        HumanTaskTemplate GetTemplateByTaskId(string humanTaskId);

        /// <summary>
        /// Release a task without completing it
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="taskId"></param>
        /// <returns></returns>
        void ReassignTask(List<HumanTaskAssignment> body, string taskId);

        /// <summary>
        /// Release a task without completing it
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns></returns>
        void ReleaseTask(string taskId);

        /// <summary>
        /// Save user form template
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="newVersion"> (optional, default to false)</param>
        /// <returns>HumanTaskTemplate</returns>
        HumanTaskTemplate SaveTemplate(HumanTaskTemplate body, bool? newVersion = null);

        /// <summary>
        /// Save user form template
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="newVersion"> (optional, default to false)</param>
        /// <returns>List&lt;HumanTaskTemplate&gt;</returns>
        List<HumanTaskTemplate> SaveTemplates(List<HumanTaskTemplate> body, bool? newVersion = null);

        /// <summary>
        /// Search human tasks
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>HumanTaskSearchResult</returns>
        HumanTaskSearchResult Search(HumanTaskSearch body);

        /// <summary>
        /// If a task is assigned to a user, this API can be used to skip that assignment and move to the next assignee
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="reason"> (optional)</param>
        /// <returns></returns>
        void SkipTask(string taskId, string reason = null);

        /// <summary>
        /// Update task output, optionally complete
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="taskId"></param>
        /// <param name="complete"> (optional, default to false)</param>
        /// <returns></returns>
        void UpdateTaskOutput(Dictionary<string, Object> body, string taskId, bool? complete = null);

        /// <summary>
        /// Update task output, optionally complete
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="workflowId"></param>
        /// <param name="taskRefName"></param>
        /// <param name="complete"> (optional, default to false)</param>
        /// <param name="iteration">Populate this value if your task is in a loop and you want to update a specific iteration. If its not in a loop OR if you want to just update the latest iteration, leave this as empty (optional)</param>
        /// <returns></returns>
        void UpdateTaskOutputByRef(Dictionary<string, Object> body, string workflowId, string taskRefName, bool? complete = null, List<int?> iteration = null);

        /// <summary>
        /// Get Conductor task by id (for human tasks only)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns>Task</returns>
        Task GetConductorTaskById(string taskId);

        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Claim a task to an external user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="userId"></param>
        /// <param name="overrideAssignment"> (optional, default to false)</param>
        /// <returns>Task of HumanTaskEntry</returns>
        System.Threading.Tasks.Task<HumanTaskEntry> AssignAndClaimAsync(string taskId, string userId, bool? overrideAssignment = null);

        /// <summary>
        /// Claim a task by authenticated Conductor user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="overrideAssignment"> (optional, default to false)</param>
        /// <returns>Task of HumanTaskEntry</returns>
        System.Threading.Tasks.Task<HumanTaskEntry> ClaimTaskAsync(string taskId, bool? overrideAssignment = null);

        /// <summary>
        /// Delete all versions of user form template by name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DeleteTemplateByNameAsync(string name);

        /// <summary>
        /// Delete a version of form template by name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DeleteTemplatesByNameAndVersionAsync(string name, int? version);

        /// <summary>
        /// List all user form templates or get templates by name, or a template by name and version
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"> (optional)</param>
        /// <param name="version"> (optional)</param>
        /// <returns>Task of List&lt;HumanTaskTemplate&gt;</returns>
        System.Threading.Tasks.Task<List<HumanTaskTemplate>> GetAllTemplatesAsync(string name = null, int? version = null);

        /// <summary>
        /// Get a task
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns>Task of HumanTaskEntry</returns>
        System.Threading.Tasks.Task<HumanTaskEntry> GetTaskAsync(string taskId);

        /// <summary>
        /// Get list of task display names applicable for the user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="searchType"></param>
        /// <returns>Task of List&lt;string&gt;</returns>
        System.Threading.Tasks.Task<List<string>> GetTaskDisplayNamesAsync(string searchType);

        /// <summary>
        /// Get user form template by name and version
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <returns>Task of HumanTaskTemplate</returns>
        System.Threading.Tasks.Task<HumanTaskTemplate> GetTemplateByNameAndVersionAsync(string name, int? version);

        /// <summary>
        /// Get user form by human task id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="humanTaskId"></param>
        /// <returns>Task of HumanTaskTemplate</returns>
        System.Threading.Tasks.Task<HumanTaskTemplate> GetTemplateByTaskIdAsync(string humanTaskId);

        /// <summary>
        /// Reassign a task without completing it
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="taskId"></param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ReassignTaskAsync(List<HumanTaskAssignment> body, string taskId);

        /// <summary>
        /// Release a task without completing it
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ReleaseTaskAsync(string taskId);

        /// <summary>
        /// Save user form template
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="newVersion"> (optional, default to false)</param>
        /// <returns>Task of HumanTaskTemplate</returns>
        System.Threading.Tasks.Task<HumanTaskTemplate> SaveTemplateAsync(HumanTaskTemplate body, bool? newVersion = null);

        /// <summary>
        /// Save user form template
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="newVersion"> (optional, default to false)</param>
        /// <returns>Task of List&lt;HumanTaskTemplate&gt;</returns>
        System.Threading.Tasks.Task<List<HumanTaskTemplate>> SaveTemplatesAsync(List<HumanTaskTemplate> body, bool? newVersion = null);

        /// <summary>
        /// Search human tasks
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>Task of HumanTaskSearchResult</returns>
        System.Threading.Tasks.Task<HumanTaskSearchResult> SearchAsync(HumanTaskSearch body);

        /// <summary>
        /// If a task is assigned to a user, this API can be used to skip that assignment and move to the next assignee
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="reason"> (optional)</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task SkipTaskAsync(string taskId, string reason = null);

        /// <summary>
        /// Update task output, optionally complete
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="taskId"></param>
        /// <param name="complete"> (optional, default to false)</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task UpdateTaskOutputAsync(Dictionary<string, Object> body, string taskId, bool? complete = null);

        /// <summary>
        /// Update task output, optionally complete
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="workflowId"></param>
        /// <param name="taskRefName"></param>
        /// <param name="complete"> (optional, default to false)</param>
        /// <param name="iteration">Populate this value if your task is in a loop and you want to update a specific iteration. If its not in a loop OR if you want to just update the latest iteration, leave this as empty (optional)</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task UpdateTaskOutputByRefAsync(Dictionary<string, Object> body, string workflowId, string taskRefName, bool? complete = null, List<int?> iteration = null);

        /// <summary>
        /// Get Conductor task by id (for human tasks only)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns>Task of Task</returns>
        System.Threading.Tasks.Task<Task> GetConductorTaskByIdAsync(string taskId);

        #endregion Asynchronous Operations
    }
}
