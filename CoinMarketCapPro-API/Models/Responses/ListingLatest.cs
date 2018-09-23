using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses
{
    public class ListingLatest
    {
        [JsonProperty("data")]
        public ListingLatestData[] Data { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}