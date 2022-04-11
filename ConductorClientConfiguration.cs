using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Conductor.Client
{
    public class ConductorClientConfiguration
    {
        public Uri ServerUrl { get; set; } = new Uri("https://play.orkes.io/api/");
        public int SleepInterval { get; set; } = 1_000;
        public string Domain { get; set; }
        public int ConcurrentWorkers { get; set; } = 1;
        public JsonSerializerSettings JsonSerializerSettings { get; set; } = new JsonSerializerSettings();

        public AuthenticationConfiguration AuthenticationConfiguration { get; set; }
        internal string Token { get; set; }
    }

    public class AuthenticationConfiguration
    {
        public AuthenticationConfiguration(string keyId, string keySecret)
        {
            this.keyId = keyId;
            this.keySecret = keySecret;
        }

        public string keyId { get; set; } 
        public string keySecret { get; set; }

        public override bool Equals(object obj)
        {
            return obj is AuthenticationConfiguration configuration &&
                   keyId == configuration.keyId &&
                   keySecret == configuration.keySecret;
        }

        public override int GetHashCode()
        {
            int hashCode = -96359911;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(keyId);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(keySecret);
            return hashCode;
        }
    }
}
