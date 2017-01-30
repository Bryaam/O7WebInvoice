using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Framework.Infrastructure.Data;
using Angkor.O7Web.Common.Finantial.Entity;
using Angkor.O7Web.Data.Finantial.DataMapper;

namespace Angkor.O7Web.Data.Finantial
{
    public class InvoiceDataService: O7AbstractData
    {
        public InvoiceDataService(string user, string password) : base(user, password)
        {

        }

        public virtual List<InvoiceSeries> Series(string companyId, string branchId,string docType )
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_tip_doc", docType));
            return DataAccess.ExecuteFunction<InvoiceSeries>("finantial_invoice.serie_ext_type", parameters, InvoiceSeriesMapper.Class);
        }

        public virtual List<InvoiceClient> AllClients(string companyId, string branchId, string word)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            parameters.Add(O7Parameter.Make("p_filter", word));
            return DataAccess.ExecuteFunction<InvoiceClient>("finantial_invoice.search_client", parameters, InvoiceClientMapper.Class);
        }

        public virtual List<InvoiceDetails> AllInvoices(string companyId, string branchId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            return DataAccess.ExecuteFunction<InvoiceDetails>("finantial_invoice.invoices", parameters, InvoiceDetailsMapper.Class);
        }

        public virtual List<ProductDetails> AllProducts(string companyId, string branchId, string ratePerception)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_tasper", ratePerception));
            return DataAccess.ExecuteFunction<ProductDetails>("finantial_invoice.search_concept_product", parameters, ProductDetailsMapper.Class);
        }


    }
}
