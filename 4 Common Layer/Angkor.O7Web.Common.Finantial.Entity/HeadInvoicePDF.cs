using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angkor.O7Web.Common.Finantial.Entity
{
    public class HeadInvoicePDF
    {
        public string company { get; set; }
        public string companyRuc { get; set; }
        public string document { get; set; }
        public string serie { get; set; }
        public string nroext { get; set; }
        public string url { get; set; }
        public string clientName { get; set; }
        public string clientId { get; set; }
        public string clientEmail { get; set; }
        public string clientAddress { get; set; }
        public string clientPhone { get; set; }
        public string documentDate { get; set; }

        public string subtotal { get; set; }

        public string taxes { get; set; }
        public string perception { get; set; }

        public string total { get; set; }

        public string totalDescription { get; set; }

        public string Observacion { get; set; }

        public string headerLeftLine1 { get; set; }
        public string headerLeftLine2 { get; set; }
        public string headerLeftLine3 { get; set; }
        public string headerLeftLine4 { get; set; }
        public string headerLeftLine5 { get; set; }

    }
}
