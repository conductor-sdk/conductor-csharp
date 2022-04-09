using Newtonsoft.Json;
using System;

namespace Conductor.Client
{
    public class ConductorWorkerClientConfiguration
    {
        public Uri ServerUrl { get; set; } = new Uri("https://play.orkes.io/api/");
        public int SleepInterval { get; set; } = 1_000;
        public string Domain { get; set; }
        public int ConcurrentWorkers { get; set; } = 1;
        public JsonSerializerSettings JsonSerializerSettings { get; set; } = new JsonSerializerSettings();

        public AuthenticationConfiguration AuthenticationClient { get; set; }
        internal string Token { get; set; }
    }

    public class AuthenticationConfiguration
    {
        public string keyId { get; set; } 
        public string keySecret { get; set; } 

    }
}
