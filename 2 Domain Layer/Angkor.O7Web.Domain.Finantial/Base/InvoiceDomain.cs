using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Infrastructure;
using Angkor.O7Web.Data.Finantial;

namespace Angkor.O7Web.Domain.Finantial.Base
{
    public abstract class InvoiceDomain
    {
        public InvoiceDataService InvoiceDataService { get; private set; }

        protected InvoiceDomain(string login, string password)
        {
            InvoiceDataService = O7DataInstanceMaker.MakeInstance<InvoiceDataService>(new object[] { login, password });
        }

        public abstract O7Response AllClients(string companyId, string branchId, string filter);
        public abstract O7Response AllInvoices(string companyId, string branchId);
        public abstract O7Response AllProducts(string companyId, string branchId, string percepcionTasa);
        public abstract O7Response Series(string companyId, string branchId, string docType);
    }
}
