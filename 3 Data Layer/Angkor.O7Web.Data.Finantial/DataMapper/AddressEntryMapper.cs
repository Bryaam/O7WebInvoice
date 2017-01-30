using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Finantial.Entity;

namespace Angkor.O7Web.Data.Finantial.DataMapper
{
    public class AddressEntryMapper : O7DbMapper<AddressEnt>
    {
        public static Type Class => typeof(AddressEntryMapper);

        public override AddressEnt MapTarget()
            => new AddressEnt
            {
                CodDir = Source.GetValue<string>(0),
                Address = Source.GetValue<string>(1),
                CodPostal = Source.GetValue<string>(2),
                Department = Source.GetValue<string>(3),
                Province = Source.GetValue<string>(4),
                District = Source.GetValue<string>(5),
                City = Source.GetValue<string>(6),
                Country = Source.GetValue<string>(7),
                Zone = Source.GetValue<string>(8),
                Route = Source.GetValue<string>(9),
                Phone = Source.GetValue<string>(10),
                Fax = Source.GetValue<string>(11),
                Contact = Source.GetValue<string>(12)
            };
    }
}
