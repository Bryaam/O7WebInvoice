using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Finantial.Entity;

namespace Angkor.O7Web.Data.Finantial.DataMapper
{
    public class LogFEMapper:O7DbMapper<LogFE>
    {
        public static Type Class => typeof(LogFEMapper);

        public override LogFE MapTarget()
            => new LogFE
            {
                estado= Source.GetValue<string>(0),
                descripcion = Source.GetValue<string>(1),
                fecha = Source.GetValue<string>(2)
            };
    }
}
