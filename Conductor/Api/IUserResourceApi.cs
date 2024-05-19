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
    public interface IUserResourceApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Delete a user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Response</returns>
        Response DeleteUser(string id);

        /// <summary>
        /// Get the permissions this user has over workflows and tasks
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <returns>Object</returns>
        Object GetGrantedPermissions(string userId);

        /// <summary>
        /// Get a user by id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        Object GetUser(string id);

        /// <summary>
        /// Get all users
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apps"> (optional, default to false)</param>
        /// <returns>List&lt;ConductorUser&gt;</returns>
        List<ConductorUser> ListUsers(bool? apps = null);

        /// <summary>
        /// Send an email with a link to this cluster
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <param name="body"> (optional)</param>
        /// <returns>Object</returns>
        Object SendInviteEmail(string id, ConductorUser body = null);

        /// <summary>
        /// Create or update a user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        Object UpsertUser(UpsertUserRequest body, string id);

        #endregion Synchronous Operations

        #region Asynchronous Operations
        /// <summary>
        /// Asynchronous Delete a user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Response</returns>
        ThreadTask.Task<Response> DeleteUserAsync(string id);

        /// <summary>
        /// Asynchronous Get the permissions this user has over workflows and tasks
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <returns>Object</returns>
        ThreadTask.Task<Object> GetGrantedPermissionsAsync(string userId);

        /// <summary>
        /// Asynchronous Get a user by id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        ThreadTask.Task<Object> GetUserAsync(string id);

        /// <summary>
        /// Asynchronous Get all users
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apps"> (optional, default to false)</param>
        /// <returns>List&lt;ConductorUser&gt;</returns>
        ThreadTask.Task<List<ConductorUser>> ListUsersAsync(bool? apps = null);

        /// <summary>
        /// Asynchronous Send an email with a link to this cluster
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <param name="body"> (optional)</param>
        /// <returns>Object</returns>
        ThreadTask.Task<Object> SendInviteEmailAsync(string id, ConductorUser body = null);

        /// <summary>
        /// Asynchronous Create or update a user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        ThreadTask.Task<Object> UpsertUserAsync(UpsertUserRequest body, string id);
        #endregion Asynchronous Operations
    }
}
