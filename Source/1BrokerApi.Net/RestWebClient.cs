using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;

namespace Jojatekok.OneBrokerAPI
{
    class RestWebClient : IDisposable
    {
        private static readonly JsonSerializer JsonSerializer = new JsonSerializer {
            DateFormatHandling = DateFormatHandling.IsoDateFormat,
            DateTimeZoneHandling = DateTimeZoneHandling.Utc
        };

        internal readonly HttpClientHandler HttpClientHandler;

        private string ApiToken { get; set; }
        private HttpClient HttpClient { get; set; }

        public RestWebClient(string apiToken, IWebProxy proxy)
        {
            ApiToken = apiToken;

            HttpClientHandler = new HttpClientHandler();
            if (HttpClientHandler.SupportsAutomaticDecompression) {
                HttpClientHandler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            }

            if (HttpClientHandler.SupportsProxy) {
                HttpClientHandler.Proxy = proxy;
                HttpClientHandler.UseProxy = proxy != null;
            }

            HttpClient = new HttpClient(HttpClientHandler) {
                Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite)
            };

            HttpClient.DefaultRequestHeaders.ExpectContinue = false;
        }

        public JsonResponse<T> GetRaw<T>(string command, Dictionary<string, object> postData = null)
        {
            var parameters = "";
            if (postData != null) {
                foreach (var keyValuePair in postData) {
                    parameters += "&" + keyValuePair.Key + "=" + keyValuePair.Value;
                }
            }

            var jsonString = SendRequest(HttpMethod.Get, command + ".php?token=" + ApiToken + parameters);
            return JsonSerializer.DeserializeObject<JsonResponse<T>>(jsonString);
        }

        public JsonResponse<object> GetRaw(string command, Dictionary<string, object> postData = null)
        {
            return GetRaw<object>(command, postData);
        }

        public T Get<T>(string command, Dictionary<string, object> postData = null)
        {
            var response = GetRaw<T>(command, postData);

            if (response.IsErrorThrown) {
                throw new OneBrokerApiException(response.ErrorCode, response.ErrorMessage);
            }

            return response.Result;
        }

        public void Get(string command, Dictionary<string, object> postData = null)
        {
            Get<object>(command, postData);
        }

        private string SendRequest(HttpMethod requestMethod, string requestRelativeUri)
        {
            using (var requestMessage = new HttpRequestMessage(requestMethod, new Uri(Utilities.ApiUrlHttpsBase + requestRelativeUri))) {
                var response = HttpClient.SendAsync(requestMessage).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) {
                HttpClient.Dispose();
                HttpClient = null;

                HttpClientHandler.Dispose();
            }
        }
    }
}
