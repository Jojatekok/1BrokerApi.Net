using Newtonsoft.Json;

namespace Jojatekok.OneBrokerAPI.JsonObjects
{
    public class MarketData
    {
        [JsonProperty("symbol")]
        public string Symbol { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("type")]
        public string TypeInternal {
            set {
                switch (value) {
                    case "CFD":
                        Type = MarketType.Cfd;
                        break;

                    default:
                        Type = MarketType.Unsupported;
                        break;
                }
            }
        }
        public MarketType Type { get; private set; }

        [JsonProperty("category")]
        private string CategoryInternal {
            set {
                switch (value) {
                    case "Forex":
                        Category = MarketCategory.Forex;
                        break;

                    case "Commodity":
                        Category = MarketCategory.Commodity;
                        break;

                    case "Stock":
                        Category = MarketCategory.Stock;
                        break;

                    case "Index":
                        Category = MarketCategory.Index;
                        break;

                    default:
                        Category = MarketCategory.Unsupported;
                        break;
                }
            }
        }
        public MarketCategory Category { get; private set; }
    }
}
