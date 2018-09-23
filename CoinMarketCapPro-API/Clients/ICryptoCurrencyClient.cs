using System.Collections.Generic;
using System.Threading.Tasks;
using CoinMarketCapPro_API.Models.Responses;

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
    }
}