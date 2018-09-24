using System;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.CryptoCurrency
{
    public class Urls
    {
        [JsonProperty("website")]
        public Uri[] Website { get; set; }

        [JsonProperty("explorer")]
        public Uri[] Explorer { get; set; }

        [JsonProperty("source_code")]
        public Uri[] SourceCode { get; set; }

        [JsonProperty("message_board")]
        public Uri[] MessageBoard { get; set; }

        [JsonProperty("chat")]
        public object[] Chat { get; set; }

        [JsonProperty("announcement")]
        public object[] Announcement { get; set; }

        [JsonProperty("reddit")]
        public Uri[] Reddit { get; set; }

        [JsonProperty("twitter")]
        public Uri[] Twitter { get; set; }
    }
}