using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using CoinMarketCapPro_API.Parameters;

namespace CoinMarketCapPro_API.Services
{
    public class QueryStringService : ApiParameters
    {
        public static Uri CreateUrl(string path, Dictionary<string, object> parameter)
        {
            var urlParameters = new List<string>();
            foreach (var par in parameter)
            {
                urlParameters.Add(string.IsNullOrWhiteSpace(par.Value.ToString()) ? null : $"{par.Key}={par.Value}");
            }

            var encodedParams = urlParameters
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(WebUtility.HtmlEncode)
                .Select((x, i) => i > 0 ? $"&{x}" : $"?{x}")
                .ToArray();
            var url = encodedParams.Length > 0 ? $"{path}{string.Join(string.Empty, encodedParams)}" : path;
            return new Uri(ApiEndPoint, url);
        }
    }
}