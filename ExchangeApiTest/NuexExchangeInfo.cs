using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApiTest
{
    class NuexExchangeInfo
    {
        public string TimeZone { get; set; }
        public string ServerTime { get; set; }
        public List<NuexExchangeInfoRateLimits> RateLimits { get; set; }
        public List<string> ExchangeFilters { get; set; }
        public List<NuexExchangeInfoSymbols> Symbols { get; set; }
    }
}
