using System.Net.Http;
using System.Threading.Tasks;
using CoinMarketCapPro_API.Clients;
using CoinMarketCapPro_API.Parameters;
using Xunit;

namespace CoinMarketCap_Pro.Tests
{
    public class ToolsApiTests
    {
        private readonly CoinMarketCapClient _coinMarketCapClient;
        public ToolsApiTests()
        {
            _coinMarketCapClient = new CoinMarketCapClient(new HttpClientHandler(), ApiEnvironment.Sandbox, "5bb4185b-ebb3-4cf7-942a-66a280f5db8b");
        }

        [Fact]
        public async Task BitcoinToUsdPriceConversion()
        {
            var result = await _coinMarketCapClient.ToolsClient.GetPriceConversion(1, "", Currency.Btc, "", new[] { Currency.Usd });
            Assert.Equal("BTC",result.Data.Symbol);
        }
    }
}