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

        Task<ResponseMain<ListingHistoricalData[]>> GetListingHistorical(string timeStamp, int start, int limit,
            string sortField, string sortDir,
            string marketType, string convert);

        Task<ResponseMain<ListingHistoricalData[]>> GetListingLatest(int start, int limit, string sortField,
            string sortDir, string marketType, string convert);
    }
}