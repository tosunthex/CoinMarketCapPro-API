using System;

namespace CoinMarketCapPro_API.Parameters
{
    public class BaseApiUrls
    {
        public static readonly Uri SandboxEndPoint = new Uri("https://sandbox.coinmarketcap.com/", UriKind.Absolute);
        public static readonly Uri ProEndPoint = new Uri("https://pro.coinmarketcap.com/", UriKind.Absolute);
    }
}