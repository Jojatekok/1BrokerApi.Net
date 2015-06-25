using Newtonsoft.Json;
using System;

namespace Jojatekok.OneBrokerAPI.JsonObjects
{
    public class Quote
    {
        [JsonProperty("symbol")]
        public string Symbol { get; private set; }

        [JsonProperty("bid")]
        public double MarketBid { get; private set; }

        [JsonProperty("ask")]
        public double MarketAsk { get; private set; }

        public double Spread {
            get { return Math.Round(MarketAsk - MarketBid, 8); }
        }

        [JsonProperty("updated")]
        public DateTime TimeUpdated { get; private set; }
    }
}
