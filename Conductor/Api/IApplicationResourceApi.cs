using System;
using System.Collections.Generic;
using Conductor.Client;
using Conductor.Client.Models;

namespace Conductor.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IApplicationResourceApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="applicationId"></param>
        /// <param name="role"></param>
        /// <returns>Object</returns>
        Object AddRoleToApplicationUser(string applicationId, string role);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="applicationId"></param>
        /// <param name="role"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> AddRoleToApplicationUserWithHttpInfo(string applicationId, string role);
        /// <summary>
        /// Create an access key for an application
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        Object CreateAccessKey(string id);

        /// <summary>
        /// Create an access key for an application
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> CreateAccessKeyWithHttpInfo(string id);
        /// <summary>
        /// Create an application
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>Object</returns>
        Object CreateApplication(CreateOrUpdateApplicationRequest body);

        /// <summary>
        /// Create an application
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> CreateApplicationWithHttpInfo(CreateOrUpdateApplicationRequest body);
        /// <summary>
        /// Delete an access key
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="applicationId"></param>
        /// <param name="keyId"></param>
        /// <returns>Object</returns>
        Object DeleteAccessKey(string applicationId, string keyId);

        /// <summary>
        /// Delete an access key
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="applicationId"></param>
        /// <param name="keyId"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> DeleteAccessKeyWithHttpInfo(string applicationId, string keyId);
        /// <summary>
        /// Delete an application
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        Object DeleteApplication(string id);

        /// <summary>
        /// Delete an application
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> DeleteApplicationWithHttpInfo(string id);
        /// <summary>
        /// Delete a tag for application
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteTagForApplication(List<TagObject> body, string id);

        /// <summary>
        /// Delete a tag for application
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="id"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DeleteTagForApplicationWithHttpInfo(List<TagObject> body, string id);
        /// <summary>
        /// Get application&#x27;s access keys
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        Object GetAccessKeys(string id);

        /// <summary>
        /// Get application&#x27;s access keys
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> GetAccessKeysWithHttpInfo(string id);
        /// <summary>
        /// Get application id by access key id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accessKeyId"></param>
        /// <returns>Object</returns>
        Object GetAppByAccessKeyId(string accessKeyId);

        /// <summary>
        /// Get application id by access key id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accessKeyId"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> GetAppByAccessKeyIdWithHttpInfo(string accessKeyId);
        /// <summary>
        /// Get an application by id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        Object GetApplication(string id);

        /// <summary>
        /// Get an application by id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> GetApplicationWithHttpInfo(string id);
        /// <summary>
        /// Get tags by application
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>List&lt;TagObject&gt;</returns>
        List<TagObject> GetTagsForApplication(string id);

        /// <summary>
        /// Get tags by application
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>ApiResponse of List&lt;TagObject&gt;</returns>
        ApiResponse<List<TagObject>> GetTagsForApplicationWithHttpInfo(string id);
        /// <summary>
        /// Get all applications
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;ExtendedConductorApplication&gt;</returns>
        List<ExtendedConductorApplication> ListApplications();

        /// <summary>
        /// Get all applications
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;ExtendedConductorApplication&gt;</returns>
        ApiResponse<List<ExtendedConductorApplication>> ListApplicationsWithHttpInfo();
        /// <summary>
        /// Put a tag to application
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        void PutTagForApplication(List<TagObject> body, string id);

        /// <summary>
        /// Put a tag to application
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="id"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> PutTagForApplicationWithHttpInfo(List<TagObject> body, string id);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="applicationId"></param>
        /// <param name="role"></param>
        /// <returns>Object</returns>
        Object RemoveRoleFromApplicationUser(string applicationId, string role);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="applicationId"></param>
        /// <param name="role"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> RemoveRoleFromApplicationUserWithHttpInfo(string applicationId, string role);
        /// <summary>
        /// Toggle the status of an access key
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="applicationId"></param>
        /// <param name="keyId"></param>
        /// <returns>Object</returns>
        Object ToggleAccessKeyStatus(string applicationId, string keyId);

        /// <summary>
        /// Toggle the status of an access key
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="applicationId"></param>
        /// <param name="keyId"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> ToggleAccessKeyStatusWithHttpInfo(string applicationId, string keyId);
        /// <summary>
        /// Update an application
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        Object UpdateApplication(CreateOrUpdateApplicationRequest body, string id);

        /// <summary>
        /// Update an application
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="id"></param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> UpdateApplicationWithHttpInfo(CreateOrUpdateApplicationRequest body, string id);
        #endregion Synchronous Operations
    }
}