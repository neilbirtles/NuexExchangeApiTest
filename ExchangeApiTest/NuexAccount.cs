using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApiTest
{
    class NuexAccount
    {
        public string makerCommission { get; set; }
        public string takerCommission { get; set; }
        public bool canTrade { get; set; }
        public bool canWithdraw { get; set; }
        public bool canDeposit { get; set; }
        public int updateTime { get; set; }
        public List<NuexAccountBalance> Balance { get; set; }
    }
}
