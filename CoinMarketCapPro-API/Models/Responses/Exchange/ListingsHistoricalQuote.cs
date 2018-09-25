using System;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.Exchange
{
    public class ListingsHistoricalQuote
    {
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("volume_24h")]
        public long Volume24H { get; set; }

        [JsonProperty("volume_7d")]
        public long Volume7D { get; set; }

        [JsonProperty("volume_30d")]
        public long Volume30D { get; set; }

        [JsonProperty("percent_change_volume_24h")]
        public double PercentChangeVolume24H { get; set; }

        [JsonProperty("percent_change_volume_7d")]
        public double PercentChangeVolume7D { get; set; }

        [JsonProperty("percent_change_volume_30d")]
        public double PercentChangeVolume30D { get; set; }
    }
}