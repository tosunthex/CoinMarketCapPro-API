using System;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.CryptoCurrency
{
    public class CryptoCurrencyInfoData:CryptoCurrencyDetail
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("logo")]
        public Uri Logo { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("urls")]
        public Urls Urls { get; set; }
    }
}