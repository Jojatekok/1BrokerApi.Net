using Jojatekok.OneBrokerAPI.JsonObjects;
using System.Collections.Generic;

namespace Jojatekok.OneBrokerAPI.ClientTools
{
    public class Markets : IMarkets
    {
        private RestWebClient RestWebClient { get; set; }

        internal Markets(RestWebClient restWebClient)
        {
            RestWebClient = restWebClient;
        }

        public IList<MarketData> GetMarketDatas()
        {
            return RestWebClient.Get<IList<MarketData>>("market/list");
        }

        public MarketDataDetailed GetMarketDataDetailed(string symbol)
        {
            var postData = new Dictionary<string, object> {
                { "symbol", symbol }
            };

            return RestWebClient.Get<MarketDataDetailed>("market/detail", postData);
        }

        public IList<Quote> GetQuotes(params string[] symbols)
        {
            var postData = new Dictionary<string, object> {
                { "symbols", string.Join(",", symbols) }
            };

            return RestWebClient.Get<IList<Quote>>("market/quotes", postData);
        }
    }
}
