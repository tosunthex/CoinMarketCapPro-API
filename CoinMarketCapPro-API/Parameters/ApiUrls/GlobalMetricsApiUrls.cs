using System;
using System.Collections.Generic;
using CoinMarketCapPro_API.Services;

namespace CoinMarketCapPro
{
    public class GlobalMetricsApiUrls
    {
        private const string GlobalMetricApiPath = "v1/global-metrics";

        public static Uri QuotesHistoricalUri(string timeStart, string timeEnd, int? count, string interval,
            string[] convert)
        {
            return QueryStringService.CreateUrl($"{GlobalMetricApiPath}/quotes/historical",
                new Dictionary<string, object>
                {
                    {"time_start", timeStart},
                    {"time_end", timeEnd},
                    {"count", count},
                    {"interval", interval},
                    {"convert", string.Join(",", convert)}
                });
        }

        public static Uri QuotesLatestUri(string[] convert)
        {
            return QueryStringService.CreateUrl($"{GlobalMetricApiPath}/quotes/latest", new Dictionary<string, object>
            {
                {"convert", string.Join(",", convert)}
            });
        }
    }
}