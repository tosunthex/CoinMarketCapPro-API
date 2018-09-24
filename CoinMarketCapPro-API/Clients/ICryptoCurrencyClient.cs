using System.Collections.Generic;
using System.Linq.Expressions;
using System.Numerics;
using System.Threading.Tasks;
using CoinMarketCapPro_API.Models.Responses.CryptoCurrency;

namespace CoinMarketCapPro_API.Clients
{
    public interface ICryptoCurrencyClient
    {
        /// <summary>
        /// Returns all static metadata for one or more cryptocurrencies including name, symbol, logo, and its various registered URLs.
        /// This endpoint is available on the following API plans:Starter,Hobbyist,Standard,Professional,Enterprise
        /// </summary>
        /// <param name="id">One or more comma-separated CoinMarketCap cryptocurrency IDs. Example: "1,2"</param>
        /// <param name="symbol">Alternatively pass one or more comma-separated cryptocurrency symbols. Example: "BTC,ETH". At least one "id" or "symbol" is required.</param>
        /// <returns></returns>
        Task<CryptoCurrencyMetaData> GetMetaData(string[] id, string[] symbol);

        /// <summary>
        /// Returns a paginated list of all cryptocurrencies by CoinMarketCap ID. We recommend using this convenience endpoint to lookup and utilize
        /// our unique cryptocurrency id across all endpoints as typical identifiers like ticker symbols can match multiple cryptocurrencies and
        /// change over time. As a convenience you may pass a comma-separated list of cryptocurrency symbols as symbol to filter this list to only
        /// those you require.
        /// This endpoint is available on the following API plans:Starter,Hobbyist,Standard,Professional,Enterprise
        /// </summary>
        /// <param name="listingStatus">Only active coins are returned by default. Pass 'inactive' to get a list of coins that are no longer active.</param>
        /// <param name="start">Optionally offset the start (1-based index) of the paginated list of items to return.</param>
        /// <param name="limit">Optionally specify the number of results to return. Use this parameter and the "start" parameter to determine your own pagination size.</param>
        /// <param name="symbol">Optionally pass a comma-separated list of cryptocurrency symbols to return CoinMarketCap IDs for. If this option is passed, other options will be ignored.</param>
        /// <returns></returns>
        Task<CryptoCurrencyIdMap> GetIdMap(string listingStatus, int start, int limit, string[] symbol);

        /// <summary>
        /// Get a paginated list of all cryptocurrencies with market data for a given historical time. Use the "convert" option to return market values in multiple fiat and cryptocurrency conversions in the same call.
        /// </summary>
        /// <param name="timestamp">Timestamp (Unix or ISO 8601) to return historical cryptocurrency listings for.</param>
        /// <param name="start">Optionally offset the start (1-based index) of the paginated list of items to return.</param>
        /// <param name="limit">Optionally specify the number of results to return. Use this parameter and the "start" parameter to determine your own pagination size</param>
        /// <param name="convert">Optionally calculate market quotes in up to 32 currencies at once by passing a comma-separated list of cryptocurrency or fiat currency symbols. Each additional convert option beyond the first requires an additional call credit. A list of supported fiat options can be found here. Each conversion is returned in its own "quote" object.</param>
        /// <param name="sort">What field to sort the list of cryptocurrencies by.</param>
        /// <param name="sortDir">The direction in which to order cryptocurrencies against the specified sort.</param>
        /// <param name="cryptocurrencyType">The type of cryptocurrency to include.</param>
        /// <returns></returns>
        Task<ListingHistorical> GetListingsHistorical(string timestamp, int start, int limit,
            string[] convert, string sortField, string sortDirection, string cryptocurrencyType);

        Task<ListingLatest> GetListingLatest(int start, int limit, string[] convert, string sortField,
            string sortDir, string cryptoCurrencyType);

        Task<MarketPairsLatest> GetMarketPairLatest(string id, string symbol, int start, int limit, string[] convert);
        
        Task<OhlcvHistorical> GetOhlvcHistorical(string id, string symbol, string timePeriod,string timeStart,string timeEnd,int count,string interval,string[] convert);

    }
}