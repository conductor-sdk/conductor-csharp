using Newtonsoft.Json;

namespace Conductor.Client.Worker.Utils
{
    public class ObjectMapperProvider
    {
        /// <summary>
        /// Method to set the serializer settings
        /// </summary>
        /// <returns></returns>
        public static JsonSerializerSettings GetJsonSerializerSettings()
        {
            var settings = new JsonSerializerSettings
            {
                // Disables throwing an exception if there are unknown properties during deserialization
                MissingMemberHandling = MissingMemberHandling.Ignore,

                // Disables throwing an exception if there are ignored properties during deserialization
                Error = (sender, args) => { args.ErrorContext.Handled = true; },

                // Disables throwing an exception if null values are encountered for primitive types during deserialization
                NullValueHandling = NullValueHandling.Include,

                // Disables throwing an exception if the object being serialized is empty
                DefaultValueHandling = DefaultValueHandling.Ignore,

                // Sets serialization inclusion to always include properties, regardless of their values
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                TypeNameHandling = TypeNameHandling.None
            };

            return settings;
        }
    }
}
