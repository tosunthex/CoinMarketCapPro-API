﻿using System;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.Exchange
{
    public partial class MapData
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("first_historical_data")]
        public DateTimeOffset FirstHistoricalData { get; set; }

        [JsonProperty("last_historical_data")]
        public DateTimeOffset LastHistoricalData { get; set; }
    }
}