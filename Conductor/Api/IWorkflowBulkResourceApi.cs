using System.Collections.Generic;
using Conductor.Client;
using Conductor.Client.Models;

namespace Conductor.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IWorkflowBulkResourceApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Pause the list of workflows
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>BulkResponse</returns>
        BulkResponse PauseWorkflow(List<string> body);

        /// <summary>
        /// Pause the list of workflows
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>ApiResponse of BulkResponse</returns>
        ApiResponse<BulkResponse> PauseWorkflowWithHttpInfo(List<string> body);
        /// <summary>
        /// Restart the list of completed workflow
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="useLatestDefinitions"> (optional, default to false)</param>
        /// <returns>BulkResponse</returns>
        BulkResponse Restart(List<string> body, bool? useLatestDefinitions = null);

        /// <summary>
        /// Restart the list of completed workflow
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="useLatestDefinitions"> (optional, default to false)</param>
        /// <returns>ApiResponse of BulkResponse</returns>
        ApiResponse<BulkResponse> RestartWithHttpInfo(List<string> body, bool? useLatestDefinitions = null);
        /// <summary>
        /// Resume the list of workflows
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>BulkResponse</returns>
        BulkResponse ResumeWorkflow(List<string> body);

        /// <summary>
        /// Resume the list of workflows
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>ApiResponse of BulkResponse</returns>
        ApiResponse<BulkResponse> ResumeWorkflowWithHttpInfo(List<string> body);
        /// <summary>
        /// Retry the last failed task for each workflow from the list
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>BulkResponse</returns>
        BulkResponse Retry(List<string> body);

        /// <summary>
        /// Retry the last failed task for each workflow from the list
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>ApiResponse of BulkResponse</returns>
        ApiResponse<BulkResponse> RetryWithHttpInfo(List<string> body);
        /// <summary>
        /// Terminate workflows execution
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="reason"> (optional)</param>
        /// <param name="triggerFailureWorkflow"> (optional, default to false)</param>
        /// <returns>BulkResponse</returns>
        BulkResponse Terminate(List<string> body, string reason = null, bool? triggerFailureWorkflow = null);

        /// <summary>
        /// Terminate workflows execution
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="reason"> (optional)</param>
        /// <param name="triggerFailureWorkflow"> (optional, default to false)</param>
        /// <returns>ApiResponse of BulkResponse</returns>
        ApiResponse<BulkResponse> TerminateWithHttpInfo(List<string> body, string reason = null, bool? triggerFailureWorkflow = null);
        #endregion Synchronous Operations
    }
}