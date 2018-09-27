using System;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.Exchange
{
    public class QuotesHistoricalQuotes
    {
        [JsonProperty("timestamp")] public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("quote")] public QuotesHistoricalQuote Quote { get; set; }

        [JsonProperty("num_market_pairs")] public long NumMarketPairs { get; set; }
    }
}