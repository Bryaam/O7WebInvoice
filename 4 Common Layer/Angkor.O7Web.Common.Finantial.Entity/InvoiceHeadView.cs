
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Angkor.O7Web.Common.Finantial.Entity
{
    public class InvoiceHeadView
    {
        public string documentType { get; set; }
        public string documentId { get; set; }
        public string documentSerie { get; set; }
        public string documentExt { get; set; }
        public string clientCode { get; set; }

        public string clientId { get; set; }
        public string clientPhone { get; set; }
        public string clientName { get; set; }
        public string clientAddress { get; set; }
        public string condSell { get; set; }
        public string bussinessLine { get; set; }
        public string payment { get; set; }
        public string finantialCode { get; set; }
        public string sellType { get; set; }
        public string seller { get; set; }

        public string documentDate { get; set; }
        public string documentVenc { get; set; }

        public string currency { get; set; }

        public string tax { get; set; }
        public string language { get; set; }
        public string perception { get; set; }
        public string nroOc { get; set; }


        public string nroGuiRem { get; set; }
        public string glosa { get; set; }
        public string donate { get; set; }
        public string documentTypeRef { get; set; }
        public string documentIdRef { get; set; }

        public string documentSerieRef { get; set; }
        public string documentExtRef { get; set; }
        public string impBase { get; set; }


        public string impVta { get; set; }
        public string impIGV { get; set; }
        public string impPer { get; set; }
        public string impTot { get; set; }

        public string estado { get; set; }

        public string estadoDesc { get; set; }


    }
}
