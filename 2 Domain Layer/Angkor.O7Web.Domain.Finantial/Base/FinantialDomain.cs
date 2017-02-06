// O7ERP Web created by felix_dev

using System.Collections.Generic;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Infrastructure;
using Angkor.O7Web.Common.Finantial.Entity;
using Angkor.O7Web.Data.Finantial;

namespace Angkor.O7Web.Domain.Finantial.Base
{
    public abstract class FinantialDomain
    {
        public FinantialDataService FinantialDataService { get; private set; }

        protected FinantialDomain(string login, string password)
        {
            FinantialDataService = O7DataInstanceMaker.MakeInstance<FinantialDataService>(new object[] {login, password});
        }

        public abstract O7Response AddCco(string companyId, string branchId,
            string code, string codeDim, string description, string dateB,
            string dateE, string accountC, string accountT, string codeCat,
            string flgDet, string flgPresup, string flgIng);

        public abstract O7Response getDimensions();

        public abstract O7Response getAccountsC(string companyId, string branchId);
        public abstract O7Response getAccountsT(string companyId, string branchId);
        

        public abstract O7Response getCategories();

        public abstract O7Response ClientChangeState(string companyId, string branchId, string clientId);

        public abstract O7Response ValidateCountryInvoicer(string countryId);

        public abstract O7Response ValidateCountryEntry(string countryId);

        public abstract O7Response GetTTHeads(string codtabl);

        public abstract O7Response GetTTData(string primary, string secondary);

        public abstract O7Response GetTTNames();

        public abstract O7Response GetCcos(string companyId, string branchId);
        public abstract O7Response InsertTTData(string codtabl, string keyocur, string datocur);
        public abstract O7Response UpdateTTData(string codtabl, string keyocur, string keyocurNew, string datocur);

        public abstract O7Response DeleteTTData(string codtabl, string keyocur);
        public abstract O7Response AllPostales();

        public abstract O7Response AllClientZones(string countryId);

        public abstract O7Response AllDepartments(string country);

        public abstract O7Response AllProvinces(string country, string departmentId);

        public abstract O7Response AllDistricts(string country, string departmentId, string provinceId);

        public abstract O7Response AllCountries(string companyId, string branchId);

        public abstract O7Response DocumentType(string clientType);

        public abstract O7Response ClientStates();

        public abstract O7Response DocumentTypes();

        public abstract O7Response ClientOrigins();

        public abstract O7Response ClientType();

        public abstract O7Response AllSeries(string companyId, string branchId);

        public abstract O7Response AddSeries(string companyId, string branchId, string documentType, string id, string current,
            string max, string min, string @default, string prefix);

        public abstract O7Response UpdateSeries(string companyId, string branchId, string documentType, string id,
            string current, string max, string min, string @default, string prefix, string idUpdate, string documentTypeUpdate);

        public abstract O7Response AllClients(string companyId, string branchId, string filter);

        public abstract O7Response AddClient(string companyId, string branchId, string typeClient, string businessName, string person, string stateClient,
            string ruc, string dni, string initialDate, string email, string country, string zone, string address, string codPost, string city, string phone,
            string ubigeoDep, string ubigeoProv, string ubigeoDist, string documentType);

        public abstract O7Response UpdateClient(string companyId, string branchId, string codClient, string typeClient, string businessName, string person,
                            string stateClient, string ruc, string dni, string country, string zone, string address, string codPost,
                            string city, string phone, string initialDate, string email, string ubigeoDep,
                            string ubigeoProv, string ubigeoDist, string documentType);

        public abstract O7Response AllRoute(string companyId, string branchId);

        public abstract O7Response ViewClient(string companyId, string branchId, string codClient);

        public abstract O7Response ViewAddressEntry(string companyId, string branchId, string codClient);

        public abstract O7Response ViewAddressFact(string companyId, string branchId, string codClient);

        public abstract O7Response UpdateAddressEntry(string companyId, string branchId, string codClient, string codDir, string route, string fax,
                            string contacto, string country, string zone, string address, string codPost, string city, string phone, string ubigeoDep,
                            string ubigeoProv, string ubigeoDist);
        public abstract O7Response UpdateAddressFact(string companyId, string branchId, string codClient, string codDir,
            string route, string fax, string contacto, string country, string zone, string address, string codPost, string city, string phone,
            string ubigeoDep, string ubigeoProv, string ubigeoDist);

