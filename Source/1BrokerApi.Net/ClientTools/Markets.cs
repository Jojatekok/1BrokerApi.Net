using Jojatekok.OneBrokerAPI.JsonObjects;
using System.Collections.Generic;
using System;

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
        public IList<Bar> GetBars(string symbol, Resolution resolution, DateTime from, DateTime to)
        {
            int res = 0;
            switch (resolution)
            {
                case Resolution.Minute:
                    res = 60;
                    if (to.Subtract(from).Days > 7)
                        throw new ArgumentException("Minute data Only supported for last 7 days.");
                    break;

                case Resolution.Hour:
                    res = 3600;
                    if (to.Subtract(from).Days > 366)
                        throw new ArgumentException("Hourly data Only supported for last 365 days.");
                    break;

                case Resolution.Daily:
                    res = 86400;
                    break;
            }

            var postData = new Dictionary<string, object> {
                { "symbol", string.Join(",", symbol) },
                { "resolution", string.Join(",", res) },
                { "from", string.Join(",", DateTimeToUnixTimestamp(from)) },
                { "to", string.Join(",", DateTimeToUnixTimestamp(to) )}
            };

            return RestWebClient.Get<IList<Bar>>("market/get_bars", postData);
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
        public static double DateTimeToUnixTimestamp(DateTime dateTime)
        {
            return (TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.Utc) -
                   new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)).TotalSeconds;
        }
    }
}
