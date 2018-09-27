using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CoinMarketCapPro;
using CoinMarketCapPro_API.Models.Responses;
using CoinMarketCapPro_API.Models.Responses.CryptoCurrency;

namespace CoinMarketCapPro_API.Clients
{
    public class CryptoCurrencyClient : BaseApiClient, ICryptoCurrencyClient
    {
        public CryptoCurrencyClient(HttpClient httpClient)
        {
        }

        public async Task<ResponseMain<Dictionary<string, CryptoCurrencyInfoData>>> GetMetaData(string[] id,
            string[] symbol)
        {
            return await GetAsync<ResponseMain<Dictionary<string, CryptoCurrencyInfoData>>>(
                    CryptoCurrencyApiUrls.MetadataUri(id, symbol))
                .ConfigureAwait(false);
        }

        public async Task<ResponseMain<IdMapData[]>> GetIdMap(string listingStatus, int start, int limit,
            string[] symbol)
        {
            return await GetAsync<ResponseMain<IdMapData[]>>(
                    CryptoCurrencyApiUrls.IdMapUri(listingStatus, start, limit, symbol))
                .ConfigureAwait(false);
        }

        public async Task<ResponseMain<ListingHistoricalData[]>> GetListingsHistorical(string timestamp, int start,
            int limit, string[] convert, string sortField, string sortDirection,
            string cryptocurrencyType)
        {
            return await GetAsync<ResponseMain<ListingHistoricalData[]>>(
                CryptoCurrencyApiUrls.ListingHistoricalUri(timestamp, start, limit, convert, sortField, sortDirection,
                    cryptocurrencyType)).ConfigureAwait(false);
        }

        public async Task<ResponseMain<ListingLatestData[]>> GetListingLatest(int start, int limit, string[] convert,
            string sortField, string sortDir,
            string cryptoCurrencyType)
        {
            return await GetAsync<ResponseMain<ListingLatestData[]>>(CryptoCurrencyApiUrls.ListingLatestUri(start,
                limit, convert,
                sortField, sortDir, cryptoCurrencyType)).ConfigureAwait(false);
        }

        public async Task<ResponseMain<MarketPairsLatestData>> GetMarketPairLatest(string id, string symbol, int start,
            int limit, string[] convert)
        {
            return await GetAsync<ResponseMain<MarketPairsLatestData>>(
                CryptoCurrencyApiUrls.LastestMarketPairsUri(id, symbol, start, limit, convert)).ConfigureAwait(false);
        }

        public async Task<ResponseMain<OhlcvHistoricalData>> GetOhlvcHistorical(string id, string symbol,
            string timePeriod, string timeStart, string timeEnd, int count,
            string interval, string[] convert)
        {
            return await GetAsync<ResponseMain<OhlcvHistoricalData>>(CryptoCurrencyApiUrls.HistoricalOhlcvUri(id,
                symbol, timePeriod,
                timeStart, timeEnd, count, interval, convert)).ConfigureAwait(false);
        }

        public async Task<ResponseMain<Dictionary<string, OhlcvLatestData>>> GetOhlcvLatest(string id, string symbol,
            string[] convert)
        {
            return await GetAsync<ResponseMain<Dictionary<string, OhlcvLatestData>>>(
                CryptoCurrencyApiUrls.LatestOhlcvUri(id, symbol, convert));
        }

        public async Task<ResponseMain<QuotesHistoricalData>> GetQuotesHistorical(string id, string symbol,
            string timeStart, string timeEnd, int count, string interval,
            string[] convert)
        {
            return await GetAsync<ResponseMain<QuotesHistoricalData>>(
                CryptoCurrencyApiUrls.HistoricalQuotesUri(id, symbol, timeStart, timeEnd, count, interval, convert));
        }

        public async Task<ResponseMain<Dictionary<string, QuotesLatestData>>> GetQuotesLatest(string id, string symbol,
            string[] convert)
        {
            return await GetAsync<ResponseMain<Dictionary<string, QuotesLatestData>>>(
                CryptoCurrencyApiUrls.LatestQuotesUri(id, symbol, convert));
        }
    }
}