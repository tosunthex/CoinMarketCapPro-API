using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.CryptoCurrency
{
    public class OhlcvHistorical
    {
        [JsonProperty("data")]
        public OhlcvHistoricalData Data { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}