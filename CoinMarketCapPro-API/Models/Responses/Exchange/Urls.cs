using System;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.Exchange
{
    public class Urls
    {
        [JsonProperty("website")]
        public Uri[] Website { get; set; }

        [JsonProperty("twitter")]
        public Uri[] Twitter { get; set; }

        [JsonProperty("blog")]
        public object[] Blog { get; set; }

        [JsonProperty("chat")]
        public Uri[] Chat { get; set; }

        [JsonProperty("fee")]
        public Uri[] Fee { get; set; }
    }
}