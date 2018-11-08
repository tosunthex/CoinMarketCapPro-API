﻿using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.CryptoCurrency
{
    public class QuoteVolumePercent
    {
        [JsonProperty("volume_24h")] public double? Volume24H { get; set; }

        [JsonProperty("percent_change_1h")] public double? PercentChange1H { get; set; }

        [JsonProperty("percent_change_24h")] public double? PercentChange24H { get; set; }

        [JsonProperty("percent_change_7d")] public double? PercentChange7D { get; set; }
    }
}