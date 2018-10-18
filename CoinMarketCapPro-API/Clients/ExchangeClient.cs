﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CoinMarketCapPro;
using CoinMarketCapPro_API.Models.Responses;
using CoinMarketCapPro_API.Models.Responses.Exchange;
using CoinMarketCapPro_API.Parameters;

namespace CoinMarketCapPro_API.Clients
{
    public class ExchangeClient : BaseApiClient, IExchangeClient
    {
        public ExchangeClient(HttpClient httpClient)
        {
        }

        public async Task<ResponseMain<Dictionary<string, InfoData>>> GetInfo(string id, string slug)
        {
            return await GetAsync<ResponseMain<Dictionary<string, InfoData>>>(ExchangeApiUrls.InfoUri(id, slug))
                .ConfigureAwait(false);
        }

        public async Task<ResponseMain<MapData[]>> GetMap(string listingStatus, string slug, int start, int limit)
        {
            return await GetAsync<ResponseMain<MapData[]>>(ExchangeApiUrls.MapUri(listingStatus, slug, start, limit))
                .ConfigureAwait(false);
        }

        public async Task<ResponseMain<ListingsHistoricalData[]>> GetListingHistorical(string timeStamp, int start,
            int limit, string sortField, string sortDir, string marketType,
            string[] convert)
        {
            return await GetAsync<ResponseMain<ListingsHistoricalData[]>>(
                    ExchangeApiUrls.ListingsHistorical(timeStamp, start, limit, sortField, sortDir, marketType,
                        convert))
                .ConfigureAwait(false);
        }

        public async Task<ResponseMain<ListingsLatestData[]>> GetListingLatest(int start, int limit, string sortField,
            string sortDir, string marketType, string[] convert)
        {
            return await GetAsync<ResponseMain<ListingsLatestData[]>>(
                ExchangeApiUrls.ListingsLatest(start, limit, sortField, sortDir, marketType, convert));
        }

        public async Task<ResponseMain<ListingsLatestData[]>> GetListingLatest()
        {
            return await GetAsync<ResponseMain<ListingsLatestData[]>>(
                    ExchangeApiUrls.ListingsLatest(1, 100, SortField.Volume24H, SortDirection.Desc, MarketType.Fees,
                        new[] {Currency.Usd}))
                .ConfigureAwait(false);
        }

        public async Task<ResponseMain<MarketPairsLatestData>> GetMarketPairsLatest(string id, string slug, int start,
            int limit, string[] convert)
        {
            return await GetAsync<ResponseMain<MarketPairsLatestData>>(
                ExchangeApiUrls.MarketPairsLatest(id, slug, start, limit, convert)).ConfigureAwait(false);

        }

        public async Task<ResponseMain<MarketPairsLatestData>> GetMarketPairsLatest(string idOrSlug)
        {   
            const int limit = 100;
            const int start = 1;
            var convert = new[] { Currency.Usd };

            return int.TryParse(idOrSlug, out var id)
                ? await GetAsync<ResponseMain<MarketPairsLatestData>>(
                        ExchangeApiUrls.MarketPairsLatest(id.ToString(), string.Empty, start, limit, convert))
                    .ConfigureAwait(false)
                : await GetAsync<ResponseMain<MarketPairsLatestData>>(
                        ExchangeApiUrls.MarketPairsLatest(string.Empty, idOrSlug, start, limit, convert))
                    .ConfigureAwait(false);
        }

        public async Task<ResponseMain<QuotesHistoricalData>> GetQuotesHistorical(string id, string slug,
            string timeStart, string timeEnd, int count, string interval,
            string[] convert)
        {
            return await GetAsync<ResponseMain<QuotesHistoricalData>>(
                    ExchangeApiUrls.QuotesHistorical(id, slug, timeStart, timeEnd, count, interval, convert))
                .ConfigureAwait(false);
        }

        public async Task<ResponseMain<QuotesHistoricalData>> GetQuotesHistorical(string idOrSlug, string timeStart, string timeEnd)
        {
            const int count = 10;
            var interval = Interval.M5;
            var convert = new []{Currency.Usd};

            return int.TryParse(idOrSlug, out var id)
                ? await GetAsync<ResponseMain<QuotesHistoricalData>>(
                    ExchangeApiUrls.QuotesHistorical(id.ToString(), string.Empty, timeStart, timeEnd, count, interval,
                        convert)).ConfigureAwait(false)
                : await GetAsync<ResponseMain<QuotesHistoricalData>>(
                    ExchangeApiUrls.QuotesHistorical(string.Empty,idOrSlug , timeStart, timeEnd, count, interval,
                        convert)).ConfigureAwait(false);
        }

        public async Task<ResponseMain<Dictionary<string, QuotesLatestData>>> GetQuotesLatest(string id, string slug,
            string[] convert)
        {
            return await GetAsync<ResponseMain<Dictionary<string, QuotesLatestData>>>(
                ExchangeApiUrls.QuotesLatest(id, slug, convert)).ConfigureAwait(false);
        }

        public async Task<ResponseMain<Dictionary<string, QuotesLatestData>>> GetQuotesLatest(string idOrSlug)
        {
            var convert = new[] { Currency.Usd };
            return int.TryParse(idOrSlug, out var id)
                ? await GetAsync<ResponseMain<Dictionary<string, QuotesLatestData>>>(
                    ExchangeApiUrls.QuotesLatest(id.ToString(), string.Empty, convert)).ConfigureAwait(false)
                : await GetAsync<ResponseMain<Dictionary<string, QuotesLatestData>>>(
                    ExchangeApiUrls.QuotesLatest(string.Empty, idOrSlug, convert)).ConfigureAwait(false);
        }
    }
}