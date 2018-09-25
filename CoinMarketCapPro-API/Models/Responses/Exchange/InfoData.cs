using System;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.Exchange
{
    public class InfoData:ExchangeDetail
    {
        [JsonProperty("urls")]
        public Urls Urls { get; set; }

        [JsonProperty("logo")]
        public Uri Logo { get; set; }
    }
}