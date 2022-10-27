# IO.Swagger.Api.SchedulerResourceApi

All URIs are relative to *https://pg-staging.orkesconductor.com/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DeleteSchedule**](SchedulerResourceApi.md#deleteschedule) | **DELETE** /api/scheduler/schedules/{name} | Deletes an existing workflow schedule by name
[**DeleteTagForSchedule**](SchedulerResourceApi.md#deletetagforschedule) | **DELETE** /api/scheduler/schedules/{name}/tags | Delete a tag for schedule
[**GetAllSchedules**](SchedulerResourceApi.md#getallschedules) | **GET** /api/scheduler/schedules | Get all existing workflow schedules and optionally filter by workflow name
[**GetNextFewSchedules**](SchedulerResourceApi.md#getnextfewschedules) | **GET** /api/scheduler/nextFewSchedules | Get list of the next x (default 3, max 5) execution times for a scheduler
[**GetSchedule**](SchedulerResourceApi.md#getschedule) | **GET** /api/scheduler/schedules/{name} | Get an existing workflow schedule by name
[**GetTagsForSchedule**](SchedulerResourceApi.md#gettagsforschedule) | **GET** /api/scheduler/schedules/{name}/tags | Get tags by schedule
[**PauseAllSchedules**](SchedulerResourceApi.md#pauseallschedules) | **GET** /api/scheduler/admin/pause | Pause all scheduling in a single conductor server instance (for debugging only)
[**PauseSchedule**](SchedulerResourceApi.md#pauseschedule) | **GET** /api/scheduler/schedules/{name}/pause | Pauses an existing schedule by name
[**PutTagForSchedule**](SchedulerResourceApi.md#puttagforschedule) | **PUT** /api/scheduler/schedules/{name}/tags | Put a tag to schedule
[**RequeueAllExecutionRecords**](SchedulerResourceApi.md#requeueallexecutionrecords) | **GET** /api/scheduler/admin/requeue | Requeue all execution records
[**ResumeAllSchedules**](SchedulerResourceApi.md#resumeallschedules) | **GET** /api/scheduler/admin/resume | Resume all scheduling
[**ResumeSchedule**](SchedulerResourceApi.md#resumeschedule) | **GET** /api/scheduler/schedules/{name}/resume | Resume a paused schedule by name
[**SaveSchedule**](SchedulerResourceApi.md#saveschedule) | **POST** /api/scheduler/schedules | Create or update a schedule for a specified workflow with a corresponding start workflow request
[**SearchV22**](SchedulerResourceApi.md#searchv22) | **GET** /api/scheduler/search/executions | Search for workflows based on payload and other parameters
[**TestTimeout**](SchedulerResourceApi.md#testtimeout) | **GET** /api/scheduler/test/timeout | Test timeout - do not use in production

<a name="deleteschedule"></a>
# **DeleteSchedule**
> Object DeleteSchedule (string name)

Deletes an existing workflow schedule by name

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class DeleteScheduleExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new SchedulerResourceApi();
            var name = name_example;  // string | 

            try
            {
                // Deletes an existing workflow schedule by name
                Object result = apiInstance.DeleteSchedule(name);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SchedulerResourceApi.DeleteSchedule: " + e.Message );
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

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="deletetagforschedule"></a>
# **DeleteTagForSchedule**
> void DeleteTagForSchedule (string name, string body = null)

Delete a tag for schedule

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class DeleteTagForScheduleExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new SchedulerResourceApi();
            var name = name_example;  // string | 
            var body = new string(); // string |  (optional) 

            try
            {
                // Delete a tag for schedule
                apiInstance.DeleteTagForSchedule(name, body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SchedulerResourceApi.DeleteTagForSchedule: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**|  | 
 **body** | [**string**](string.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getallschedules"></a>
# **GetAllSchedules**
> List<WorkflowSchedule> GetAllSchedules (string workflowName = null)

Get all existing workflow schedules and optionally filter by workflow name

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetAllSchedulesExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new SchedulerResourceApi();
            var workflowName = workflowName_example;  // string |  (optional) 

            try
            {
                // Get all existing workflow schedules and optionally filter by workflow name
                List&lt;WorkflowSchedule&gt; result = apiInstance.GetAllSchedules(workflowName);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SchedulerResourceApi.GetAllSchedules: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **workflowName** | **string**|  | [optional] 

### Return type

[**List<WorkflowSchedule>**](WorkflowSchedule.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getnextfewschedules"></a>
# **GetNextFewSchedules**
> List<long?> GetNextFewSchedules (string cronExpression, long? scheduleStartTime = null, long? scheduleEndTime = null, int? limit = null)

Get list of the next x (default 3, max 5) execution times for a scheduler

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetNextFewSchedulesExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new SchedulerResourceApi();
            var cronExpression = cronExpression_example;  // string | 
            var scheduleStartTime = 789;  // long? |  (optional) 
            var scheduleEndTime = 789;  // long? |  (optional) 
            var limit = 56;  // int? |  (optional)  (default to 3)

            try
            {
                // Get list of the next x (default 3, max 5) execution times for a scheduler
                List&lt;long?&gt; result = apiInstance.GetNextFewSchedules(cronExpression, scheduleStartTime, scheduleEndTime, limit);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SchedulerResourceApi.GetNextFewSchedules: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **cronExpression** | **string**|  | 
 **scheduleStartTime** | **long?**|  | [optional] 
 **scheduleEndTime** | **long?**|  | [optional] 
 **limit** | **int?**|  | [optional] [default to 3]

### Return type

**List<long?>**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getschedule"></a>
# **GetSchedule**
> WorkflowSchedule GetSchedule (string name)

Get an existing workflow schedule by name

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetScheduleExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new SchedulerResourceApi();
            var name = name_example;  // string | 

            try
            {
                // Get an existing workflow schedule by name
                WorkflowSchedule result = apiInstance.GetSchedule(name);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SchedulerResourceApi.GetSchedule: " + e.Message );
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

[**WorkflowSchedule**](WorkflowSchedule.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="gettagsforschedule"></a>
# **GetTagsForSchedule**
> List<TagObject> GetTagsForSchedule (string name)

Get tags by schedule

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetTagsForScheduleExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new SchedulerResourceApi();
            var name = name_example;  // string | 

            try
            {
                // Get tags by schedule
                List&lt;TagObject&gt; result = apiInstance.GetTagsForSchedule(name);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SchedulerResourceApi.GetTagsForSchedule: " + e.Message );
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

[**List<TagObject>**](TagObject.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="pauseallschedules"></a>
# **PauseAllSchedules**
> Dictionary<string, Object> PauseAllSchedules ()

Pause all scheduling in a single conductor server instance (for debugging only)

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PauseAllSchedulesExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new SchedulerResourceApi();

            try
            {
                // Pause all scheduling in a single conductor server instance (for debugging only)
                Dictionary&lt;string, Object&gt; result = apiInstance.PauseAllSchedules();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SchedulerResourceApi.PauseAllSchedules: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**Dictionary<string, Object>**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="pauseschedule"></a>
# **PauseSchedule**
> Object PauseSchedule (string name)

Pauses an existing schedule by name

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PauseScheduleExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new SchedulerResourceApi();
            var name = name_example;  // string | 

            try
            {
                // Pauses an existing schedule by name
                Object result = apiInstance.PauseSchedule(name);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SchedulerResourceApi.PauseSchedule: " + e.Message );
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

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="puttagforschedule"></a>
# **PutTagForSchedule**
> void PutTagForSchedule (string name, string body = null)

Put a tag to schedule

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PutTagForScheduleExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new SchedulerResourceApi();
            var name = name_example;  // string | 
            var body = new string(); // string |  (optional) 

            try
            {
                // Put a tag to schedule
                apiInstance.PutTagForSchedule(name, body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SchedulerResourceApi.PutTagForSchedule: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**|  | 
 **body** | [**string**](string.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="requeueallexecutionrecords"></a>
# **RequeueAllExecutionRecords**
> Dictionary<string, Object> RequeueAllExecutionRecords ()

Requeue all execution records

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RequeueAllExecutionRecordsExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new SchedulerResourceApi();

            try
            {
                // Requeue all execution records
                Dictionary&lt;string, Object&gt; result = apiInstance.RequeueAllExecutionRecords();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SchedulerResourceApi.RequeueAllExecutionRecords: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**Dictionary<string, Object>**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="resumeallschedules"></a>
# **ResumeAllSchedules**
> Dictionary<string, Object> ResumeAllSchedules ()

Resume all scheduling

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ResumeAllSchedulesExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new SchedulerResourceApi();

            try
            {
                // Resume all scheduling
                Dictionary&lt;string, Object&gt; result = apiInstance.ResumeAllSchedules();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SchedulerResourceApi.ResumeAllSchedules: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**Dictionary<string, Object>**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="resumeschedule"></a>
# **ResumeSchedule**
> Object ResumeSchedule (string name)

Resume a paused schedule by name

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ResumeScheduleExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new SchedulerResourceApi();
            var name = name_example;  // string | 

            try
            {
                // Resume a paused schedule by name
                Object result = apiInstance.ResumeSchedule(name);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SchedulerResourceApi.ResumeSchedule: " + e.Message );
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

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="saveschedule"></a>
# **SaveSchedule**
> Object SaveSchedule (SaveScheduleRequest body)

Create or update a schedule for a specified workflow with a corresponding start workflow request

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SaveScheduleExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new SchedulerResourceApi();
            var body = new SaveScheduleRequest(); // SaveScheduleRequest | 

            try
            {
                // Create or update a schedule for a specified workflow with a corresponding start workflow request
                Object result = apiInstance.SaveSchedule(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SchedulerResourceApi.SaveSchedule: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**SaveScheduleRequest**](SaveScheduleRequest.md)|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="searchv22"></a>
# **SearchV22**
> SearchResultWorkflowScheduleExecutionModel SearchV22 (int? start = null, int? size = null, string sort = null, string freeText = null, string query = null)

Search for workflows based on payload and other parameters

use sort options as sort=<field>:ASC|DESC e.g. sort=name&sort=workflowId:DESC. If order is not specified, defaults to ASC.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SearchV22Example
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new SchedulerResourceApi();
            var start = 56;  // int? |  (optional)  (default to 0)
            var size = 56;  // int? |  (optional)  (default to 100)
            var sort = sort_example;  // string |  (optional) 
            var freeText = freeText_example;  // string |  (optional)  (default to *)
            var query = query_example;  // string |  (optional) 

            try
            {
                // Search for workflows based on payload and other parameters
                SearchResultWorkflowScheduleExecutionModel result = apiInstance.SearchV22(start, size, sort, freeText, query);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SchedulerResourceApi.SearchV22: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **start** | **int?**|  | [optional] [default to 0]
 **size** | **int?**|  | [optional] [default to 100]
 **sort** | **string**|  | [optional] 
 **freeText** | **string**|  | [optional] [default to *]
 **query** | **string**|  | [optional] 

### Return type

[**SearchResultWorkflowScheduleExecutionModel**](SearchResultWorkflowScheduleExecutionModel.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="testtimeout"></a>
# **TestTimeout**
> void TestTimeout ()

Test timeout - do not use in production

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class TestTimeoutExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new SchedulerResourceApi();

            try
            {
                // Test timeout - do not use in production
                apiInstance.TestTimeout();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SchedulerResourceApi.TestTimeout: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

void (empty response body)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
