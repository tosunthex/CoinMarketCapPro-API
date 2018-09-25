using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CoinMarketCapPro_API.Models.Responses;
using CoinMarketCapPro_API.Models.Responses.Exchange;
using CoinMarketCapPro_API.Parameters;

namespace CoinMarketCapPro_API.Clients
{
    public class ExchangeClient:BaseApiClient,IExchangeClient
    {
        public ExchangeClient(HttpClient httpClient)
        {
            
        }
        public async Task<ResponseMain<Dictionary<string, InfoData>>> GetInfo(string id, string slug)
        {
            return await GetAsync<ResponseMain<Dictionary<string, InfoData>>>(ExchangeApiUrls.InfoUri(id, slug))
                .ConfigureAwait(false);
        }
    }
}