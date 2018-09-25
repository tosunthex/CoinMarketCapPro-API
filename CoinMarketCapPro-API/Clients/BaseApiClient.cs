using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CoinMarketCapPro_API.Models.Responses;
using CoinMarketCapPro_API.Models.Responses.CryptoCurrency;
using CoinMarketCapPro_API.Parameters;
using Newtonsoft.Json;

namespace CoinMarketCapPro_API.Clients
{
    public class BaseApiClient:IApiClient
    {
        public Task<TApiResponse> GetAsync<TApiResponse>(Uri resourceUri)
        {
            return SendRequestAsync<TApiResponse>(HttpMethod.Get, resourceUri);
        }

        public async Task<TApiResponse> SendRequestAsync<TApiResponse>(HttpMethod httpMethod, Uri resourseUri)
        {
            var request = new HttpRequestMessage(httpMethod, resourseUri);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Accept-Encoding", "deflate, gzip");
            request.Headers.Add("X-CMC_PRO_API_KEY",ApiParameters.ApiKey);


            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            using (var client = new HttpClient(handler))
            {
                var response = await client.SendAsync(request).ConfigureAwait(false);
                var responseContent = await response.Content.ReadAsStringAsync();
                try
                {
                    return JsonConvert.DeserializeObject<TApiResponse>(responseContent);
                }
                catch (Exception e)
                {
                    var errorResponse = JsonConvert.DeserializeObject<Dictionary<string, Status>>(responseContent);
                    var errorMessage = $"Error Code : {errorResponse.Values.First().ErrorCode} Error Message : {errorResponse.Values.First().ErrorMessage}";
                    throw new HttpRequestException(errorMessage);
                }
            }
        }
    }
}