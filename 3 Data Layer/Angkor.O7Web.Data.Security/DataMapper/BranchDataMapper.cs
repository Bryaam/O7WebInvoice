// Create by Felix A. Bueno

using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Security.Entity;

namespace Angkor.O7Web.Data.Security.DataMapper
{
    public class BranchDataMapper : O7DbMapper<Branch>
    {
        public static Type Class => typeof(BranchDataMapper);

        public override Branch MapTarget()
            => new Branch { Id = Source.GetValue<string>(0), Description = Source.GetValue<string>(1) };
    }
}