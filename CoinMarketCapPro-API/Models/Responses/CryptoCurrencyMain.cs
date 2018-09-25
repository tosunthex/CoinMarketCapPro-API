using CoinMarketCapPro_API.Models.Responses.CryptoCurrency;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses
{
    public class CryptoCurrencyMain<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}