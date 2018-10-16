using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.CryptoCurrency
{
    public class QuotesLatestData : LastestDataDetail
    {
        [JsonProperty("circulating_supply")] public long CirculatingSupply { get; set; }

        [JsonProperty("total_supply")] public long TotalSupply { get; set; }

        [JsonProperty("quote")] public Dictionary<string,QuotesLatestQuote> Quote { get; set; }
    }
}