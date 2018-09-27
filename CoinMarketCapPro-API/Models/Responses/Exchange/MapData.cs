using System;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.Exchange
{
    public class MapData : CryptoCurrencyBase
    {
        [JsonProperty("is_active")] public bool IsActive { get; set; }

        [JsonProperty("first_historical_data")]
        public DateTimeOffset FirstHistoricalData { get; set; }

        [JsonProperty("last_historical_data")] public DateTimeOffset LastHistoricalData { get; set; }
    }
}