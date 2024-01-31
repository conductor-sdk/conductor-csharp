using System;
using System.Collections.Generic;
using Conductor.Client;
using Conductor.Client.Models;

namespace Conductor.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ISecretResourceApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Delete a secret value by key
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="key"></param>
        /// <returns>Object</returns>
        Object DeleteSecret(string key);

        /// <summary>
        /// Delete a secret value by key
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="key"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> DeleteSecretWithHttpInfo(string key);
        /// <summary>
        /// Delete tags of the secret
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        void DeleteTagForSecret(List<TagObject> body, string key);

        /// <summary>
        /// Delete tags of the secret
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="key"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DeleteTagForSecretWithHttpInfo(List<TagObject> body, string key);
        /// <summary>
        /// Get secret value by key
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="key"></param>
        /// <returns>Object</returns>
        Object GetSecret(string key);

        /// <summary>
        /// Get secret value by key
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="key"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> GetSecretWithHttpInfo(string key);
        /// <summary>
        /// Get tags by secret
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="key"></param>
        /// <returns>List&lt;TagObject&gt;</returns>
        List<TagObject> GetTags(string key);

        /// <summary>
        /// Get tags by secret
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="key"></param>
        /// <returns>ApiResponse of List&lt;TagObject&gt;</returns>
        ApiResponse<List<TagObject>> GetTagsWithHttpInfo(string key);
        /// <summary>
        /// List all secret names
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Object</returns>
        Object ListAllSecretNames();

        /// <summary>
        /// List all secret names
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> ListAllSecretNamesWithHttpInfo();
        /// <summary>
        /// List all secret names user can grant access to
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;string&gt;</returns>
        List<string> ListSecretsThatUserCanGrantAccessTo();

        /// <summary>
        /// List all secret names user can grant access to
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;string&gt;</returns>
        ApiResponse<List<string>> ListSecretsThatUserCanGrantAccessToWithHttpInfo();
        /// <summary>
        /// List all secret names along with tags user can grant access to
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;ExtendedSecret&gt;</returns>
        List<ExtendedSecret> ListSecretsWithTagsThatUserCanGrantAccessTo();

        /// <summary>
        /// List all secret names along with tags user can grant access to
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;ExtendedSecret&gt;</returns>
        ApiResponse<List<ExtendedSecret>> ListSecretsWithTagsThatUserCanGrantAccessToWithHttpInfo();
        /// <summary>
        /// Put a secret value by key
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="key"></param>
        /// <returns>Object</returns>
        Object PutSecret(string body, string key);

        /// <summary>
        /// Put a secret value by key
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="key"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> PutSecretWithHttpInfo(string body, string key);
        /// <summary>
        /// Tag a secret
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        void PutTagForSecret(List<TagObject> body, string key);

        /// <summary>
        /// Tag a secret
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="key"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> PutTagForSecretWithHttpInfo(List<TagObject> body, string key);
        /// <summary>
        /// Check if secret exists
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="key"></param>
        /// <returns>Object</returns>
        Object SecretExists(string key);

        /// <summary>
        /// Check if secret exists
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="key"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> SecretExistsWithHttpInfo(string key);
        #endregion Synchronous Operations
    }
}