using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Finantial.Entity;

namespace Angkor.O7Web.Data.Finantial.DataMapper
{
    public class InvoiceDetailsMapper: O7DbMapper<InvoiceDetails>
    {
        public static Type Class => typeof(InvoiceDetailsMapper);

        public override InvoiceDetails MapTarget()
            => new InvoiceDetails
            {
                DocumentType = Source.GetValue<string>(0),
                Serie = Source.GetValue<string>(1),
                Currency = Source.GetValue<string>(2),
                Amount = Source.GetValue<string>(3),
                Date = Source.GetValue<string>(4),
                ClientCode = Source.GetValue<string>(5),
                ClientName = Source.GetValue<string>(6),
                ClientDoc = Source.GetValue<string>(7),
            };
    }
}
