using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Finantial.Entity;

namespace Angkor.O7Web.Data.Finantial.DataMapper
{
    public class InvoiceDetailMapper : O7DbMapper<InvoiceDetail>
    {
        public static Type Class => typeof(InvoiceDetailMapper);

        public override InvoiceDetail MapTarget()
            => new InvoiceDetail
            {
                documentType = Source.GetValue<string>(0),
                documentId = Source.GetValue<string>(1),
                detailId = Source.GetValue<string>(2),
                conceptId = Source.GetValue<string>(3),

                taxId = Source.GetValue<string>(4),
                taxPorc = Source.GetValue<string>(5),

                ccoId = Source.GetValue<string>(6),

                amount = Source.GetValue<string>(7),

                price = Source.GetValue<string>(8),

                commentary = Source.GetValue<string>(9),
                conceptContent = Source.GetValue<string>(10),
                ccoContent = Source.GetValue<string>(11)
            };
    }
}
