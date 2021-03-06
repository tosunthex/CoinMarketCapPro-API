﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.Exchange
{
    public class ListingsHistoricalData
    {
        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("slug")] public string Slug { get; set; }

        [JsonProperty("cmc_rank")] public long CmcRank { get; set; }

        [JsonProperty("num_market_pairs")] public long NumMarketPairs { get; set; }

        [JsonProperty("timestamp")] public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("quote")] public Dictionary<string, ListingsHistoricalQuote> Quote { get; set; }
    }
}