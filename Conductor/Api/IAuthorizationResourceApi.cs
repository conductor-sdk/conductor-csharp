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
        /// Remove user&#x27;s access over the target
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>Response</returns>
        Response RemovePermissions(AuthorizationRequest body);

        #endregion Synchronous Operations

        #region Asynchronous Operations
        /// <summary>
        /// Asynchronous Get the access that have been granted over the given object
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        ThreadTask.Task<Object> GetPermissionsAsync(string type, string id);

        /// <summary>
        /// Asynchronous Grant access to a user over the target
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>Response</returns>
        ThreadTask.Task<Response> GrantPermissionsAsync(AuthorizationRequest body);

        /// <summary>
        /// Asynchronous Remove user&#x27;s access over the target
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>Response</returns>
        ThreadTask.Task<Response> RemovePermissionsAsync(AuthorizationRequest body);


        #endregion Asynchronous Operations
    }
}
