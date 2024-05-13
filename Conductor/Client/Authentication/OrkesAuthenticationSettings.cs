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
using System.Collections.Generic;

namespace Conductor.Client.Authentication
{
    public class OrkesAuthenticationSettings
    {

        public OrkesAuthenticationSettings(string keyId, string keySecret)
        {
            if (string.IsNullOrEmpty(keyId))
            {
                throw new System.Exception("keyId should not be empty");
            }
            KeyId = keyId;
            if (string.IsNullOrEmpty(keySecret))
            {
                throw new System.Exception("keySecret should not be empty");
            }
            KeySecret = keySecret;
        }

        public string KeyId { get; set; }
        public string KeySecret { get; set; }

        public override bool Equals(object obj)
        {
            return obj is OrkesAuthenticationSettings configuration &&
                   KeyId == configuration.KeyId &&
                   KeySecret == configuration.KeySecret;
        }

        public override int GetHashCode()
        {
            int hashCode = -96359911;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(KeyId);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(KeySecret);
            return hashCode;
        }
    }
}