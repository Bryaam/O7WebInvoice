// Create by Felix A. Bueno
using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Framework.Web.Model;

namespace Angkor.O7Web.Data.Security.DataMapper
{
    public class ModuleDataMapper : O7DbMapper<O7Module>
    {
        public static Type Class => typeof(ModuleDataMapper);

        public override O7Module MapTarget()
            => new O7Module
            {
                    Title = Source.GetValue<string>(0),
                    Version = Source.GetValue<string>(1),
                    Url = Source.GetValue<string>(2),
                    Icon = Source.GetValue<string>(3)
                };
    }
}