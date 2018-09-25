using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using CoinMarketCapPro_API.Models.Responses;
using CoinMarketCapPro_API.Models.Responses.Exchange;

namespace CoinMarketCapPro_API.Clients
{
    public interface IExchangeClient
    {
        Task<ResponseMain<Dictionary<string, InfoData>>> GetInfo(string id, string slug);
        Task<ResponseMain<MapData[]>> GetMap(string listingStart, string slug, int start, int limit);

        Task<ResponseMain<ListingsHistoricalData[]>> GetListingHistorical(string timeStamp, int start, int limit,
            string sortField, string sortDir,string marketType, string[] convert);

        Task<ResponseMain<ListingsLatestData[]>> GetListingLatest(int start, int limit, string sortField,
            string sortDir, string marketType, string[] convert);

        Task<ResponseMain<MarketPairsLatestData>> GetMarketPairsLatest(string id, string slug, int start, int limit,
            string[] convert);

        Task<ResponseMain<QuotesHistoricalData>> GetQuotesHistorical(string id, string slug, string timeStart,
            string timeEnd, int count, string interval, string[] convert);

    }
}