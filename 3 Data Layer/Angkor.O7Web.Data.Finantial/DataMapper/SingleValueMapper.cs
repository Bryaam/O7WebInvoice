using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Finantial.Entity;

namespace Angkor.O7Web.Data.Finantial.DataMapper
{
    public class SingleValueMapper : O7DbMapper<SingleValue>
    {
        public static Type Class => typeof(SingleValueMapper);

        public override SingleValue MapTarget()
            => new SingleValue
            {
                Content = Source.GetValue<string>(0)
            };
    }
}
