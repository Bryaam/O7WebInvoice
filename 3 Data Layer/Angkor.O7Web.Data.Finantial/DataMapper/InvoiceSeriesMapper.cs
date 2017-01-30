using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Finantial.Entity;

namespace Angkor.O7Web.Data.Finantial.DataMapper
{
    public class InvoiceSeriesMapper : O7DbMapper<InvoiceSeries>
    {
        public static Type Class => typeof(InvoiceSeriesMapper);

        public override InvoiceSeries MapTarget()
            => new InvoiceSeries
            {
                Value = Source.GetValue<string>(0),
                Default = Source.GetValue<string>(1)
            };
    }
}
