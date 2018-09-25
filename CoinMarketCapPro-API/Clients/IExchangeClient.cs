using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using CoinMarketCapPro_API.Models.Responses;
using CoinMarketCapPro_API.Models.Responses.Exchange;

namespace CoinMarketCapPro_API.Clients
{
    public interface IExchangeClient
    {
        Task<ResponseMain<Dictionary<string, InfoData>>> GetInfo(string id, string slug);
    }
}