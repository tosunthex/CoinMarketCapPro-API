using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.CryptoCurrency
{
    public class OhlcvLatest
    {
        [JsonProperty("data")]
        public Dictionary<string,OhlcvLatestData> Data { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class OhlcvLatestData
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("time_open")]
        public DateTimeOffset TimeOpen { get; set; }

        [JsonProperty("time_close")]
        public object TimeClose { get; set; }

        [JsonProperty("quote")]
        public Dictionary<string,OhlcvQuote> Quote { get; set; }
    }
}