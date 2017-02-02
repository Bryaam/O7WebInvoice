// O7ERP Web created by felix_dev
using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Finantial.Entity;

namespace Angkor.O7Web.Data.Finantial.DataMapper
{
    public class TTDataMapper : O7DbMapper<TTData>
    {
        public static Type Class => typeof(TTDataMapper);
        public override TTData MapTarget()
            => new TTData
            {
                key = Source.GetValue<string>(0),
                content = Source.GetValue<string>(1)
            };
    }
}