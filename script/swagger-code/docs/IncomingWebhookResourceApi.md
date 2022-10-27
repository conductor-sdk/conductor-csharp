# IO.Swagger.Api.IncomingWebhookResourceApi

All URIs are relative to *https://pg-staging.orkesconductor.com/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**HandleWebhook**](IncomingWebhookResourceApi.md#handlewebhook) | **POST** /webhook/{id} | 
[**HandleWebhook1**](IncomingWebhookResourceApi.md#handlewebhook1) | **GET** /webhook/{id} | 

<a name="handlewebhook"></a>
# **HandleWebhook**
> string HandleWebhook (string body, string id)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class HandleWebhookExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new IncomingWebhookResourceApi();
            var body = new string(); // string | 
            var id = id_example;  // string | 

            try
            {
                string result = apiInstance.HandleWebhook(body, id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling IncomingWebhookResourceApi.HandleWebhook: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**string**](string.md)|  | 
 **id** | **string**|  | 

### Return type

**string**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="handlewebhook1"></a>
# **HandleWebhook1**
> string HandleWebhook1 (string id, Dictionary<string, string> requestParams)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class HandleWebhook1Example
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new IncomingWebhookResourceApi();
            var id = id_example;  // string | 
            var requestParams = new Dictionary<string, string>(); // Dictionary<string, string> | 

            try
            {
                string result = apiInstance.HandleWebhook1(id, requestParams);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling IncomingWebhookResourceApi.HandleWebhook1: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 
 **requestParams** | [**Dictionary&lt;string, string&gt;**](string.md)|  | 

### Return type

**string**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
