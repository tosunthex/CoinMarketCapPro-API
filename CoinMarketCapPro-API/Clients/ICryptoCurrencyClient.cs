using System.Collections.Generic;
using System.Threading.Tasks;
using CoinMarketCapPro_API.Models.Responses;
using CoinMarketCapPro_API.Models.Responses.CryptoCurrency;

namespace CoinMarketCapPro_API.Clients
{
    public interface ICryptoCurrencyClient
    {
        /// <summary>
        ///     Returns all static metadata for one or more cryptocurrencies including name, symbol, logo, and its various
        ///     registered URLs.
        ///     This endpoint is available on the following API plans:Starter,Hobbyist,Standard,Professional,Enterprise
        /// </summary>
        /// <param name="id">One or more comma-separated CoinMarketCap cryptocurrency IDs. Example: "1,2"</param>
        /// <param name="symbol">
        ///     Alternatively pass one or more comma-separated cryptocurrency symbols. Example: "BTC,ETH". At
        ///     least one "id" or "symbol" is required.
        /// </param>
        /// <returns></returns>
        Task<ResponseMain<Dictionary<string, CryptoCurrencyInfoData>>> GetMetaData(string[] id, string[] symbol);
        /// <summary>
        ///     Returns all static metadata for one or more cryptocurrencies including name, symbol, logo, and its various
        ///     registered URLs.
        ///     This endpoint is available on the following API plans:Starter,Hobbyist,Standard,Professional,Enterprise
        /// </summary>
        /// <param name="idOrSymbol">
        ///     One or more comma-separated CoinMarketCap cryptocurrency IDs or Cryptocurrency symbols.Example: "1,2" or "BTC,ETH"
        /// </param>
        /// <returns></returns>
        Task<ResponseMain<Dictionary<string, CryptoCurrencyInfoData>>> GetMetaData(string[] idOrSymbol);

        /// <summary>
        ///     Returns a paginated list of all cryptocurrencies by CoinMarketCap ID. We recommend using this convenience endpoint
        ///     to lookup and utilize
        ///     our unique cryptocurrency id across all endpoints as typical identifiers like ticker symbols can match multiple
        ///     cryptocurrencies and
        ///     change over time. As a convenience you may pass a comma-separated list of cryptocurrency symbols as symbol to
        ///     filter this list to only
        ///     those you require.
        ///     This endpoint is available on the following API plans:Starter,Hobbyist,Standard,Professional,Enterprise
        /// </summary>
        /// <param name="listingStatus">
        ///     Only active coins are returned by default. Pass 'inactive' to get a list of coins that are
        ///     no longer active.
        /// </param>
        /// <param name="start">Optionally offset the start (1-based index) of the paginated list of items to return.</param>
        /// <param name="limit">
        ///     Optionally specify the number of results to return. Use this parameter and the "start" parameter to
        ///     determine your own pagination size.
        /// </param>
        /// <param name="symbol">
        ///     Optionally pass a comma-separated list of cryptocurrency symbols to return CoinMarketCap IDs for.
        ///     If this option is passed, other options will be ignored.
        /// </param>
        /// <returns></returns>
        Task<ResponseMain<IdMapData[]>> GetIdMap(string listingStatus, int start, int limit, string[] symbol);

        /// <summary>
        ///     Returns a paginated list of all cryptocurrencies by CoinMarketCap ID. We recommend using this convenience endpoint
        ///     to lookup and utilize
        ///     our unique cryptocurrency id across all endpoints as typical identifiers like ticker symbols can match multiple
        ///     cryptocurrencies and
        ///     change over time. As a convenience you may pass a comma-separated list of cryptocurrency symbols as symbol to
        ///     filter this list to only
        ///     those you require.
        ///     This endpoint is available on the following API plans:Starter,Hobbyist,Standard,Professional,Enterprise
        ///     Default Values: listing_status = true and start = 1
        /// </summary>
        /// <param name="limit">
        ///     Optionally specify the number of results to return. Use this parameter and the "start" parameter to
        ///     determine your own pagination size.
        /// </param>
        /// <param name="symbol">
        ///     Optionally pass a comma-separated list of cryptocurrency symbols to return CoinMarketCap IDs for.
        ///     If this option is passed, other options will be ignored.
        /// </param>
        /// <returns></returns>
        Task<ResponseMain<IdMapData[]>> GetIdMap(int limit, string[] symbol);

