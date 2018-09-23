using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses
{
    public class MarketPairsLatest
    {
        [JsonProperty("data")]
        public MarketPairsLatestData Data { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}
