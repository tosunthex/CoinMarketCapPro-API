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
        }
        [Fact]
        public async Task MetaDataMustReturnGivenCurrencyDetail()
        {
            var  currencyInfo = await _coinMarketCapClient.CryptoCurrencyClient.GetMetaData(new string[]{}, new []{Currency.Btc,Currency.Xrp});
            Assert.Equal("BTC",currencyInfo.Data.Values.First().Symbol);
            Assert.Equal("XRP", currencyInfo.Data.Values.Last().Symbol);
        }

        [Fact]
        public async Task FirstElemantofIdMapMustBeBtc()
        {
            var idMap = await _coinMarketCapClient.CryptoCurrencyClient.GetIdMap(ListingStatus.Active, 1, 1, new[]{""});
            Assert.Single(idMap.Data);
            Assert.Equal("BTC",idMap.Data.First().Symbol);
        }

//        [Fact]
//        public async Task BtcToUsdListingsHistorical()
//        {
//            var listingHistorical = await _coinMarketCapClient.CryptoCurrencyClient.GetListingsHistorical("", 1, 2,
//                new[] {"USD"}, SortField.MarketCap, SortDirection.Desc, "");
//            Assert.Equal("BTC",listingHistorical.Data.First().Symbol);
//        }
        [Fact]
        public async Task BtcToUsdListingsLatest()
        {
            var listingHistorical = await _coinMarketCapClient.CryptoCurrencyClient.GetListingLatest(1, 2,
                new[] {"USD"}, SortField.MarketCap, "", CryptoCurrencyType.All);
            Assert.Equal("BTC",listingHistorical.Data.First().Symbol);
            Assert.Equal("USD",listingHistorical.Data.First().Quote.First().Key);
        }

        [Fact]
        public async Task MarketPairsLastestForBtc()
        {
            var marketPairs =
                await _coinMarketCapClient.CryptoCurrencyClient.GetMarketPairLatest("", Currency.Btc, 1, 1, new []{ Currency.Usd,Currency.Eur });
            Assert.Equal("BTC/USD",marketPairs.Data.MarketPairs.First().MarketPair);
            Assert.Equal("BitMEX",marketPairs.Data.MarketPairs.First().Exchange.Name);
            Assert.Equal("USD", marketPairs.Data.MarketPairs.First().Quote.Last().Key);
        }

        [Fact]
        public async Task OhlcvHistoricalForBtc()
        {
            var result = await _coinMarketCapClient.CryptoCurrencyClient.GetOhlvcHistorical("", "BTC", Interval.Daily,
                "2018-08-07T00:00:00.000Z", "2018-08-10T00:00:00.000Z", 10, Interval.Daily, new string[] {Currency.Usd});
            Assert.Equal(3, result.Data.Quotes.Length);
            Assert.Equal("BTC", result.Data.Symbol);
        }

        [Fact]
        public async Task OhlcvLatestForBtc()
        {
            var result = await _coinMarketCapClient.CryptoCurrencyClient.GetOhlcvLatest(new []{""}, new []{ Currency.Btc }, new [] { Currency.Usd });
            Assert.Equal("BTC",result.Data.First().Value.Symbol);
            Assert.Equal("Bitcoin",result.Data.First().Value.Name);
        }

        [Fact]
        public async Task QuotesHistoricalForBtc()
        {
            var result = await _coinMarketCapClient.CryptoCurrencyClient.GetQuotesHistorical("", "BTC","2018-08-07T00:00:00.000Z", "2018-08-10T00:00:00.000Z",10,Interval.Daily, new [] { Currency.Usd });
            Assert.Equal("Bitcoin",result.Data.Name);
        }

        [Fact]
        public async Task QuotesLatestForBtc()
        {
            var result = await _coinMarketCapClient.CryptoCurrencyClient.GetQuotesLatest(new[] { "" }, new[] { Currency.Btc }, new [] { Currency.Usd });
            Assert.Equal("Bitcoin",result.Data.First().Value.Name);
            Assert.Equal("USD",result.Data.First().Value.Quote.First().Key);
        }
    }
}
