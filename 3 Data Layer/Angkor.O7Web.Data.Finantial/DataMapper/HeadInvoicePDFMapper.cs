using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Angkor.O7Web.Common.Finantial.Entity;

using Angkor.O7Framework.Data.Tool;

namespace Angkor.O7Web.Data.Finantial.DataMapper
{
    public class HeadInvoicePDFMapper : O7DbMapper<HeadInvoicePDF>
    {
        public static Type Class => typeof(HeadInvoicePDFMapper);

        public override HeadInvoicePDF MapTarget()
            => new HeadInvoicePDF
            {

                company = Source.GetValue<string>(0),
                companyRuc = Source.GetValue<string>(1),
                document = Source.GetValue<string>(2),
                serie = Source.GetValue<string>(3),
                nroext = Source.GetValue<string>(4),
                url = Source.GetValue<string>(5),
                clientName = Source.GetValue<string>(6),
                clientId = Source.GetValue<string>(7),
                clientEmail = Source.GetValue<string>(8),
                clientAddress = Source.GetValue<string>(9),
                clientPhone = Source.GetValue<string>(10),
                documentDate = Source.GetValue<string>(11),
                subtotal = Source.GetValue<string>(12),
                taxes = Source.GetValue<string>(13),
                perception = Source.GetValue<string>(14),
                total = Source.GetValue<string>(15),
                totalDescription = Source.GetValue<string>(16),
                Observacion = Source.GetValue<string>(17),
                headerLeftLine1 = Source.GetValue<string>(18),
                headerLeftLine2 = Source.GetValue<string>(19),
                headerLeftLine3 = Source.GetValue<string>(20),
                headerLeftLine4 = Source.GetValue<string>(21),
                headerLeftLine5 = Source.GetValue<string>(22),
            };
    }
}

