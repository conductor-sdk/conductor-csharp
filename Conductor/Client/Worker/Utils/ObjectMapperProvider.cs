/*
 * Copyright 2024 Conductor Authors.
 * <p>
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with
 * the License. You may obtain a copy of the License at
 * <p>
 * http://www.apache.org/licenses/LICENSE-2.0
 * <p>
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on
 * an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the
 * specific language governing permissions and limitations under the License.
 */
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
