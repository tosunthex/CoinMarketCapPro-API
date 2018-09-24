﻿using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.CryptoCurrency
{
   public class CryptoCurrencyIdMap
    {
        [JsonProperty("data")]
        public IdMapData[] Data { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}