﻿using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses
{
    public class ListingHistorical
    {
        [JsonProperty("data")]
        public ListingHistoricalData[] Data { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}