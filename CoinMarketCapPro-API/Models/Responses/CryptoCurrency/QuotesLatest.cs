using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.CryptoCurrency
{
    public class QuotesLatest
    {
        [JsonProperty("data")]
        public Dictionary<string,QuotesLatestData> Data { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}