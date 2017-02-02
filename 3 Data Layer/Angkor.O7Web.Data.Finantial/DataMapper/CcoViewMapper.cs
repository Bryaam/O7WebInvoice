// O7ERP Web created by felix_dev
using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Finantial.Entity;

namespace Angkor.O7Web.Data.Finantial.DataMapper
{
    public class CcoViewMapper : O7DbMapper<CcoView>
    {
        public static Type Class => typeof(CcoViewMapper);

        public override CcoView MapTarget()
            => new CcoView
            {
                codigo = Source.GetValue<string>(0),
                dimension = Source.GetValue<string>(1),
                descripcion = Source.GetValue<string>(2),
                fecini = Source.GetValue<string>(3),
                fecfin = Source.GetValue<string>(4),
            };
    }
}