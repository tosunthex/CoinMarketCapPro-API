using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CoinMarketCapPro_API.Clients;
using CoinMarketCapPro_API.Parameters;
using Xunit;

namespace CoinMarketCap_Pro.Tests
{
    public class GlobalMetricsApiTests
    {
        private readonly CoinMarketCapClient _coinMarketCapClient;
        public GlobalMetricsApiTests()
        {
            _coinMarketCapClient = new CoinMarketCapClient(new HttpClientHandler(), ApiEnvironment.Sandbox, "5bb4185b-ebb3-4cf7-942a-66a280f5db8b");
        }

        [Fact]
        public async Task GlobalMetricsHistorical()
        {
            var result =
                await _coinMarketCapClient.GlobalMetricClient.GetGlobalMetricsHistorical("2018-08-16T00:02:00.000Z", "2018-08-17T00:02:00.000Z", 10, Interval.Daily,
                    new[] { Currency.Usd });
            Assert.Equal("USD",result.Data.Quotes.First().Quote.Keys.First());
        }
        [Fact]
        public async Task GlobalMetricsLatest()
        {
            var result =
                await _coinMarketCapClient.GlobalMetricClient.GetGlobalMetricsLatest(new[] { Currency.Usd });
            Assert.Equal("USD", result.Data.Quote.First().Key);
        }
    }
}