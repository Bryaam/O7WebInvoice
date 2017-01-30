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
                currency = Source.GetValue<string>(18),
                tax = Source.GetValue<string>(19),
                language = Source.GetValue<string>(20),
                perception = Source.GetValue<string>(21),
                nroOc = Source.GetValue<string>(22),
                nroGuiRem = Source.GetValue<string>(23),
                glosa = Source.GetValue<string>(24),
                donate = Source.GetValue<string>(25),
                documentTypeRef = Source.GetValue<string>(26),
                documentIdRef = Source.GetValue<string>(27),
                documentSerieRef = Source.GetValue<string>(28),
                documentExtRef = Source.GetValue<string>(29),
                impBase = Source.GetValue<string>(30),
                impVta = Source.GetValue<string>(31),
                impIGV = Source.GetValue<string>(32),
                impPer = Source.GetValue<string>(33),
                impTot = Source.GetValue<string>(34),

            };
    }
}
