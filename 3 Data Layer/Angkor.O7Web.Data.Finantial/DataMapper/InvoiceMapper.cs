using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Finantial.Entity;

namespace Angkor.O7Web.Data.Finantial.DataMapper
{
    public class InvoiceMapper : O7DbMapper<InvoiceEdit>
    {
        public static Type Class => typeof(InvoiceMapper);

        public override InvoiceEdit MapTarget()
            => new InvoiceEdit
            {
                documentType = Source.GetValue<string>(0),
                documentId = Source.GetValue<string>(1),
                serie = Source.GetValue<string>(2),
                documentExt = Source.GetValue<string>(3),
                currency = Source.GetValue<string>(4),
                documentDate = Source.GetValue<string>(5),
                expirationDate = Source.GetValue<string>(6),
                clientCode = Source.GetValue<string>(7),
                TaxId = Source.GetValue<string>(8),
                clientName = Source.GetValue<string>(9),
                clientAddressId = Source.GetValue<string>(10),
                clientAddressDescription = Source.GetValue<string>(11),
                clientId = Source.GetValue<string>(12),

                glosa = Source.GetValue<string>(13),

                typeSell = Source.GetValue<string>(14),

                language = Source.GetValue<string>(15),
                condSell = Source.GetValue<string>(16),
                payment = Source.GetValue<string>(17),
                bussinessLine = Source.GetValue<string>(18),
                finantialCode = Source.GetValue<string>(19),

                clientPhone = Source.GetValue<string>(20),

                Seller = Source.GetValue<string>(21),

                perception = Source.GetValue<string>(22),

                donate = Source.GetValue<string>(23),

                documentTypeRef = Source.GetValue<string>(24),

                documentTypeId = Source.GetValue<string>(25),

                documentSerieRef = Source.GetValue<string>(26),

                documentNroDoceRef = Source.GetValue<string>(27),

                TaxPorc = Source.GetValue<string>(28)
            };
    }
}
