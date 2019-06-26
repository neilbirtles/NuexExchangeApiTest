using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApiTest
{
    class NuexExchangeInfoFiltersLotSizeFilter
    {
        public string FilterType { get; set; }
        public string MinQty { get; set; }
        public string MaxQty { get; set; }
        public string StepSize { get; set; }
    }
}
