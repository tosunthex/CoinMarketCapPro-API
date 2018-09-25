using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.CryptoCurrency
{
    public class CryptoCurrencyDetail:Exchange
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }
}