        /// <summary>
        ///     Get a paginated list of all cryptocurrencies with market data for a given historical time. Use the "convert" option
        ///     to return market values in multiple fiat and cryptocurrency conversions in the same call.
        /// </summary>
        /// <param name="timestamp">Timestamp (Unix or ISO 8601) to return historical cryptocurrency listings for.</param>
        /// <param name="start">Optionally offset the start (1-based index) of the paginated list of items to return.</param>
        /// <param name="limit">
        ///     Optionally specify the number of results to return. Use this parameter and the "start" parameter to
        ///     determine your own pagination size
        /// </param>
        /// <param name="convert">
        ///     Optionally calculate market quotes in up to 32 currencies at once by passing a comma-separated
        ///     list of cryptocurrency or fiat currency symbols. Each additional convert option beyond the first requires an
        ///     additional call credit. A list of supported fiat options can be found here. Each conversion is returned in its own
        ///     "quote" object.
        /// </param>
        /// <param name="sortField">
        ///     Default field "market_cap""name". Valid values: "symbol" "date_added" "market_cap" "price"
        ///     "circulating_supply" "total_supply" "max_supply" "num_market_pairs" "volume_24h" "percent_change_1h" "percent_change_24h"
        ///     "percent_change_7d" What field to sort the list of cryptocurrencies by.
        /// </param>
        /// <param name="sortDirection">
        ///     Default: "desc". Valid values: "asc" "desc" The direction in which to order cryptocurrencies
        ///     against the specified sort.
        /// </param>
        /// <param name="cryptocurrencyType">
        ///     Default: "all". Valid values: "all" "coins" "tokens" The type of cryptocurrency to include.
        /// </param>
        /// <returns></returns>
        Task<ResponseMain<ListingHistoricalData[]>> GetListingsHistorical(string timestamp, int start, int limit,
            string[] convert, string sortField, string sortDirection, string cryptocurrencyType);

        /// <summary>
        ///     Get a paginated list of all cryptocurrencies with market data for a given historical time. Use the "convert" option
        ///     to return market values in multiple fiat and cryptocurrency conversions in the same call.
        ///     Default Values; start = 1, limit = 100, sort = "market_cap", sort_dir="desc", cryptocurrency_type="all"
        /// </summary>
        /// <param name="timestamp">Timestamp (Unix or ISO 8601) to return historical cryptocurrency listings for.</param>
        /// <param name="convert">
        ///     Optionally calculate market quotes in up to 32 currencies at once by passing a comma-separated
        ///     list of cryptocurrency or fiat currency symbols. Each additional convert option beyond the first requires an
        ///     additional call credit. A list of supported fiat options can be found here. Each conversion is returned in its own
        ///     "quote" object.
        /// </param>
        /// <returns></returns>
        Task<ResponseMain<ListingHistoricalData[]>> GetListingsHistorical(string timestamp, string[] convert);

        /// <summary>
        ///     Get a paginated list of all cryptocurrencies with latest market data. You can configure this call to sort by market
        ///     cap or another market ranking field. Use the "convert" option to return market values in multiple fiat and
        ///     cryptocurrency conversions in the same call.
        ///     This endpoint is available on the following API plans:Starter,Hobbyist,Standard,Professional,Enterprise
        /// </summary>
        /// <param name="start">Optionally offset the start (1-based index) of the paginated list of items to return.</param>
        /// <param name="limit">
        ///     Optionally specify the number of results to return. Use this parameter and the "start" parameter to
        ///     determine your own pagination size.
        /// </param>
        /// <param name="convert">
        ///     Optionally calculate market quotes in up to 32 currencies at once by passing a comma-separated
        ///     list of cryptocurrency or fiat currency symbols. Each additional convert option beyond the first requires an
        ///     additional call credit. A list of supported fiat options can be found here. Each conversion is returned in its own
        ///     "quote" object.
        /// </param>
        /// <param name="sortField">What field to sort the list of cryptocurrencies by.</param>
        /// <param name="sortDir">The direction in which to order cryptocurrencies against the specified sort.</param>
        /// <param name="cryptoCurrencyType">The type of cryptocurrency to include.</param>
        /// <returns></returns>
        Task<ResponseMain<ListingLatestData[]>> GetListingLatest(int start, int limit, string[] convert,
            string sortField,string sortDir, string cryptoCurrencyType);

