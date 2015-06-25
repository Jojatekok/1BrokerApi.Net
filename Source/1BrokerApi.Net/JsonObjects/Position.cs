using Newtonsoft.Json;

namespace Jojatekok.OneBrokerAPI.JsonObjects
{
    public class Position
    {
        [JsonProperty("position_id")]
        public ulong Id { get; private set; }

        [JsonProperty("status")]
        private string StatusInternal {
            set { Status = value == "open" ? PositionStatus.Open : PositionStatus.Closed; }
        }
        public PositionStatus Status { get; private set; }

        [JsonProperty("symbol")]
        public string Symbol { get; private set; }

        [JsonProperty("margin")]
        public double AmountMargin { get; private set; }

        [JsonProperty("leverage")]
        public float Leverage { get; private set; }

        [JsonProperty("direction")]
        private string TradeDirectionInternal {
            set { TradeDirection = value == "long" ? TradeDirection.Long : TradeDirection.Short; }
        }
        public TradeDirection TradeDirection { get; private set; }

        [JsonProperty("entry_price")]
        public double PriceEntry { get; private set; }

        [JsonProperty("current_bid")]
        public double SymbolMarketBid { get; private set; }

        [JsonProperty("current_ask")]
        public double SymbolMarketAsk { get; private set; }

        [JsonProperty("profit_loss")]
        public double ProfitOrLossAmount { get; private set; }

        [JsonProperty("profit_loss_percent")]
        public double ProfitOrLossPercentage { get; private set; }

        [JsonProperty("market_close")]
        public bool IsClosedWithMarketOrder { get; private set; }

        [JsonProperty("stop_loss")]
        public double? StopLoss { get; private set; }

        [JsonProperty("take_profit")]
        public double? TakeProfit { get; private set; }
    }
}
