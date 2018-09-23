﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using CoinMarketCapPro_API.Models.Responses;
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
                sortField, sortDir, cryptoCurrencyType));
        }

        public async Task<MarketPairsLatest> GetMarketPairLatest(string id, string symbol, int start, int limit, string[] convert)
        {
            return await GetAsync<MarketPairsLatest>(
                CryptoCurrencyApiUrls.LastestMarketPairsUri(id, symbol, start, limit, convert));
        }
    }
}