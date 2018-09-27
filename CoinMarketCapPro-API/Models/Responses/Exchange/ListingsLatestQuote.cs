using System;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.Exchange
{
    public class ListingsLatestQuote
    {
        [JsonProperty("volume_24h")] public double Volume24H { get; set; }

        [JsonProperty("last_updated")] public DateTimeOffset LastUpdated { get; set; }
    }
}