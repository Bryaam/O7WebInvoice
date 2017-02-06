// O7ERP Web created by felix_dev
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Utility;
using Angkor.O7Web.Data.Security.DataMapper;
using Angkor.O7Web.Domain.Finantial.Base;

namespace Angkor.O7Web.Domain.Finantial
{
    public class FinantialFlow : FinantialDomain
    {
        public FinantialFlow(string login, string password) : base(login, password)
        {
        }

        public override O7Response ValidateCountryInvoicer(string countryId)
        {
            var client = FinantialDataService.ValidateCountryInvoicer(countryId);
            return O7SuccessResponse.MakeResponse($"{client}");
        }

        public override O7Response ValidateCountryEntry(string countryId)
        {
            var client = FinantialDataService.ValidateCountryEntry(countryId);
            return O7SuccessResponse.MakeResponse($"{client}");
        }

        public override O7Response AllPostales()
        {
            var client = FinantialDataService.AllPostales();
            var clientSerialized = O7JsonSerealizer.Serialize(client);
            return O7SuccessResponse.MakeResponse(clientSerialized);
        }

        public override O7Response GetCcos(string companyId,string branchId)
        {
            var ccos = FinantialDataService.GetCcos(companyId,branchId);
            var ccosSerialized = O7JsonSerealizer.Serialize(ccos);
            return O7SuccessResponse.MakeResponse(ccosSerialized);
        }

        public override O7Response GetTTHeads(string codtabl)
        {
            var heads = FinantialDataService.GetTTHeads(codtabl);
            var headsSerialized = O7JsonSerealizer.Serialize(heads);
            return O7SuccessResponse.MakeResponse(headsSerialized);
        }

        public override O7Response getDimensions()
        {
            var dimensiones = FinantialDataService.getDimensions();
            var dimensionesSerialized = O7JsonSerealizer.Serialize(dimensiones);
            return O7SuccessResponse.MakeResponse(dimensionesSerialized);
        }

        public override O7Response getAccountsC(string companyId,string branchId)
        {
            var accounts = FinantialDataService.getAccountsC(companyId,branchId);
            var accountsSerialized = O7JsonSerealizer.Serialize(accounts);
            return O7SuccessResponse.MakeResponse(accountsSerialized);
        }

        public override O7Response getAccountsT(string companyId, string branchId)
        {
            var accounts = FinantialDataService.getAccountsT(companyId, branchId);
            var accountsSerialized = O7JsonSerealizer.Serialize(accounts);
            return O7SuccessResponse.MakeResponse(accountsSerialized);
        }

        public override O7Response getCategories()
        {
            var accounts = FinantialDataService.getCategories();
            var accountsSerialized = O7JsonSerealizer.Serialize(accounts);
            return O7SuccessResponse.MakeResponse(accountsSerialized);
        }

        public override O7Response GetTTData(string primary,string secondary)
        {
            var data = FinantialDataService.GetTTData(primary,secondary);
            var dataSerialized = O7JsonSerealizer.Serialize(data);
            return O7SuccessResponse.MakeResponse(dataSerialized);
        }

        public override O7Response GetTTNames()
        {
            var ttnames = FinantialDataService.GetTTNames();
            var ttnamesSerialized = O7JsonSerealizer.Serialize(ttnames);
            return O7SuccessResponse.MakeResponse(ttnamesSerialized);
        }
        public override O7Response InsertTTData(string codtabl,string keyocur,string datocur)
        {
            var respuesta = FinantialDataService.InsertTTData(codtabl,keyocur,datocur);
            var respuestaSerialized = O7JsonSerealizer.Serialize(respuesta);
            return O7SuccessResponse.MakeResponse(respuestaSerialized);
        }
        public override O7Response UpdateTTData(string codtabl, string keyocur,string keyocurNew, string datocur)
        {
            var respuesta = FinantialDataService.UpdateTTData(codtabl,keyocur,keyocurNew,datocur);
            var respuestaSerialized = O7JsonSerealizer.Serialize(respuesta);
            return O7SuccessResponse.MakeResponse(respuestaSerialized);
        }

        public override O7Response DeleteTTData(string codtabl,string keyocur)
        {
            var respuesta = FinantialDataService.DeleteTTData(codtabl,keyocur);
            var respuestaSerialized = O7JsonSerealizer.Serialize(respuesta);
            return O7SuccessResponse.MakeResponse(respuestaSerialized);
        }

