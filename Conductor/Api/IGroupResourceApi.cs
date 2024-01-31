using System;
using System.Collections.Generic;
using Conductor.Client;
using Conductor.Client.Models;

namespace Conductor.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IGroupResourceApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Add user to group
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId"></param>
        /// <param name="userId"></param>
        /// <returns>Object</returns>
        Object AddUserToGroup(string groupId, string userId);

        /// <summary>
        /// Add user to group
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId"></param>
        /// <param name="userId"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> AddUserToGroupWithHttpInfo(string groupId, string userId);
        /// <summary>
        /// Add users to group
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        void AddUsersToGroup(List<string> body, string groupId);

        /// <summary>
        /// Add users to group
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="groupId"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> AddUsersToGroupWithHttpInfo(List<string> body, string groupId);
        /// <summary>
        /// Delete a group
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Response</returns>
        Response DeleteGroup(string id);

        /// <summary>
        /// Delete a group
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>ApiResponse of Response</returns>
        ApiResponse<Response> DeleteGroupWithHttpInfo(string id);
        /// <summary>
        /// Get the permissions this group has over workflows and tasks
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId"></param>
        /// <returns>Object</returns>
        Object GetGrantedPermissions(string groupId);

        /// <summary>
        /// Get the permissions this group has over workflows and tasks
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> GetGrantedPermissionsWithHttpInfo(string groupId);
        /// <summary>
        /// Get a group by id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        Object GetGroup(string id);

        /// <summary>
        /// Get a group by id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> GetGroupWithHttpInfo(string id);
        /// <summary>
        /// Get all users in group
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        Object GetUsersInGroup(string id);

        /// <summary>
        /// Get all users in group
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> GetUsersInGroupWithHttpInfo(string id);
        /// <summary>
        /// Get all groups
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;Group&gt;</returns>
        List<Group> ListGroups();

        /// <summary>
        /// Get all groups
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;Group&gt;</returns>
        ApiResponse<List<Group>> ListGroupsWithHttpInfo();
        /// <summary>
        /// Remove user from group
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId"></param>
        /// <param name="userId"></param>
        /// <returns>Object</returns>
        Object RemoveUserFromGroup(string groupId, string userId);

        /// <summary>
        /// Remove user from group
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId"></param>
        /// <param name="userId"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> RemoveUserFromGroupWithHttpInfo(string groupId, string userId);
        /// <summary>
        /// Remove users from group
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        void RemoveUsersFromGroup(List<string> body, string groupId);

        /// <summary>
        /// Remove users from group
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="groupId"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> RemoveUsersFromGroupWithHttpInfo(List<string> body, string groupId);
        /// <summary>
        /// Create or update a group
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        Object UpsertGroup(UpsertGroupRequest body, string id);

        /// <summary>
        /// Create or update a group
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="id"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> UpsertGroupWithHttpInfo(UpsertGroupRequest body, string id);
        #endregion Synchronous Operations
    }
}