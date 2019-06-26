using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApiTest
{
    class NuexExchangeInfoFiltersPriceFilter
    {
        public string FilterType { get; set; }
        public string MinPrice { get; set; }
        public string MaxPrice { get; set; }
        public string TickSize { get; set; }
    }
}
