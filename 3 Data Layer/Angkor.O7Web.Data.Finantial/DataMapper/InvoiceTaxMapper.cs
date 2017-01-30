using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Finantial.Entity;

namespace Angkor.O7Web.Data.Finantial.DataMapper
{
    public class InvoiceTaxMapper : O7DbMapper<InvoiceTax>
    {
        public static Type Class => typeof(InvoiceTaxMapper);

        public override InvoiceTax MapTarget()
            => new InvoiceTax
            {
                Value = Source.GetValue<string>(0),
                Content = Source.GetValue<string>(1),
                Porcentaje = Source.GetValue<string>(2)
            };
    }
}
