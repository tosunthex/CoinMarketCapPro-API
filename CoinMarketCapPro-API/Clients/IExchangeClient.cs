using System.Collections.Generic;
using System.Threading.Tasks;
using CoinMarketCapPro_API.Models.Responses;
using CoinMarketCapPro_API.Models.Responses.Exchange;

namespace CoinMarketCapPro_API.Clients
{
    public interface IExchangeClient
    {
        /// <summary>
        ///     Returns all static metadata for one or more exchanges including logo and homepage URL.
        ///     This endpoint is available on the following API plans:Hobbyist,Standard,Professional,Enterprise
        /// </summary>
        /// <param name="id">One or more comma-separated CoinMarketCap cryptocurrency exchange ids. Example: "1,2"</param>
        /// <param name="slug">
        ///     Alternatively, one or more comma-separated exchange names in URL friendly shorthand "slug" format
        ///     (all lowercase, spaces replaced with hyphens). Example: "binance,gdax". At least one "id" or "slug" is required
        /// </param>
        /// <returns></returns>
        Task<ResponseMain<Dictionary<string, InfoData>>> GetInfo(string id, string slug);

        /// <summary>
        ///     Returns a paginated list of all cryptocurrency exchanges by CoinMarketCap ID. We recommend using this convenience
        ///     endpoint to lookup and utilize our unique exchange id across all endpoints as typical exchange identifiers may
        ///     change over time. As a convenience you may pass a comma-separated list of exchanges by slug to filter this list to
        ///     only those you require.
        ///     This endpoint is available on the following API plans:Hobbyist,Standard,Professional,Enterprise
        /// </summary>
        /// <param name="listingStatus">
        ///     Only active cryptocurrency exchanges are returned by default. Pass 'inactive' to get a list
        ///     of exchanges that are no longer active.Default : "active"
        /// </param>
        /// <param name="slug">
        ///     Optionally pass a comma-separated list of exchange slugs (lowercase URL friendly shorthand name with
        ///     spaces replaced with dashes) to return CoinMarketCap IDs for. If this option is passed, other options will be
        ///     ignored
        /// </param>
        /// <param name="start">Optionally offset the start (1-based index) of the paginated list of items to return. Default:1 </param>
        /// <param name="limit">
        ///     Optionally specify the number of results to return. Use this parameter and the "start" parameter to
        ///     determine your own pagination size.
        /// </param>
        /// <returns></returns>
        Task<ResponseMain<MapData[]>> GetMap(string listingStatus, string slug, int start, int limit);

        /// <summary>
        ///     Get a paginated list of all cryptocurrency exchanges with historical market data for a given point in time. Use the
        ///     "convert" option to return market values in multiple fiat and cryptocurrency conversions in the same call
        ///     This endpoint is not yet available. It is slated for release in early Q4 2018.
        /// </summary>
        /// <param name="timeStamp">Timestamp (Unix or ISO 8601) to return historical exchange listings for</param>
        /// <param name="start">Optionally offset the start (1-based index) of the paginated list of items to return Default:1 </param>
        /// <param name="limit">
        ///     Optionally specify the number of results to return. Use this parameter and the "start" parameter to
        ///     determine your own pagination size
        /// </param>
        /// <param name="sortField">
        ///     What field to sort the list of exchanges by Valid Values: "name" , "volume_24h"
        ///     Default:"date_added"
        /// </param>
        /// <param name="sortDir">The direction in which to order exchanges against the specified sort Valid Values: "asc","desc"</param>
        /// <param name="marketType">The type of exchange markets to include in rankings Valid Values: "fees","no_fees","all"</param>
        /// <param name="convert">
        ///     Optionally calculate market quotes in up to 32 currencies at once by passing a comma-separated
        ///     list of cryptocurrency or fiat currency symbols. Each additional convert option beyond the first requires an
        ///     additional call credit. Each conversion is returned in its own "quote" object
        /// </param>
        /// <returns></returns>
        Task<ResponseMain<ListingsHistoricalData[]>> GetListingHistorical(string timeStamp, int start, int limit,
            string sortField, string sortDir, string marketType, string[] convert);

        /// <summary>
        ///     Get a paginated list of all cryptocurrency exchanges with 24 hour volume. Additional market data fields will be
        ///     available in the future. You can configure this call to sort by 24 hour volume or another field. Use the "convert"
        ///     option to return market values in multiple fiat and cryptocurrency conversions in the same call.
        ///     This endpoint is available on the following API plans:Standard,Professional,Enterprise
        /// </summary>
        /// <param name="start">Optionally offset the start (1-based index) of the paginated list of items to return Default: 1</param>
        /// <param name="limit">
        ///     Optionally specify the number of results to return. Use this parameter and the "start" parameter to
        ///     determine your own pagination size Default: 100
        /// </param>
        /// <param name="sortField">
        ///     What field to sort the list of exchanges by Valid Values: "name" , "volume_24h"
        ///     Default:"volume_24h"
        /// </param>
        /// <param name="sortDir">The direction in which to order exchanges against the specified sort Valid Values: "asc","desc"</param>
        /// <param name="marketType">The type of exchange markets to include in rankings Valid Values: "fees","no_fees","all"</param>
        /// <param name="convert">
        ///     Optionally calculate market quotes in up to 32 currencies at once by passing a comma-separated
        ///     list of cryptocurrency or fiat currency symbols. Each additional convert option beyond the first requires an
        ///     additional call credit. Each conversion is returned in its own "quote" object
        /// </param>
        /// <returns></returns>
        Task<ResponseMain<ListingsLatestData[]>> GetListingLatest(int start, int limit, string sortField,
            string sortDir, string marketType, string[] convert);

