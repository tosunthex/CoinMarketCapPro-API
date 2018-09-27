using System;
using System.Net.Http;
using CoinMarketCapPro_API.Parameters;

namespace CoinMarketCapPro_API.Clients
{
    public class CoinMarketCapClient : ICoinMarketCapClient, IDisposable
    {
        private readonly HttpClient _httpClient;
        private bool _isDisposed;

        public CoinMarketCapClient(HttpClientHandler httpClientHandler, string apiEnvironment, string apiKey)
        {
            ApiParameters.ApiEndPoint =
                new Uri($"https://{(apiEnvironment == ApiEnvironment.Pro ? "pro" : "sandbox")}-api.coinmarketcap.com/",
                    UriKind.Absolute);
            ApiParameters.ApiKey = apiKey;
            _httpClient = new HttpClient(httpClientHandler, true);
        }

        public ICryptoCurrencyClient CryptoCurrencyClient => new CryptoCurrencyClient(_httpClient);
        public IExchangeClient ExchangeClient => new ExchangeClient(_httpClient);
        public IToolsClient ToolsClient => new ToolsClient(_httpClient);
        public IGlobalMetricClient GlobalMetricClient => new GlobalMetricsClient(_httpClient);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed) {return;}
            if (disposing) {_httpClient?.Dispose();}
            _isDisposed = true;
        }
    }
}