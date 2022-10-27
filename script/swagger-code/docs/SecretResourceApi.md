# IO.Swagger.Api.SecretResourceApi

All URIs are relative to *https://pg-staging.orkesconductor.com/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DeleteSecret**](SecretResourceApi.md#deletesecret) | **DELETE** /api/secrets/{key} | Delete a secret value by key
[**DeleteTagForSecret**](SecretResourceApi.md#deletetagforsecret) | **DELETE** /api/secrets/{key}/tags | Delete a tag by secret
[**GetSecret**](SecretResourceApi.md#getsecret) | **GET** /api/secrets/{key} | Get secret value by key
[**GetTags**](SecretResourceApi.md#gettags) | **GET** /api/secrets/{key}/tags | Get tags by secret
[**ListAllSecretNames**](SecretResourceApi.md#listallsecretnames) | **POST** /api/secrets | List all secret names
[**ListSecretsThatUserCanGrantAccessTo**](SecretResourceApi.md#listsecretsthatusercangrantaccessto) | **GET** /api/secrets | List all secret names user can grant access to
[**PutSecret**](SecretResourceApi.md#putsecret) | **PUT** /api/secrets/{key} | Put a secret value by key
[**PutTagForSecret**](SecretResourceApi.md#puttagforsecret) | **PUT** /api/secrets/{key}/tags | Put a tag by secret
[**SecretExists**](SecretResourceApi.md#secretexists) | **GET** /api/secrets/{key}/exists | Check if secret exists

<a name="deletesecret"></a>
# **DeleteSecret**
> Object DeleteSecret (string key)

Delete a secret value by key

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class DeleteSecretExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new SecretResourceApi();
            var key = key_example;  // string | 

            try
            {
                // Delete a secret value by key
                Object result = apiInstance.DeleteSecret(key);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SecretResourceApi.DeleteSecret: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **key** | **string**|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="deletetagforsecret"></a>
# **DeleteTagForSecret**
> void DeleteTagForSecret (string key, string body = null)

Delete a tag by secret

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class DeleteTagForSecretExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new SecretResourceApi();
            var key = key_example;  // string | 
            var body = new string(); // string |  (optional) 

            try
            {
                // Delete a tag by secret
                apiInstance.DeleteTagForSecret(key, body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SecretResourceApi.DeleteTagForSecret: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **key** | **string**|  | 
 **body** | [**string**](string.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getsecret"></a>
# **GetSecret**
> Object GetSecret (string key)

Get secret value by key

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetSecretExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new SecretResourceApi();
            var key = key_example;  // string | 

            try
            {
                // Get secret value by key
                Object result = apiInstance.GetSecret(key);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SecretResourceApi.GetSecret: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **key** | **string**|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="gettags"></a>
# **GetTags**
> List<TagObject> GetTags (string key)

Get tags by secret

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetTagsExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new SecretResourceApi();
            var key = key_example;  // string | 

            try
            {
                // Get tags by secret
                List&lt;TagObject&gt; result = apiInstance.GetTags(key);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SecretResourceApi.GetTags: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **key** | **string**|  | 

### Return type

[**List<TagObject>**](TagObject.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="listallsecretnames"></a>
# **ListAllSecretNames**
> Object ListAllSecretNames ()

List all secret names

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ListAllSecretNamesExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new SecretResourceApi();

            try
            {
                // List all secret names
                Object result = apiInstance.ListAllSecretNames();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SecretResourceApi.ListAllSecretNames: " + e.Message );
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
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="listsecretsthatusercangrantaccessto"></a>
# **ListSecretsThatUserCanGrantAccessTo**
> List<string> ListSecretsThatUserCanGrantAccessTo ()

List all secret names user can grant access to

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ListSecretsThatUserCanGrantAccessToExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new SecretResourceApi();

            try
            {
                // List all secret names user can grant access to
                List&lt;string&gt; result = apiInstance.ListSecretsThatUserCanGrantAccessTo();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SecretResourceApi.ListSecretsThatUserCanGrantAccessTo: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**List<string>**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="putsecret"></a>
# **PutSecret**
> Object PutSecret (string body, string key)

Put a secret value by key

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PutSecretExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new SecretResourceApi();
            var body = new string(); // string | 
            var key = key_example;  // string | 

            try
            {
                // Put a secret value by key
                Object result = apiInstance.PutSecret(body, key);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SecretResourceApi.PutSecret: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**string**](string.md)|  | 
 **key** | **string**|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="puttagforsecret"></a>
# **PutTagForSecret**
> void PutTagForSecret (string key, string body = null)

Put a tag by secret

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PutTagForSecretExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new SecretResourceApi();
            var key = key_example;  // string | 
            var body = new string(); // string |  (optional) 

            try
            {
                // Put a tag by secret
                apiInstance.PutTagForSecret(key, body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SecretResourceApi.PutTagForSecret: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **key** | **string**|  | 
 **body** | [**string**](string.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="secretexists"></a>
# **SecretExists**
> Object SecretExists (string key)

Check if secret exists

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SecretExistsExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new SecretResourceApi();
            var key = key_example;  // string | 

            try
            {
                // Check if secret exists
                Object result = apiInstance.SecretExists(key);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SecretResourceApi.SecretExists: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **key** | **string**|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