        /// <summary>
        ///     Get a paginated list of all cryptocurrencies with latest market data. You can configure this call to sort by market
        ///     cap or another market ranking field. Use the "convert" option to return market values in multiple fiat and
        ///     cryptocurrency conversions in the same call.
        ///     This endpoint is available on the following API plans:Starter,Hobbyist,Standard,Professional,Enterprise
        ///     Default Values; start = 1, limit = 100, convert="usd", sort = "market_cap", sort_dir="desc", cryptocurrency_type="all" 
        /// </summary>
        /// <returns></returns>
        Task<ResponseMain<ListingLatestData[]>> GetListingLatest();

        /// <summary>
        ///     Lists all market pairs for the specified cryptocurrency with associated stats. Use the "convert" option to return
        ///     market values in multiple fiat and cryptocurrency conversions in the same call.
        ///     This endpoint is available on the following API plans:Standard,Professional,Enterprise
        /// </summary>
        /// <param name="id">A cryptocurrency by CoinMarketCap ID. Example: "1"</param>
        /// <param name="symbol">
        ///     Alternatively pass a cryptocurrency by symbol. Example: "BTC". A single cryptocurrency "id" or
        ///     "symbol" is required.
        /// </param>
        /// <param name="start">Optionally offset the start (1-based index) of the paginated list of items to return.Default = 1</param>
        /// <param name="limit">
        ///     Optionally specify the number of results to return. Use this parameter and the "start" parameter to
        ///     determine your own pagination size.Default = 100
        /// </param>
        /// <param name="convert">
        ///     Optionally calculate market quotes in up to 32 currencies at once by passing a comma-separated
        ///     list of cryptocurrency or fiat currency symbols. Each additional convert option beyond the first requires an
        ///     additional call credit. A list of supported fiat options can be found here. Each conversion is returned in its own
        ///     "quote" object. Default = "USD"
        /// </param>
        /// <returns></returns>
        Task<ResponseMain<MarketPairsLatestData>> GetMarketPairLatest(string id, string symbol, int start, int limit,
            string[] convert);

        /// <summary>
        ///     Lists all market pairs for the specified cryptocurrency with associated stats. Use the "convert" option to return
        ///     market values in multiple fiat and cryptocurrency conversions in the same call.
        ///     This endpoint is available on the following API plans:Standard,Professional,Enterprise
        ///     Default Values; start = 1, limit = 100, convert="usd"
        /// </summary>
        ///     
        /// <param name="idOrSymbol">A CoinMarketCap cryptocurrency ID or cryptocurrency symbol. Example: "1" ,"BTC".</param>
        /// <returns></returns>
        Task<ResponseMain<MarketPairsLatestData>> GetMarketPairLatest(string idOrSymbol);

        /// <summary>
        ///     Return an interval of historic OHLCV (Open, High, Low, Close, Volume) market quotes for a cryptocurrency.
        ///     This endpoint is available on the following API plans : Standard (1 month),Professional (12 months),Enterprise (Up
        ///     to 5 years)
        /// </summary>
        /// <param name="id">A CoinMarketCap cryptocurrency ID. Example: "1"</param>
        /// <param name="symbol">
        ///     Alternatively a cryptocurrency symbol. Example: "BTC". One "id" or "symbol" is required.
        /// </param>
        /// <param name="timePeriod">
        ///     Time period to return OHLCV data for. The default is "daily". Additional options will be
        ///     available in the future. See the main endpoint description for details.Default = "daily"
        /// </param>
        /// <param name="timeStart">
        ///     Timestamp (Unix or ISO 8601) to start returning OHLCV time periods for. Only the date portion
        ///     of the timestamp is used for daily OHLCV so it's recommended to send an ISO date format like "2018-09-19" without
        ///     time.
        /// </param>
        /// <param name="timeEnd">
        ///     Timestamp (Unix or ISO 8601) to stop returning OHLCV time periods for (inclusive). Optional, if
        ///     not passed we'll default to the current time. Only the date portion of the timestamp is used for daily OHLCV so
        ///     it's recommended to send an ISO date format like "2018-09-19" without time.
        /// </param>
        /// <param name="count">
        ///     Optionally limit the number of time periods to return results for. The default is 10 items. The
        ///     current query limit is 10000 items. Default = 10
        /// </param>
        /// <param name="interval">
        ///     Optionally adjust the interval that "time_period" is sampled. See main endpoint description for
        ///     available options. Default= "daily"
        /// </param>
        /// <param name="convert">
        ///     By default market quotes are returned in USD. Optionally calculate market quotes in another fiat
        ///     currency or cryptocurrency. Currently historic endpoints are restricted to USD for fiat options.Default = "USD"
        /// </param>
        /// <returns></returns>
        Task<ResponseMain<OhlcvHistoricalData>> GetOhlvcHistorical(string id, string symbol, string timePeriod,
            string timeStart, string timeEnd, int count, string interval, string[] convert);

