using Newtonsoft.Json;

namespace Jojatekok.OneBrokerAPI.JsonObjects
{
    public class MarketDataDetailed : MarketData
    {
        [JsonProperty("maximum_leverage")]
        public float MaximumLeverage { get; private set; }

        [JsonProperty("limit_btc")]
        public double MaximumMarginAmount { get; private set; }

        [JsonProperty("overnight_charge_long_percent")]
        public double OvernightChargePercentageForLongPositions { get; private set; }

        [JsonProperty("overnight_charge_short_percent")]
        public double OvernightChargePercentageForShortPositions { get; private set; }
    }
}
