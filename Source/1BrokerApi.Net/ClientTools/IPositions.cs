using Jojatekok.OneBrokerAPI.JsonObjects;
using System.Collections.Generic;

namespace Jojatekok.OneBrokerAPI.ClientTools
{
    public interface IPositions
    {
        /// <summary>Gets a list of the account's open positions.</summary>
        IList<Position> GetOpenPositions();

        /// <summary>Changes the parameters of a position.</summary>
        /// <param name="id">The ID of the position to be changed.</param>
        /// <param name="isClosableWithMarketOrder">Set this parameter to true if the position should be closed with a market order.</param>
        /// <param name="stopLoss">Stop loss for the position, once opened.</param>
        /// <param name="takeProfit">Take profit for the position, once opened.</param>
        void EditPosition(ulong id, bool isClosableWithMarketOrder = false, double? stopLoss = null, double? takeProfit = null);
    }
}
