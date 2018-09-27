using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.CryptoCurrency
{
    public class OhlcvHistoricalQuotes
    {
        [JsonProperty("time_open")] public DateTimeOffset TimeOpen { get; set; }

        [JsonProperty("time_close")] public DateTimeOffset TimeClose { get; set; }

        [JsonProperty("quote")] public Dictionary<string, OhlcvQuote> Quote { get; set; }
    }
}