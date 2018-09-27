using System;
using System.Collections.Generic;
using CoinMarketCapPro_API.Services;

namespace CoinMarketCapPro
{
    public class ExchangeApiUrls
    {
        private const string ExchangeApiPath = "v1/exchange";

        public static Uri InfoUri(string id, string slug)
        {
            return QueryStringService.CreateUrl($"{ExchangeApiPath}/info", new Dictionary<string, object>
            {
                {"id", id},
                {"slug", slug}
            });
        }

        public static Uri MapUri(string listingStatus, string slug, int start, int limit)
        {
            return QueryStringService.CreateUrl($"{ExchangeApiPath}/map", new Dictionary<string, object>
            {
                {"listing_status", listingStatus},
                {"slug", slug},
                {"start", start},
                {"limit", limit}
            });
        }

        public static Uri ListingsHistorical(string timeStamp, int start, int limit, string sortField, string sortDir,
            string marketType, string[] convert)
        {
            return QueryStringService.CreateUrl($"{ExchangeApiPath}/listings/historical", new Dictionary<string, object>
            {
                {"timestamp", timeStamp},
                {"start", start},
                {"limit", limit},
                {"sort", sortField},
                {"sort_dir", sortDir},
                {"market_type", marketType},
                {"convert", string.Join(",", convert)}
            });
        }

        public static Uri ListingsLatest(int start, int limit, string sortField, string sortDir, string marketType,
            string[] convert)
        {
            return QueryStringService.CreateUrl($"{ExchangeApiPath}/listings/latest", new Dictionary<string, object>
            {
                {"start", start},
                {"limit", limit},
                {"sort", sortField},
                {"sort_dir", sortDir},
                {"market_type", marketType},
                {"convert", string.Join(",", convert)}
            });
        }

        public static Uri MarketPairsLatest(string id, string slug, int start, int limit, string[] convert)
        {
            return QueryStringService.CreateUrl($"{ExchangeApiPath}/market-pairs/latest", new Dictionary<string, object>
            {
                {"id", id},
                {"slug", slug},
                {"start", start},
                {"limit", limit},
                {"convert", string.Join(",", convert)}
            });
        }

        public static Uri QuotesHistorical(string id, string slug, string timeStart, string timeEnd, int count,
            string interval, string[] convert)
        {
            return QueryStringService.CreateUrl($"{ExchangeApiPath}/quotes/historical", new Dictionary<string, object>
            {
                {"id", id},
                {"slug", slug},
                {"time_start", timeStart},
                {"time_end", timeEnd},
                {"count", count},
                {"interval", interval},
                {"convert", string.Join(",", convert)}
            });
        }

        public static Uri QuotesLatest(string id, string slug, string[] convert)
        {
            return QueryStringService.CreateUrl($"{ExchangeApiPath}/quotes/latest", new Dictionary<string, object>
            {
                {"id", id},
                {"slug", slug},
                {"convert", string.Join(",", convert)}
            });
        }
    }
}