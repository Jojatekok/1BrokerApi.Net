using Jojatekok.OneBrokerAPI.JsonObjects;

namespace Jojatekok.OneBrokerAPI.ClientTools
{
    public class Account : IAccount
    {
        private RestWebClient RestWebClient { get; set; }

        internal Account(RestWebClient restWebClient)
        {
            RestWebClient = restWebClient;
        }

        public AccountInfo GetAccountInfo()
        {
            return RestWebClient.Get<AccountInfo>("account/info");
        }

        public string GetBitcoinDepositAddress()
        {
            return RestWebClient.Get<BitcoinAddress>("account/bitcoindepositaddress").Value;
        }
    }
}
