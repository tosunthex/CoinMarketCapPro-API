﻿namespace CoinMarketCapPro_API.Clients
{
    public interface ICoinMarketCapClient
    {
        ICryptoCurrencyClient CryptoCurrencyClient { get; }
        IExchangeClient ExchangeClient { get; }
        IToolsClient ToolsClient { get; }

        IGlobalMetricClient GlobalMetricClient { get; }
    }
}