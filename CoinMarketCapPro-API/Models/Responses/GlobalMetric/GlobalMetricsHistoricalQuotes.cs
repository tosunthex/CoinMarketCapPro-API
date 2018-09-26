using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCapPro
{
    public class GlobalMetricsHistoricalQuotes
    {
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("btc_dominance")]
        public double BtcDominance { get; set; }

        [JsonProperty("quote")]
        public Dictionary<string, GlobalMetricsHistoricalQuote> Quote { get; set; }
    }
}