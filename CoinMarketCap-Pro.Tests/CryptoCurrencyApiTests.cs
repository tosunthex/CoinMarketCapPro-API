using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CoinMarketCapPro_API.Clients;
using CoinMarketCapPro_API.Parameters;
using FluentAssertions;
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
        public async Task Meta_Data_Must_Return_Given_Currency_Symbol()
        {
            var  result = await _coinMarketCapClient.CryptoCurrencyClient.GetMetaData(new string[]{}, new []{Currency.Btc,Currency.Xrp});
            Assert.Equal("BTC",result.Data.Values.First().Symbol);
            Assert.Equal("XRP", result.Data.Values.Last().Symbol);
        }
        [Fact]
        public async Task Meta_Data_WithIdorSymbol_Must_Return_Same_Values()
        {
            var expected = await _coinMarketCapClient.CryptoCurrencyClient.GetMetaData(new string[]{}, new []{Currency.Btc,Currency.Xrp});
            var actual = await _coinMarketCapClient.CryptoCurrencyClient.GetMetaData(new []{Currency.Btc,Currency.Xrp});
            Assert.Equal(expected.Data.Count, actual.Data.Count);
            expected.Data.Should().BeEquivalentTo(actual.Data); 
        }

        [Fact]
        public async Task FirstElemantofIdMapMustBeBtc()
        {
            var result = await _coinMarketCapClient.CryptoCurrencyClient.GetIdMap(ListingStatus.Active, 1, 1, new[]{""});
            Assert.Single(result.Data);
            Assert.Equal("BTC",result.Data.First().Symbol);
        }
        [Fact]
        public async Task Limit_One_Must_Return_BTC()
        {
            var expected = await _coinMarketCapClient.CryptoCurrencyClient.GetIdMap(1);
            var actual = await _coinMarketCapClient.CryptoCurrencyClient.GetIdMap(new[] {"BTC" });
            expected.Data.Should().BeEquivalentTo(actual.Data);
        }

