using System;
using System.Collections.Generic;
using CoinMarketCapPro_API.Services;

namespace CoinMarketCapPro_API.Parameters
{
    public class CryptoCurrencyApiUrls
    {
        private const string CryptoCurrencyPath = "/v1/cryptocurrency";

        public static Uri Info(string[] id,string[] symbol,bool useProApi)
        {
            return QueryStringService.AppendQueryString($"{CryptoCurrencyPath}/info", new Dictionary<string, string>
            {
                {"id",string.Join(",",id) },
                {"symbol",string.Join(",",symbol) }
            }, useProApi);
        }
        public static Uri Map(string listingStatus,int start,int limit,string[] symbol,bool useProApi)
        {
            return QueryStringService.AppendQueryString($"{CryptoCurrencyPath}/map", new Dictionary<string, string>
            {
                {"listing_status",listingStatus },
                {"start",start.ToString() },
                {"limit",limit.ToString() },
                {"symbol",string.Join(",",symbol) }
            }, useProApi);
        }
        public static Uri ListingLatest(bool useProApi)
        {
            return QueryStringService.AppendQueryString($"{CryptoCurrencyPath}/listings/latest", null, useProApi);
        }
        public static Uri ListingHistorical(string timeStamp,int start,int limit,string[] convert,string sort,string sortDir, string cryptoCurrencyType,bool useProApi)
        {
            return QueryStringService.AppendQueryString($"{CryptoCurrencyPath}/listings/historical", new Dictionary<string, string>
            {
                {"timeStamp",timeStamp },
                {"start",start.ToString() },
                {"limit",limit.ToString() },
                {"convert",string.Join(",",convert) },
                {"sort",sort },
                {"sort_dir",sortDir },
                {"cryptocurrency_type",cryptoCurrencyType }
            }, useProApi);
        }
        public static Uri LastestMarketPairs(bool useProApi)
        {
            return QueryStringService.AppendQueryString($"{CryptoCurrencyPath}/market-pairs/latest", null, useProApi);
        }
        public static Uri HistoricalOhlcv(bool useProApi)
        {
            return QueryStringService.AppendQueryString($"{CryptoCurrencyPath}/ohlcv/historical", null, useProApi);
        }
        public static Uri LatestQuotes(bool useProApi)
        {
            return QueryStringService.AppendQueryString($"{CryptoCurrencyPath}/quotes/latest", null, useProApi);
        }
        public static Uri HistoricalQuotes(bool useProApi)
        {
            return QueryStringService.AppendQueryString($"{CryptoCurrencyPath}/quotes/historical", null, useProApi);
        }

    }
}
/*
/v1/cryptocurrency/info Get metadata
/v1/cryptocurrency/map Get CoinMarketCap ID map
/v1/cryptocurrency/listings/latest List all cryptocurrencies(latest)
/v1/cryptocurrency/listings/historical List all cryptocurrencies(historical)
/v1/cryptocurrency/market-pairs/latest Get market pairs(latest)
/v1/cryptocurrency/ohlcv/historical Get OHLCV values(historical)
/v1/cryptocurrency/quotes/latest Get market quotes(latest)
/v1/cryptocurrency/quotes/historical Get market quotes(historical)
*/