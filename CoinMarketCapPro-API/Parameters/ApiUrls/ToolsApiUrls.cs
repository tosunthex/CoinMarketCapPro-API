using System;
using System.Collections.Generic;
using CoinMarketCapPro_API.Services;

namespace CoinMarketCapPro
{
    public class ToolsApiUrls
    {
        private const string ToolsApiPath = "v1/tools";
        public static Uri InfoUri(float amount, string id, string symbol,
            string time, string[] convert)
        {
            return QueryStringService.CreateUrl($"{ToolsApiPath}/price-conversion", new Dictionary<string, object>
            {
                {"amount",amount },
                {"id", id},
                {"symbol", symbol},
                {"time",time },
                {"convert",string.Join(",",convert) }
            });
        }
    }
}