        /// <summary>
        ///     Get a list of active market pairs for an exchange. Active means the market pair is open for trading. Use the
        ///     "convert" option to return market values in multiple fiat and cryptocurrency conversions in the same call.
        ///     This endpoint is available on the following API plans:Standard,Professional,Enterprise
        /// </summary>
        /// <param name="id">A CoinMarketCap exchange ID. Example: "1</param>
        /// <param name="slug">
        ///     Alternatively pass an exchange "slug" (URL friendly all lowercase shorthand version of name with
        ///     spaces replaced with hyphens). Example: "binance". One "id" or "slug" is required
        /// </param>
        /// <param name="start">Optionally offset the start (1-based index) of the paginated list of items to return Default: 1</param>
        /// <param name="limit">
        ///     Optionally specify the number of results to return. Use this parameter and the "start" parameter to
        ///     determine your own pagination size Default: 100
        /// </param>
        /// <param name="convert">
        ///     Optionally calculate market quotes in up to 32 currencies at once by passing a comma-separated
        ///     list of cryptocurrency or fiat currency symbols. Each additional convert option beyond the first requires an
        ///     additional call credit.
        /// </param>
        /// <returns></returns>
        Task<ResponseMain<MarketPairsLatestData>> GetMarketPairsLatest(string id, string slug, int start, int limit,
            string[] convert);

        /// <summary>
        ///     Returns an interval of historic quotes for any exchange based on time and interval parameters.
        ///     This endpoint is available on the following API plans:Standard,Professional,Enterprise
        /// </summary>
        /// <param name="id">The CoinMarketCap exchange ID to return historical data for</param>
        /// <param name="slug">
        ///     Alternatively the exchange slug to return historical data for. The 'slug' is a URL friendly
        ///     shorthand version (all lowercase, spaces replaced with hyphens) of the exchange name. One "id" or "slug" is
        ///     required
        /// </param>
        /// <param name="timeStart">
        ///     Timestamp (Unix or ISO 8601) to start returning quotes for. Optional, if not passed, we'll
        ///     return quotes calculated in reverse from "time_end
        /// </param>
        /// <param name="timeEnd">
        ///     Timestamp (Unix or ISO 8601) to stop returning quotes for (inclusive). Optional, if not passed,
        ///     we'll default to the current time. If no "time_start" is passed, we return quotes in reverse order starting from
        ///     this time
        /// </param>
        /// <param name="count">
        ///     The number of interval periods to return results for. Optional, required if both "time_start" and
        ///     "time_end" aren't supplied. The default is 10 items. The current query limit is 10000 Default: 10
        /// </param>
        /// <param name="interval">
        ///     Interval of time to return data points for. See details in endpoint description.Valid Values :
        ///     "5m" "yearly" "monthly" "weekly" "daily" "hourly" "5m" "10m" "15m" "30m" "45m" "1h" "2h" "3h" "6h" "12h" "24h" "1d"
        ///     "2d" "3d" "7d" "14d" "15d" "30d" "60d" "90d" "365d" Default: "5m"
        /// </param>
        /// <param name="convert">
        ///     Optionally calculate market quotes in up to 32 currencies at once by passing a comma-separated
        ///     list of cryptocurrency or fiat currency symbols. Each additional convert option beyond the first requires an
        ///     additional call credit.
        /// </param>
        /// <returns></returns>
        Task<ResponseMain<QuotesHistoricalData>> GetQuotesHistorical(string id, string slug, string timeStart,
            string timeEnd, int count, string interval, string[] convert);

        /// <summary>
        ///     Get the latest 24 hour volume quote for 1 or more exchanges. Additional market data fields will be available in the
        ///     future. Use the "convert" option to return market values in multiple fiat and cryptocurrency conversions in the
        ///     same call.
        ///     This endpoint is available on the following API plans:Standard,Professional,Enterprise
        /// </summary>
        /// <param name="id">One or more comma-separated CoinMarketCap exchange IDs. Example: "1,2"</param>
        /// <param name="slug">
        ///     Alternatively, pass a comma-separated list of exchange "slugs" (URL friendly all lowercase shorthand
        ///     version of name with spaces replaced with hyphens). Example: "binance,gdax". At least one "id" or "slug" is
        ///     required
        /// </param>
        /// <param name="convert">
        ///     Optionally calculate market quotes in up to 32 currencies at once by passing a comma-separated
        ///     list of cryptocurrency or fiat currency symbols. Each additional convert option beyond the first requires an
        ///     additional call credit.
        /// </param>
        /// <returns></returns>
        Task<ResponseMain<Dictionary<string, QuotesLatestData>>> GetQuotesLatest(string id, string slug,
            string[] convert);
    }
}