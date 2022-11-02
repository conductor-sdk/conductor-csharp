using System.Collections.Generic;

namespace Conductor.Authentication
{
    public class OrkesAuthenticationSettings
    {

        public OrkesAuthenticationSettings(string keyId, string keySecret)
        {
            KeyId = keyId;
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