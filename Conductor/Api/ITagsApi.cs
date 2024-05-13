/*
 * Copyright 2024 Conductor Authors.
 * <p>
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with
 * the License. You may obtain a copy of the License at
 * <p>
 * http://www.apache.org/licenses/LICENSE-2.0
 * <p>
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on
 * an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the
 * specific language governing permissions and limitations under the License.
 */
using Conductor.Client.Models;
using Conductor.Client;
using System;
using System.Collections.Generic;
using System.Text;
using ThreadTask = System.Threading.Tasks;

namespace conductor_csharp.Api
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
        /// List all tags
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;TagObject&gt;</returns>
        List<TagObject> GetTags();

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

        #endregion Synchronous Operations

        #region Asynchronous Operations
        /// <summary>
        /// Asynchronous Adds the tag to the task
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="taskName"></param>
        /// <returns>Object</returns>
        ThreadTask.Task<Object> AddTaskTagAsync(TagObject body, string taskName);

        /// <summary>
        /// Asynchronous Adds the tag to the workflow
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>Object</returns>
        ThreadTask.Task<Object> AddWorkflowTagAsync(TagObject body, string name);

        /// <summary>
        /// Asynchronous Removes the tag of the task
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="taskName"></param>
        /// <returns>Object</returns>
        ThreadTask.Task<Object> DeleteTaskTagAsync(TagString body, string taskName);

        /// <summary>
        /// Asynchronous Removes the tag of the workflow
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>Object</returns>
        ThreadTask.Task<Object> DeleteWorkflowTagAsync(TagObject body, string name);

        /// <summary>
        /// Asynchronous List all tags
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;TagObject&gt;</returns>
        ThreadTask.Task<List<TagObject>> GetTagsAsync();

        /// <summary>
        /// Asynchronous Returns all the tags of the task
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskName"></param>
        /// <returns>List&lt;TagObject&gt;</returns>
        ThreadTask.Task<List<TagObject>> GetTaskTagsAsync(string taskName);

        /// <summary>
        /// Asynchronous Returns all the tags of the workflow
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>List&lt;TagObject&gt;</returns>
        ThreadTask.Task<List<TagObject>> GetWorkflowTagsAsync(string name);

        /// <summary>
        /// Asynchronous Adds the tag to the task
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="taskName"></param>
        /// <returns>Object</returns>
        ThreadTask.Task<Object> SetTaskTagsAsync(List<TagObject> body, string taskName);

        /// <summary>
        /// Asynchronous Set the tags of the workflow
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>Object</returns>
        ThreadTask.Task<Object> SetWorkflowTagsAsync(List<TagObject> body, string name);
        #endregion Asynchronous Operations
    }
}
