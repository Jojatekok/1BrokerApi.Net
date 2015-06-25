using Newtonsoft.Json;

namespace Jojatekok.OneBrokerAPI.JsonObjects
{
    public class BitcoinAddress
    {
        [JsonProperty("bitcoin_address")]
        public string Value { get; private set; }
    }
}
