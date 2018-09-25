using System;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.Exchange
{
    public class ExchangeReported
    {
        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("volume_24h_base")]
        public double Volume24HBase { get; set; }

        [JsonProperty("volume_24h_quote")]
        public double Volume24HQuote { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset LastUpdated { get; set; }
    }
}