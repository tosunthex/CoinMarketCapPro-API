using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.CryptoCurrency
{
    public class QuotesHistoricalData
    {
        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("symbol")] public string Symbol { get; set; }

        [JsonProperty("quotes")] public Quotes[] Quotes { get; set; }
    }
}