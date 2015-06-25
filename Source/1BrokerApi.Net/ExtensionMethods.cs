using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Jojatekok.OneBrokerAPI
{
    static class ExtensionMethods
    {
        public static string ToPostDataValue(this TradeDirection tradeDirection)
        {
            return tradeDirection == TradeDirection.Long ? "long" : "short";
        }

        public static string ToPostDataValue(this OrderType orderType)
        {
            switch (orderType) {
                case OrderType.Market:
                    return "Market";

                case OrderType.Limit:
                    return "Limit";

                case OrderType.StopEntry:
                    return "Stopentry";

                default:
                    return null;
            }
        }

        [SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
        public static T DeserializeObject<T>(this JsonSerializer serializer, string value)
        {
            if (value == null) return default(T);

            using (var stringReader = new StringReader(value)) {
                using (var jsonTextReader = new JsonTextReader(stringReader)) {
                    return (T)serializer.Deserialize(jsonTextReader, typeof(T));
                }
            }
        }
    }
}
