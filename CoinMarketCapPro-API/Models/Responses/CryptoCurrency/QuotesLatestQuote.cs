using System;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.CryptoCurrency
{
    public class QuotesLatestQuote: QuoteVolumePercent
    {
        [JsonProperty("price")] public double Price { get; set; }

        [JsonProperty("market_cap")] public double MarketCap { get; set; }

        [JsonProperty("last_updated")] public DateTimeOffset LastUpdated { get; set; }
    }
}