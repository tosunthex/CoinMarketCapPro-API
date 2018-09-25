using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.Exchange
{
    public class MarketPairs
    {
        [JsonProperty("market_pair")]
        public string MarketPair { get; set; }

        [JsonProperty("market_pair_base")]
        public MarketPairBaseClass MarketPairBase { get; set; }

        [JsonProperty("market_pair_quote")]
        public MarketPairBaseClass MarketPairQuote { get; set; }

        [JsonProperty("quote")]
        public MarketPairsQuote Quote { get; set; }
    }
}