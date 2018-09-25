using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using CoinMarketCapPro_API.Models.Responses.CryptoCurrency;
using CoinMarketCapPro_API.Parameters;

namespace CoinMarketCapPro_API.Clients
{
    public class CryptoCurrencyClient:BaseApiClient,ICryptoCurrencyClient
    {
        public CryptoCurrencyClient(HttpClient httpClient)
        {
        }
        public async Task<CryptoCurrencyMetaData> GetMetaData(string[] id, string[] symbol)
        {
            return await GetAsync<CryptoCurrencyMetaData>(CryptoCurrencyApiUrls.MetadataUri(id, symbol))
                .ConfigureAwait(false);
        }

        public async Task<CryptoCurrencyIdMap> GetIdMap(string listingStatus, int start, int limit, string[] symbol)
        {
            return await GetAsync<CryptoCurrencyIdMap>(CryptoCurrencyApiUrls.IdMapUri(listingStatus, start, limit, symbol))
                .ConfigureAwait(false);
        }

        public async Task<ListingHistorical> GetListingsHistorical(string timestamp, int start, int limit, string[] convert, string sortField, string sortDirection,
            string cryptocurrencyType)
        {
            return await GetAsync<ListingHistorical>(
                CryptoCurrencyApiUrls.ListingHistoricalUri(timestamp, start, limit, convert, sortField, sortDirection,
                    cryptocurrencyType)).ConfigureAwait(false);
        }

        public async Task<ListingLatest> GetListingLatest(int start, int limit, string[] convert, string sortField, string sortDir,
            string cryptoCurrencyType)
        {
            return await GetAsync<ListingLatest>(CryptoCurrencyApiUrls.ListingLatestUri(start, limit, convert,
                sortField, sortDir, cryptoCurrencyType)).ConfigureAwait(false);
        }

        public async Task<MarketPairsLatest> GetMarketPairLatest(string id, string symbol, int start, int limit, string[] convert)
        {
            return await GetAsync<MarketPairsLatest>(
                CryptoCurrencyApiUrls.LastestMarketPairsUri(id, symbol, start, limit, convert)).ConfigureAwait(false);
        }

        public async Task<OhlcvHistorical> GetOhlvcHistorical(string id, string symbol, string timePeriod, string timeStart, string timeEnd, int count,
            string interval,string[] convert)
        {
            return await GetAsync < OhlcvHistorical > (CryptoCurrencyApiUrls.HistoricalOhlcvUri(id, symbol, timePeriod,
                       timeStart, timeEnd, count, interval, convert)).ConfigureAwait(false);
        }

        public async Task<OhlcvLatest> GetOhlcvLatest(string id, string symbol, string[] convert)
        {
            return await GetAsync<OhlcvLatest>(CryptoCurrencyApiUrls.LatestOhlcvUri(id, symbol, convert));
        }

        public async Task<QuotesHistorical> GetQuotesHistorical(string id, string symbol, string timeStart, string timeEnd, int count, string interval,
            string[] convert)
        {
            return await GetAsync<QuotesHistorical>(
                CryptoCurrencyApiUrls.HistoricalQuotesUri(id, symbol, timeStart, timeEnd, count, interval, convert));
        }
    }
}