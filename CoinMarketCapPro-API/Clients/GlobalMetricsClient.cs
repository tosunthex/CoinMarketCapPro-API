using System.Net.Http;
using System.Threading.Tasks;
using CoinMarketCapPro;
using CoinMarketCapPro_API.Models.Responses;
using CoinMarketCapPro_API.Parameters;

namespace CoinMarketCapPro_API.Clients
{
    public class GlobalMetricsClient : BaseApiClient, IGlobalMetricClient
    {
        public GlobalMetricsClient(HttpClient _httpClient)
        {
        }

        public async Task<ResponseMain<GlobalMetricsHistoricalData>> GetGlobalMetricsHistorical(string timeStart,
            string timeEnd, int? count, string interval, string[] convert)
        {
            return await GetAsync<ResponseMain<GlobalMetricsHistoricalData>>(GlobalMetricsApiUrls.QuotesHistoricalUri(
                timeStart, timeEnd, count, interval, convert));
        }

        public async Task<ResponseMain<GlobalMetricsHistoricalData>> GetGlobalMetricsHistorical(string timeStart, string timeEnd)
        {
            
            return await GetAsync<ResponseMain<GlobalMetricsHistoricalData>>(GlobalMetricsApiUrls.QuotesHistoricalUri(
                timeStart, timeEnd, null, Interval.D1, new[] { string.Empty }));
        }

        public async Task<ResponseMain<GlobalMetricsLatestData>> GetGlobalMetricsLatest(string[] convert)
        {
            return await GetAsync<ResponseMain<GlobalMetricsLatestData>>(GlobalMetricsApiUrls.QuotesLatestUri(convert));
        }

        public async Task<ResponseMain<GlobalMetricsLatestData>> GetGlobalMetricsLatest()
        {
            return await GetAsync<ResponseMain<GlobalMetricsLatestData>>(GlobalMetricsApiUrls.QuotesLatestUri(new[] { string.Empty }));
        }
    }
}