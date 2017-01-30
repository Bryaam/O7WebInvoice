// Create by Felix A. Bueno

using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Advisory.Entity;

namespace Angkor.O7Web.Data.Advisory.DataMapper
{
    public class ActivityReportDataMapper : O7DbMapper<ActivityReport>
    {
        public static Type Class => typeof(ActivityReportDataMapper);
        
        public override ActivityReport MapTarget()
            => new ActivityReport
            {
                WorkerId = Source.GetValue<string>(0),
                Worker = Source.GetValue<string>(1),
                CenterCostId = Source.GetValue<string>(2),
                CenterCost = Source.GetValue<string>(3),
                Date = Source.GetValue<string>(4),
                Title = Source.GetValue<string>(5),
                Period = Source.GetValue<string>(6)
            };
    }
}