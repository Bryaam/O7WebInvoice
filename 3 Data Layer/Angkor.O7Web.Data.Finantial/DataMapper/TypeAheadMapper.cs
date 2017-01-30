using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Finantial.Entity;

namespace Angkor.O7Web.Data.Finantial.DataMapper
{
    public class TypeAheadMapper : O7DbMapper<InvoiceTypeAhead>
    {
        public static Type Class => typeof(TypeAheadMapper);

        public override InvoiceTypeAhead MapTarget()
            => new InvoiceTypeAhead
            {
                Value = Source.GetValue<string>(0),
                name = Source.GetValue<string>(1),
            };
    }
}
