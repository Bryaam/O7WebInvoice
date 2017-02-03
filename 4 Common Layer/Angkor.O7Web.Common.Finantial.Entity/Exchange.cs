using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angkor.O7Web.Common.Finantial.Entity
{
    public class Exchange
    {
        public string date { get; set; }
        public string currencyBegin { get; set; }
        public string currencyEnd { get; set; }
        public string BuyValue { get; set; }

        public string SellValue { get; set; }
    }
}
