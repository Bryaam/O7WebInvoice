// Create by Felix A. Bueno

using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Advisory.Entity;

namespace Angkor.O7Web.Data.Advisory.DataMapper
{
    public class PeriodStateDataMapper : O7DbMapper<Year>
    {
        public static Type Class => typeof(PeriodStateDataMapper);
        public override Year MapTarget()
            => new Year {Id = Source.GetValue<int>(0), Description = Source.GetValue<string>(1)};
    }
}