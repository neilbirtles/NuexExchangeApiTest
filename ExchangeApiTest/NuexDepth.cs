using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApiTest
{
    class NuexDepth
    {
        public string LastUpdateId { get; set; }
        public List<List<object>> Bids { get; set; }
        public List<List<object>> Asks { get; set; }
    }
}