        public override O7Response AllClientZones(string countryId)
        {
            var client = FinantialDataService.AllClientZones(countryId);
            var clientSerialized = O7JsonSerealizer.Serialize(client);
            return O7SuccessResponse.MakeResponse(clientSerialized);
        }

        public override O7Response AllCountries(string companyId, string branchId)
        {
            var client = FinantialDataService.AllCountries(companyId, branchId);
            var clientSerialized = O7JsonSerealizer.Serialize(client);
            return O7SuccessResponse.MakeResponse(clientSerialized);
        }

        public override O7Response ClientChangeState(string companyId, string branchId, string clientId)
        {
            var client = FinantialDataService.ClientChangeState(companyId, branchId, clientId);
            return O7SuccessResponse.MakeResponse($"{client}");
        }

        public override O7Response DocumentType(string clientType)
        {
            var client = FinantialDataService.DocumentType(clientType);
            var clientSerialized = O7JsonSerealizer.Serialize(client);
            return O7SuccessResponse.MakeResponse(clientSerialized);
        }

        public override O7Response AllClients(string companyId, string branchId, string filter)
        {
            var client = FinantialDataService.AllClients(companyId, branchId, filter);
            var clientSerialized = O7JsonSerealizer.Serialize(client);
            return O7SuccessResponse.MakeResponse(clientSerialized);
        }

