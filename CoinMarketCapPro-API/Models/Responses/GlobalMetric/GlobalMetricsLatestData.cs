using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCapPro
{
    public class GlobalMetricsLatestData
    {
        [JsonProperty("btc_dominance")]
        public double BtcDominance { get; set; }

        [JsonProperty("eth_dominance")]
        public double EthDominance { get; set; }

        [JsonProperty("active_cryptocurrencies")]
        public long ActiveCryptocurrencies { get; set; }

        [JsonProperty("active_market_pairs")]
        public long ActiveMarketPairs { get; set; }

        [JsonProperty("active_exchanges")]
        public long ActiveExchanges { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("quote")]
        public Dictionary<string, GlobalMetricsLatestQuote> Quote { get; set; }
    }

    public class GlobalMetricsLatestQuote
    {
        [JsonProperty("total_market_cap")]
        public long TotalMarketCap { get; set; }

        [JsonProperty("total_volume_24h")]
        public long TotalVolume24H { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset LastUpdated { get; set; }
    }
}