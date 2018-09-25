using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.Exchange
{
    public class MarketPairsLatestData:CryptoCurrencyBase
    {
        [JsonProperty("num_market_pairs")]
        public long NumMarketPairs { get; set; }

        [JsonProperty("market_pairs")]
        public MarketPairs[] MarketPairs { get; set; }
    }
}