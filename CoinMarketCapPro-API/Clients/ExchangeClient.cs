using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CoinMarketCapPro_API.Models.Responses;
using CoinMarketCapPro_API.Models.Responses.Exchange;
using CoinMarketCapPro_API.Parameters;

namespace CoinMarketCapPro_API.Clients
{
    public class ExchangeClient:BaseApiClient,IExchangeClient
    {
        public ExchangeClient(HttpClient httpClient)
        {
            
        }
        public async Task<ResponseMain<Dictionary<string, InfoData>>> GetInfo(string id, string slug)
        {
            return await GetAsync<ResponseMain<Dictionary<string, InfoData>>>(ExchangeApiUrls.InfoUri(id, slug))
                .ConfigureAwait(false);
        }

        public async Task<ResponseMain<MapData[]>> GetMap(string listingStart, string slug, int start, int limit)
        {
            return await GetAsync<ResponseMain<MapData[]>>(ExchangeApiUrls.MapUri(listingStart, slug, start, limit));
        }

        public async Task<ResponseMain<ListingHistoricalData[]>> GetListingHistorical(string timeStamp, int start, int limit, string sortField, string sortDir, string marketType,
            string convert)
        {
            return await GetAsync<ResponseMain<ListingHistoricalData[]>>(
                ExchangeApiUrls.ListingsHistorical(timeStamp, start, limit, sortField, sortDir, marketType, convert));
        }
    }
}