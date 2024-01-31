using System;
using System.Collections.Generic;
using Conductor.Client;
using EventHandler = Conductor.Client.Models.EventHandler;

namespace Conductor.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
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
        /// Add a new event handler.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> AddEventHandlerWithHttpInfo(EventHandler body);
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
        /// Delete queue config by name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="queueType"></param>
        /// <param name="queueName"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DeleteQueueConfigWithHttpInfo(string queueType, string queueName);
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
        /// Get all the event handlers
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;EventHandler&gt;</returns>
        ApiResponse<List<EventHandler>> GetEventHandlersWithHttpInfo();
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
        /// Get event handlers for a given event
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="_event"></param>
        /// <param name="activeOnly"> (optional, default to true)</param>
        /// <returns>ApiResponse of List&lt;EventHandler&gt;</returns>
        ApiResponse<List<EventHandler>> GetEventHandlersForEventWithHttpInfo(string _event, bool? activeOnly = null);
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
        /// Get queue config by name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="queueType"></param>
        /// <param name="queueName"></param>
        /// <returns>ApiResponse of Dictionary&lt;string, Object&gt;</returns>
        ApiResponse<Dictionary<string, Object>> GetQueueConfigWithHttpInfo(string queueType, string queueName);
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
        /// Get all queue configs
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Dictionary&lt;string, string&gt;</returns>
        ApiResponse<Dictionary<string, string>> GetQueueNamesWithHttpInfo();
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
        /// Create or update queue config by name
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="queueType"></param>
        /// <param name="queueName"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> PutQueueConfigWithHttpInfo(string body, string queueType, string queueName);
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
        /// Remove an event handler
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> RemoveEventHandlerStatusWithHttpInfo(string name);
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

        /// <summary>
        /// Update an existing event handler.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Conductor.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> UpdateEventHandlerWithHttpInfo(EventHandler body);
        #endregion Synchronous Operations
    }
}