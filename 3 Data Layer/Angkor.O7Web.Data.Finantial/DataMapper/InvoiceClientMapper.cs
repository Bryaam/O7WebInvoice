using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Finantial.Entity;

namespace Angkor.O7Web.Data.Finantial.DataMapper
{
    public class InvoiceClientMapper:O7DbMapper<InvoiceClient>
    {
        public static Type Class => typeof(InvoiceClientMapper);

        public override InvoiceClient MapTarget()
            => new InvoiceClient
            {
                ClientCode= Source.GetValue<string>(0),
                ClientType = Source.GetValue<string>(1),
                ClientOrigin = Source.GetValue<string>(2),
                DocumentNumber = Source.GetValue<string>(3),
                ClientName = Source.GetValue<string>(4),
                ClientPhone = Source.GetValue<string>(5),
                ClientEmail = Source.GetValue<string>(6)
            };
    }
}
