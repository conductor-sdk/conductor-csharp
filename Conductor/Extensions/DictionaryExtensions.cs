using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Conductor.Extensions
{
    public static class DictionaryExtensions
    {
        public static Dictionary<string, object> MergeValues(this Dictionary<string, object> existing, object data)
        {
            var existingAsJson = JsonConvert.SerializeObject(existing);
            var dataAsJson = JsonConvert.SerializeObject(data);

            var existingAsJObject = JsonConvert.DeserializeObject<JObject>(existingAsJson);
            var dataAsJObject = JsonConvert.DeserializeObject<JObject>(dataAsJson);

            existingAsJObject.Merge(dataAsJObject, new JsonMergeSettings
            {
                MergeArrayHandling = MergeArrayHandling.Union
            });

            return existingAsJObject.ToObject<Dictionary<string, object>>();
        }
    }
}
