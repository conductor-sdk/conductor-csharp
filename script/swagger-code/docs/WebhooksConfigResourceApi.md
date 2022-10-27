# IO.Swagger.Api.WebhooksConfigResourceApi

All URIs are relative to *https://pg-staging.orkesconductor.com/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateWebhook**](WebhooksConfigResourceApi.md#createwebhook) | **POST** /api/metadata/webhook | 
[**DeleteWebhook**](WebhooksConfigResourceApi.md#deletewebhook) | **DELETE** /api/metadata/webhook/{id} | 
[**GetAllWebhook**](WebhooksConfigResourceApi.md#getallwebhook) | **GET** /api/metadata/webhook | 
[**GetWebhook**](WebhooksConfigResourceApi.md#getwebhook) | **GET** /api/metadata/webhook/{id} | 
[**UpdateWebhook**](WebhooksConfigResourceApi.md#updatewebhook) | **PUT** /api/metadata/webhook/{id} | 

<a name="createwebhook"></a>
# **CreateWebhook**
> WebhookEvent CreateWebhook (WebhookEvent body)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CreateWebhookExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WebhooksConfigResourceApi();
            var body = new WebhookEvent(); // WebhookEvent | 

            try
            {
                WebhookEvent result = apiInstance.CreateWebhook(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WebhooksConfigResourceApi.CreateWebhook: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**WebhookEvent**](WebhookEvent.md)|  | 

### Return type

[**WebhookEvent**](WebhookEvent.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="deletewebhook"></a>
# **DeleteWebhook**
> void DeleteWebhook (string id)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class DeleteWebhookExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WebhooksConfigResourceApi();
            var id = id_example;  // string | 

            try
            {
                apiInstance.DeleteWebhook(id);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WebhooksConfigResourceApi.DeleteWebhook: " + e.Message );
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

void (empty response body)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getallwebhook"></a>
# **GetAllWebhook**
> List<WebhookEvent> GetAllWebhook ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetAllWebhookExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WebhooksConfigResourceApi();

            try
            {
                List&lt;WebhookEvent&gt; result = apiInstance.GetAllWebhook();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WebhooksConfigResourceApi.GetAllWebhook: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<WebhookEvent>**](WebhookEvent.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getwebhook"></a>
# **GetWebhook**
> WebhookEvent GetWebhook (string id)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetWebhookExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WebhooksConfigResourceApi();
            var id = id_example;  // string | 

            try
            {
                WebhookEvent result = apiInstance.GetWebhook(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WebhooksConfigResourceApi.GetWebhook: " + e.Message );
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

[**WebhookEvent**](WebhookEvent.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="updatewebhook"></a>
# **UpdateWebhook**
> WebhookEvent UpdateWebhook (WebhookEvent body, string id)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UpdateWebhookExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WebhooksConfigResourceApi();
            var body = new WebhookEvent(); // WebhookEvent | 
            var id = id_example;  // string | 

            try
            {
                WebhookEvent result = apiInstance.UpdateWebhook(body, id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WebhooksConfigResourceApi.UpdateWebhook: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**WebhookEvent**](WebhookEvent.md)|  | 
 **id** | **string**|  | 

### Return type

[**WebhookEvent**](WebhookEvent.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
