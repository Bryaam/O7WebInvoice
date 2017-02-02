// O7ERP Web created by felix_dev
using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Finantial.Entity;

namespace Angkor.O7Web.Data.Finantial.DataMapper
{
    public class TTHeadMapper : O7DbMapper<TTHeads>
    {
        public static Type Class => typeof(TTHeadMapper);
        public override TTHeads MapTarget()
            => new TTHeads
            {
                TK = Source.GetValue<string>(0),
                TF = Source.GetValue<string>(1),
                CK = Source.GetValue<string>(2),
                CF = Source.GetValue<string>(3)
            };
    }
}