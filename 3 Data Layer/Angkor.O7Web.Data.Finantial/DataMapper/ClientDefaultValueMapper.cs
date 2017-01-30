using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Finantial.Entity;

namespace Angkor.O7Web.Data.Finantial.DataMapper
{
    public class ClientDefaultValueMapper : O7DbMapper<ClientDefaultValues>
    {
        public static Type Class => typeof(ClientDefaultValueMapper);

        public override ClientDefaultValues MapTarget()
            => new ClientDefaultValues
            {
                TaxId = Source.GetValue<string>(0),
                CurrencyId = Source.GetValue<string>(1),
                TypeSell = Source.GetValue<string>(2),
                CondSell = Source.GetValue<string>(3),
                Payment = Source.GetValue<string>(4),
                Seller = Source.GetValue<string>(5),
                FinantialCode = Source.GetValue<string>(6),
                BussinessLine = Source.GetValue<string>(7),
                Language = Source.GetValue<string>(8),
                FlgPer = Source.GetValue<string>(9),
            };
    }
}
