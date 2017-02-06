// O7ERP Web created by felix_dev
using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Finantial.Entity;

namespace Angkor.O7Web.Data.Finantial.DataMapper
{
    public class CcoMapper : O7DbMapper<Cco>
    {
        public static Type Class => typeof(CcoMapper);

        public override Cco MapTarget()
            => new Cco
            {
                code = Source.GetValue<string>(0),
                codeDim = Source.GetValue<string>(1),
                description = Source.GetValue<string>(2),
                dateB = Source.GetValue<string>(3),
                dateE = Source.GetValue<string>(4),
                flgDet = Source.GetValue<string>(5),
                flgPresup = Source.GetValue<string>(6),
                flgIng = Source.GetValue<string>(7),
                accountC = Source.GetValue<string>(8),
                accountT = Source.GetValue<string>(9),
                codeCat = Source.GetValue<string>(10),
            };
    }
}