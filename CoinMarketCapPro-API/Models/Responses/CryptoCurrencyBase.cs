using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Models.Responses
{
    public class CryptoCurrencyBase
    {
        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("slug")] public string Slug { get; set; }
    }
}