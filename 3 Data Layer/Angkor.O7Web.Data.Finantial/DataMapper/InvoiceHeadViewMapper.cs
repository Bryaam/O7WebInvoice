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
                documentType = Source.GetValue<string>(0),
                documentId = Source.GetValue<string>(1),
                documentSerie = Source.GetValue<string>(2),
                documentExt = Source.GetValue<string>(3),
                clientCode = Source.GetValue<string>(4),

                clientId = Source.GetValue<string>(5),
                clientPhone = Source.GetValue<string>(6),
                clientName = Source.GetValue<string>(7),
                clientAddress = Source.GetValue<string>(8),
                condSell = Source.GetValue<string>(9),
                bussinessLine = Source.GetValue<string>(10),
                payment = Source.GetValue<string>(11),
                finantialCode = Source.GetValue<string>(12),
                sellType = Source.GetValue<string>(13),
                seller = Source.GetValue<string>(14),
                documentDate = Source.GetValue<string>(15),
                documentVenc = Source.GetValue<string>(16),
                currency = Source.GetValue<string>(17),
                tax = Source.GetValue<string>(18),
                language = Source.GetValue<string>(19),
                perception = Source.GetValue<string>(20),
                nroOc = Source.GetValue<string>(21),
                nroGuiRem = Source.GetValue<string>(22),
                glosa = Source.GetValue<string>(23),
                donate = Source.GetValue<string>(24),
                documentTypeRef = Source.GetValue<string>(25),
                documentIdRef = Source.GetValue<string>(26),
                documentSerieRef = Source.GetValue<string>(27),
                documentExtRef = Source.GetValue<string>(28),
                impBase = Source.GetValue<string>(29),
                impVta = Source.GetValue<string>(30),
                impIGV = Source.GetValue<string>(31),
                impTot = Source.GetValue<string>(32),
                impPer = Source.GetValue<string>(33),
                estado= Source.GetValue<string>(34),
                estadoDes = Source.GetValue<string>(35),


            };
    }
}
