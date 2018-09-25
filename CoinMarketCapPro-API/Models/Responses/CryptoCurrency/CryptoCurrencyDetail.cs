using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.CryptoCurrency
{
    public class CryptoCurrencyDetail:ExchangeDetail
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }
}