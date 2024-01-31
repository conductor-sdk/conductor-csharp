using System;
using System.Collections.Generic;
using Conductor.Client;
using Conductor.Client.Models;

namespace Conductor.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ITagsApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Adds the tag to the task
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="taskName"></param>
        /// <returns>Object</returns>
        Object AddTaskTag(TagObject body, string taskName);

        /// <summary>
        /// Adds the tag to the task
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="taskName"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> AddTaskTagWithHttpInfo(TagObject body, string taskName);
        /// <summary>
        /// Adds the tag to the workflow
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>Object</returns>
        Object AddWorkflowTag(TagObject body, string name);

        /// <summary>
        /// Adds the tag to the workflow
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> AddWorkflowTagWithHttpInfo(TagObject body, string name);
        /// <summary>
        /// Removes the tag of the task
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="taskName"></param>
        /// <returns>Object</returns>
        Object DeleteTaskTag(TagString body, string taskName);

        /// <summary>
        /// Removes the tag of the task
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="taskName"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> DeleteTaskTagWithHttpInfo(TagString body, string taskName);
        /// <summary>
        /// Removes the tag of the workflow
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>Object</returns>
        Object DeleteWorkflowTag(TagObject body, string name);

        /// <summary>
        /// Removes the tag of the workflow
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> DeleteWorkflowTagWithHttpInfo(TagObject body, string name);
        /// <summary>
        /// List all tags
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;TagObject&gt;</returns>
        List<TagObject> GetTags();

        /// <summary>
        /// List all tags
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;TagObject&gt;</returns>
        ApiResponse<List<TagObject>> GetTagsWithHttpInfo();
        /// <summary>
        /// Returns all the tags of the task
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskName"></param>
        /// <returns>List&lt;TagObject&gt;</returns>
        List<TagObject> GetTaskTags(string taskName);

        /// <summary>
        /// Returns all the tags of the task
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskName"></param>
        /// <returns>ApiResponse of List&lt;TagObject&gt;</returns>
        ApiResponse<List<TagObject>> GetTaskTagsWithHttpInfo(string taskName);
        /// <summary>
        /// Returns all the tags of the workflow
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>List&lt;TagObject&gt;</returns>
        List<TagObject> GetWorkflowTags(string name);

        /// <summary>
        /// Returns all the tags of the workflow
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>ApiResponse of List&lt;TagObject&gt;</returns>
        ApiResponse<List<TagObject>> GetWorkflowTagsWithHttpInfo(string name);
        /// <summary>
        /// Adds the tag to the task
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="taskName"></param>
        /// <returns>Object</returns>
        Object SetTaskTags(List<TagObject> body, string taskName);

        /// <summary>
        /// Adds the tag to the task
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="taskName"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> SetTaskTagsWithHttpInfo(List<TagObject> body, string taskName);
        /// <summary>
        /// Set the tags of the workflow
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>Object</returns>
        Object SetWorkflowTags(List<TagObject> body, string name);

        /// <summary>
        /// Set the tags of the workflow
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> SetWorkflowTagsWithHttpInfo(List<TagObject> body, string name);
        #endregion Synchronous Operations
    }
}