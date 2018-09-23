using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses
{
    public class CryptoCurrencyMetaData
    {
        [JsonProperty("data")]
        public Dictionary<string,MetaDataData> Data { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}