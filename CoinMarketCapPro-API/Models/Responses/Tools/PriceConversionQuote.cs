using System;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.Tools
{
    public class PriceConversionQuote
    {
        [JsonProperty("price")] public double Price { get; set; }

        [JsonProperty("last_updated")] public DateTimeOffset LastUpdated { get; set; }
    }
}