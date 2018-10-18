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
            string timeEnd, int count, string interval, string[] convert)
        {
            return await GetAsync<ResponseMain<GlobalMetricsHistoricalData>>(GlobalMetricsApiUrls.QuotesHistoricalUri(
                timeStart, timeEnd, count, interval, convert));
        }

        public async Task<ResponseMain<GlobalMetricsHistoricalData>> GetGlobalMetricsHistorical(string timeStart, string timeEnd)
        {
            var convert = new[] { Currency.Usd };
            const int count = 10;
            return await GetAsync<ResponseMain<GlobalMetricsHistoricalData>>(GlobalMetricsApiUrls.QuotesHistoricalUri(
                timeStart, timeEnd, count, Interval.D1, convert));
        }

        public async Task<ResponseMain<GlobalMetricsLatestData>> GetGlobalMetricsLatest(string[] convert)
        {
            return await GetAsync<ResponseMain<GlobalMetricsLatestData>>(GlobalMetricsApiUrls.QuotesLatestUri(convert));
        }

        public async Task<ResponseMain<GlobalMetricsLatestData>> GetGlobalMetricsLatest()
        {
            var convert = new[] { Currency.Usd };
            return await GetAsync<ResponseMain<GlobalMetricsLatestData>>(GlobalMetricsApiUrls.QuotesLatestUri(convert));
        }
    }
}