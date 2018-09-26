using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CoinMarketCapPro;
using CoinMarketCapPro_API.Models.Responses;

namespace CoinMarketCapPro_API.Clients
{
    public class GlobalMetricsClient:BaseApiClient,IGlobalMetricClient
    {
        public GlobalMetricsClient(HttpClient _httpClient)
        {
            
        }
        public async Task<ResponseMain<GlobalMetricsData>> GetGlobalMetricsHistorical(string timeStart, string timeEnd, int count, string interval, string[] convert)
        {
            return await GetAsync<ResponseMain<GlobalMetricsData>>(GlobalMetricsApiUrls.QuotesHistoricalUri(
                timeStart, timeEnd, count, interval, convert));
        }
    }
}