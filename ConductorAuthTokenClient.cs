using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;


namespace Conductor.Client
{
    public class ConductorAuthTokenClient
    {

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
                var response = httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).Result;


                var result = (JObject)JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);

                return result["token"].Value<string>();

            }
        }
    }
}
