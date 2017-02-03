// O7ERP Web created by felix_dev
using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Finantial.Entity;

namespace Angkor.O7Web.Data.Finantial.DataMapper
{
    public class ExchangeMapper : O7DbMapper<Exchange>
    {
        public static Type Class => typeof(ExchangeMapper);

        public override Exchange MapTarget()
            => new Exchange
            {
                date = Source.GetValue<string>(0),
                currencyBegin = Source.GetValue<string>(1),
                currencyEnd = Source.GetValue<string>(2),
                BuyValue = Source.GetValue<string>(3),
                SellValue = Source.GetValue<string>(4),
            };
    }
}