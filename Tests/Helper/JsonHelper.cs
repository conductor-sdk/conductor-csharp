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
using System;
using System.IO;

namespace conductor_csharp.test.Helper
{
    public static class JsonHelper
    {
        /// <summary>
        /// Deserialize JSON content from a file into an object of type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonFilePath"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static T DeserializeJson<T>(string jsonFilePath)
        {
            try
            {
                string jsonString = File.ReadAllText(jsonFilePath);
                T deserializedObject = JsonConvert.DeserializeObject<T>(jsonString);
                return deserializedObject;
            }
            catch (Exception ex)
            {
                string errorMessage = string.Format(TestConstants.DeserializingErrorMessage, ex.Message);
                throw new Exception(errorMessage, ex);
            }
        }
    }
}
