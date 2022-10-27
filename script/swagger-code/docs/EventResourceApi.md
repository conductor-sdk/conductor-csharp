# IO.Swagger.Api.EventResourceApi

All URIs are relative to *https://pg-staging.orkesconductor.com/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AddEventHandler**](EventResourceApi.md#addeventhandler) | **POST** /api/event | Add a new event handler.
[**DeleteQueueConfig**](EventResourceApi.md#deletequeueconfig) | **DELETE** /api/event/queue/config/{queueType}/{queueName} | Delete queue config by name
[**GetEventHandlers**](EventResourceApi.md#geteventhandlers) | **GET** /api/event | Get all the event handlers
[**GetEventHandlersForEvent**](EventResourceApi.md#geteventhandlersforevent) | **GET** /api/event/{event} | Get event handlers for a given event
[**GetQueueConfig**](EventResourceApi.md#getqueueconfig) | **GET** /api/event/queue/config/{queueType}/{queueName} | Get queue config by name
[**GetQueueNames**](EventResourceApi.md#getqueuenames) | **GET** /api/event/queue/config | Get all queue configs
[**PutQueueConfig**](EventResourceApi.md#putqueueconfig) | **PUT** /api/event/queue/config/{queueType}/{queueName} | Create or update queue config by name
[**RemoveEventHandlerStatus**](EventResourceApi.md#removeeventhandlerstatus) | **DELETE** /api/event/{name} | Remove an event handler
[**UpdateEventHandler**](EventResourceApi.md#updateeventhandler) | **PUT** /api/event | Update an existing event handler.

<a name="addeventhandler"></a>
# **AddEventHandler**
> void AddEventHandler (EventHandler body)

Add a new event handler.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AddEventHandlerExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new EventResourceApi();
            var body = new EventHandler(); // EventHandler | 

            try
            {
                // Add a new event handler.
                apiInstance.AddEventHandler(body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling EventResourceApi.AddEventHandler: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**EventHandler**](EventHandler.md)|  | 

### Return type

void (empty response body)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="deletequeueconfig"></a>
# **DeleteQueueConfig**
> void DeleteQueueConfig (string queueType, string queueName)

Delete queue config by name

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class DeleteQueueConfigExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new EventResourceApi();
            var queueType = queueType_example;  // string | 
            var queueName = queueName_example;  // string | 

            try
            {
                // Delete queue config by name
                apiInstance.DeleteQueueConfig(queueType, queueName);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling EventResourceApi.DeleteQueueConfig: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **queueType** | **string**|  | 
 **queueName** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="geteventhandlers"></a>
# **GetEventHandlers**
> List<EventHandler> GetEventHandlers ()

Get all the event handlers

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetEventHandlersExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new EventResourceApi();

            try
            {
                // Get all the event handlers
                List&lt;EventHandler&gt; result = apiInstance.GetEventHandlers();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling EventResourceApi.GetEventHandlers: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<EventHandler>**](EventHandler.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="geteventhandlersforevent"></a>
# **GetEventHandlersForEvent**
> List<EventHandler> GetEventHandlersForEvent (string _event, bool? activeOnly = null)

Get event handlers for a given event

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetEventHandlersForEventExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new EventResourceApi();
            var _event = _event_example;  // string | 
            var activeOnly = true;  // bool? |  (optional)  (default to true)

            try
            {
                // Get event handlers for a given event
                List&lt;EventHandler&gt; result = apiInstance.GetEventHandlersForEvent(_event, activeOnly);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling EventResourceApi.GetEventHandlersForEvent: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **_event** | **string**|  | 
 **activeOnly** | **bool?**|  | [optional] [default to true]

### Return type

[**List<EventHandler>**](EventHandler.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getqueueconfig"></a>
# **GetQueueConfig**
> Dictionary<string, Object> GetQueueConfig (string queueType, string queueName)

Get queue config by name

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetQueueConfigExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new EventResourceApi();
            var queueType = queueType_example;  // string | 
            var queueName = queueName_example;  // string | 

            try
            {
                // Get queue config by name
                Dictionary&lt;string, Object&gt; result = apiInstance.GetQueueConfig(queueType, queueName);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling EventResourceApi.GetQueueConfig: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **queueType** | **string**|  | 
 **queueName** | **string**|  | 

### Return type

**Dictionary<string, Object>**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getqueuenames"></a>
# **GetQueueNames**
> Dictionary<string, string> GetQueueNames ()

Get all queue configs

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetQueueNamesExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new EventResourceApi();

            try
            {
                // Get all queue configs
                Dictionary&lt;string, string&gt; result = apiInstance.GetQueueNames();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling EventResourceApi.GetQueueNames: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**Dictionary<string, string>**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="putqueueconfig"></a>
# **PutQueueConfig**
> void PutQueueConfig (string body, string queueType, string queueName)

Create or update queue config by name

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PutQueueConfigExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new EventResourceApi();
            var body = new string(); // string | 
            var queueType = queueType_example;  // string | 
            var queueName = queueName_example;  // string | 

            try
            {
                // Create or update queue config by name
                apiInstance.PutQueueConfig(body, queueType, queueName);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling EventResourceApi.PutQueueConfig: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**string**](string.md)|  | 
 **queueType** | **string**|  | 
 **queueName** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="removeeventhandlerstatus"></a>
# **RemoveEventHandlerStatus**
> void RemoveEventHandlerStatus (string name)

Remove an event handler

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RemoveEventHandlerStatusExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new EventResourceApi();
            var name = name_example;  // string | 

            try
            {
                // Remove an event handler
                apiInstance.RemoveEventHandlerStatus(name);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling EventResourceApi.RemoveEventHandlerStatus: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="updateeventhandler"></a>
# **UpdateEventHandler**
> void UpdateEventHandler (EventHandler body)

Update an existing event handler.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UpdateEventHandlerExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new EventResourceApi();
            var body = new EventHandler(); // EventHandler | 

            try
            {
                // Update an existing event handler.
                apiInstance.UpdateEventHandler(body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling EventResourceApi.UpdateEventHandler: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**EventHandler**](EventHandler.md)|  | 

### Return type

void (empty response body)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
