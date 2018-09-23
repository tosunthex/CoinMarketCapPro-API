using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CoinMarketCapPro_API.Clients;
using CoinMarketCapPro_API.Parameters;
using Xunit;

namespace CoinMarketCap_Pro.Tests
{
    public class CryptoCurrencyApiTests
    {
        private readonly CoinMarketCapClient _coinMarketCapClient;
        public CryptoCurrencyApiTests()
        {
            _coinMarketCapClient = new CoinMarketCapClient(new HttpClientHandler(), ApiEnvironment.Sandbox, "5bb4185b-ebb3-4cf7-942a-66a280f5db8b");
            //_coinMarketCapClient = new CoinMarketCapClient(new HttpClientHandler(), ApiEnvironment.Pro, "c572865c-d03a-4be2-8cba-84c963e48869");
        }
        [Fact]
        public async Task MetaDataMustReturnGivenCurrencyDetail()
        {
            var  currencyInfo = await _coinMarketCapClient.CryptoCurrencyClient.GetMetaData(new string[]{}, new []{"BTC","XRP"});
            Assert.Equal("BTC",currencyInfo.Data.Values.First().Symbol);
            Assert.Equal("XRP", currencyInfo.Data.Values.Last().Symbol);
        }
    }
}
