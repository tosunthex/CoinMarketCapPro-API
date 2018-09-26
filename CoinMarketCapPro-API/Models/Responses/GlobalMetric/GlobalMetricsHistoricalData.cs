using Newtonsoft.Json;

namespace CoinMarketCapPro
{
    public class GlobalMetricsHistoricalData
    {
        [JsonProperty("quotes")]
        public GlobalMetricsHistoricalQuotes[] Quotes { get; set; }
    }
}