using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApiTest
{
    class NuexExchangeInterface
    {
        private string apiSecret;
        private string apiKey;

        private static readonly HashSet<string> publicInterface = new HashSet<string> { "v1/exchangeInfo", "v3/ticker/price", "v3/ticker/bookTicker", "v1/depth", "v1/time" };
        private static readonly HashSet<string> marketInterface = new HashSet<string> { };
        private static readonly HashSet<string> accountInterface = new HashSet<string> { "v3/account" };

        private NuexExchangeInfo nuexExchangeInfo;

        public NuexExchangeInterface(string apiSecret, string apiKey)
        {
            this.apiSecret = apiSecret;
            this.apiKey = apiKey;
        }

        private T NuexApiQuery<T>(string apiMethod, string options) where T : new()
        {

            string nonce, apiUrl, request, signature;
            Dictionary<string, string> headers = new Dictionary<string, string>();
            const string nuexBaseUrl = "https://api.nuex.com/api/";

            if (publicInterface.Contains(apiMethod))
            {
                request = "";
                if (options != "")
                {
                    apiUrl = nuexBaseUrl;
                    request = apiMethod + "?" + options;
                }
                else
                {
                    apiUrl = nuexBaseUrl + apiMethod;
                }

                return HelperMethods.DownloadSerializedJSONData<T>(apiUrl, request, headers, RestMethods.GET);

            }
            else if (accountInterface.Contains(apiMethod))
            {
                NuexTime nuexTime = NuexApiQuery<NuexTime>("v1/time", "");
                nonce = nuexTime.serverTime.ToString();
                //this should also work?
                //nonce = HelperMethods.UnixTimeNowInTicks().ToString();

         
                apiUrl = nuexBaseUrl + apiMethod;
                request = "timestamp=" + nonce;
                
                signature = HelperMethods.GenerateHMAC256Hash(apiSecret, request);
                headers.Add("x-mbx-apikey", apiKey);

                
                apiUrl = apiUrl + "?" + request + "&signature=" + signature;
                request = "";

                return HelperMethods.DownloadSerializedJSONData<T>(apiUrl, request, headers, RestMethods.GET);
            }
            else
            {
                return new T();
            }
        }

        private void GetNuexExchangeInfo()
        {
            nuexExchangeInfo = NuexApiQuery<NuexExchangeInfo>("v1/exchangeInfo", "");
        }



        public void GetTicker(string baseCurrency, string coin)
        {
            NuexTickerPrice nuexTickerPrice;
            NuexTickerBookTicker nuexTickerBookTicker;
            NuexDepth nuexDepth;

            nuexTickerPrice = NuexApiQuery<NuexTickerPrice>("v3/ticker/price", "symbol=" + coin.ToUpper() + baseCurrency.ToUpper());
            nuexTickerBookTicker = NuexApiQuery<NuexTickerBookTicker>("v3/ticker/bookTicker", "symbol=" + coin.ToUpper() + baseCurrency.ToUpper());
            nuexDepth = NuexApiQuery<NuexDepth>("v1/depth", "symbol=" + coin.ToUpper() + baseCurrency.ToUpper() + "&limit=1");

        }

        public List<NuexAccountBalance> GetAccountInfo()
        {
            NuexAccount nuexAccount = NuexApiQuery<NuexAccount>("v3/account", "");
            return nuexAccount.Balance;
        }
    }
}

