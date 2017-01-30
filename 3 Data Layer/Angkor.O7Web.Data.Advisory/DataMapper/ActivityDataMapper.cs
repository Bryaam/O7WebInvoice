// Create by Felix A. Bueno

using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Advisory.Entity;

namespace Angkor.O7Web.Data.Advisory.DataMapper
{
    public class ActivityDataMapper : O7DbMapper<Activity>
    {
        public static Type Class => typeof(ActivityDataMapper);

        public override Activity MapTarget()
            => new Activity {Title = Source.GetValue<string>(0), Date = Source.GetValue<string>(1)};
    }
}