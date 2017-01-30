// O7ERP Web created by felix_dev

using System;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Finantial.Entity;

namespace Angkor.O7Web.Data.Finantial.DataMapper
{
    public class InvoiceDocumentTypeMapper : O7DbMapper<InvoiceDocumentType>
    {
        public static Type Class
            => typeof(InvoiceDocumentTypeMapper);

        public override InvoiceDocumentType MapTarget()
            => new InvoiceDocumentType
            {
                Value = Source.GetValue<string>(0),
                Content = Source.GetValue<string>(1)
            };
    }
}