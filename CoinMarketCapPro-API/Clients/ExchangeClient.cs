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

        public async Task<ResponseMain<ListingsHistoricalData[]>> GetListingHistorical(string timeStamp, int start, int limit, string sortField, string sortDir, string marketType,
            string[] convert)
        {
            return await GetAsync<ResponseMain<ListingsHistoricalData[]>>(
                ExchangeApiUrls.ListingsHistorical(timeStamp, start, limit, sortField, sortDir, marketType, convert));
        }

        public async Task<ResponseMain<ListingsLatestData[]>> GetListingLatest(int start, int limit, string sortField, string sortDir, string marketType, string[] convert)
        {
            return await GetAsync<ResponseMain<ListingsLatestData[]>>(
                ExchangeApiUrls.ListingsLatest(start, limit, sortField, sortDir, marketType, convert));
        }

        public async Task<ResponseMain<MarketPairsLatestData>> GetMarketPairsLatest(string id, string slug, int start,
            int limit, string[] convert)
        {
            return await GetAsync<ResponseMain<MarketPairsLatestData>>(
                ExchangeApiUrls.MarketPairsLatest(id, slug, start, limit, convert));
        }

        public async Task<ResponseMain<QuotesHistoricalData>> GetQuotesHistorical(string id, string slug, string timeStart, string timeEnd, int count, string interval,
            string[] convert)
        {
            return await GetAsync<ResponseMain<QuotesHistoricalData>>(
                ExchangeApiUrls.QuotesHistorical(id, slug, timeStart, timeEnd, count, interval, convert));
        }

        public async Task<ResponseMain<Dictionary<string, QuotesLatestData>>> GetQuotesLatest(string id, string slug, string[] convert)
        {
            return await GetAsync<ResponseMain<Dictionary<string, QuotesLatestData>>>(
                ExchangeApiUrls.QuotesLatest(id, slug, convert));
        }
    }
}