//        [Fact]
//        public async Task BtcToUsdListingsHistorical()
//        {
//            var listingHistorical = await _coinMarketCapClient.CryptoCurrencyClient.GetListingsHistorical("", 1, 2,
//                new[] {"USD"}, SortField.MarketCap, SortDirection.Desc, "");
//            Assert.Equal("BTC",listingHistorical.Data.First().Symbol);
//        }
        [Fact]
        public async Task Listings_Latest_BtcToUsd()
        {
            var result = await _coinMarketCapClient.CryptoCurrencyClient.GetListingLatest(1, 2,
                new[] {"USD"}, SortField.MarketCap, "", CryptoCurrencyType.All);
            Assert.Equal("BTC",result.Data.First().Symbol);
            Assert.Equal("USD",result.Data.First().Quote.First().Key);
        }
        [Fact]
        public async Task Listings_Latest_Percent_Change_24H_Asc()
        {
            var result = await _coinMarketCapClient.CryptoCurrencyClient.GetListingLatest(1, 100,
                new[] { "USD" }, SortField.PercentChange24H, SortDirection.Asc, CryptoCurrencyType.All);
            Assert.Equal("USD", result.Data.First().Quote.First().Key);
        }
        [Fact]
        public async Task Listing_Latest_Default_Parameters_Must_Give_Same_Result()
        {
            var expected = await _coinMarketCapClient.CryptoCurrencyClient.GetListingLatest(1, 100,
                new[] {"USD"}, SortField.MarketCap, SortDirection.Desc, CryptoCurrencyType.All);
            var actual = await _coinMarketCapClient.CryptoCurrencyClient.GetListingLatest();
            expected.Data.Should().BeEquivalentTo(actual.Data);
        }

        [Fact]
        public async Task MarketPairsLastestForBtc()
        {
            var result =
                await _coinMarketCapClient.CryptoCurrencyClient.GetMarketPairLatest("", Currency.Btc, 1, 1, new []{ Currency.Usd,Currency.Eur });
            Assert.Equal("BTC/USD",result.Data.MarketPairs.First().MarketPair);
            Assert.Equal("BitMEX",result.Data.MarketPairs.First().Exchange.Name);
            Assert.Equal("USD", result.Data.MarketPairs.First().Quote.Last().Key);
        }

        [Fact]
        public async Task MarketPairs_Lastest_For_Default_Values()
        {
            var expected =
                await _coinMarketCapClient.CryptoCurrencyClient.GetMarketPairLatest("", Currency.Btc, 1, 100, new []{ Currency.Usd });
            var actual =
                await _coinMarketCapClient.CryptoCurrencyClient.GetMarketPairLatest("BTC");
            expected.Data.Should().BeEquivalentTo(actual.Data);

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
        public async Task Ohlcv_Historical_ForBtc_Default_Values()
        {
            var expected = await _coinMarketCapClient.CryptoCurrencyClient.GetOhlvcHistorical("", "BTC", Interval.Daily,
                "2018-08-07T00:00:00.000Z", "2018-08-10T00:00:00.000Z", 10, Interval.Daily, new string[] { Currency.Usd });
            var actual = await _coinMarketCapClient.CryptoCurrencyClient.GetOhlvcHistorical("BTC",
                "2018-08-07T00:00:00.000Z", "2018-08-10T00:00:00.000Z");
            expected.Data.Should().BeEquivalentTo(actual.Data);
        }

        [Fact]
        public async Task OhlcvLatestForBtc()
        {
            var result = await _coinMarketCapClient.CryptoCurrencyClient.GetOhlcvLatest(new []{""}, new []{ Currency.Btc }, new [] { Currency.Usd });
            Assert.Equal("BTC",result.Data.First().Value.Symbol);
            Assert.Equal("Bitcoin",result.Data.First().Value.Name);
        }
        [Fact]
        public async Task Ohlcv_Latest_ForBtc_Default_Values()
        {
            var expected = await _coinMarketCapClient.CryptoCurrencyClient.GetOhlcvLatest(new []{""}, new []{ Currency.Btc }, new [] { Currency.Usd });
            var actual = await _coinMarketCapClient.CryptoCurrencyClient.GetOhlcvLatest(new []{"BTC"});
            expected.Data.Should().BeEquivalentTo(actual.Data);
        }

        [Fact]
        public async Task QuotesHistoricalForBtc()
        {
            var result = await _coinMarketCapClient.CryptoCurrencyClient.GetQuotesHistorical("", "BTC",
                "2018-08-07T00:00:00.000Z", "2018-08-10T00:00:00.000Z", 10, Interval.Daily, new[] {Currency.Usd});
            Assert.Equal("Bitcoin",result.Data.Name);
        }
        [Fact]
        public async Task Quotes_Historical_ForBtc_Default_Values()
        {
            var expected = await _coinMarketCapClient.CryptoCurrencyClient.GetQuotesHistorical("", "BTC",
                "2018-08-07T00:00:00.000Z", "2018-08-10T00:00:00.000Z", 10, Interval.M5, new[] {Currency.Usd});
            var actual = await _coinMarketCapClient.CryptoCurrencyClient.GetQuotesHistorical("BTC",
                "2018-08-07T00:00:00.000Z", "2018-08-10T00:00:00.000Z");
            expected.Data.Should().BeEquivalentTo(actual.Data);
        }

        [Fact]
        public async Task QuotesLatestForBtc()
        {
            var result = await _coinMarketCapClient.CryptoCurrencyClient.GetQuotesLatest(new[] { "" }, new[] { Currency.Btc }, new [] { Currency.Usd });
            Assert.Equal("Bitcoin",result.Data.First().Value.Name);
            Assert.Equal("USD",result.Data.First().Value.Quote.First().Key);
        }
        [Fact]
        public async Task Quotes_Latest_For_Btc_Default()
        {
            var expected =
                await _coinMarketCapClient.CryptoCurrencyClient.GetQuotesLatest(new[] {""}, new[] {Currency.Btc},
                    new[] {Currency.Usd});
            var actual =
                await _coinMarketCapClient.CryptoCurrencyClient.GetQuotesLatest( new []{"BTC"});
            expected.Data.Should().BeEquivalentTo(actual.Data);
        }
    }
}
