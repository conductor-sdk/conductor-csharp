using Conductor.Exceptions;
using Conductor.Client.Interfaces;
using Conductor.Client.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Conductor.Client
{
    public class ConductorRestClient : IConductorRestClient
    {
        private readonly HttpClient httpClient;
        private readonly ConductorClientSettings settings;
        public ConductorRestClient(HttpClient httpClient, IOptions<ConductorClientSettings> options) 
        { 
            httpClient.BaseAddress = options.Value.ServerUrl;
            this.httpClient = httpClient;
            this.settings = options.Value;
        }

        public Task<Models.Task> PollTask(string taskType, string workerId, string domain)
        {
            return PollAsync(taskType, workerId, domain, System.Threading.CancellationToken.None);
        }

        public async Task<Models.Task> PollAsync(string tasktype, string workerid, string domain, System.Threading.CancellationToken cancellationToken)
        {
            if (tasktype == null)
                throw new ArgumentNullException("tasktype");

            var urlBuilder = new StringBuilder();
            urlBuilder.Append(settings.ServerUrl.OriginalString.Trim('/'));
            urlBuilder.Append("/tasks/poll/{tasktype}?");
            urlBuilder.Replace("{tasktype}", Uri.EscapeDataString(tasktype));
            if (workerid != null)
            {
                urlBuilder.Append("workerid=").Append(Uri.EscapeDataString(workerid)).Append("&");
            }
            if (domain != null)
            {
                urlBuilder.Append("domain=").Append(Uri.EscapeDataString(domain)).Append("&");
            }
            urlBuilder.Length--;

            using (var request = new HttpRequestMessage { Method = System.Net.Http.HttpMethod.Get, RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute) })
            {
                request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
                if(!string.IsNullOrEmpty(this.settings.Token))
                {
                    request.Headers.Add("X-AUTHORIZATION", this.settings.Token);
                }
                var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                try
                {
                    var headers = System.Linq.Enumerable.ToDictionary(response.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response.Content != null && response.Content.Headers != null)
                    {
                        foreach (var item_ in response.Content.Headers)
                            headers[item_.Key] = item_.Value;
                    }

                    if (!response.IsSuccessStatusCode)
                    {
                        var responseData_ = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ConductorApiException("The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").", (int)response.StatusCode, responseData_, headers, null);
                    }

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return await ReadResponseAsync<Models.Task>(response, headers);
                    }

                    return default(Models.Task);
                }
                finally
                {
                    if (response != null)
                        response.Dispose();
                }
            }
        }

        public Task<string> UpdateTask(TaskResult result)
        {
            return UpdateTaskAsync(result, System.Threading.CancellationToken.None);
        }

        public async Task<string> UpdateTaskAsync(TaskResult body, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(settings.ServerUrl.OriginalString.Trim('/'));
            urlBuilder.Append("/tasks");

            using (var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8))
            using (var request = new HttpRequestMessage { Method = System.Net.Http.HttpMethod.Post, RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute) })
            {
                request.Content = content;
                content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
                if (!string.IsNullOrEmpty(this.settings.Token))
                {
                    request.Headers.Add("X-AUTHORIZATION", this.settings.Token);
                }
                var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                try
                {
                    var headers = System.Linq.Enumerable.ToDictionary(response.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response.Content != null && response.Content.Headers != null)
                    {
                        foreach (var item_ in response.Content.Headers)
                            headers[item_.Key] = item_.Value;
                    }

                    if (!response.IsSuccessStatusCode)
                    {
                        var responseData_ = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ConductorApiException("The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").", (int)response.StatusCode, responseData_, headers, null);
                    }

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }

                    return default(string);
                }
                finally
                {
                    if (response != null)
                        response.Dispose();
                }
            }
        }

        protected async Task<T> ReadResponseAsync<T>(HttpResponseMessage response, IReadOnlyDictionary<string, IEnumerable<string>> headers)
        {
            if (response == null || response.Content == null)
            {
                return default(T);
            }

            try
            {
                var responseText = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseText, settings.JsonSerializerSettings ?? JsonConvert.DefaultSettings());
            }
            catch (JsonException exception)
            {
                var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
                throw new ConductorApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
            }
        }
    }
}

