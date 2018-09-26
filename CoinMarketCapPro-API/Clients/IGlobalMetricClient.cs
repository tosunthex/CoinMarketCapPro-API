using System.Collections.Generic;
using System.Threading.Tasks;
using CoinMarketCapPro_API.Models.Responses;

namespace CoinMarketCapPro_API.Clients
{
    public interface IGlobalMetricClient
    {
        Task<ResponseMain<GlobalMetricsData>> GetGlobalMetricsHistorical(string timeStart, string timeEnd,
            int count, string interval, string[] convert);
    }
}