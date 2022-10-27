# IO.Swagger.Api.GroupResourceApi

All URIs are relative to *https://pg-staging.orkesconductor.com/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AddUserToGroup**](GroupResourceApi.md#addusertogroup) | **POST** /api/groups/{groupId}/users/{userId} | Add user to group
[**AddUsersToGroup**](GroupResourceApi.md#adduserstogroup) | **POST** /api/groups/{groupId}/users | Add users to group
[**DeleteGroup**](GroupResourceApi.md#deletegroup) | **DELETE** /api/groups/{id} | Delete a group
[**GetGrantedPermissions1**](GroupResourceApi.md#getgrantedpermissions1) | **GET** /api/groups/{groupId}/permissions | Get the permissions this group has over workflows and tasks
[**GetGroup**](GroupResourceApi.md#getgroup) | **GET** /api/groups/{id} | Get a group by id
[**GetUsersInGroup**](GroupResourceApi.md#getusersingroup) | **GET** /api/groups/{id}/users | Get all users in group
[**ListGroups**](GroupResourceApi.md#listgroups) | **GET** /api/groups | Get all groups
[**RemoveUserFromGroup**](GroupResourceApi.md#removeuserfromgroup) | **DELETE** /api/groups/{groupId}/users/{userId} | Remove user from group
[**RemoveUsersFromGroup**](GroupResourceApi.md#removeusersfromgroup) | **DELETE** /api/groups/{groupId}/users | Remove users from group
[**UpsertGroup**](GroupResourceApi.md#upsertgroup) | **PUT** /api/groups/{id} | Create or update a group

<a name="addusertogroup"></a>
# **AddUserToGroup**
> Object AddUserToGroup (string groupId, string userId)

Add user to group

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AddUserToGroupExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new GroupResourceApi();
            var groupId = groupId_example;  // string | 
            var userId = userId_example;  // string | 

            try
            {
                // Add user to group
                Object result = apiInstance.AddUserToGroup(groupId, userId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GroupResourceApi.AddUserToGroup: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **groupId** | **string**|  | 
 **userId** | **string**|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="adduserstogroup"></a>
# **AddUsersToGroup**
> void AddUsersToGroup (List<string> body, string groupId)

Add users to group

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AddUsersToGroupExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new GroupResourceApi();
            var body = new List<string>(); // List<string> | 
            var groupId = groupId_example;  // string | 

            try
            {
                // Add users to group
                apiInstance.AddUsersToGroup(body, groupId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GroupResourceApi.AddUsersToGroup: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**List&lt;string&gt;**](string.md)|  | 
 **groupId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="deletegroup"></a>
# **DeleteGroup**
> Response DeleteGroup (string id)

Delete a group

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class DeleteGroupExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new GroupResourceApi();
            var id = id_example;  // string | 

            try
            {
                // Delete a group
                Response result = apiInstance.DeleteGroup(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GroupResourceApi.DeleteGroup: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 

### Return type

[**Response**](Response.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getgrantedpermissions1"></a>
# **GetGrantedPermissions1**
> Object GetGrantedPermissions1 (string groupId)

Get the permissions this group has over workflows and tasks

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetGrantedPermissions1Example
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new GroupResourceApi();
            var groupId = groupId_example;  // string | 

            try
            {
                // Get the permissions this group has over workflows and tasks
                Object result = apiInstance.GetGrantedPermissions1(groupId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GroupResourceApi.GetGrantedPermissions1: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **groupId** | **string**|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getgroup"></a>
# **GetGroup**
> Object GetGroup (string id)

Get a group by id

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetGroupExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new GroupResourceApi();
            var id = id_example;  // string | 

            try
            {
                // Get a group by id
                Object result = apiInstance.GetGroup(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GroupResourceApi.GetGroup: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getusersingroup"></a>
# **GetUsersInGroup**
> Object GetUsersInGroup (string id)

Get all users in group

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetUsersInGroupExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new GroupResourceApi();
            var id = id_example;  // string | 

            try
            {
                // Get all users in group
                Object result = apiInstance.GetUsersInGroup(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GroupResourceApi.GetUsersInGroup: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="listgroups"></a>
# **ListGroups**
> List<Group> ListGroups ()

Get all groups

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ListGroupsExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new GroupResourceApi();

            try
            {
                // Get all groups
                List&lt;Group&gt; result = apiInstance.ListGroups();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GroupResourceApi.ListGroups: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<Group>**](Group.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="removeuserfromgroup"></a>
# **RemoveUserFromGroup**
> Object RemoveUserFromGroup (string groupId, string userId)

Remove user from group

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RemoveUserFromGroupExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new GroupResourceApi();
            var groupId = groupId_example;  // string | 
            var userId = userId_example;  // string | 

            try
            {
                // Remove user from group
                Object result = apiInstance.RemoveUserFromGroup(groupId, userId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GroupResourceApi.RemoveUserFromGroup: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **groupId** | **string**|  | 
 **userId** | **string**|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="removeusersfromgroup"></a>
# **RemoveUsersFromGroup**
> void RemoveUsersFromGroup (List<string> body, string groupId)

Remove users from group

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RemoveUsersFromGroupExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new GroupResourceApi();
            var body = new List<string>(); // List<string> | 
            var groupId = groupId_example;  // string | 

            try
            {
                // Remove users from group
                apiInstance.RemoveUsersFromGroup(body, groupId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GroupResourceApi.RemoveUsersFromGroup: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**List&lt;string&gt;**](string.md)|  | 
 **groupId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="upsertgroup"></a>
# **UpsertGroup**
> Object UpsertGroup (UpsertGroupRequest body, string id)

Create or update a group

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UpsertGroupExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new GroupResourceApi();
            var body = new UpsertGroupRequest(); // UpsertGroupRequest | 
            var id = id_example;  // string | 

            try
            {
                // Create or update a group
                Object result = apiInstance.UpsertGroup(body, id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GroupResourceApi.UpsertGroup: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**UpsertGroupRequest**](UpsertGroupRequest.md)|  | 
 **id** | **string**|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
