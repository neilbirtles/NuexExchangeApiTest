using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApiTest
{
    class NuexExchangeInfoSymbols
    {
        public string Symbol { get; set; }
        public string Status { get; set; }
        public string BaseAsset { get; set; }
        public string BaseAssetPrecision { get; set; }
        public string QuoteAsset { get; set; }
        public string QuotePrecision { get; set; }
        public List<string> OrderTypes { get; set; }
        public string IcebergAllowed { get; set; }
        public Dictionary<NuexExchangeInfoFiltersPriceFilter, NuexExchangeInfoFiltersLotSizeFilter> Filters { get; set; }
    }
}
