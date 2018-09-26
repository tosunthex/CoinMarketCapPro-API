using System.Threading.Tasks;
using CoinMarketCapPro_API.Models.Responses;
using CoinMarketCapPro_API.Models.Responses.Tools;

namespace CoinMarketCapPro_API.Clients
{
    public interface IToolsClient
    {
        Task<ResponseMain<PriceConversionData>> GetPriceConversion(float amount, string id, string symbol,
            string time, string[] convert);
    }
}