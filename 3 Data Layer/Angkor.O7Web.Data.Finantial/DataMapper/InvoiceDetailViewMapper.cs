using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Finantial.Entity;

namespace Angkor.O7Web.Data.Finantial.DataMapper
{
    public class InvoiceDetailViewMapper : O7DbMapper<InvoiceDetailView>
    {
        public static Type Class => typeof(InvoiceDetailViewMapper);

        public override InvoiceDetailView MapTarget()
            => new InvoiceDetailView
            {
                concept = Source.GetValue<string>(0),
                observation = Source.GetValue<string>(1),
                cco = Source.GetValue<string>(2),
                price = Source.GetValue<string>(3),
                cant = Source.GetValue<string>(4),
                taxDetail = Source.GetValue<string>(5),
                subtotal = Source.GetValue<string>(6)
            };
    }
}
