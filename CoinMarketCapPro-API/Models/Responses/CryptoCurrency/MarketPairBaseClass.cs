using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.CryptoCurrency
{
    public class MarketPairBaseClass
    {
        [JsonProperty("currency_id")]
        public long CurrencyId { get; set; }

        [JsonProperty("currency_symbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty("currency_type")]
        public string CurrencyType { get; set; }
    }
}