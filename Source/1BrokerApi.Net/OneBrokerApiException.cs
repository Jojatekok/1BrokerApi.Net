using System;

namespace Jojatekok.OneBrokerAPI
{
    public class OneBrokerApiException : Exception {
        public OneBrokerApiException(int errorCode, string errorMessage) : base("The server threw an exception as a response: [" + errorCode + "] " + errorMessage)
        {

        }
    }
}
