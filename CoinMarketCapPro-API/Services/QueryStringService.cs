using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using CoinMarketCapPro_API.Parameters;

namespace CoinMarketCapPro_API.Services
{
    public class QueryStringService : BaseApiUrls
    {
        public static Uri AppendQueryString(string path, Dictionary<string, string> parameter, bool useProApi)
        {
            return CreateUrl(path, parameter, useProApi);
        }
        private static Uri CreateUrl(string path, Dictionary<string, string> parameter, bool useProApi)
        {
            var urlParameters = new List<string>();
            foreach (var par in parameter)
            {
                urlParameters.Add(string.IsNullOrWhiteSpace(par.Value) ? null : $"{par.Key}={par.Value}");
            }

            var encodedParams = urlParameters
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(WebUtility.HtmlEncode)
                .Select((x, i) => i > 0 ? $"&{x}" : $"?{x}")
                .ToArray();

            var url = encodedParams.Length > 0 ? $"{path}{string.Join(string.Empty, encodedParams)}" : path;
            return useProApi ? new Uri(ProEndPoint, url) : new Uri(SandboxEndPoint, url);
        }
    }
}