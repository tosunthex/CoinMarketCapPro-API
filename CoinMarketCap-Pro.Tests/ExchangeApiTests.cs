using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CoinMarketCapPro_API.Clients;
using CoinMarketCapPro_API.Parameters;
using FluentAssertions;
using Xunit;

namespace CoinMarketCap_Pro.Tests
{
    public class ExchangeApiTests
    {
        private readonly CoinMarketCapClient _coinMarketCapClient;
        public ExchangeApiTests()
        {
            _coinMarketCapClient = new CoinMarketCapClient(new HttpClientHandler(), ApiEnvironment.Sandbox,"5bb4185b-ebb3-4cf7-942a-66a280f5db8b");
        }
        
        [Fact]
        public async Task ExchangeInfoMustReturnBinanceDetail()
        {
            var result = await _coinMarketCapClient.ExchangeClient.GetInfo("", "binance");
            Assert.Equal("Binance",result.Data.First().Value.Name);
            Assert.Equal("binance",result.Data.First().Key);
        }

        [Fact]
        public async Task MapMustReturnBinance()
        {
            var result = await _coinMarketCapClient.ExchangeClient.GetMap("", "binance", 1, 100);
            Assert.Equal("Binance",result.Data.First().Name);
        }

//        [Fact]
//        public async Task ExchangeListingHistoricalBinance()
//        {
//            var result = await _coinMarketCapClient.ExchangeClient.GetListingHistorical("2018-06-02T00:00:00.000Z",1,10,"","","","");
//            Assert.Equal("Binance",result.Data.First().Name);
//        }
        [Fact]
        public async Task ListingLatestBinance()
        {
            var result = await _coinMarketCapClient.ExchangeClient.GetListingLatest(1, 100,SortField.Volume24H, SortDirection.Desc, MarketType.Fees, new []{""});
            Assert.Equal("Binance",result.Data.First().Name);
            Assert.Equal("binance",result.Data.First().Slug);
        }

        [Fact]
        public async Task ListingLatestBinance_For_Default_Values()
        {
            var expected = await _coinMarketCapClient.ExchangeClient.GetListingLatest(1, 100,SortField.Volume24H, SortDirection.Desc, MarketType.Fees, new []{""});
            var actual = await _coinMarketCapClient.ExchangeClient.GetListingLatest();
            expected.Data.Should().BeEquivalentTo(actual.Data);
        }

        [Fact]
        public async Task MarketPairsLatest()
        {
            var result = await _coinMarketCapClient.ExchangeClient.GetMarketPairsLatest("", "binance", 1, 1, new[] { Currency.Usd });
            Assert.Equal("Binance",result.Data.Name);
            Assert.Equal("BTC/USDT",result.Data.MarketPairs.First().MarketPair);
        }
        [Fact]
        public async Task MarketPairsLatest_Default_Values()
        {
            var expected = await _coinMarketCapClient.ExchangeClient.GetMarketPairsLatest("", "binance", 1, 100, new[] { Currency.Usd });
            var actual = await _coinMarketCapClient.ExchangeClient.GetMarketPairsLatest("binance");
            expected.Data.Should().BeEquivalentTo(actual.Data);
        }
        
        [Fact]
        public async Task QuotesHistorical()
        {
            var result = await _coinMarketCapClient.ExchangeClient.GetQuotesHistorical("", "binance",
                "2018-08-15T08:55:14.000Z", "2018-09-15T08:55:14.000Z", 1, "", new[] {Currency.Usd});
            Assert.Equal("Binance",result.Data.Name);
        }
        [Fact]
        public async Task QuotesHistorical_Default_Values()
        {
            var expected = await _coinMarketCapClient.ExchangeClient.GetQuotesHistorical("", "binance",
                "2018-08-15T08:55:14.000Z", "2018-09-15T08:55:14.000Z", 1, "", new[] { Currency.Usd });
            var actual = await _coinMarketCapClient.ExchangeClient.GetQuotesHistorical("binance",
                "2018-08-15T08:55:14.000Z", "2018-09-15T08:55:14.000Z");
            expected.Data.Name.Should().BeEquivalentTo(actual.Data.Name);
        }
        
        [Fact]
        public async Task QuotesLatest()
        {
            var result = await _coinMarketCapClient.ExchangeClient.GetQuotesLatest("", "binance",new[] { Currency.Usd });
            Assert.Equal("Binance",result.Data.First().Value.Name);
        }        

        [Fact]
        public async Task QuotesLatest_Default_Values()
        {
            var expected = await _coinMarketCapClient.ExchangeClient.GetQuotesLatest("", "binance",new[] { Currency.Usd });
            var actual = await _coinMarketCapClient.ExchangeClient.GetQuotesLatest("binance");
            expected.Data.Should().BeEquivalentTo(actual.Data);
            
        }
    }
}