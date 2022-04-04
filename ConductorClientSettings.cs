using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Conductor.Client
{
    public class ConductorClientSettings
    {
        public Uri ServerUrl { get; set; } = new Uri("http://localhost:8080/api/");
        public int SleepInterval { get; set; } = 1_000;
        public string Domain { get; set; }
        public int ConcurrentWorkers { get; set; } = 1;
        public JsonSerializerSettings JsonSerializerSettings { get; set; }

        public Dictionary<string,string> Headers { get; set; }
    }
}
