using Newtonsoft.Json;
using System;

namespace Jojatekok.OneBrokerAPI.JsonObjects
{
    public class Order
    {
        [JsonProperty("order_id")]
        public ulong Id { get; private set; }

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

        [JsonProperty("order_type")]
        private string TypeInternal {
            set {
                switch (value) {
                    case "Market":
                        Type = OrderType.Market;
                        break;

                    case "Limit":
                        Type = OrderType.Limit;
                        break;

                    case "Stopentry":
                        Type = OrderType.StopEntry;
                        break;

                    default:
                        Type = OrderType.Unsupported;
                        break;
                }
            }
        }
        public OrderType Type { get; private set; }

        [JsonProperty("order_type_parameter")]
        public double TypeParameter { get; private set; }

        [JsonProperty("stop_loss")]
        public double? StopLoss { get; private set; }

        [JsonProperty("take_profit")]
        public double? TakeProfit { get; private set; }

        [JsonProperty("created")]
        public DateTime TimeCreated { get; private set; }

        public Order(string symbol, double amountMargin, TradeDirection tradeDirection, float leverage, OrderType type, double typeParameter = -1, double? stopLoss = null, double? takeProfit = null)
        {
            Symbol = symbol;
            AmountMargin = amountMargin;
            TradeDirection = tradeDirection;
            Leverage = leverage;
            Type = type;
            TypeParameter = typeParameter;
            StopLoss = stopLoss;
            TakeProfit = takeProfit;
        }
    }
}
