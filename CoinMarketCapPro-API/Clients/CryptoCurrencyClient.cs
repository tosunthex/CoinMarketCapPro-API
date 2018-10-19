using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CoinMarketCapPro;
using CoinMarketCapPro_API.Models.Responses;
using CoinMarketCapPro_API.Models.Responses.CryptoCurrency;
using CoinMarketCapPro_API.Parameters;
using CoinMarketCapPro_API.Services;

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

        public async Task<ResponseMain<Dictionary<string, CryptoCurrencyInfoData>>> GetMetaData(string[] idOrSymbol)
        {
            return QueryStringService.IsIdOrString(idOrSymbol) == "Id"
                ? await GetAsync<ResponseMain<Dictionary<string, CryptoCurrencyInfoData>>>(
                    CryptoCurrencyApiUrls.MetadataUri(idOrSymbol, new[] {string.Empty})).ConfigureAwait(false)
                : await GetAsync<ResponseMain<Dictionary<string, CryptoCurrencyInfoData>>>(
                    CryptoCurrencyApiUrls.MetadataUri(new[] {string.Empty}, idOrSymbol)).ConfigureAwait(false);
        }

        public async Task<ResponseMain<IdMapData[]>> GetIdMap(string listingStatus, int? start, int? limit,
            string[] symbol)
        {
            return await GetAsync<ResponseMain<IdMapData[]>>(
                    CryptoCurrencyApiUrls.IdMapUri(listingStatus, start, limit, symbol))
                .ConfigureAwait(false);
        }

        public async Task<ResponseMain<IdMapData[]>> GetIdMap(int? limit)
        {
            return await GetAsync<ResponseMain<IdMapData[]>>(
                    CryptoCurrencyApiUrls.IdMapUri(ListingStatus.Active, 1, limit, new[] { string.Empty }))
                .ConfigureAwait(false);
        }

        public async Task<ResponseMain<IdMapData[]>> GetIdMap(string[] symbol)
        {
            return await GetAsync<ResponseMain<IdMapData[]>>(
                    CryptoCurrencyApiUrls.IdMapUri(ListingStatus.Active, 1, limit: null, symbol: symbol))
                .ConfigureAwait(false);
        }

        public async Task<ResponseMain<ListingHistoricalData[]>> GetListingsHistorical(string timestamp, int? start,
            int? limit, string[] convert, string sortField, string sortDirection,
            string cryptocurrencyType)
        {
            return await GetAsync<ResponseMain<ListingHistoricalData[]>>(
                CryptoCurrencyApiUrls.ListingHistoricalUri(timestamp, start, limit, convert, sortField, sortDirection,
                    cryptocurrencyType)).ConfigureAwait(false);
        }

        public async Task<ResponseMain<ListingHistoricalData[]>> GetListingsHistorical(string timestamp, string[] convert)
        {
            return await GetAsync<ResponseMain<ListingHistoricalData[]>>(
                CryptoCurrencyApiUrls.ListingHistoricalUri(timestamp, null, null, convert, SortField.MarketCap, SortDirection.Desc,
                    CryptoCurrencyType.All)).ConfigureAwait(false);
        }

        public async Task<ResponseMain<ListingLatestData[]>> GetListingLatest(int? start, int? limit, string[] convert,
            string sortField, string sortDir,
            string cryptoCurrencyType)
        {
            return await GetAsync<ResponseMain<ListingLatestData[]>>(CryptoCurrencyApiUrls.ListingLatestUri(start,
                limit, convert,sortField, sortDir, cryptoCurrencyType)).ConfigureAwait(false);
        }

        public async Task<ResponseMain<ListingLatestData[]>> GetListingLatest()
        {
            return await GetAsync<ResponseMain<ListingLatestData[]>>(CryptoCurrencyApiUrls.ListingLatestUri(null,
                null, new []{string.Empty}, string.Empty, string.Empty, string.Empty)).ConfigureAwait(false);
        }

        public async Task<ResponseMain<MarketPairsLatestData>> GetMarketPairLatest(string id, string symbol, int? start,
            int? limit, string[] convert)
        {
            return await GetAsync<ResponseMain<MarketPairsLatestData>>(
                CryptoCurrencyApiUrls.LastestMarketPairsUri(id, symbol, start, limit, convert)).ConfigureAwait(false);
        }

        public async Task<ResponseMain<MarketPairsLatestData>> GetMarketPairLatest(string idOrSymbol)
        {
            var convert = new[] { "" };

            return int.TryParse(idOrSymbol, out var id)
                ? await GetAsync<ResponseMain<MarketPairsLatestData>>(
                        CryptoCurrencyApiUrls.LastestMarketPairsUri(id.ToString(), string.Empty, null, null, convert))
                    .ConfigureAwait(false)
                : await GetAsync<ResponseMain<MarketPairsLatestData>>(
                        CryptoCurrencyApiUrls.LastestMarketPairsUri(string.Empty, idOrSymbol, null, null, convert))
                    .ConfigureAwait(false);
        }

        public async Task<ResponseMain<OhlcvHistoricalData>> GetOhlvcHistorical(string id, string symbol,
            string timePeriod, string timeStart, string timeEnd, int? count,
            string interval, string[] convert)
        {
            return await GetAsync<ResponseMain<OhlcvHistoricalData>>(CryptoCurrencyApiUrls.HistoricalOhlcvUri(id,
                symbol, timePeriod,
                timeStart, timeEnd, count, interval, convert)).ConfigureAwait(false);
        }

        public async Task<ResponseMain<OhlcvHistoricalData>> GetOhlvcHistorical(string idOrSymbol, string timeStart, string timeEnd)
        {
            const string timePeriod = "daily";

            return int.TryParse(idOrSymbol, out var id)
                ? await GetAsync<ResponseMain<OhlcvHistoricalData>>(CryptoCurrencyApiUrls.HistoricalOhlcvUri(id.ToString(),
                string.Empty, timePeriod, timeStart, timeEnd, null, Interval.Daily, new[] { string.Empty })).ConfigureAwait(false)
                : await GetAsync<ResponseMain<OhlcvHistoricalData>>(CryptoCurrencyApiUrls.HistoricalOhlcvUri(string.Empty,
                idOrSymbol, timePeriod, timeStart, timeEnd, null, Interval.Daily, new[] { string.Empty })).ConfigureAwait(false);
        }

        public async Task<ResponseMain<Dictionary<string, OhlcvLatestData>>> GetOhlcvLatest(string[] id, string[] symbol,
            string[] convert)
        {
            return await GetAsync<ResponseMain<Dictionary<string, OhlcvLatestData>>>(
                CryptoCurrencyApiUrls.LatestOhlcvUri(id, symbol, convert)).ConfigureAwait(false);
        }

        public async Task<ResponseMain<Dictionary<string, OhlcvLatestData>>> GetOhlcvLatest(string[] idOrSymbol)
        {
            return QueryStringService.IsIdOrString(idOrSymbol) == "Id"
                ? await GetAsync<ResponseMain<Dictionary<string, OhlcvLatestData>>>(
                        CryptoCurrencyApiUrls.LatestOhlcvUri(idOrSymbol, new[] {string.Empty}, new[] { string.Empty }))
                    .ConfigureAwait(false)
                : await GetAsync<ResponseMain<Dictionary<string, OhlcvLatestData>>>(
                        CryptoCurrencyApiUrls.LatestOhlcvUri(new[] {string.Empty}, idOrSymbol, new[] { string.Empty }))
                    .ConfigureAwait(false);
        }

        public async Task<ResponseMain<QuotesHistoricalData>> GetQuotesHistorical(string id, string symbol,
            string timeStart, string timeEnd, int? count, string interval,
            string[] convert)
        {
            return await GetAsync<ResponseMain<QuotesHistoricalData>>(
                    CryptoCurrencyApiUrls.HistoricalQuotesUri(id, symbol, timeStart, timeEnd, count, interval, convert))
                .ConfigureAwait(false);
        }

        public async Task<ResponseMain<QuotesHistoricalData>> GetQuotesHistorical(string idOrSymbol, string timeStart, string timeEnd)
        {

            return int.TryParse(idOrSymbol, out var id)
                ? await GetAsync<ResponseMain<QuotesHistoricalData>>(
                    CryptoCurrencyApiUrls.HistoricalQuotesUri(id.ToString(), string.Empty, timeStart, timeEnd, null,
                        Interval.M5, new[] { string.Empty })).ConfigureAwait(false)
                : await GetAsync<ResponseMain<QuotesHistoricalData>>(
                    CryptoCurrencyApiUrls.HistoricalQuotesUri("", idOrSymbol, timeStart, timeEnd, null, Interval.M5,
                        new[] { string.Empty })).ConfigureAwait(false);
        }

        public async Task<ResponseMain<Dictionary<string, QuotesLatestData>>> GetQuotesLatest(string[] id, string[] symbol,
            string[] convert)
        {
            return await GetAsync<ResponseMain<Dictionary<string, QuotesLatestData>>>(
                CryptoCurrencyApiUrls.LatestQuotesUri(id, symbol, convert));
        }

        public async Task<ResponseMain<Dictionary<string, QuotesLatestData>>> GetQuotesLatest(string[] idOrSymbol)
        {
            return QueryStringService.IsIdOrString(idOrSymbol) == "Id"
                ? await GetAsync<ResponseMain<Dictionary<string, QuotesLatestData>>>(
                        CryptoCurrencyApiUrls.LatestQuotesUri(idOrSymbol, new[] {string.Empty}, new[] { string.Empty }))
                    .ConfigureAwait(false)
                : await GetAsync<ResponseMain<Dictionary<string, QuotesLatestData>>>(
                        CryptoCurrencyApiUrls.LatestQuotesUri(new[] {string.Empty}, idOrSymbol, new[] { string.Empty }))
                    .ConfigureAwait(false);
        }
    }
}