        public override O7Response DocumentTypes()
        {
            var series = FinantialDataService.DocumentTypes();
            var seriesSerialized = O7JsonSerealizer.Serialize(series);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        public override O7Response AllSeries(string companyId, string branchId)
        {
            var series = FinantialDataService.AllSeries(companyId, branchId);
            var seriesSerialized = O7JsonSerealizer.Serialize(series);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        public override O7Response AddSeries(string companyId, string branchId, string documentType, string id, string current,
            string max, string min, string @default, string prefix)
        {
            var result = FinantialDataService.AddSeries(companyId, branchId, documentType, id, current, max, min, @default, prefix);
            var seriesSerialized = O7JsonSerealizer.Serialize(result);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        public override O7Response UpdateSeries(string companyId, string branchId, string documentType, string id,
            string current, string max, string min, string @default, string prefix, string idUpdate, string documentTypeUpdate)
        {
            var result = FinantialDataService.UpdateSeries(companyId, branchId, documentType, id, current, max, min,
                @default, prefix, idUpdate, documentTypeUpdate);
            var seriesSerialized = O7JsonSerealizer.Serialize(result);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        public override O7Response AddClient(string companyId, string branchId, string typeClient, string businessName, string person, string stateClient,
            string ruc, string dni, string initialDate, string email, string country, string zone, string address, string codPost, string city, string phone,
            string ubigeoDep, string ubigeoProv, string ubigeoDist, string documentType)
        {
            var clientId = FinantialDataService.AddClient(companyId, branchId, typeClient, businessName, person, stateClient, ruc,
                dni, initialDate, email, country, zone, address, codPost, city, phone, ubigeoDep, ubigeoProv, ubigeoDist, documentType);
            var seriesSerialized = "{" + clientId + "}";
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        public override O7Response UpdateClient(string companyId, string branchId, string codClient, string typeClient, string businessName, string person,
                            string stateClient, string ruc, string dni, string country, string zone, string address, string codPost,
                            string city, string phone, string initialDate, string email, string ubigeoDep, string ubigeoProv, string ubigeoDist, string documentType)
        {

            var result = FinantialDataService.UpdateClient(companyId, branchId, codClient, typeClient, businessName, person, stateClient, ruc,
                dni, country, zone, address, codPost, city, phone, initialDate, email, ubigeoDep, ubigeoProv, ubigeoDist, documentType);
            var seriesSerialized = O7JsonSerealizer.Serialize(result);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        public override O7Response ClientOrigins()
        {
            var result = FinantialDataService.ClientOrigins();
            var seriesSerialized = O7JsonSerealizer.Serialize(result);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        public override O7Response ClientType()
        {
            var result = FinantialDataService.ClientType();
            var seriesSerialized = O7JsonSerealizer.Serialize(result);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        public override O7Response ClientStates()
        {
            var result = FinantialDataService.ClientStates();
            var seriesSerialized = O7JsonSerealizer.Serialize(result);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        public override O7Response AllDepartments(string country)
        {
            var result = FinantialDataService.AllDepartments(country);
            var seriesSerialized = O7JsonSerealizer.Serialize(result);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        public override O7Response AllProvinces(string country, string departmentId)
        {
            var result = FinantialDataService.AllProvinces(country, departmentId);
            var seriesSerialized = O7JsonSerealizer.Serialize(result);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        public override O7Response AllDistricts(string country, string departmentId, string provinceId)
        {
            var result = FinantialDataService.AllDistricts(country, departmentId, provinceId);
            var seriesSerialized = O7JsonSerealizer.Serialize(result);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        public override O7Response AllRoute(string companyId, string branchId)
        {
            var result = FinantialDataService.AllRoutes(companyId, branchId);
            var seriesSerialized = O7JsonSerealizer.Serialize(result);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        public override O7Response ViewClient(string companyId, string branchId, string codClient)
        {
            var result = FinantialDataService.ViewClient(companyId, branchId, codClient);
            var seriesSerialized = O7JsonSerealizer.Serialize(result);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        public override O7Response ViewAddressEntry(string companyId, string branchId, string codClient)
        {
            var result = FinantialDataService.ViewAddressEntry(companyId, branchId, codClient);
            var seriesSerialized = O7JsonSerealizer.Serialize(result);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        public override O7Response ViewAddressFact(string companyId, string branchId, string codClient)
        {
            var result = FinantialDataService.ViewAddressFact(companyId, branchId, codClient);
            var seriesSerialized = O7JsonSerealizer.Serialize(result);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        public override O7Response UpdateAddressEntry(string companyId, string branchId, string codClient, string codDir, string route, string fax,
                            string contacto, string country, string zone, string address, string codPost, string city, string phone, string ubigeoDep,
                            string ubigeoProv, string ubigeoDist)
        {
            var result = FinantialDataService.UpdateAddressEntry(companyId, branchId, codClient, codDir,
             route, fax, contacto, country, zone, address, codPost, city, phone, ubigeoDep, ubigeoProv, ubigeoDist);
            var seriesSerialized = O7JsonSerealizer.Serialize(result);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        public override O7Response UpdateAddressFact(string companyId, string branchId, string codClient, string codDir,
            string route, string fax, string contacto, string country, string zone, string address, string codPost,
            string city, string phone, string ubigeoDep, string ubigeoProv, string ubigeoDist)
        {
            var result = FinantialDataService.UpdateAddressFact(companyId, branchId, codClient, codDir,
             route, fax, contacto, country, zone, address, codPost, city, phone, ubigeoDep, ubigeoProv, ubigeoDist);
            var seriesSerialized = O7JsonSerealizer.Serialize(result);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        public override O7Response AddAddressFact(string companyId, string branchId, string codClient, string address,
            string codPostal, string ubi1, string ubi2, string ubi3, string country, string city, string zone,
            string route, string phone, string fax, string contact)
        {
            var result = FinantialDataService.AddAddressFact(companyId, branchId, codClient, address, codPostal, ubi1, ubi2, ubi3, country, city, zone,
             route, phone, fax, contact);
            var seriesSerialized = O7JsonSerealizer.Serialize(result);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        public override O7Response AddAddressEnt(string companyId, string branchId, string codClient, string address,
            string codPostal, string ubi1, string ubi2, string ubi3, string country, string city, string zone,
            string route, string phone, string fax, string contact)
        {
            var result = FinantialDataService.AddAddressEntrega(companyId, branchId, codClient, address, codPostal, ubi1, ubi2, ubi3, country, city, zone,
             route, phone, fax, contact);
            var seriesSerialized = O7JsonSerealizer.Serialize(result);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        public override O7Response SavePrincipalAddressFact(string companyId, string branchId, string codClient, string dirFact)
        {
            var result = FinantialDataService.SavePrincipalAddressFact(companyId, branchId, codClient, dirFact);
            var seriesSerialized = O7JsonSerealizer.Serialize(result);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        public override O7Response SavePrincipalAddressEnt(string companyId, string branchId, string codClient, string dirEnt)
        {
            var result = FinantialDataService.SavePrincipalAddressEnt(companyId, branchId, codClient, dirEnt);
            var seriesSerialized = O7JsonSerealizer.Serialize(result);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        public override O7Response UpdatePrincipalAddressEnt(string companyId, string branchId, string codClient,
            string codDir, string route, string fax, string contacto, string country, string zone, string address,
            string codPost, string city, string phone, string ubigeoDep, string ubigeoProv, string ubigeoDist)
        {
            var result = FinantialDataService.UpdatePrincipalAddressEnt(companyId, branchId, codClient, codDir, route, fax, contacto, country, zone, address,
             codPost, city, phone, ubigeoDep, ubigeoProv, ubigeoDist);
            var seriesSerialized = O7JsonSerealizer.Serialize(result);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        public override O7Response UpdatePrincipalAddressFact(string companyId, string branchId, string codClient,
            string codDir, string route, string fax, string contacto, string country, string zone, string address,
            string codPost, string city, string phone,
            string ubigeoDep, string ubigeoProv, string ubigeoDist)
        {
            var result = FinantialDataService.UpdatePrincipalAddressFact(companyId, branchId, codClient, codDir, route, fax, contacto, country, zone, address,
             codPost, city, phone, ubigeoDep, ubigeoProv, ubigeoDist);
            var seriesSerialized = O7JsonSerealizer.Serialize(result);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        // Inicio de la parte InvoiceFlow de Gf
        public override O7Response AllInvoices(string companyId, string branchId, string filter, string clientCode)
        {
            var invoices = FinantialDataService.AllInvoices(companyId, branchId, filter, clientCode);
            var invoicesSerialized = O7JsonSerealizer.Serialize(invoices);
            return O7SuccessResponse.MakeResponse(invoicesSerialized);
        }

        public override O7Response GetInvoice(string companyId, string branchId, string documentType, string documentId)
        {
            var result = FinantialDataService.GetInvoice(companyId, branchId, documentType, documentId);
            var seriesSerialized = O7JsonSerealizer.Serialize(result);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

        public override O7Response GetInvoiceHeadView(string companyId, string branchId, string documentType, string documentId)
        {
            var head = FinantialDataService.GetInvoiceHeadView(companyId, branchId, documentType, documentId);
            return O7SuccessResponse.MakeResponse(head);
 
        }

        public override O7Response GetInvoiceDetailView(string companyId, string branchId, string documentType, string documentId)
        {
            var detail = FinantialDataService.GetInvoiceDetailView(companyId, branchId, documentType, documentId);
            return O7SuccessResponse.MakeResponse(detail);
        }


        public override O7Response GetInvoiceDetail(string companyId, string branchId, string documentType, string documentId)
        {
            var result = FinantialDataService.GetInvoiceDetail(companyId, branchId, documentType, documentId);
            var seriesSerialized = O7JsonSerealizer.Serialize(result);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }

    

        public override O7Response GenerateReporte(string companyId, string branchId, string documentType, string documentId)
        {
            var pdf = FinantialDataService.GenerateReporte(companyId, branchId, documentType, documentId);
            return O7SuccessResponse.MakeResponse(pdf);
        }

        public override O7Response GeneratePdf(string companyId, string branchId, string documentType, string documentId)
        {
            var pdf = FinantialDataService.GeneratePDF(companyId, branchId, documentType, documentId);
            return O7SuccessResponse.MakeResponse(pdf);
        }

        public override O7Response UpdateInvoice(string companyId, string branchId,
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
                                       string serieExtRef, string nroExtRef)
        {
            var invoices = FinantialDataService.UpdateInvoiceHead(companyId, branchId,
                                         documentType, documentId,
                                        currency, documentDate,
                                        documentExpiration, clienteCode
                                       , codTax, porTax, clientName
                                       , invoiceAddress, clientId, glosa,
                                        sellType, language,
                                        condSell, payment,
                                        bussinessline, finantialcod,
                                        telephone, seller,
                                        employeeId, perception,
                                        donate, documentTypeRef,
                                        documentIdRef, documentOC,
                                        guiRem, addressId,
                                        serieExtRef, nroExtRef);
            var invoicesSerialized = O7JsonSerealizer.Serialize(invoices);
            return O7SuccessResponse.MakeResponse(invoicesSerialized);
        }

        public override O7Response AnularInvoice(string companyId, string branchId,
                                        string documentType, string documentId)
        {
            var invoices = FinantialDataService.AnularInvoice(companyId, branchId,
                                         documentType, documentId);
            var invoicesSerialized = O7JsonSerealizer.Serialize(invoices);
            return O7SuccessResponse.MakeResponse(invoicesSerialized);
        }

        public override O7Response sendSunat(string companyId, string branchId,
                                        string documentType, string documentId)
        {
            var invoices = FinantialDataService.sendSunat(companyId, branchId,
                                         documentType, documentId);
            var invoicesSerialized = O7JsonSerealizer.Serialize(invoices);
            return O7SuccessResponse.MakeResponse(invoicesSerialized);
        }

        public override O7Response GetLogFE(string companyId, string branchId,
                                        string documentSerie, string documentExt)
        {
            var logfe = FinantialDataService.GetLogFE(companyId, branchId,
                                         documentSerie, documentExt);
            var logfeSerialized = O7JsonSerealizer.Serialize(logfe);
            return O7SuccessResponse.MakeResponse(logfeSerialized);
        }

        public override O7Response AddInvoice(string companyId, string branchId,
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
                                            string documentIdRef, string documentOc,
                                            string guiRem, string addressId,
                                            string serieExtRef, string nroDoceExt)
        {
            var invoices = FinantialDataService.AddInvoice(companyId, branchId,
                                             documentType, serie,
                                             currency, documentDate,
                                             documentExpiration, clienteCode
                                            , codTax, clientName
                                            , invoiceAddress, clientId, glosa,
                                             sellType, language,
                                             condSell, payment,
                                             bussinessline, finantialcod,
                                             telephone, seller,
                                             employeeId, perception,
                                             donate, documentTypeRef,
                                             documentIdRef, documentOc,
                                             guiRem, addressId, serieExtRef, nroDoceExt);
           // var invoicesSerialized = O7JsonSerealizer.Serialize(invoices);
            return O7SuccessResponse.MakeResponse(invoices);
        }

        public override O7Response AddInvoiceDetail(string companyId, string branchId,
                                    string documentType, string documentId,
                                    string conceptId, string observacion,
                                    string cantidad, string unitValue,
                                    string taxId, string perception,
                                    string ccoId, string flgfin)
        {
            var invoices = FinantialDataService.AddInvoiceDetail(companyId, branchId,
                                     documentType, documentId,
                                     conceptId, observacion,
                                     cantidad, unitValue,
                                     taxId, perception,
                                     ccoId, flgfin);
            var invoicesSerialized = O7JsonSerealizer.Serialize(invoices);
            return O7SuccessResponse.MakeResponse(invoicesSerialized);
        }

        public override O7Response Concepts(string companyId, string branchId, string ratePerception)
        {
            var concepts = FinantialDataService.AllConcepts(companyId, branchId, ratePerception);
            var conceptsSerialized = O7JsonSerealizer.Serialize(concepts);
            return O7SuccessResponse.MakeResponse(conceptsSerialized);
        }

        public override O7Response Cco(string companyId, string branchId)
        {
            var cco = FinantialDataService.AllCco(companyId, branchId);
            var ccoSerialized = O7JsonSerealizer.Serialize(cco);
            return O7SuccessResponse.MakeResponse(ccoSerialized);
        }

        public override O7Response ClientDefaultValues(string companyId, string branchId, string clientCode)
        {
            var cco = FinantialDataService.ClientDefaultValues(companyId, branchId, clientCode);
            var ccoSerialized = O7JsonSerealizer.Serialize(cco);
            return O7SuccessResponse.MakeResponse(ccoSerialized);
        }

        public override O7Response documentInformation(string companyId, string branchId, string documentType)
        {
            var cco = FinantialDataService.DocumentInformation(companyId, branchId, documentType);
            var ccoSerialized = O7JsonSerealizer.Serialize(cco);
            return O7SuccessResponse.MakeResponse(ccoSerialized);
        }

        public override O7Response getExpirationDate(string companyId, string branchId, string payment, string documentDate)
        {
            var cco = FinantialDataService.GetFecVto(companyId, branchId, payment, documentDate);
            var ccoSerialized = O7JsonSerealizer.Serialize(cco);
            return O7SuccessResponse.MakeResponse(ccoSerialized);
        }

        public override O7Response Series(string companyId, string branchId, string docType)
        {
            var series = FinantialDataService.Series(companyId, branchId, docType);
            var seriesSerialized = O7JsonSerealizer.Serialize(series);
            return O7SuccessResponse.MakeResponse(seriesSerialized);
        }
        //cond venta,tipventa ,form pago,codfin,vende,line
        public override O7Response CondSells()
        {
            var condsells = FinantialDataService.AllCondSells();
            var condsellsSerialized = O7JsonSerealizer.Serialize(condsells);
            return O7SuccessResponse.MakeResponse(condsellsSerialized);
        }

        public override O7Response SellTypes()
        {
            var selltypes = FinantialDataService.AllSellsTypes();
            var selltypesSerialized = O7JsonSerealizer.Serialize(selltypes);
            return O7SuccessResponse.MakeResponse(selltypesSerialized);
        }

        public override O7Response DeleteDetailInvoice(string companyId, string branchId,
                                    string DocumentType, string DocumentId)
        {
            var selltypes = FinantialDataService.DeleteDetailInvoice(companyId, branchId, DocumentType, DocumentId);
            var selltypesSerialized = O7JsonSerealizer.Serialize(selltypes);
            return O7SuccessResponse.MakeResponse(selltypesSerialized);
        }

        public override O7Response Payments(string cod_sell)
        {
            var payment = FinantialDataService.AllPayements(cod_sell);
            var paymentSerialized = O7JsonSerealizer.Serialize(payment);
            return O7SuccessResponse.MakeResponse(paymentSerialized);
        }

        public override O7Response FinantialCodes()
        {
            var finantialcodes = FinantialDataService.AllFinantialCodes();
            var finantialcodesSerialized = O7JsonSerealizer.Serialize(finantialcodes);
            return O7SuccessResponse.MakeResponse(finantialcodesSerialized);
        }

        public override O7Response Sellers(string companyId, string branchId)
        {
            var sellers = FinantialDataService.AllSeller(companyId, branchId);
            var sellersSerialized = O7JsonSerealizer.Serialize(sellers);
            return O7SuccessResponse.MakeResponse(sellersSerialized);
        }

        public override O7Response BussinessLine(string companyId, string branchId)
        {
            var bussinesslines = FinantialDataService.AllBusinessLines(companyId, branchId);
            var bussinesslinesSerialized = O7JsonSerealizer.Serialize(bussinesslines);
            return O7SuccessResponse.MakeResponse(bussinesslinesSerialized);
        }

        public override O7Response InvoiceAdresses(string companyId, string branchId, string clientId)
        {
            var invoiceadresses = FinantialDataService.AllDirFacs(companyId, branchId, clientId);
            var invoiceadressesSerialized = O7JsonSerealizer.Serialize(invoiceadresses);
            return O7SuccessResponse.MakeResponse(invoiceadressesSerialized);
        }

        public override O7Response Currencies()
        {
            var invoiceadresses = FinantialDataService.AllCurrencies();
            var invoiceadressesSerialized = O7JsonSerealizer.Serialize(invoiceadresses);
            return O7SuccessResponse.MakeResponse(invoiceadressesSerialized);
        }
        public override O7Response Languages()
        {
            var invoiceadresses = FinantialDataService.AllLanguages();
            var invoiceadressesSerialized = O7JsonSerealizer.Serialize(invoiceadresses);
            return O7SuccessResponse.MakeResponse(invoiceadressesSerialized);
        }
        public override O7Response Taxes()
        {
            var invoiceadresses = FinantialDataService.AllTaxes();
            var invoiceadressesSerialized = O7JsonSerealizer.Serialize(invoiceadresses);
            return O7SuccessResponse.MakeResponse(invoiceadressesSerialized);
        }
        public override O7Response Perceptions()
        {
            var invoiceadresses = FinantialDataService.AllPerception();
            var invoiceadressesSerialized = O7JsonSerealizer.Serialize(invoiceadresses);
            return O7SuccessResponse.MakeResponse(invoiceadressesSerialized);
        }

    }
}