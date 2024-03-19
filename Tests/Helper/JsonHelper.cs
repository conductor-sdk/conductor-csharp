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
