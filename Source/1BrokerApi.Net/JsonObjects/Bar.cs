using Newtonsoft.Json;
using System;

namespace Jojatekok.OneBrokerAPI.JsonObjects
{
    public class Bar
    {
        [JsonProperty("time")]
        public string Time { get; private set; }

        [JsonProperty("o")]
        public double o { get; private set; }

        [JsonProperty("h")]
        public double h { get; private set; }

        [JsonProperty("l")]
        public double l { get; private set; }

        [JsonProperty("c")]
        public double c { get;  private set; }
        
    }
}
