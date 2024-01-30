using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Conductor.Client.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IdempotencyStrategy
    {
        [EnumMember(Value = "FAIL")]
        FAIL = 0,
        [EnumMember(Value = "RETURN_EXISTING")]
        RETURN_EXISTING = 1
    }
}