using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Finantial.Entity;

namespace Angkor.O7Web.Data.Finantial.DataMapper
{
    public class DetailInvoicePDFMapper : O7DbMapper<DetailInvoicePDF>
    {
        public static Type Class => typeof(DetailInvoicePDFMapper);

        public override DetailInvoicePDF MapTarget()
            => new DetailInvoicePDF
            {
                descripcion = Source.GetValue<string>(0),
                cantidad = Source.GetValue<string>(1),
                valor_unitario = Source.GetValue<string>(2),
                impuesto = Source.GetValue<string>(3),
                importe = Source.GetValue<string>(4)
            };
    }
}
