using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Finantial.Entity;

namespace Angkor.O7Web.Data.Finantial.DataMapper
{
    public class InvoiceHeadViewMapper : O7DbMapper<InvoiceHeadView>
    {
        public static Type Class => typeof(InvoiceHeadViewMapper);

        public override InvoiceHeadView MapTarget()
            => new InvoiceHeadView
            {

            };
    }
}
