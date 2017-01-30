// O7ERP Web created by felix_dev
using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Finantial.Entity;

namespace Angkor.O7Web.Data.Finantial.DataMapper
{
    public class ClientCountryMapper : O7DbMapper<ClientCountry>
    {
        public static Type Class => typeof(ClientCountryMapper);

        public override ClientCountry MapTarget()
            => new ClientCountry
            {
                Id = Source.GetValue<string>(0),
                Description = Source.GetValue<string>(1)
            };
    }
}