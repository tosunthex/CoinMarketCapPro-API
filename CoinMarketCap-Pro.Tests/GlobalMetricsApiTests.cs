using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CoinMarketCapPro_API.Clients;
using CoinMarketCapPro_API.Parameters;
using FluentAssertions;
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
            var startDate = (DateTime.Now + new TimeSpan(-30, 0, 0, 0)).ToString("yyyy-MM-dd'T'HH:mm:ss.fffffff'Z'");
            var finishDate = (DateTime.Now + new TimeSpan(-15, 0, 0, 0)).ToString("yyyy-MM-dd'T'HH:mm:ss.fffffff'Z'");
            var result =
                await _coinMarketCapClient.GlobalMetricClient.GetGlobalMetricsHistorical(startDate,
                    finishDate, 10, Interval.Daily,
                    new[] {Currency.Usd});
            Assert.Equal("USD",result.Data.Quotes.First().Quote.Keys.First());
        }
        [Fact]
        public async Task GlobalMetricsHistorical_Default_Values()
        {
            var startDate = (DateTime.Now + new TimeSpan(-16, 0, 0, 0)).ToString("yyyy-MM-dd'T'HH:mm:ss.fffffff'Z'");
            var finishDate = (DateTime.Now + new TimeSpan(-15, 0, 0, 0)).ToString("yyyy-MM-dd'T'HH:mm:ss.fffffff'Z'");
            var expected =
                await _coinMarketCapClient.GlobalMetricClient.GetGlobalMetricsHistorical(startDate,
                    finishDate, 10, Interval.Daily,
                    new[] {Currency.Usd});
           Assert.True(expected.Data.Quotes[0].Quote.ContainsKey("USD"));
        }
        [Fact]
        public async Task GlobalMetricsLatest()
        {
            var result =
                await _coinMarketCapClient.GlobalMetricClient.GetGlobalMetricsLatest(new[] { Currency.Usd });
            Assert.Equal("USD", result.Data.Quote.First().Key);
        }
        [Fact]
        public async Task GlobalMetricsLatest_Default_Values()
        {
            var expected =
                await _coinMarketCapClient.GlobalMetricClient.GetGlobalMetricsLatest(new[] { Currency.Usd });
            var actual =
                await _coinMarketCapClient.GlobalMetricClient.GetGlobalMetricsLatest();
            expected.Data.Should().BeEquivalentTo(actual.Data);
        }
    }
}