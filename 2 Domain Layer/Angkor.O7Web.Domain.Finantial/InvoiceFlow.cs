using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Utility;
using Angkor.O7Web.Common.Finantial.Entity;
using Angkor.O7Web.Data.Finantial;
using Angkor.O7Web.Domain.Finantial.Base;

namespace Angkor.O7Web.Domain.Finantial
{
    public class InvoiceFlow :InvoiceDomain
    {
        public InvoiceFlow(string login, string password) : base(login, password)
        {

        }

        public override O7Response AllClients(string companyId, string branchId, string filter)
        {
            var client = InvoiceDataService.AllClients(companyId,branchId,filter);
            var clientSerialized = O7JsonSerealizer.Serialize(client);
            return O7SuccessResponse.MakeResponse(clientSerialized);
        }

        public override O7Response AllInvoices(string companyId, string branchId)
        {
            var invoices = InvoiceDataService.AllInvoices(companyId, branchId);
            var invoicesSerialized = O7JsonSerealizer.Serialize(invoices);
            return O7SuccessResponse.MakeResponse(invoicesSerialized);
        }

        public override O7Response AllProducts(string companyId, string branchId, string ratePerception)
        {
            var products = InvoiceDataService.AllProducts(companyId, branchId, ratePerception);
            var productsSerialized = O7JsonSerealizer.Serialize(products);
            return O7SuccessResponse.MakeResponse(productsSerialized);
        }

        public override O7Response Series(string companyId, string branchId, string docType)
        {
            var series = InvoiceDataService.Series(companyId, branchId, docType);
            var seriesSerialized = O7JsonSerealizer.Serialize(series);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }
    }
}
