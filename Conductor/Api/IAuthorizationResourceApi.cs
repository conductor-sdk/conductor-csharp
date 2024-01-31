using System;
using Conductor.Client;
using Conductor.Client.Models;

namespace Conductor.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IAuthorizationResourceApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get the access that have been granted over the given object
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        Object GetPermissions(string type, string id);

        /// <summary>
        /// Get the access that have been granted over the given object
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> GetPermissionsWithHttpInfo(string type, string id);
        /// <summary>
        /// Grant access to a user over the target
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>Response</returns>
        Response GrantPermissions(AuthorizationRequest body);

        /// <summary>
        /// Grant access to a user over the target
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>ApiResponse of Response</returns>
        ApiResponse<Response> GrantPermissionsWithHttpInfo(AuthorizationRequest body);
        /// <summary>
        /// Remove user&#x27;s access over the target
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>Response</returns>
        Response RemovePermissions(AuthorizationRequest body);

        /// <summary>
        /// Remove user&#x27;s access over the target
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>ApiResponse of Response</returns>
        ApiResponse<Response> RemovePermissionsWithHttpInfo(AuthorizationRequest body);
        #endregion Synchronous Operations
    }
}