        public abstract O7Response AddAddressFact(string companyId, string branchId, string codClient, string address,
            string codPostal, string ubi1, string ubi2, string ubi3, string country, string city, string zone, string route, string phone,
            string fax, string contact);
        public abstract O7Response AddAddressEnt(string companyId, string branchId, string codClient, string address,
            string codPostal, string ubi1, string ubi2, string ubi3, string country, string city, string zone, string route, string phone,
            string fax, string contact);

        public abstract O7Response SavePrincipalAddressFact(string companyId, string branchId, string codClient, string dirFact);

        public abstract O7Response SavePrincipalAddressEnt(string companyId, string branchId, string codClient, string dirEnt);

        public abstract O7Response UpdatePrincipalAddressEnt(string companyId, string branchId, string codClient,
            string codDir, string route, string fax, string contacto, string country, string zone, string address, string codPost, string city, string phone,
            string ubigeoDep, string ubigeoProv, string ubigeoDist);

        public abstract O7Response UpdatePrincipalAddressFact(string companyId, string branchId, string codClient,
            string codDir, string route, string fax, string contacto, string country, string zone, string address, string codPost, string city, string phone,
            string ubigeoDep, string ubigeoProv, string ubigeoDist);

        // Inicio modificacion Invoice Gf
        public abstract O7Response AllInvoices(string companyId, string branchId, string filter,string clientCode);
        public abstract O7Response Concepts(string companyId, string branchId, string percepcionTasa);
        public abstract O7Response Series(string companyId, string branchId, string docType);
        public abstract O7Response Cco(string companyId, string branchId);
        public abstract O7Response CondSells();
        public abstract O7Response AddInvoice(string companyId, string branchId,
            string documentType, string serie,
            string currency, string documentDate,
            string documentExpiration, string clienteCode
            , string codTax, string clientName
            , string invoiceAddress, string clientId, string glosa,
            string sellType, string language,
            string condSell, string payment,
            string bussinessline, string finantialcod,
            string telephone, string seller,
            string employeeId, string perception,
            string donate, string documentTypeRef,
            string documentIdRef, string documentOC,
            string guiRem, string addressId, string serieExtRef, string nroDoceExt);

        public abstract O7Response GeneratePdf(string companyId, string branchId, string documentType, string documentId);


        public abstract O7Response getExpirationDate(string companyId, string branchId, string payment, string documentDate);

        public abstract O7Response GetInvoice(string companyId, string branchId, string documentType, string documentId);


        public abstract O7Response GetInvoiceHeadView(string companyId, string branchId, string documentType, string documentId);

        public abstract O7Response GetInvoiceDetailView(string companyId, string branchId, string documentType, string documentId);

        public abstract O7Response GetInvoiceDetail(string companyId, string branchId, string documentType, string documentId);

        public abstract O7Response AnularInvoice(string companyId, string branchId,
                                                string documentType, string documentId);
        public abstract O7Response documentInformation(string companyId, string branchId, string documentType);

           public abstract O7Response GenerateReporte(string companyId, string branchId, string documentType, string documentId);

        public abstract O7Response DeleteDetailInvoice(string companyId, string branchId,
            string DocumentType, string DocumentId);

        public abstract O7Response UpdateInvoice(string companyId, string branchId,
            string documentType, string documentId,
            string currency, string documentDate,
            string documentExpiration, string clienteCode
            , string codTax, string porTax, string clientName
            , string invoiceAddress, string clientId, string glosa,
            string sellType, string language,
            string condSell, string payment,
            string bussinessline, string finantialcod,
            string telephone, string seller,
            string employeeId, string perception,
            string donate, string documentTypeRef,
            string documentIdRef, string documentOC,
            string guiRem, string addressId,
            string serieExtRef, string nroExtRef);
        public abstract O7Response ClientDefaultValues(string companyId, string branchId, string clientCode);
        public abstract O7Response AddInvoiceDetail(string companyId, string branchId,
            string documentType, string documentId,
            string conceptId, string observacion,
            string cantidad, string unitValue,
            string taxId, string perception,
            string ccoId,string flgfin);

        public abstract O7Response sendSunat(string companyId, string branchId,
            string documentType, string documentId);

        public abstract O7Response GetLogFE(string companyId, string branchId,
            string documentSerie, string documentExt);

        public abstract O7Response SellTypes();

        public abstract O7Response Payments(string cod_sell);

        public abstract O7Response FinantialCodes();

        public abstract O7Response Sellers(string companyId, string branchId);

        public abstract O7Response BussinessLine(string companyId, string branchId);

        public abstract O7Response InvoiceAdresses(string companyId, string branchId, string clientId);

        public abstract O7Response Currencies();

        public abstract O7Response Languages();

        public abstract O7Response Taxes();

        public abstract O7Response Perceptions();
    }

}