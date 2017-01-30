using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angkor.O7Web.Common.Finantial.Entity
{
    public class InvoiceBasicInformation
    {
        public string DocumentType { get; set; }
        public string Serie { get; set; }
        public string Currency { get; set; }
        public string Amount { get; set; }
        public string Date { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string ClientDoc { get; set; }

        public string State { get; set; }

    }
}
