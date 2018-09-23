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
    }
}