using System.Net.Http;
using System.Threading.Tasks;
using CoinMarketCapPro;
using CoinMarketCapPro_API.Models.Responses;
using CoinMarketCapPro_API.Models.Responses.Tools;

namespace CoinMarketCapPro_API.Clients
{
    public class ToolsClient:BaseApiClient,IToolsClient
    {
        public ToolsClient(HttpClient httpClient)
        {
            
        }
        public async Task<ResponseMain<PriceConversionData>> GetPriceConversion(float amount, string id, string symbol, string time, string[] convert)
        {
            return await GetAsync<ResponseMain<PriceConversionData>>(ToolsApiUrls.InfoUri(amount, id, symbol, time,
                convert));
        }
    }
}