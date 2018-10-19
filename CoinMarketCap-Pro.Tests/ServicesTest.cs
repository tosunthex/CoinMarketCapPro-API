using System;
using System.Net.Http;
using System.Security.Authentication;
using CoinMarketCapPro_API.Services;
using Xunit;

namespace CoinMarketCap_Pro.Tests
{
    public class ServicesTest
    {
        [Fact]
        public static void IsAllValuesNumericMethodCheck()
        {
            Assert.True(QueryStringService.IsAllValuesNumeric(new[] { "1", "2", "3" }));
            Assert.False(QueryStringService.IsAllValuesNumeric(new[] { "abc", "dfg", "fre" }));
            Assert.False(QueryStringService.IsAllValuesNumeric(new[] { "1", "dfg", "fre" }));
        }
        [Fact]
        public static void IsAllValuesStringMethodCheck()
        {
            Assert.False(QueryStringService.IsAllValuesString(new[] { "1", "2", "3" }));
            Assert.True(QueryStringService.IsAllValuesString(new[] { "abc", "dfg", "fre" }));
            Assert.False(QueryStringService.IsAllValuesString(new[] { "1", "dfg", "fre" }));
        }
        [Fact]
        public static void IsIdOrSymbolMethodCheck()
        {
            Assert.Equal("Id",QueryStringService.IsIdOrString(new[] { "1", "2", "3" }));
            Assert.Equal("Symbol",QueryStringService.IsIdOrString(new[] { "abc", "dfg", "fre" }));
        }
        [Fact]
        public static void Wrong_Parameters_Throws_HttpRequestException()
        {
            Exception ex = Assert.Throws<HttpRequestException>(() => QueryStringService.IsIdOrString(new[] { "asd", "1" }));
            Assert.Equal("All Parameters must be Symbol or Id", ex.Message);
        }

    }
}