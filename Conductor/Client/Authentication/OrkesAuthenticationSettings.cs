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