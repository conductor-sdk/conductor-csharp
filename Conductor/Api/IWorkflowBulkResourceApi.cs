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

        #endregion Synchronous Operations

        #region Asynchronous Operations
        /// <summary>
        /// Asynchronous Pause the list of workflows
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>BulkResponse</returns>
        ThreadTask.Task<BulkResponse> PauseWorkflowAsync(List<string> body);

        /// <summary>
        /// Asynchronous Restart the list of completed workflow
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="useLatestDefinitions"> (optional, default to false)</param>
        /// <returns>BulkResponse</returns>
        ThreadTask.Task<BulkResponse> RestartAsync(List<string> body, bool? useLatestDefinitions = null);

        /// <summary>
        /// Asynchronous Resume the list of workflows
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>BulkResponse</returns>
        ThreadTask.Task<BulkResponse> ResumeWorkflowAsync(List<string> body);

        /// <summary>
        /// Asynchronous Retry the last failed task for each workflow from the list
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>BulkResponse</returns>
        ThreadTask.Task<BulkResponse> RetryAsync(List<string> body);

        /// <summary>
        /// Asynchronous Terminate workflows execution
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="reason"> (optional)</param>
        /// <param name="triggerFailureWorkflow"> (optional, default to false)</param>
        /// <returns>BulkResponse</returns>
        ThreadTask.Task<BulkResponse> TerminateAsync(List<string> body, string reason = null, bool? triggerFailureWorkflow = null);
        #endregion Asynchronous Operations
    }
}
