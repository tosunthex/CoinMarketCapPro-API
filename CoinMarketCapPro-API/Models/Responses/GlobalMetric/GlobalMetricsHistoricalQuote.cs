using System;
using Newtonsoft.Json;

namespace CoinMarketCapPro
{
    public class GlobalMetricsHistoricalQuote
    {
        [JsonProperty("total_market_cap")] public double TotalMarketCap { get; set; }

        [JsonProperty("total_volume_24h")] public double TotalVolume24H { get; set; }

        [JsonProperty("timestamp")] public DateTimeOffset Timestamp { get; set; }
    }
}