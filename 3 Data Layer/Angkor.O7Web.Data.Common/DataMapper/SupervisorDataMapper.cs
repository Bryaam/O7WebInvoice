// Create by Felix A. Bueno

using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Entity;

namespace Angkor.O7Web.Data.Common.DataMapper
{
    public class SupervisorDataMapper : O7DbMapper<Supervisor>
    {
        public static Type Class => typeof(SupervisorDataMapper);
        public override Supervisor MapTarget()
        => new Supervisor { Name = Source.GetValue<string>(2), Phone = Source.GetValue<string>(3), Email = Source.GetValue<string>(4) };
    }
}