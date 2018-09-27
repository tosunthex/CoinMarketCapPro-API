using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.Exchange
{
    public class QuotesHistoricalData : CryptoCurrencyBase
    {
        [JsonProperty("quotes")] public QuotesHistoricalQuotes[] Quotes { get; set; }
    }
}