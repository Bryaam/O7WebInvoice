using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Finantial.Entity;

namespace Angkor.O7Web.Data.Finantial.DataMapper
{
    public class ClientRoutMapper : O7DbMapper<ClientRoute>
    {
        public static Type Class => typeof(ClientRoutMapper);

        public override ClientRoute MapTarget()
            => new ClientRoute
            {
                Id = Source.GetValue<string>(0),
                Description = Source.GetValue<string>(1)
            };
    }
}
