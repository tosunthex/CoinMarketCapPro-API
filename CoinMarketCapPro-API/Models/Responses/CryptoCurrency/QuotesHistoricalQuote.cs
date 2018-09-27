using System;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.CryptoCurrency
{
    public class QuotesHistoricalQuote
    {
        [JsonProperty("price")] public double Price { get; set; }

        [JsonProperty("volume_24h")] public long Volume24H { get; set; }

        [JsonProperty("market_cap")] public double MarketCap { get; set; }

        [JsonProperty("last_updated")] public DateTimeOffset LastUpdated { get; set; }
    }
}