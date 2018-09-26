using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses
{
    public class GlobalMetricsQuotes
    {
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("btc_dominance")]
        public double BtcDominance { get; set; }

        [JsonProperty("quote")]
        public Dictionary<string, GlobalMetricsQuote> Quote { get; set; }
    }
}