# IO.Swagger.Api.WorkflowBulkResourceApi

All URIs are relative to *https://pg-staging.orkesconductor.com/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**PauseWorkflow1**](WorkflowBulkResourceApi.md#pauseworkflow1) | **PUT** /api/workflow/bulk/pause | Pause the list of workflows
[**Restart1**](WorkflowBulkResourceApi.md#restart1) | **POST** /api/workflow/bulk/restart | Restart the list of completed workflow
[**ResumeWorkflow1**](WorkflowBulkResourceApi.md#resumeworkflow1) | **PUT** /api/workflow/bulk/resume | Resume the list of workflows
[**Retry1**](WorkflowBulkResourceApi.md#retry1) | **POST** /api/workflow/bulk/retry | Retry the last failed task for each workflow from the list
[**Terminate**](WorkflowBulkResourceApi.md#terminate) | **POST** /api/workflow/bulk/terminate | Terminate workflows execution

<a name="pauseworkflow1"></a>
# **PauseWorkflow1**
> BulkResponse PauseWorkflow1 (List<string> body)

Pause the list of workflows

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PauseWorkflow1Example
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowBulkResourceApi();
            var body = new List<string>(); // List<string> | 

            try
            {
                // Pause the list of workflows
                BulkResponse result = apiInstance.PauseWorkflow1(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowBulkResourceApi.PauseWorkflow1: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**List&lt;string&gt;**](string.md)|  | 

### Return type

[**BulkResponse**](BulkResponse.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="restart1"></a>
# **Restart1**
> BulkResponse Restart1 (List<string> body, bool? useLatestDefinitions = null)

Restart the list of completed workflow

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class Restart1Example
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowBulkResourceApi();
            var body = new List<string>(); // List<string> | 
            var useLatestDefinitions = true;  // bool? |  (optional)  (default to false)

            try
            {
                // Restart the list of completed workflow
                BulkResponse result = apiInstance.Restart1(body, useLatestDefinitions);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowBulkResourceApi.Restart1: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**List&lt;string&gt;**](string.md)|  | 
 **useLatestDefinitions** | **bool?**|  | [optional] [default to false]

### Return type

[**BulkResponse**](BulkResponse.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="resumeworkflow1"></a>
# **ResumeWorkflow1**
> BulkResponse ResumeWorkflow1 (List<string> body)

Resume the list of workflows

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ResumeWorkflow1Example
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowBulkResourceApi();
            var body = new List<string>(); // List<string> | 

            try
            {
                // Resume the list of workflows
                BulkResponse result = apiInstance.ResumeWorkflow1(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowBulkResourceApi.ResumeWorkflow1: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**List&lt;string&gt;**](string.md)|  | 

### Return type

[**BulkResponse**](BulkResponse.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="retry1"></a>
# **Retry1**
> BulkResponse Retry1 (List<string> body)

Retry the last failed task for each workflow from the list

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class Retry1Example
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowBulkResourceApi();
            var body = new List<string>(); // List<string> | 

            try
            {
                // Retry the last failed task for each workflow from the list
                BulkResponse result = apiInstance.Retry1(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowBulkResourceApi.Retry1: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**List&lt;string&gt;**](string.md)|  | 

### Return type

[**BulkResponse**](BulkResponse.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="terminate"></a>
# **Terminate**
> BulkResponse Terminate (List<string> body, string reason = null)

Terminate workflows execution

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class TerminateExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowBulkResourceApi();
            var body = new List<string>(); // List<string> | 
            var reason = reason_example;  // string |  (optional) 

            try
            {
                // Terminate workflows execution
                BulkResponse result = apiInstance.Terminate(body, reason);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowBulkResourceApi.Terminate: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**List&lt;string&gt;**](string.md)|  | 
 **reason** | **string**|  | [optional] 

### Return type

[**BulkResponse**](BulkResponse.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
