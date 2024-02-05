using Conductor.Client;
using System;
using System.Collections.Generic;
using System.Text;
using ThreadTask = System.Threading.Tasks;
using EventHandler = Conductor.Client.Models.EventHandler;

namespace conductor_csharp.Api
{
    // <summary>
    // Represents a collection of functions to interact with the API endpoints
    // </summary>
    public interface IEventResourceApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Add a new event handler.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns></returns>
        void AddEventHandler(EventHandler body);

        /// <summary>
        /// Delete queue config by name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="queueType"></param>
        /// <param name="queueName"></param>
        /// <returns></returns>
        void DeleteQueueConfig(string queueType, string queueName);

        /// <summary>
        /// Get all the event handlers
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;EventHandler&gt;</returns>
        List<EventHandler> GetEventHandlers();

        /// <summary>
        /// Get event handlers for a given event
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="_event"></param>
        /// <param name="activeOnly"> (optional, default to true)</param>
        /// <returns>List&lt;EventHandler&gt;</returns>
        List<EventHandler> GetEventHandlersForEvent(string _event, bool? activeOnly = null);

        /// <summary>
        /// Get queue config by name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="queueType"></param>
        /// <param name="queueName"></param>
        /// <returns>Dictionary&lt;string, Object&gt;</returns>
        Dictionary<string, Object> GetQueueConfig(string queueType, string queueName);

        /// <summary>
        /// Get all queue configs
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Dictionary&lt;string, string&gt;</returns>
        Dictionary<string, string> GetQueueNames();

        /// <summary>
        /// Create or update queue config by name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="queueType"></param>
        /// <param name="queueName"></param>
        /// <returns></returns>
        void PutQueueConfig(string body, string queueType, string queueName);

        /// <summary>
        /// Remove an event handler
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns></returns>
        void RemoveEventHandlerStatus(string name);

        /// <summary>
        /// Update an existing event handler.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns></returns>
        void UpdateEventHandler(EventHandler body);

        #endregion Synchronous Operations

        #region Asynchronous Operations
        /// <summary>
        /// Asynchronous Add a new event handler.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns></returns>
        void AddEventHandlerAsync(EventHandler body);

        /// <summary>
        /// Asynchronous Delete queue config by name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="queueType"></param>
        /// <param name="queueName"></param>
        /// <returns></returns>
        void DeleteQueueConfigAsync(string queueType, string queueName);

        /// <summary>
        /// Asynchronous Get all the event handlers
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;EventHandler&gt;</returns>
        ThreadTask.Task<List<EventHandler>> GetEventHandlersAsync();

        /// <summary>
        /// Asynchronous Get event handlers for a given event
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="_event"></param>
        /// <param name="activeOnly"> (optional, default to true)</param>
        /// <returns>List&lt;EventHandler&gt;</returns>
        ThreadTask.Task<List<EventHandler>> GetEventHandlersForEventAsync(string _event, bool? activeOnly = null);

        /// <summary>
        /// Asynchronous Get queue config by name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="queueType"></param>
        /// <param name="queueName"></param>
        /// <returns>Dictionary&lt;string, Object&gt;</returns>
        ThreadTask.Task<Dictionary<string, Object>> GetQueueConfigAsync(string queueType, string queueName);

        /// <summary>
        /// Asynchronous Get all queue configs
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Dictionary&lt;string, string&gt;</returns>
        ThreadTask.Task<Dictionary<string, string>> GetQueueNamesAsync();

        /// <summary>
        /// Asynchronous Create or update queue config by name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="queueType"></param>
        /// <param name="queueName"></param>
        /// <returns></returns>
        void PutQueueConfigAsync(string body, string queueType, string queueName);

        /// <summary>
        /// Asynchronous Remove an event handler
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns></returns>
        void RemoveEventHandlerStatusAsync(string name);

        /// <summary>
        /// Asynchronous Update an existing event handler.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns></returns>
        void UpdateEventHandlerAsync(EventHandler body);

        #endregion Asynchronous Operations
    }
}
