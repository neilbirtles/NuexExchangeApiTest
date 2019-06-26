using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApiTest
{
    class NuexTickerBookTicker
    {
        public string Symbol { get; set; }
        public string BidPrice { get; set; }
        public string BidQty { get; set; }
        public string AskPrice { get; set; }
        public string AskQty { get; set; }
    }
}
