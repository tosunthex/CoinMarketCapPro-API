using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.Exchange
{
    public class ListingsLatestData : CryptoCurrencyBase
    {
        [JsonProperty("num_market_pairs")] public long NumMarketPairs { get; set; }

        [JsonProperty("last_updated")] public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("quote")] public Dictionary<string, ListingsLatestQuote> Quote { get; set; }
    }
}