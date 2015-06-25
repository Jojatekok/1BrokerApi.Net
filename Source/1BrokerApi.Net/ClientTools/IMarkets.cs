using Jojatekok.OneBrokerAPI.JsonObjects;
using System.Collections.Generic;

namespace Jojatekok.OneBrokerAPI.ClientTools
{
    public interface IMarkets
    {
        /// <summary>Gets basic information about all the available markets.</summary>
        IList<MarketData> GetMarketDatas();

        /// <summary>Gets detailed information of a market.</summary>
        /// <param name="symbol">Symbol of the market to fetch data from.</param>
        MarketDataDetailed GetMarketDataDetailed(string symbol);

        /// <summary>Gets quotes of the given markets.</summary>
        /// <param name="symbols">Symbols of the markets to fetch data from.</param>
        IList<Quote> GetQuotes(params string[] symbols);
    }
}
