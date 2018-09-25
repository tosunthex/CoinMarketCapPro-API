﻿using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CoinMarketCapPro_API.Clients;
using CoinMarketCapPro_API.Parameters;
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
    }
}