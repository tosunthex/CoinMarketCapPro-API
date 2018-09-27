using System;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.CryptoCurrency
{
    public class Quote:QuoteVolumePercent
    {
        [JsonProperty("price")] public double Price { get; set; }

        [JsonProperty("market_cap")] public long MarketCap { get; set; }

        [JsonProperty("last_updated")] public DateTimeOffset LastUpdated { get; set; }
    }
}