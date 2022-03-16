using Conductor.Client.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Conductor.Client.Extensions
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
