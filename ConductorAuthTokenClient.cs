using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;


namespace Conductor.Client
{
    public class ConductorAuthTokenClient
    {

        private MemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions());

        public async Task<string> PostForToken(String uri, String keyId, String keySecret)
        {
            HttpClient httpClient = new HttpClient();
            var urlBuilder = new StringBuilder(uri);

            using (var request = new HttpRequestMessage { Method = System.Net.Http.HttpMethod.Post, RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute) })
            {
                request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
                request.Content = JsonContent.Create(new
                {
                    keyId = keyId,
                    keySecret = keySecret,
                });
                var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = (JObject)JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);

                    return result["token"].Value<string>();

                }
                return default(string);
            }
        }

        public string getToken(string uri, string keyId, string keySecret)
        {

            Object token = memoryCache.Get(new AuthenticationConfiguration(keyId, keySecret));
            if (token != null)
            {
                return token.ToString();
            }
            token = PostForToken(uri, keyId, keySecret).Result;
            memoryCache.Set(new AuthenticationConfiguration(keyId, keySecret), token, DateTimeOffset.Now.AddHours(4));

            return token.ToString();
        }

        public string refreshToken(string uri, string keyId, string keySecret)
        {
            string token = PostForToken(uri, keyId, keySecret).Result;
            memoryCache.Set(new AuthenticationConfiguration(keyId, keySecret), token, DateTimeOffset.Now.AddHours(4));
            return token;
        }
    }

    public class AuthenticationConfiguration
    {
        public AuthenticationConfiguration(string keyId, string keySecret)
        {
            this.keyId = keyId;
            this.keySecret = keySecret;
        }

        public string keyId { get; set; }
        public string keySecret { get; set; }

        public override bool Equals(object obj)
        {
            return obj is AuthenticationConfiguration configuration &&
                   keyId == configuration.keyId &&
                   keySecret == configuration.keySecret;
        }

        public override int GetHashCode()
        {
            int hashCode = -96359911;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(keyId);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(keySecret);
            return hashCode;
        }
    }
}
