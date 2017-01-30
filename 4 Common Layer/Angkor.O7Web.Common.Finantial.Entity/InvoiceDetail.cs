using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angkor.O7Web.Common.Finantial.Entity
{
    public class InvoiceDetail
    {
        public string documentType { get; set; }
        public string documentId { get; set; }
        public string detailId { get; set; }
        public string conceptId { get; set; }

        public string taxId { get; set; }

        public string taxPorc { get; set; }

        public string ccoId { get; set; }

        public string amount { get; set; }

        public string price { get; set; }

        public string commentary { get; set; }

        public string conceptContent { get; set; }

        public string ccoContent { get; set; }

    }
}
