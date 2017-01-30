using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Finantial.Entity;

namespace Angkor.O7Web.Data.Finantial.DataMapper
{
    public class ClientViewMapper : O7DbMapper<ClientView>
    {
        public static Type Class => typeof(ClientViewMapper);

        public override ClientView MapTarget()
            => new ClientView
            {
                TypeClient = Source.GetValue<string>(0),
                BussinessName = Source.GetValue<string>(1),
                Person = Source.GetValue<string>(2),
                StateClient = Source.GetValue<string>(3),
                Ruc = Source.GetValue<string>(4),
                Country = Source.GetValue<string>(5),
                Zone = Source.GetValue<string>(6).Trim(),
                Address = Source.GetValue<string>(7),
                CodPost = Source.GetValue<string>(8),
                City = Source.GetValue<string>(9),
                Phone = Source.GetValue<string>(10),
                Dni = Source.GetValue<string>(11),
                InitialDate = Source.GetValue<string>(12),
                Email = Source.GetValue<string>(13),
                UbigeoDep = Source.GetValue<string>(14),
                UbigeProv = Source.GetValue<string>(15),
                UbigeoDistrict = Source.GetValue<string>(16),
                PrincipalAddressEntry = Source.GetValue<string>(17),
                PrincipalAddressFact = Source.GetValue<string>(18),
                DocumentType = Source.GetValue<string>(19)
            };

    }
}
