using Newtonsoft.Json;
using System;

namespace Jojatekok.OneBrokerAPI
{
    class JsonResponse<T>
    {
        [JsonProperty("server_time")]
        public DateTime ServerTime { get; private set; }

        [JsonProperty("error")]
        public bool IsErrorThrown { get; private set; }

        [JsonProperty("error_code")]
        public int ErrorCode { get; private set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; private set; }

        [JsonProperty("warning")]
        public bool IsWarningThrown { get; private set; }

        [JsonProperty("warning_message")]
        public string WarningMessage { get; private set; }

        [JsonProperty("response")]
        public T Result { get; private set; }
    }
}
