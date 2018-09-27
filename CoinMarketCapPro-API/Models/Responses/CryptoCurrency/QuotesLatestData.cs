using System;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.CryptoCurrency
{
    public class QuotesLatestData : CryptoCurrencyDetail
    {
        [JsonProperty("circulating_supply")] public long CirculatingSupply { get; set; }

        [JsonProperty("total_supply")] public long TotalSupply { get; set; }

        [JsonProperty("max_supply")] public long MaxSupply { get; set; }

        [JsonProperty("date_added")] public DateTimeOffset DateAdded { get; set; }

        [JsonProperty("num_market_pairs")] public long NumMarketPairs { get; set; }

        [JsonProperty("cmc_rank")] public long CmcRank { get; set; }

        [JsonProperty("last_updated")] public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("quote")] public QuotesLatestQuote Quote { get; set; }
    }
}