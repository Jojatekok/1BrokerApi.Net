using Jojatekok.OneBrokerAPI.JsonObjects;
using System.Collections.Generic;

namespace Jojatekok.OneBrokerAPI.ClientTools
{
    public class Orders : IOrders
    {
        private RestWebClient RestWebClient { get; set; }

        internal Orders(RestWebClient restWebClient)
        {
            RestWebClient = restWebClient;
        }

        public IList<Order> GetOpenOrders()
        {
            return RestWebClient.Get<IList<Order>>("order/list_open");
        }

        public Order PostOrder(Order order)
        {
            var postData = new Dictionary<string, object> {
                { "symbol", order.Symbol },
                { "margin", order.AmountMargin.ToString(Utilities.InvariantCulture) },
                { "direction", order.TradeDirection.ToPostDataValue() },
                { "leverage", order.Leverage.ToString(Utilities.InvariantCulture) },
                { "order_type", order.Type.ToPostDataValue() },
                { "order_type_parameter", order.TypeParameter.ToString(Utilities.InvariantCulture) }
            };

            if (order.StopLoss != null) {
                postData.Add("stop_loss", order.StopLoss.Value.ToString(Utilities.InvariantCulture));
            }

            if (order.TakeProfit != null) {
                postData.Add("take_profit", order.TakeProfit.Value.ToString(Utilities.InvariantCulture));
            }

            return RestWebClient.Get<Order>("order/create", postData);
        }

        public void DeleteOrder(ulong id)
        {
            var postData = new Dictionary<string, object> {
                { "order_id", id }
            };

            RestWebClient.Get("order/cancel", postData);
        }
    }
}
