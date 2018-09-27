using System.Collections.Generic;
using System.Threading.Tasks;
using CoinMarketCapPro;
using CoinMarketCapPro_API.Models.Responses;

namespace CoinMarketCapPro_API.Clients
{
    public interface IGlobalMetricClient
    {
        /// <summary>
        /// Get an interval of aggregate 24 hour volume and market cap data globally based on time and interval parameters.
        /// 
        /// This endpoint is available on the following API plans:Standard,Professional,Enterprise
        /// </summary>
        /// <param name="timeStart">Timestamp (Unix or ISO 8601) to start returning quotes for. Optional, if not passed, we'll return quotes calculated in reverse from "time_end</param>
        /// <param name="timeEnd">Timestamp (Unix or ISO 8601) to stop returning quotes for (inclusive). Optional, if not passed, we'll default to the current time. If no "time_start" is passed, we return quotes in reverse order starting from this time</param>
        /// <param name="count">The number of interval periods to return results for. Optional, required if both "time_start" and "time_end" aren't supplied. The default is 10 items. The current query limit is 10000 Default: 10</param>
        /// <param name="interval">Interval of time to return data points for. See details in endpoint description.Valid Values : "5m" "yearly" "monthly" "weekly" "daily" "hourly" "5m" "10m" "15m" "30m" "45m" "1h" "2h" "3h" "6h" "12h" "24h" "1d" "2d" "3d" "7d" "14d" "15d" "30d" "60d" "90d" "365d" Default: "5m"</param>
        /// <param name="convert">Optionally calculate market quotes in up to 32 currencies at once by passing a comma-separated list of cryptocurrency or fiat currency symbols. Each additional convert option beyond the first requires an additional call credit.</param>
        /// <returns></returns>
        Task<ResponseMain<GlobalMetricsHistoricalData>> GetGlobalMetricsHistorical(string timeStart, string timeEnd,
            int count, string interval, string[] convert);

        /// <summary>
        /// Get the latest quote of aggregate market metrics. Use the "convert" option to return market values in multiple fiat and cryptocurrency conversions in the same call.
        /// 
        /// This endpoint is available on the following API plans:Starter,Hobbyist,Standard,Professional,Enterprise
        /// </summary>
        /// <param name="convert">Optionally calculate market quotes in up to 32 currencies at once by passing a comma-separated list of cryptocurrency or fiat currency symbols. Each additional convert option beyond the first requires an additional call credit.</param>
        /// <returns></returns>
        Task<ResponseMain<GlobalMetricsLatestData>> GetGlobalMetricsLatest(string[] convert);
    }
}