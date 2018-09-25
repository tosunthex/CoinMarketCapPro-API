using System;
using System.Collections.Generic;
using CoinMarketCapPro_API.Services;

namespace CoinMarketCapPro_API.Parameters
{
    public class CryptoCurrencyApiUrls
    {
        private const string CryptoCurrencyPath = "v1/cryptocurrency";

        public static Uri MetadataUri(string[] id,string[] symbol)
        {
            return QueryStringService.CreateUrl($"{CryptoCurrencyPath}/info", new Dictionary<string, object>
            {
                {"id",string.Join(",",id) },
                {"symbol",string.Join(",",symbol) }
            });
        }
        public static Uri IdMapUri(string listingStatus,int start,int limit,string[] symbol)
        {
            return QueryStringService.CreateUrl($"{CryptoCurrencyPath}/map", new Dictionary<string, object>
            {
                {"listing_status",listingStatus },
                {"start",start },
                {"limit",limit },
                {"symbol",string.Join(",",symbol) }
            });
        }
        public static Uri ListingLatestUri(int start,int limit,string[] convert,string sort,string sortDir,string cryptocurrencyType)
        {
            return QueryStringService.CreateUrl($"{CryptoCurrencyPath}/listings/latest"
                , new Dictionary<string, object>
            {
                {"start",start },
                {"limit",limit},
                {"convert",string.Join(",",convert) },
                {"sort",sort },
                {"sort_dir",sortDir },
                {"cryptocurrency_type",cryptocurrencyType }
            });
        }
        public static Uri ListingHistoricalUri(string timeStamp,int start,int limit,string[] convert,string sort,string sortDir, string cryptoCurrencyType)
        {
            return QueryStringService.CreateUrl($"{CryptoCurrencyPath}/listings/historical", 
                new Dictionary<string, object>
            {
                {"timeStamp",timeStamp },
                {"start",start },
                {"limit",limit },
                {"convert",string.Join(",",convert) },
                {"sort",sort },
                {"sort_dir",sortDir },
                {"cryptocurrency_type",cryptoCurrencyType }
            });
        }
        public static Uri LastestMarketPairsUri(string id,string symbol,int start,int limit,string[] convert)
        {
            return QueryStringService.CreateUrl($"{CryptoCurrencyPath}/market-pairs/latest"
                ,new Dictionary<string, object>
                {
                    {"id",id },
                    {"symbol",symbol },
                    {"start",start },
                    {"limit",limit },
                    {"convert",string.Join(",",convert) }
                } );
        }
        public static Uri HistoricalOhlcvUri(string id, string symbol, string timePeriod, string timeStart, string timeEnd,
            int count, string interval, string[] convert)
        {
            return QueryStringService.CreateUrl($"{CryptoCurrencyPath}/ohlcv/historical"
                , new Dictionary<string, object>
            {
                {"id",id },
                {"symbol",symbol },
                {"time_period",timePeriod },
                {"time_start",timeStart },
                {"time_end",timeEnd },
                {"count",count },
                {"interval",interval },
                {"convert",string.Join(",",convert) }
            });
        }
        public static Uri LatestOhlcvUri(string id, string symbol, string[] convert)
        {
            return QueryStringService.CreateUrl($"{CryptoCurrencyPath}/ohlcv/latest"
                , new Dictionary<string, object>
            {
                {"id",id },
                {"symbol",symbol },
                {"convert",string.Join(",",convert) }
            });
        }
        public static Uri HistoricalQuotesUri(string id, string symbol, string timeStart, string timeEnd, int count,
            string interval, string[] convert)
        {
            return QueryStringService.CreateUrl($"{CryptoCurrencyPath}/quotes/latest", new Dictionary<string, object>
            {
                {"id",id },
                {"symbol",symbol },
                {"timeStart",timeStart },
                {"timeEnd",timeEnd },
                {"count",count },
                {"interval",interval },
                {"convert",string.Join(",",convert) }
            });
        }
        public static Uri LatestQuotesUri(string id, string symbol, string[] convert)
        {
            return QueryStringService.CreateUrl($"{CryptoCurrencyPath}/quotes/historical", new Dictionary<string, object>
            {
                {"id",id },
                {"symbol",symbol },
                {"convert",string.Join(",",convert) }
            });
        }

    }
}