using System;
using System.Net;

namespace Jojatekok.OneBrokerAPI
{
    public class OneBrokerClient : IDisposable
    {
        private IWebProxy _proxy;

        private string ApiToken { get; set; }
        private RestWebClient RestWebClient { get; set; }

        /// <summary>Provides information about the account being used.</summary>
        public ClientTools.IAccount Account { get; private set; }

        /// <summary>Provides functions to create, edit or cancel orders.</summary>
        public ClientTools.IOrders Orders { get; private set; }

        /// <summary>Provides functions to create, edit or close positions.</summary>
        public ClientTools.IPositions Positions { get; private set; }

        /// <summary>Provides information about markets.</summary>
        public ClientTools.IMarkets Markets { get; private set; }

        /// <summary>If set, the client will use the proxy specified by this property.</summary>
        public IWebProxy Proxy {
            get { return _proxy; }
            set {
                _proxy = value;
                RestWebClient.HttpClientHandler.UseProxy = value != null;
            }
        }

        /// <summary>Creates a new instance of 1Broker API .NET's client service.</summary>
        /// <param name="apiToken">Your secret API token.</param>
        public OneBrokerClient(string apiToken)
        {
            ApiToken = apiToken;
            RestWebClient = new RestWebClient(apiToken, Proxy);

            Account = new ClientTools.Account(RestWebClient);
            Orders = new ClientTools.Orders(RestWebClient);
            Positions = new ClientTools.Positions(RestWebClient);
            Markets = new ClientTools.Markets(RestWebClient);
        }

        /// <summary>Checks whether the API token used for the client is valid.</summary>
        public bool IsApiTokenValid()
        {
            if (ApiToken.Length != 32) return false;
            return !RestWebClient.GetRaw("account/bitcoindepositaddress").IsErrorThrown;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) {
                RestWebClient.Dispose();
                RestWebClient = null;
            }
        }
    }
}
