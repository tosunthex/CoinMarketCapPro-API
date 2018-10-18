using CoinMarketCapPro_API.Services;
using Xunit;

namespace CoinMarketCap_Pro.Tests
{
    public class ServicesTest
    {
        [Fact]
        public void IsAllValuesNumericMethodCheck()
        {
            Assert.True(QueryStringService.IsAllValuesNumeric(new[] { "1", "2", "3" }));
            Assert.False(QueryStringService.IsAllValuesNumeric(new[] { "abc", "dfg", "fre" }));
            Assert.False(QueryStringService.IsAllValuesNumeric(new[] { "1", "dfg", "fre" }));
        }
        [Fact]
        public void IsAllValuesStringMethodCheck()
        {
            Assert.False(QueryStringService.IsAllValuesString(new[] { "1", "2", "3" }));
            Assert.True(QueryStringService.IsAllValuesString(new[] { "abc", "dfg", "fre" }));
            Assert.False(QueryStringService.IsAllValuesString(new[] { "1", "dfg", "fre" }));
        }
        [Fact]
        public void IsIdOrSymbolMethodCheck()
        {
            Assert.Equal("Id",QueryStringService.IsIdOrString(new[] { "1", "2", "3" }));
            Assert.Equal("Symbol",QueryStringService.IsIdOrString(new[] { "abc", "dfg", "fre" }));
        }

    }
}