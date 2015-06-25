using Jojatekok.OneBrokerAPI.JsonObjects;
using System.Collections.Generic;

namespace Jojatekok.OneBrokerAPI.ClientTools
{
    public class Positions : IPositions
    {
        private RestWebClient RestWebClient { get; set; }

        internal Positions(RestWebClient restWebClient)
        {
            RestWebClient = restWebClient;
        }

        public IList<Position> GetOpenPositions()
        {
            return RestWebClient.Get<IList<Position>>("position/list_open");
        }

        public void EditPosition(ulong id, bool isClosableWithMarketOrder = false, double? stopLoss = null, double? takeProfit = null)
        {
            var postData = new Dictionary<string, object> {
                { "position_id", id }
            };

            if (isClosableWithMarketOrder) {
                postData.Add("market_close", true);
            }

            if (stopLoss != null) {
                postData.Add("stop_loss", stopLoss.Value.ToString(Utilities.InvariantCulture));
            }

            if (takeProfit != null) {
                postData.Add("take_profit", takeProfit.Value.ToString(Utilities.InvariantCulture));
            }

            RestWebClient.Get("position/edit", postData);
        }
    }
}
