using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Finantial.Entity;

namespace Angkor.O7Web.Data.Finantial.DataMapper
{
    public class InvoiceHeadViewMapper : O7DbMapper<InvoiceHeadView>
    {
        public static Type Class => typeof(InvoiceHeadViewMapper);

        public override InvoiceHeadView MapTarget()
            => new InvoiceHeadView
            {
                documentType = Source.GetValue<string>(1),
                documentId = Source.GetValue<string>(2),
                documentSerie = Source.GetValue<string>(3),
                documentExt = Source.GetValue<string>(4),
                clientCode = Source.GetValue<string>(5),

                clientId = Source.GetValue<string>(6),
                clientPhone = Source.GetValue<string>(7),
                clientName = Source.GetValue<string>(8),
                clientAddress = Source.GetValue<string>(9),
                condSell = Source.GetValue<string>(10),
                bussinessLine = Source.GetValue<string>(11),
                payment = Source.GetValue<string>(12),
                finantialCode = Source.GetValue<string>(13),
                sellType = Source.GetValue<string>(14),
                seller = Source.GetValue<string>(15),

                documentDate = Source.GetValue<string>(16),
                documentVenc = Source.GetValue<string>(17),
                language = Source.GetValue<string>(18),
                perception = Source.GetValue<string>(19),
                nroOc = Source.GetValue<string>(20),


                nroGuiRem = Source.GetValue<string>(21),
                glosa = Source.GetValue<string>(22),
                donate = Source.GetValue<string>(23),
                documentTypeRef = Source.GetValue<string>(24),
                documentIdRef = Source.GetValue<string>(25),
                documentSerieRef = Source.GetValue<string>(26),
                documentExtRef = Source.GetValue<string>(27),
                impBase = Source.GetValue<string>(28),
                impVta = Source.GetValue<string>(29),
                impIGV = Source.GetValue<string>(30),
                impPer = Source.GetValue<string>(31),
                impTot = Source.GetValue<string>(32),

            };
    }
}