        /// <summary>
        ///     Return an interval of historic OHLCV (Open, High, Low, Close, Volume) market quotes for a cryptocurrency.
        ///     This endpoint is available on the following API plans : Standard (1 month),Professional (12 months),Enterprise (Up
        ///     to 5 years)
        ///     Default Values : count=10, interval="daily", convert="USD"
        /// </summary>
        /// <param name="idOrSymbol">A CoinMarketCap cryptocurrency ID or cryptocurrency symbol. Example: "1" ,"BTC".</param>
        /// <param name="timeStart">
        ///     Timestamp (Unix or ISO 8601) to start returning OHLCV time periods for. Only the date portion
        ///     of the timestamp is used for daily OHLCV so it's recommended to send an ISO date format like "2018-09-19" without
        ///     time.
        /// </param>
        /// <param name="timeEnd">
        ///     Timestamp (Unix or ISO 8601) to stop returning OHLCV time periods for (inclusive). Optional, if
        ///     not passed we'll default to the current time. Only the date portion of the timestamp is used for daily OHLCV so
        ///     it's recommended to send an ISO date format like "2018-09-19" without time.
        /// </param>
        /// <returns></returns>
        Task<ResponseMain<OhlcvHistoricalData>> GetOhlvcHistorical(string idOrSymbol,string timeStart, string timeEnd);

        /// <summary>
        ///     Return the latest OHLCV (Open, High, Low, Close, Volume) market values for one or more cryptocurrencies in the
        ///     currently UTC day. Since the current UTC day is still active these values are updated frequently. You can find the
        ///     final calculated OHLCV values for the last completed UTC day along with all historic days using
        ///     /cryptocurrency/ohlcv/historical.
        ///     This endpoint is available on the following API plans:Standard,Professional,Enterprise
        /// </summary>
        /// <param name="id">One or more comma-separated CoinMarketCap cryptocurrency IDs. Example: "1,2"</param>
        /// <param name="symbol">
        ///     Alternatively pass one or more comma-separated cryptocurrency symbols. Example: "BTC,ETH". At
        ///     least one "id" or "symbol" is required.
        /// </param>
        /// <param name="convert">
        ///     By default market quotes are returned in USD. Optionally calculate market quotes in another fiat
        ///     currency or cryptocurrency. Currently historic endpoints are restricted to USD for fiat options.Default = "USD"
        /// </param>
        /// <returns></returns>
        Task<ResponseMain<Dictionary<string, OhlcvLatestData>>> GetOhlcvLatest(string[] id, string[] symbol,string[] convert);

        /// <summary>
        ///     Return the latest OHLCV (Open, High, Low, Close, Volume) market values for one or more cryptocurrencies in the
        ///     currently UTC day. Since the current UTC day is still active these values are updated frequently. You can find the
        ///     final calculated OHLCV values for the last completed UTC day along with all historic days using
        ///     /cryptocurrency/ohlcv/historical.
        ///     This endpoint is available on the following API plans:Standard,Professional,Enterprise
        ///     Default Values : convert="USD"
        /// </summary>
        /// <param name="idOrSymbol">
        ///     One or more comma-separated CoinMarketCap cryptocurrency IDs or Cryptocurrency symbols.Example: "1,2" or "BTC,ETH"
        /// </param>
        /// <returns></returns>
        Task<ResponseMain<Dictionary<string, OhlcvLatestData>>> GetOhlcvLatest(string[] idOrSymbol);

