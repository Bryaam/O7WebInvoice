// O7ERP Web created by felix_dev
using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Finantial.Entity;

namespace Angkor.O7Web.Data.Finantial.DataMapper
{
    public class InvoiceDocumentCountMapper : O7DbMapper<InvoiceDocumentCount>
    {
        public static Type Class => typeof(InvoiceDocumentCountMapper);

        public override InvoiceDocumentCount MapTarget()
            => new InvoiceDocumentCount
            {
                DocumentType = Source.GetValue<string>(0), Id = Source.GetValue<string>(1), Min = Source.GetValue<string>(2), Max = Source.GetValue<string>(3),
                Current = Source.GetValue<string>(4), Default = Source.GetValue<string>(5), Digital = Source.GetValue<string>(6), DocumentDescription = Source.GetValue<string>(7),
                Prefix = Source.GetValue<string>(8)
            };
    }
}