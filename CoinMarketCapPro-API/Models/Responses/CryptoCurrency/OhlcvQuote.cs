using System;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.CryptoCurrency
{
    public class OhlcvQuote
    {
        [JsonProperty("open")] public double Open { get; set; }

        [JsonProperty("high")] public double High { get; set; }

        [JsonProperty("low")] public double Low { get; set; }

        [JsonProperty("close")] public double Close { get; set; }

        [JsonProperty("volume")] public long Volume { get; set; }

        [JsonProperty("timestamp")] public DateTimeOffset Timestamp { get; set; }
    }
}