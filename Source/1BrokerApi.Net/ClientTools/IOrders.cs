using Jojatekok.OneBrokerAPI.JsonObjects;
using System.Collections.Generic;

namespace Jojatekok.OneBrokerAPI.ClientTools
{
    public interface IOrders
    {
        /// <summary>Gets a list of the account's open orders.</summary>
        IList<Order> GetOpenOrders();

        /// <summary>Posts a new order to the markets.</summary>
        /// <param name="order">Contains the parameters of the order to post.</param>
        Order PostOrder(Order order);

        /// <summary>Cancels an unexecuted order.</summary>
        /// <param name="id">The ID of the order to cancel.</param>
        void DeleteOrder(ulong id);
    }
}