        /// <summary>
        ///     Returns an interval of historic market quotes for any cryptocurrency based on time and interval parameters.
        ///     This endpoint is available on the following API plans : Standard (1 month),Professional (12 months),Enterprise (Up
        ///     to 5 years)
        /// </summary>
        /// <param name="id">A CoinMarketCap cryptocurrency ID. Example: "1"</param>
        /// <param name="symbol">Alternatively pass a cryptocurrency symbol. Example: "BTC". One "id" or "symbol" is required.</param>
        /// <param name="timeStart">
        ///     Timestamp (Unix or ISO 8601) to start returning OHLCV time periods for. Only the date portion
        ///     of the timestamp is used for daily OHLCV so it's recommended to send an ISO date format like "2018-09-19" without
        ///     time.
        /// </param>
        /// <param name="timeEnd">
        ///     Timestamp (Unix or ISO 8601) to stop returning OHLCV time periods for (inclusive). Optional, if
        ///     not passed we'll default to the current time. Only the date portion of the timestamp is used for daily OHLCV so
        ///     it's recommended to send an ISO date format like "2018-09-19" without time.
        /// </param>
        /// <param name="count">
        ///     Optionally limit the number of time periods to return results for. The default is 10 items. The
        ///     current query limit is 10000 items. Default = 10
        /// </param>
        /// <param name="interval">
        ///     Optionally adjust the interval that "time_period" is sampled. See main endpoint description for
        ///     available options.
        /// </param>
        /// <param name="convert">
        ///     By default market quotes are returned in USD. Optionally calculate market quotes in another fiat
        ///     currency or cryptocurrency. Currently historic endpoints are restricted to USD for fiat options.Default = "USD"
        /// </param>
        /// <returns></returns>
        Task<ResponseMain<QuotesHistoricalData>> GetQuotesHistorical(string id, string symbol, string timeStart,
            string timeEnd, int count, string interval, string[] convert);

        /// <summary>
        ///     Returns an interval of historic market quotes for any cryptocurrency based on time and interval parameters.
        ///     This endpoint is available on the following API plans : Standard (1 month),Professional (12 months),Enterprise (Up
        ///     to 5 years)
        ///     Default Values: count=10 ,interval="5m" , convert="USD"
        /// </summary>
        /// <param name="idOrSymbol">A CoinMarketCap cryptocurrency ID or cryptocurrency symbol. Example: "1" ,"BTC".</param>
        /// <param name="timeStart">
        ///     Timestamp (Unix or ISO 8601) to start returning OHLCV time periods for. Only the date portion
        ///     of the timestamp is used for daily OHLCV so it's recommended to send an ISO date format like "2018-09-19" without
        ///     time.
        /// </param>
        /// <param name="timeEnd">
        ///     Timestamp (Unix or ISO 8601) to stop returning OHLCV time periods for (inclusive). Optional, if
        ///     not passed we'll default to the current time. Only the date portion of the timestamp is used for daily OHLCV so
        ///     it's recommended to send an ISO date format like "2018-09-19" without time.
        /// </param>
        /// <returns></returns>
        Task<ResponseMain<QuotesHistoricalData>> GetQuotesHistorical(string idOrSymbol, string timeStart,string timeEnd);

        /// <summary>
        ///     Get the latest market quote for 1 or more cryptocurrencies. Use the "convert" option to return market values in
        ///     multiple fiat and cryptocurrency conversions in the same call.
        ///     This endpoint is available on the following API plans:Starter,Hobbyist,Standard,Professional,Enterprise
        /// </summary>
        /// <param name="id">One or more comma-separated CoinMarketCap cryptocurrency IDs. Example: "1,2"</param>
        /// <param name="symbol">
        ///     Alternatively pass one or more comma-separated cryptocurrency symbols. Example: "BTC,ETH". At
        ///     least one "id" or "symbol" is required.
        /// </param>
        /// <param name="convert">
        ///     By default market quotes are returned in USD. Optionally calculate market quotes in another fiat
        ///     currency or cryptocurrency. Currently historic endpoints are restricted to USD for fiat options.Default = "USD"
        /// </param>
        /// <returns></returns>
        Task<ResponseMain<Dictionary<string, QuotesLatestData>>> GetQuotesLatest(string[] id, string[] symbol,
            string[] convert);
        /// <summary>
        ///     Get the latest market quote for 1 or more cryptocurrencies. Use the "convert" option to return market values in
        ///     multiple fiat and cryptocurrency conversions in the same call.
        ///     This endpoint is available on the following API plans:Starter,Hobbyist,Standard,Professional,Enterprise
        ///     Default Values: convert="USD"
        /// </summary>
        /// <param name="idOrSymbol">
        ///     One or more comma-separated CoinMarketCap cryptocurrency IDs or Cryptocurrency symbols.Example: "1,2" or "BTC,ETH"
        /// </param>
        /// <returns></returns>
        Task<ResponseMain<Dictionary<string, QuotesLatestData>>> GetQuotesLatest(string[] idOrSymbol);
    }
}