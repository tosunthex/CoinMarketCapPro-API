using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.CryptoCurrency
{
    public class ListingLatestData : LastestDataDetail
    {
        [JsonProperty("circulating_supply")] public double? CirculatingSupply { get; set; }

        [JsonProperty("total_supply")] public double? TotalSupply { get; set; }

        [JsonProperty("quote")] public Dictionary<string,Quote> Quote { get; set; }
    }
    public class LastestDataDetail: CryptoCurrencyDetail
    { 
        [JsonProperty("max_supply")] public long? MaxSupply { get; set; }

        [JsonProperty("date_added")] public DateTimeOffset DateAdded { get; set; }

        [JsonProperty("num_market_pairs")] public long NumMarketPairs { get; set; }

        [JsonProperty("cmc_rank")] public long CmcRank { get; set; }

        [JsonProperty("last_updated")] public DateTimeOffset LastUpdated { get; set; }
    }
}