# IO.Swagger.Api.MetadataResourceApi

All URIs are relative to *https://pg-staging.orkesconductor.com/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**Create**](MetadataResourceApi.md#create) | **POST** /api/metadata/workflow | Create a new workflow definition
[**Get**](MetadataResourceApi.md#get) | **GET** /api/metadata/workflow/{name} | Retrieves workflow definition along with blueprint
[**GetAllWorkflows**](MetadataResourceApi.md#getallworkflows) | **GET** /api/metadata/workflow | Retrieves all workflow definition along with blueprint
[**GetTaskDef**](MetadataResourceApi.md#gettaskdef) | **GET** /api/metadata/taskdefs/{tasktype} | Gets the task definition
[**GetTaskDefs**](MetadataResourceApi.md#gettaskdefs) | **GET** /api/metadata/taskdefs | Gets all task definition
[**RegisterTaskDef**](MetadataResourceApi.md#registertaskdef) | **POST** /api/metadata/taskdefs | Create or update task definition(s)
[**UnregisterTaskDef**](MetadataResourceApi.md#unregistertaskdef) | **DELETE** /api/metadata/taskdefs/{tasktype} | Remove a task definition
[**UnregisterWorkflowDef**](MetadataResourceApi.md#unregisterworkflowdef) | **DELETE** /api/metadata/workflow/{name}/{version} | Removes workflow definition. It does not remove workflows associated with the definition.
[**Update**](MetadataResourceApi.md#update) | **PUT** /api/metadata/workflow | Create or update workflow definition(s)
[**UpdateTaskDef**](MetadataResourceApi.md#updatetaskdef) | **PUT** /api/metadata/taskdefs | Update an existing task
[**UploadWorkflowsAndTasksDefinitionsToS3**](MetadataResourceApi.md#uploadworkflowsandtasksdefinitionstos3) | **POST** /api/metadata/workflow-task-defs/upload | Upload all workflows and tasks definitions to S3

<a name="create"></a>
# **Create**
> Object Create (WorkflowDef body, bool? overwrite = null)

Create a new workflow definition

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CreateExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new MetadataResourceApi();
            var body = new WorkflowDef(); // WorkflowDef | 
            var overwrite = true;  // bool? |  (optional)  (default to false)

            try
            {
                // Create a new workflow definition
                Object result = apiInstance.Create(body, overwrite);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MetadataResourceApi.Create: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**WorkflowDef**](WorkflowDef.md)|  | 
 **overwrite** | **bool?**|  | [optional] [default to false]

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="get"></a>
# **Get**
> WorkflowDef Get (string name, int? version = null, bool? metadata = null)

Retrieves workflow definition along with blueprint

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new MetadataResourceApi();
            var name = name_example;  // string | 
            var version = 56;  // int? |  (optional) 
            var metadata = true;  // bool? |  (optional)  (default to false)

            try
            {
                // Retrieves workflow definition along with blueprint
                WorkflowDef result = apiInstance.Get(name, version, metadata);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MetadataResourceApi.Get: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**|  | 
 **version** | **int?**|  | [optional] 
 **metadata** | **bool?**|  | [optional] [default to false]

### Return type

[**WorkflowDef**](WorkflowDef.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getallworkflows"></a>
# **GetAllWorkflows**
> List<WorkflowDef> GetAllWorkflows (string access = null, bool? metadata = null, string tagKey = null, string tagValue = null)

Retrieves all workflow definition along with blueprint

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetAllWorkflowsExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new MetadataResourceApi();
            var access = access_example;  // string |  (optional)  (default to READ)
            var metadata = true;  // bool? |  (optional)  (default to false)
            var tagKey = tagKey_example;  // string |  (optional) 
            var tagValue = tagValue_example;  // string |  (optional) 

            try
            {
                // Retrieves all workflow definition along with blueprint
                List&lt;WorkflowDef&gt; result = apiInstance.GetAllWorkflows(access, metadata, tagKey, tagValue);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MetadataResourceApi.GetAllWorkflows: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **access** | **string**|  | [optional] [default to READ]
 **metadata** | **bool?**|  | [optional] [default to false]
 **tagKey** | **string**|  | [optional] 
 **tagValue** | **string**|  | [optional] 

### Return type

[**List<WorkflowDef>**](WorkflowDef.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="gettaskdef"></a>
# **GetTaskDef**
> Object GetTaskDef (string tasktype, bool? metadata = null)

Gets the task definition

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetTaskDefExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new MetadataResourceApi();
            var tasktype = tasktype_example;  // string | 
            var metadata = true;  // bool? |  (optional)  (default to false)

            try
            {
                // Gets the task definition
                Object result = apiInstance.GetTaskDef(tasktype, metadata);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MetadataResourceApi.GetTaskDef: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **tasktype** | **string**|  | 
 **metadata** | **bool?**|  | [optional] [default to false]

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="gettaskdefs"></a>
# **GetTaskDefs**
> List<TaskDef> GetTaskDefs (string access = null, bool? metadata = null, string tagKey = null, string tagValue = null)

Gets all task definition

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetTaskDefsExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new MetadataResourceApi();
            var access = access_example;  // string |  (optional)  (default to READ)
            var metadata = true;  // bool? |  (optional)  (default to false)
            var tagKey = tagKey_example;  // string |  (optional) 
            var tagValue = tagValue_example;  // string |  (optional) 

            try
            {
                // Gets all task definition
                List&lt;TaskDef&gt; result = apiInstance.GetTaskDefs(access, metadata, tagKey, tagValue);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MetadataResourceApi.GetTaskDefs: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **access** | **string**|  | [optional] [default to READ]
 **metadata** | **bool?**|  | [optional] [default to false]
 **tagKey** | **string**|  | [optional] 
 **tagValue** | **string**|  | [optional] 

### Return type

[**List<TaskDef>**](TaskDef.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="registertaskdef"></a>
# **RegisterTaskDef**
> Object RegisterTaskDef (List<TaskDef> body)

Create or update task definition(s)

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RegisterTaskDefExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new MetadataResourceApi();
            var body = new List<TaskDef>(); // List<TaskDef> | 

            try
            {
                // Create or update task definition(s)
                Object result = apiInstance.RegisterTaskDef(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MetadataResourceApi.RegisterTaskDef: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**List&lt;TaskDef&gt;**](TaskDef.md)|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="unregistertaskdef"></a>
# **UnregisterTaskDef**
> void UnregisterTaskDef (string tasktype)

Remove a task definition

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UnregisterTaskDefExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new MetadataResourceApi();
            var tasktype = tasktype_example;  // string | 

            try
            {
                // Remove a task definition
                apiInstance.UnregisterTaskDef(tasktype);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MetadataResourceApi.UnregisterTaskDef: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **tasktype** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="unregisterworkflowdef"></a>
# **UnregisterWorkflowDef**
> void UnregisterWorkflowDef (string name, int? version)

Removes workflow definition. It does not remove workflows associated with the definition.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UnregisterWorkflowDefExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new MetadataResourceApi();
            var name = name_example;  // string | 
            var version = 56;  // int? | 

            try
            {
                // Removes workflow definition. It does not remove workflows associated with the definition.
                apiInstance.UnregisterWorkflowDef(name, version);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MetadataResourceApi.UnregisterWorkflowDef: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**|  | 
 **version** | **int?**|  | 

### Return type

void (empty response body)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="update"></a>
# **Update**
> Object Update (List<WorkflowDef> body, bool? overwrite = null)

Create or update workflow definition(s)

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UpdateExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new MetadataResourceApi();
            var body = new List<WorkflowDef>(); // List<WorkflowDef> | 
            var overwrite = true;  // bool? |  (optional)  (default to true)

            try
            {
                // Create or update workflow definition(s)
                Object result = apiInstance.Update(body, overwrite);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MetadataResourceApi.Update: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**List&lt;WorkflowDef&gt;**](WorkflowDef.md)|  | 
 **overwrite** | **bool?**|  | [optional] [default to true]

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="updatetaskdef"></a>
# **UpdateTaskDef**
> Object UpdateTaskDef (TaskDef body)

Update an existing task

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UpdateTaskDefExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new MetadataResourceApi();
            var body = new TaskDef(); // TaskDef | 

            try
            {
                // Update an existing task
                Object result = apiInstance.UpdateTaskDef(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MetadataResourceApi.UpdateTaskDef: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**TaskDef**](TaskDef.md)|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="uploadworkflowsandtasksdefinitionstos3"></a>
# **UploadWorkflowsAndTasksDefinitionsToS3**
> Object UploadWorkflowsAndTasksDefinitionsToS3 ()

Upload all workflows and tasks definitions to S3

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UploadWorkflowsAndTasksDefinitionsToS3Example
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new MetadataResourceApi();

            try
            {
                // Upload all workflows and tasks definitions to S3
                Object result = apiInstance.UploadWorkflowsAndTasksDefinitionsToS3();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MetadataResourceApi.UploadWorkflowsAndTasksDefinitionsToS3: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
