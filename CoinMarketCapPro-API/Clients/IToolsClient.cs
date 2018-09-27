using System.Threading.Tasks;
using CoinMarketCapPro_API.Models.Responses;
using CoinMarketCapPro_API.Models.Responses.Tools;

namespace CoinMarketCapPro_API.Clients
{
    public interface IToolsClient
    {
        /// <summary>
        /// Convert an amount of one currency into up to 32 other cryptocurrency or fiat currencies at the same time using latest exchange rates. Optionally pass a historical timestamp to convert values based on historic averages.
        /// 
        /// This endpoint is available on the following API plans:Hobbyist,Standard,Professional,Enterprise
        /// </summary>
        /// <param name="amount">An amount of currency to convert. Example: 10.43</param>
        /// <param name="id">The CoinMarketCap cryptocurrency ID of the base currency to convert from. Example: "1"</param>
        /// <param name="symbol">Alternatively the cryptocurrency symbol of the base currency to convert from. Example: "BTC". One "id" or "symbol" is required</param>
        /// <param name="time">Optional timestamp (Unix or ISO 8601) to reference historical pricing during conversion. If not passed, the current time will be used. If passed, we'll reference the closest historic values available during conversion</param>
        /// <param name="convert">Optionally calculate market quotes in up to 32 currencies at once by passing a comma-separated list of cryptocurrency or fiat currency symbols. Each additional convert option beyond the first requires an additional call credit.</param>
        /// <returns></returns>
        Task<ResponseMain<PriceConversionData>> GetPriceConversion(float amount, string id, string symbol,
            string time, string[] convert);
    }
}