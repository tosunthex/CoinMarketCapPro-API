using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.CryptoCurrency
{
    public class QuotesHistorical
    {
        [JsonProperty("data")]
        public QuotesHistoricalData Data { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}