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
    public interface ITokenResourceApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Generate JWT with the given access key
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>Response</returns>
        Token GenerateToken(GenerateTokenRequest body);

        /// <summary>
        /// Get the user info from the token
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="claims"> (optional, default to false)</param>
        /// <returns>Object</returns>
        Object GetUserInfo(bool? claims = null);

        #endregion Synchronous Operations

        #region Asynchronous Operations
        /// <summary>
        /// Asynchronous Generate JWT with the given access key
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>Response</returns>
        ThreadTask.Task<Token> GenerateTokenAsync(GenerateTokenRequest body);

        /// <summary>
        /// Asynchronous Get the user info from the token
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="claims"> (optional, default to false)</param>
        /// <returns>Object</returns>
        ThreadTask.Task<Object> GetUserInfoAsync(bool? claims = null);

        #endregion Asynchronous Operations
    }
}
