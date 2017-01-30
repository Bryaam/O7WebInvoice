using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Finantial.Entity;

namespace Angkor.O7Web.Data.Finantial.DataMapper
{
    public class InvoiceGenericListMapper : O7DbMapper<GenericListValue>
    {
        public static Type Class => typeof(InvoiceGenericListMapper);

        public override GenericListValue MapTarget()
            => new GenericListValue
            {
                Value = Source.GetValue<string>(0),
                Content = Source.GetValue<string>(1)
            };
    }
}
