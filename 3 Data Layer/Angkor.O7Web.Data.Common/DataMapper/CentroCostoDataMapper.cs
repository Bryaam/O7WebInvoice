// Create by Felix A. Bueno

using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Entity;

namespace Angkor.O7Web.Data.Common.DataMapper
{
    public class CentroCostoDataMapper : O7DbMapper<CentroCosto>
    {
        public static Type Class => typeof(CentroCostoDataMapper);
        public override CentroCosto MapTarget()
        => new CentroCosto { Id = Source.GetValue<string>(0), Description= Source.GetValue<string>(1) };
    }
}