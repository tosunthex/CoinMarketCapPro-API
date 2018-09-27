using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.Exchange
{
    public class MarketPairsQuote
    {
        [JsonProperty("exchange_reported")] public ExchangeReported ExchangeReported { get; set; }

        public Dictionary<string, MarketPairsCurrencyDetail> CurrencyDetail { get; set; }
    }
}