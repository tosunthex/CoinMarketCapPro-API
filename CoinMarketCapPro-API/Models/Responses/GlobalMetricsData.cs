using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses
{
    public class GlobalMetricsData
    {
        [JsonProperty("quotes")]
        public GlobalMetricsQuotes[] Quotes { get; set; }
    }
}