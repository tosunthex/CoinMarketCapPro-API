using System.Collections.Generic;
using System.Threading.Tasks;
using CoinMarketCapPro;
using CoinMarketCapPro_API.Models.Responses;

namespace CoinMarketCapPro_API.Clients
{
    public interface IGlobalMetricClient
    {
        Task<ResponseMain<GlobalMetricsHistoricalData>> GetGlobalMetricsHistorical(string timeStart, string timeEnd,
            int count, string interval, string[] convert);

        Task<ResponseMain<GlobalMetricsLatestData>> GetGlobalMetricsLatest(string[] convert);
    }
}