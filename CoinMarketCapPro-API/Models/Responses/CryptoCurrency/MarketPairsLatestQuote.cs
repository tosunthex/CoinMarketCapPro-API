using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.CryptoCurrency
{
    public class MarketPairsLatestQuote
    {
        [JsonProperty("exchange_reported")]
        public ExchangeReported ExchangeReported { get; set; }

        public Dictionary<string,QuoteConvert> QuoteConvert { get; set; }
    }
}