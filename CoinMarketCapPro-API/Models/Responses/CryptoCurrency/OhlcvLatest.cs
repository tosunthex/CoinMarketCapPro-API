﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses.CryptoCurrency
{
    public class OhlcvLatest
    {
        [JsonProperty("data")]
        public Dictionary<string,OhlcvLatestData> Data { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}