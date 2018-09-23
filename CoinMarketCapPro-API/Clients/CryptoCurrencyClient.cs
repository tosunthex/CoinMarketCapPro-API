using System.Collections.Generic;
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
    }
}