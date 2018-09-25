using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using CoinMarketCapPro_API.Models.Responses;
using CoinMarketCapPro_API.Models.Responses.CryptoCurrency;
using CoinMarketCapPro_API.Parameters;

namespace CoinMarketCapPro_API.Clients
{
    public class CryptoCurrencyClient:BaseApiClient,ICryptoCurrencyClient
    {
        public CryptoCurrencyClient(HttpClient httpClient)
        {
        }
        public async Task<CryptoCurrencyMain<Dictionary<string,MetaDataData>>> GetMetaData(string[] id, string[] symbol)
        {
            return await GetAsync<CryptoCurrencyMain<Dictionary<string,MetaDataData>>>(CryptoCurrencyApiUrls.MetadataUri(id, symbol))
                .ConfigureAwait(false);
        }

        public async Task<CryptoCurrencyMain<IdMapData[]>> GetIdMap(string listingStatus, int start, int limit, string[] symbol)
        {
            return await GetAsync<CryptoCurrencyMain<IdMapData[]>>(CryptoCurrencyApiUrls.IdMapUri(listingStatus, start, limit, symbol))
                .ConfigureAwait(false);
        }

        public async Task<CryptoCurrencyMain<ListingHistoricalData[]>> GetListingsHistorical(string timestamp, int start, int limit, string[] convert, string sortField, string sortDirection,
            string cryptocurrencyType)
        {
            return await GetAsync<CryptoCurrencyMain<ListingHistoricalData[]>>(
                CryptoCurrencyApiUrls.ListingHistoricalUri(timestamp, start, limit, convert, sortField, sortDirection,
                    cryptocurrencyType)).ConfigureAwait(false);
        }

        public async Task<CryptoCurrencyMain<ListingLatestData[]>> GetListingLatest(int start, int limit, string[] convert, string sortField, string sortDir,
            string cryptoCurrencyType)
        {
            return await GetAsync<CryptoCurrencyMain<ListingLatestData[]>>(CryptoCurrencyApiUrls.ListingLatestUri(start, limit, convert,
                sortField, sortDir, cryptoCurrencyType)).ConfigureAwait(false);
        }

        public async Task<CryptoCurrencyMain<MarketPairsLatestData>> GetMarketPairLatest(string id, string symbol, int start, int limit, string[] convert)
        {
            return await GetAsync<CryptoCurrencyMain<MarketPairsLatestData>>(
                CryptoCurrencyApiUrls.LastestMarketPairsUri(id, symbol, start, limit, convert)).ConfigureAwait(false);
        }

        public async Task<CryptoCurrencyMain<OhlcvHistoricalData>> GetOhlvcHistorical(string id, string symbol, string timePeriod, string timeStart, string timeEnd, int count,
            string interval,string[] convert)
        {
            return await GetAsync<CryptoCurrencyMain<OhlcvHistoricalData>>(CryptoCurrencyApiUrls.HistoricalOhlcvUri(id, symbol, timePeriod,
                       timeStart, timeEnd, count, interval, convert)).ConfigureAwait(false);
        }

        public async Task<CryptoCurrencyMain<Dictionary<string,OhlcvLatestData>>> GetOhlcvLatest(string id, string symbol, string[] convert)
        {
            return await GetAsync<CryptoCurrencyMain<Dictionary<string,OhlcvLatestData>>>(CryptoCurrencyApiUrls.LatestOhlcvUri(id, symbol, convert));
        }

        public async Task<CryptoCurrencyMain<QuotesHistoricalData>> GetQuotesHistorical(string id, string symbol, string timeStart, string timeEnd, int count, string interval,
            string[] convert)
        {
            return await GetAsync<CryptoCurrencyMain<QuotesHistoricalData>>(
                CryptoCurrencyApiUrls.HistoricalQuotesUri(id, symbol, timeStart, timeEnd, count, interval, convert));
        }

        public async Task<CryptoCurrencyMain<Dictionary<string,QuotesLatestData>>> GetQuotesLatest(string id, string symbol, string[] convert)
        {
            return await GetAsync<CryptoCurrencyMain<Dictionary<string,QuotesLatestData>>>(CryptoCurrencyApiUrls.LatestQuotesUri(id, symbol, convert));
        }
    }
}