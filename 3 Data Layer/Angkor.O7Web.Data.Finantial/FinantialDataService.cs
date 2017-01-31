// O7ERP Web created by felix_dev
using System.Collections.Generic;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Framework.Infrastructure.Data;
using Angkor.O7Web.Common.Finantial.Entity;
using Angkor.O7Web.Data.Finantial.DataMapper;
using System.IO;

namespace Angkor.O7Web.Data.Finantial
{
    public class FinantialDataService : O7AbstractData
    {
        public FinantialDataService(string user, string password) : base(user, password)
        {
        }

        public virtual List<ClientRoute> AllRoutes(string companyId, string branchId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            return DataAccess.ExecuteFunction<ClientRoute>("CRUD_DIR_ENTREGA.lov_route", parameters, InvoiceDocumentCountMapper.Class);
        }

        public virtual List<ClientPostale> AllPostales()
        {           
            return DataAccess.ExecuteFunction<ClientPostale>("o7express_package_cliente.lov_codpos", O7DbParameterCollection.Make, ClientPostaleMapper.Class);
        }

        public virtual List<ClientZone> AllClientZones(string countryId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_pais", countryId));
            return DataAccess.ExecuteFunction<ClientZone>("o7express_package_cliente.lov_zon", parameters, ClientZoneMapper.Class);
        }


        public virtual List<ClientDepartment> AllDepartments(string countryId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_pais", countryId));
            return DataAccess.ExecuteFunction<ClientDepartment>("o7express_package_cliente.lov_ubidpto", parameters, ClientDepartmentMapper.Class);
        }

        public virtual List<ClientProvince> AllProvinces(string countryId,string departmentId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_pais", countryId));
            parameters.Add(O7Parameter.Make("p_ubidpto", departmentId));            
            return DataAccess.ExecuteFunction<ClientProvince>("o7express_package_cliente.lov_ubiprov", parameters, ClientProvinceMapper.Class);
        }

        public virtual List<ClientDistrict> AllDistricts(string countryId,string departmentId, string provinceId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_pais", countryId));
            parameters.Add(O7Parameter.Make("p_ubidpto", departmentId));
            parameters.Add(O7Parameter.Make("p_ubipro", provinceId));            
            return DataAccess.ExecuteFunction<ClientDistrict>("o7express_package_cliente.lov_ubidis", parameters, ClientDistrictMapper.Class);
        }

        public virtual List<ClientCountry> AllCountries(string companyId, string branchId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            return DataAccess.ExecuteFunction<ClientCountry>("o7express_package_cliente.lov_pais", parameters, ClientCountryMapper.Class);
        }


        public virtual List<ClientType> DocumentType(string clientType)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_tipper", clientType));            
            return DataAccess.ExecuteFunction<ClientType>("o7express_package_cliente.lov_tipdoc", parameters, ClientTypeMapper.Class);
        }

        public virtual List<ClientType> ClientType()
        {
            return DataAccess.ExecuteFunction<ClientType>("o7express_package_cliente.lov_person_type", O7DbParameterCollection.Make, ClientTypeMapper.Class);
        }

        public virtual List<ClientState> ClientStates()
        {
            return DataAccess.ExecuteFunction<ClientState>("o7express_package_cliente.lov_estcli", O7DbParameterCollection.Make, ClientStateMapper.Class);
        }

        public virtual List<ClientOrigin> ClientOrigins()
        {            
            return DataAccess.ExecuteFunction<ClientOrigin>("o7express_package_cliente.lov_tipcli", O7DbParameterCollection.Make, ClientOriginMapper.Class);
        }

        public virtual List<InvoiceDocumentType> DocumentTypes()
        {
            return DataAccess.ExecuteFunction<InvoiceDocumentType>("finantial_invoice.document_type", O7DbParameterCollection.Make, InvoiceDocumentTypeMapper.Class);
        }

        public virtual bool UpdateSeries(string companyId, string branchId, string documentType, string id, string current,
            string max, string min, string @default, string prefix, string idUpdate, string documentTypeUpdate)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            parameters.Add(O7Parameter.Make("p_document_type", documentType));
            parameters.Add(O7Parameter.Make("p_id", id));
            parameters.Add(O7Parameter.Make("p_min", min));
            parameters.Add(O7Parameter.Make("p_max", max));
            parameters.Add(O7Parameter.Make("p_current", current));
            parameters.Add(O7Parameter.Make("p_default", @default));
            parameters.Add(O7Parameter.Make("p_prefix", prefix));
            parameters.Add(O7Parameter.Make("p_document_type_new", documentTypeUpdate));
            parameters.Add(O7Parameter.Make("p_id_new", idUpdate));
            return DataAccess.ExecuteFunction<int>("O7EXPRESS_PACKAGE_SERIESF.update_serieF", parameters) == 1;
        }

        public virtual bool AddSeries(string companyId, string branchId, string documentType, string id, string current,
            string max, string min, string @default, string prefix)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            parameters.Add(O7Parameter.Make("p_document_type", documentType));
            parameters.Add(O7Parameter.Make("p_id", id));
            parameters.Add(O7Parameter.Make("p_min", min));
            parameters.Add(O7Parameter.Make("p_max", max));
            parameters.Add(O7Parameter.Make("p_current", current));
            parameters.Add(O7Parameter.Make("p_default", @default));
            parameters.Add(O7Parameter.Make("p_prefix", prefix));
            return DataAccess.ExecuteFunction<int>("O7EXPRESS_PACKAGE_SERIESF.insert_newserieF", parameters) == 1;
        }

        public virtual List<InvoiceDocumentCount> AllSeries(string companyId, string branchId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));            
            return DataAccess.ExecuteFunction<InvoiceDocumentCount>("O7EXPRESS_PACKAGE_SERIESF.get_seriesF", parameters, InvoiceDocumentCountMapper.Class);
        }

        //Retorno ClientId
        public virtual string AddClient(string companyId, string branchId, string typeClient, string businessName, string person,
                            string stateClient, string ruc, string dni, string initialDate, string email, string country, string zone, string address, string codPost,
                            string city, string phone,string ubigeoDep, string ubigeoProv, string ubigeoDist, string documentType)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            parameters.Add(O7Parameter.Make("p_tip_cli", typeClient));
            parameters.Add(O7Parameter.Make("p_raz_soc", businessName));
            parameters.Add(O7Parameter.Make("p_tip_per", person));
            parameters.Add(O7Parameter.Make("p_est_cli", stateClient));
            parameters.Add(O7Parameter.Make("p_ruc", ruc));
            parameters.Add(O7Parameter.Make("p_dni", dni));
            parameters.Add(O7Parameter.Make("p_pais", country));
            parameters.Add(O7Parameter.Make("p_zona", zone));
            parameters.Add(O7Parameter.Make("p_dir", address));
            parameters.Add(O7Parameter.Make("p_codpost", codPost));
            parameters.Add(O7Parameter.Make("p_ciudad", city));
            parameters.Add(O7Parameter.Make("p_nrotel", phone));
            parameters.Add(O7Parameter.Make("p_fec_ing", initialDate));
            parameters.Add(O7Parameter.Make("p_email", email));
            parameters.Add(O7Parameter.Make("p_ubidpt", ubigeoDep));
            parameters.Add(O7Parameter.Make("p_ubiprv", ubigeoProv));
            parameters.Add(O7Parameter.Make("p_ubidis", ubigeoDist));
            parameters.Add(O7Parameter.Make("p_tipdoc", documentType));
            
            return DataAccess.ExecuteFunction<string>("o7express_package_cliente.insert_client", parameters);
        }

        public virtual bool AddAddressFact(string companyId, string branchId, string codClient, string address, string codPostal,
            string ubi1, string ubi2,string ubi3, string country, string city,string zone, string route, string phone, string fax, string contact)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            parameters.Add(O7Parameter.Make("p_codclie", codClient));
            parameters.Add(O7Parameter.Make("p_dir", address));
            parameters.Add(O7Parameter.Make("p_cod_postal", codPostal));
            parameters.Add(O7Parameter.Make("p_ubi_1", ubi1));
            parameters.Add(O7Parameter.Make("p_ubi_2", ubi2));
            parameters.Add(O7Parameter.Make("p_ubi_3", ubi3));
            parameters.Add(O7Parameter.Make("p_pais", country));
            parameters.Add(O7Parameter.Make("p_ciudad", city));
            parameters.Add(O7Parameter.Make("p_zona", zone));
            parameters.Add(O7Parameter.Make("p_ruta", route));
            parameters.Add(O7Parameter.Make("p_nro_tlf", phone));
            parameters.Add(O7Parameter.Make("p_nro_fax", fax));
            parameters.Add(O7Parameter.Make("p_contacto", contact));
            return DataAccess.ExecuteFunction<int>("CRUD_DIR_FACT.insert_dir_fact", parameters)==1;
        }

        public virtual bool AddAddressEntrega(string companyId, string branchId, string codClient, string address, string codPostal,
            string ubi1, string ubi2, string ubi3, string country, string city,string zone, string route, string phone, string fax, string contact)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            parameters.Add(O7Parameter.Make("p_codclie", codClient));
            parameters.Add(O7Parameter.Make("p_dir", address));
            parameters.Add(O7Parameter.Make("p_cod_postal", codPostal));
            parameters.Add(O7Parameter.Make("p_ubi_1", ubi1));
            parameters.Add(O7Parameter.Make("p_ubi_2", ubi2));
            parameters.Add(O7Parameter.Make("p_ubi_3", ubi3));
            parameters.Add(O7Parameter.Make("p_pais", country));
            parameters.Add(O7Parameter.Make("p_ciudad", city));
            parameters.Add(O7Parameter.Make("p_zona", zone));
            parameters.Add(O7Parameter.Make("p_ruta", route));
            parameters.Add(O7Parameter.Make("p_nro_tlf", phone));
            parameters.Add(O7Parameter.Make("p_nro_fax", fax));
            parameters.Add(O7Parameter.Make("p_contacto", contact));
            return DataAccess.ExecuteFunction<int>("CRUD_DIR_ENTREGA.insert_dir_ent", parameters)==1;
        }

        public virtual bool SavePrincipalAddressFact(string companyId, string branchId, string codClient, string dirFact)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            parameters.Add(O7Parameter.Make("p_codcli", codClient));
            parameters.Add(O7Parameter.Make("p_dirfac", dirFact));
            return DataAccess.ExecuteFunction<int>("O7EXPRESS_PACKAGE_CLIENTE.save_prin_dir_fac_client", parameters) == 1;
        }

        public virtual bool SavePrincipalAddressEnt(string companyId, string branchId, string codClient, string dirEnt)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            parameters.Add(O7Parameter.Make("p_codcli", codClient));
            parameters.Add(O7Parameter.Make("p_dirent", dirEnt));
            return DataAccess.ExecuteFunction<int>("O7EXPRESS_PACKAGE_CLIENTE.save_prin_dir_ent_client", parameters) == 1;
        }

        public virtual bool UpdatePrincipalAddressEnt(string companyId, string branchId, string codClient, string codDir, string route, string fax,
                            string contacto, string country, string zone, string address, string codPost, string city, string phone, string ubigeoDep,
                            string ubigeoProv, string ubigeoDist)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            parameters.Add(O7Parameter.Make("p_codcli", codClient));
            parameters.Add(O7Parameter.Make("p_coddir", codDir));
            parameters.Add(O7Parameter.Make("p_dir", address));
            parameters.Add(O7Parameter.Make("p_cod_postal", codPost));
            parameters.Add(O7Parameter.Make("p_ubi_1", ubigeoDep));
            parameters.Add(O7Parameter.Make("p_ubi_2", ubigeoProv));
            parameters.Add(O7Parameter.Make("p_ubi_3", ubigeoDist));
            parameters.Add(O7Parameter.Make("p_ciudad", city));
            parameters.Add(O7Parameter.Make("p_pais", country));
            parameters.Add(O7Parameter.Make("p_zona", zone));
            parameters.Add(O7Parameter.Make("p_ruta", route));
            parameters.Add(O7Parameter.Make("p_nro_tlf", phone));
            parameters.Add(O7Parameter.Make("p_nro_fax", fax));
            parameters.Add(O7Parameter.Make("p_contacto", contacto));

            return DataAccess.ExecuteFunction<int>("O7EXPRESS_PACK.update_dir_ent", parameters) == 1;
        }

        public virtual bool UpdatePrincipalAddressFact(string companyId, string branchId, string codClient, string codDir, string route, string fax,
                            string contacto, string country, string zone, string address, string codPost, string city, string phone, string ubigeoDep,
                            string ubigeoProv, string ubigeoDist)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            parameters.Add(O7Parameter.Make("p_codcli", codClient));
            parameters.Add(O7Parameter.Make("p_coddir", codDir));
            parameters.Add(O7Parameter.Make("p_dir", address));
            parameters.Add(O7Parameter.Make("p_cod_postal", codPost));
            parameters.Add(O7Parameter.Make("p_ubi_1", ubigeoDep));
            parameters.Add(O7Parameter.Make("p_ubi_2", ubigeoProv));
            parameters.Add(O7Parameter.Make("p_ubi_3", ubigeoDist));
            parameters.Add(O7Parameter.Make("p_ciudad", city));
            parameters.Add(O7Parameter.Make("p_pais", country));
            parameters.Add(O7Parameter.Make("p_zona", zone));
            parameters.Add(O7Parameter.Make("p_ruta", route));
            parameters.Add(O7Parameter.Make("p_nro_tlf", phone));
            parameters.Add(O7Parameter.Make("p_nro_fax", fax));
            parameters.Add(O7Parameter.Make("p_contacto", contacto));

            return DataAccess.ExecuteFunction<int>("O7EXPRESS_PACK.update_dir_fact", parameters) == 1;
        }

        public virtual List<ClientView> ViewClient(string companyId, string branchId, string codClient)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            parameters.Add(O7Parameter.Make("p_codcli", codClient));
            return DataAccess.ExecuteFunction<ClientView>("o7express_package_cliente.view_client", parameters, ClientViewMapper.Class);
        }

        //Esto es para cuando vaya a editar necesito mostrar todas las direcciones anteriores de facturacion
        public virtual List<AddressFact> ViewAddressFact(string companyId, string branchId, string codClient)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            parameters.Add(O7Parameter.Make("p_codcli", codClient));
            return DataAccess.ExecuteFunction<AddressFact>("CRUD_DIR_FAC.view_dir_fac", parameters, AddressFactMapper.Class);
        }
        //Esto es para cuando vaya a editar necesito mostrar todas las direcciones anteriores de entrega
        public virtual List<AddressEnt> ViewAddressEntry(string companyId, string branchId, string codClient)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            parameters.Add(O7Parameter.Make("p_codcli", codClient));
            return DataAccess.ExecuteFunction<AddressEnt>("CRUD_DIR_ENTREGA.view_dir_ent", parameters, AddressEntryMapper.Class);
        }
        public virtual bool UpdateClient(string companyId, string branchId, string codClient, string typeClient, string businessName, string person,
                            string stateClient, string ruc, string dni, string country, string zone, string address, string codPost,
                            string city, string phone, string initialDate, string email, string ubigeoDep,
                            string ubigeoProv, string ubigeoDist)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            parameters.Add(O7Parameter.Make("p_codcli", codClient));
            parameters.Add(O7Parameter.Make("p_tip_cli", typeClient));
            parameters.Add(O7Parameter.Make("p_raz_soc", businessName));
            parameters.Add(O7Parameter.Make("p_tip_per", person));
            parameters.Add(O7Parameter.Make("p_est_cli", stateClient));
            parameters.Add(O7Parameter.Make("p_ruc", ruc));
            parameters.Add(O7Parameter.Make("p_nrodni", dni));
            parameters.Add(O7Parameter.Make("p_pais", country));
            parameters.Add(O7Parameter.Make("p_zona", zone));
            parameters.Add(O7Parameter.Make("p_dir", address));
            parameters.Add(O7Parameter.Make("p_codpost", codPost));
            parameters.Add(O7Parameter.Make("p_ciudad", city));
            parameters.Add(O7Parameter.Make("p_nrotel", phone));
            parameters.Add(O7Parameter.Make("p_fec_ing", initialDate));
            parameters.Add(O7Parameter.Make("p_email", email));
            parameters.Add(O7Parameter.Make("p_ubidpt", ubigeoDep));
            parameters.Add(O7Parameter.Make("p_ubiprv", ubigeoProv));
            parameters.Add(O7Parameter.Make("p_ubidis", ubigeoDist));

            return DataAccess.ExecuteFunction<int>("o7express_package_cliente.update_client", parameters) == 1;
        }
        //Esto es para editar una fila de la tabla de direcciones de entrega 
        public virtual bool UpdateAddressFact(string companyId, string branchId, string codClient, string codDir, string route, string fax,
                            string contacto,string country, string zone, string address, string codPost,string city, string phone, string ubigeoDep,
                            string ubigeoProv, string ubigeoDist)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            parameters.Add(O7Parameter.Make("p_codcli", codClient));
            parameters.Add(O7Parameter.Make("p_coddir", codDir));
            parameters.Add(O7Parameter.Make("p_dir", address));
            parameters.Add(O7Parameter.Make("p_cod_postal", codPost));
            parameters.Add(O7Parameter.Make("p_ubi_1", ubigeoDep));
            parameters.Add(O7Parameter.Make("p_ubi_2", ubigeoProv));
            parameters.Add(O7Parameter.Make("p_ubi_3", ubigeoDist));
            parameters.Add(O7Parameter.Make("p_ciudad", city));
            parameters.Add(O7Parameter.Make("p_pais", country));
            parameters.Add(O7Parameter.Make("p_zona", zone));
            parameters.Add(O7Parameter.Make("p_ruta", route));
            parameters.Add(O7Parameter.Make("p_nro_tlf", phone));
            parameters.Add(O7Parameter.Make("p_nro_fax", fax));
            parameters.Add(O7Parameter.Make("p_contacto", contacto));

            return DataAccess.ExecuteFunction<int>("O7EXPRESS_PACK.update_dir_fact", parameters) == 1;
        }

        //Esto es para editar una fila de la tabla de direcciones de facturacion 

        public virtual bool UpdateAddressEntry(string companyId, string branchId, string codClient, string codDir, string route, string fax,
                            string contacto, string country, string zone, string address, string codPost, string city, string phone, string ubigeoDep,
                            string ubigeoProv, string ubigeoDist)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            parameters.Add(O7Parameter.Make("p_codcli", codClient));
            parameters.Add(O7Parameter.Make("p_coddir", codDir));
            parameters.Add(O7Parameter.Make("p_dir", address));
            parameters.Add(O7Parameter.Make("p_cod_postal", codPost));
            parameters.Add(O7Parameter.Make("p_ubi_1", ubigeoDep));
            parameters.Add(O7Parameter.Make("p_ubi_2", ubigeoProv));
            parameters.Add(O7Parameter.Make("p_ubi_3", ubigeoDist));
            parameters.Add(O7Parameter.Make("p_ciudad", city));
            parameters.Add(O7Parameter.Make("p_pais", country));
            parameters.Add(O7Parameter.Make("p_zona", zone));
            parameters.Add(O7Parameter.Make("p_ruta", route));
            parameters.Add(O7Parameter.Make("p_nro_tlf", phone));
            parameters.Add(O7Parameter.Make("p_nro_fax", fax));
            parameters.Add(O7Parameter.Make("p_contacto", contacto));

            return DataAccess.ExecuteFunction<int>("CRUD_DIR_ENT.update_dir_ent", parameters) == 1;
        }
        public virtual List<InvoiceClient> AllClients(string companyId, string branchId, string word)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            parameters.Add(O7Parameter.Make("p_filter", word));
            return DataAccess.ExecuteFunction<InvoiceClient>("o7express_package_cliente.get_clients", parameters, InvoiceClientMapper.Class);
        }


        // Inicio modificacion Invoice Gf
        public virtual List<InvoiceBasicInformation> AllInvoices(string companyId, string branchId, string pFilter)

        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_filter", pFilter));
            return DataAccess.ExecuteFunction<InvoiceBasicInformation>("finantial_invoice.invoices", parameters, InvoiceBasicInformationMapper.Class);
        }

        public virtual List<InvoiceTypeAhead> AllConcepts(string companyId, string branchId, string ratePerception)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_tasper", ratePerception));
            return DataAccess.ExecuteFunction<InvoiceTypeAhead>("finantial_invoice.search_concept_product", parameters, TypeAheadMapper.Class);
        }



        public virtual List<GenericListValue> AllCondSells()
        {
            var parameters = O7DbParameterCollection.Make;
            return DataAccess.ExecuteFunction<GenericListValue>("finantial_invoice.cond_vta_type", parameters, InvoiceGenericListMapper.Class);
        }

        public virtual List<GenericListValue> AllSellsTypes()
        {
            var parameters = O7DbParameterCollection.Make;
            return DataAccess.ExecuteFunction<GenericListValue>("finantial_invoice.tip_vta_type", parameters, InvoiceGenericListMapper.Class);
        }

        public virtual List<GenericListValue> AllPayements(string cond_vta_code)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_convta", cond_vta_code));
            return DataAccess.ExecuteFunction<GenericListValue>("finantial_invoice.form_pago_type", parameters, InvoiceGenericListMapper.Class);
        }
        //cod finan linneg  vendedor
        public virtual List<GenericListValue> AllFinantialCodes()
        {
            var parameters = O7DbParameterCollection.Make;
            return DataAccess.ExecuteFunction<GenericListValue>("finantial_invoice.cod_fin_type", parameters, InvoiceGenericListMapper.Class);
        }

        public virtual List<GenericListValue> AllBusinessLines(string companyId, string branchId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            return DataAccess.ExecuteFunction<GenericListValue>("finantial_invoice.lin_neg_type", parameters, InvoiceGenericListMapper.Class);

        }

        public virtual List<GenericListValue> AllSeller(string companyId, string branchId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            return DataAccess.ExecuteFunction<GenericListValue>("finantial_invoice.seller_type", parameters, InvoiceGenericListMapper.Class);

        }

        public virtual List<GenericListValue> AllDirFacs(string companyId, string branchId, string clientId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_cliente", clientId));
            return DataAccess.ExecuteFunction<GenericListValue>("finantial_invoice.dirs_fac", parameters, InvoiceGenericListMapper.Class);

        }

        public virtual List<GenericListValue> AllCurrencies()
        {
            var parameters = O7DbParameterCollection.Make;
            return DataAccess.ExecuteFunction<GenericListValue>("finantial_invoice.money_type", parameters, InvoiceGenericListMapper.Class);

        }

        public virtual List<GenericListValue> AllLanguages()
        {
            var parameters = O7DbParameterCollection.Make;
            return DataAccess.ExecuteFunction<GenericListValue>("finantial_invoice.language_type", parameters, InvoiceGenericListMapper.Class);

        }

        public virtual List<GenericListValue> AllTaxes()
        {
            var parameters = O7DbParameterCollection.Make;
            return DataAccess.ExecuteFunction<GenericListValue>("finantial_invoice.tax_type", parameters, InvoiceGenericListMapper.Class);

        }

        public virtual List<GenericListValue> AllPerception()
        {
            var parameters = O7DbParameterCollection.Make;
            return DataAccess.ExecuteFunction<GenericListValue>("finantial_invoice.percep_type", parameters, InvoiceGenericListMapper.Class);

        }
        public virtual List<InvoiceTypeAhead> AllCco(string companyId, string branchId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            return DataAccess.ExecuteFunction<InvoiceTypeAhead>("finantial_invoice.search_cen_cos", parameters, TypeAheadMapper.Class);

        }
        public virtual int DeleteDetailInvoice(string companyId, string branchId, string documentType, string documentId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_tipo_doc", documentType));
            parameters.Add(O7Parameter.Make("p_nro_doc", documentId));
            return DataAccess.ExecuteFunction<int>("finantial_invoice.delete_details", parameters);

        }
        public virtual int UpdateInvoiceHead(string companyId, string branchId,
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
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_tipo_doc", documentType));
            parameters.Add(O7Parameter.Make("p_nro_doc", documentId));
            parameters.Add(O7Parameter.Make("p_moneda", currency));
            parameters.Add(O7Parameter.Make("p_fecha_doc", documentDate));
            parameters.Add(O7Parameter.Make("p_fecha_vto", documentExpiration));
            parameters.Add(O7Parameter.Make("p_codcli", clienteCode));
            parameters.Add(O7Parameter.Make("p_cod_imp_afec", codTax));
            parameters.Add(O7Parameter.Make("p_por_imp_afec", porTax));
            parameters.Add(O7Parameter.Make("p_razon_social", clientName));
            parameters.Add(O7Parameter.Make("p_dir_fact", invoiceAddress));
            parameters.Add(O7Parameter.Make("p_nro_ruc", clientId));
            parameters.Add(O7Parameter.Make("p_glosa", glosa));
            parameters.Add(O7Parameter.Make("p_tipo_venta", sellType));
            parameters.Add(O7Parameter.Make("p_cod_idioma", language));
            parameters.Add(O7Parameter.Make("p_cond_venta", condSell));
            parameters.Add(O7Parameter.Make("p_forma_pago", payment));
            parameters.Add(O7Parameter.Make("p_linea_negocio", bussinessline));
            parameters.Add(O7Parameter.Make("p_cod_financiero", finantialcod));
            parameters.Add(O7Parameter.Make("p_nro_telefono", telephone));
            parameters.Add(O7Parameter.Make("p_cod_vendedor", seller));
            parameters.Add(O7Parameter.Make("p_cod_trabajador", employeeId));
            parameters.Add(O7Parameter.Make("p_porc_perc", perception));
            parameters.Add(O7Parameter.Make("p_donacion", donate));
            parameters.Add(O7Parameter.Make("p_doc_ref_1", documentTypeRef));
            parameters.Add(O7Parameter.Make("p_doc_ref_2", documentIdRef));
            parameters.Add(O7Parameter.Make("p_nro_oc", documentOC));
            parameters.Add(O7Parameter.Make("p_nro_gui_rem", guiRem));
            parameters.Add(O7Parameter.Make("p_coddir", addressId));
            parameters.Add(O7Parameter.Make("p_serdoceref", serieExtRef));
            parameters.Add(O7Parameter.Make("p_nrodoceref", nroExtRef));
            return DataAccess.ExecuteFunction<int>("finantial_invoice.update_invoice", parameters);

        }

        public virtual int AnularInvoice(string companyId, string branchId,
                                       string documentType, string documentId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_tipdoc", documentType));
            parameters.Add(O7Parameter.Make("p_nrodoc", documentId));
            return DataAccess.ExecuteFunction<int>("finantial_invoice.anula_documento", parameters);

        }

        public virtual int sendSunat(string companyId, string branchId,
                                      string documentType, string documentId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_tipdoc", documentType));
            parameters.Add(O7Parameter.Make("p_nrodoc", documentId));
            return DataAccess.ExecuteFunction<int>("finantial_invoice.sendSunat", parameters);

        }

        public virtual List<InvoiceHeadView> GetInvoiceHeadView(string companyId, string branchId, string documentType, string documentId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_tipdoc", documentType));
            parameters.Add(O7Parameter.Make("p_nrodoc", documentId));
            return DataAccess.ExecuteFunction<InvoiceHeadView>("finantial_invoice.view_invoicehead", parameters, InvoiceHeadViewMapper.Class);
        }

        public virtual List<LogFE> GetLogFE(string companyId, string branchId, string documentSerie, string documentExt)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_serie", documentSerie));
            parameters.Add(O7Parameter.Make("p_nrodoce", documentExt));
            return DataAccess.ExecuteFunction<LogFE>("finantial_invoice.getlogfe", parameters, LogFEMapper.Class);
        }

        public virtual List<InvoiceDetailView> GetInvoiceDetailView(string companyId, string branchId, string documentType, string documentId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_tipdoc", documentType));
            parameters.Add(O7Parameter.Make("p_nrodoc", documentId));
            return DataAccess.ExecuteFunction<InvoiceDetailView>("finantial_invoice.view_invoicedetail", parameters, InvoiceDetailViewMapper.Class);
        }


        public virtual List<InvoiceEdit> GetInvoice(string companyId, string branchId, string documentType, string documentId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_tipo_doc", documentType));
            parameters.Add(O7Parameter.Make("p_nro_doc", documentId));
            return DataAccess.ExecuteFunction<InvoiceEdit>("finantial_invoice.search_fact", parameters, InvoiceMapper.Class);
        }

        public virtual List<InvoiceDetail> GetInvoiceDetail(string companyId, string branchId, string documentType, string documentId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_tipo_doc", documentType));
            parameters.Add(O7Parameter.Make("p_nro_doc", documentId));
            return DataAccess.ExecuteFunction<InvoiceDetail>("finantial_invoice.search_fact_detail", parameters, InvoiceDetailMapper.Class);
        }

        public virtual List<InvoiceSeries> Series(string companyId, string branchId, string docType)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_tip_doc", docType));
            return DataAccess.ExecuteFunction<InvoiceSeries>("finantial_invoice.serie_ext_type", parameters, InvoiceSeriesMapper.Class);
        }

      
        public virtual Stream GenerateReporte(string companyId, string branchId, string documentType, string documentId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_tipdoc", documentType));
            parameters.Add(O7Parameter.Make("p_nrodoc", documentId));

            HeadInvoicePDF head =
              DataAccess.ExecuteFunction<HeadInvoicePDF>("finantial_invoice.head_pdf", parameters,
                  HeadInvoicePDFMapper.Class)[0];

            List<DetailInvoicePDF> details = DataAccess.ExecuteFunction<DetailInvoicePDF>("finantial_invoice.detail_pdf", parameters, DetailInvoicePDFMapper.Class);


            int result = DataAccess.ExecuteFunction<int>("finantial_invoice.facturar_electronica", parameters);


            return PdfGenerator.generar(head, details, "tura.pdf");
        }

        public virtual List<SingleValue> GetFecVto(string companyId, string branchId, string payment, string documentDate)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_fecha", documentDate));
            parameters.Add(O7Parameter.Make("p_cod_forp", payment));
            return DataAccess.ExecuteFunction<SingleValue>("finantial_invoice.calcular_fecha_vto", parameters, SingleValueMapper.Class);
        }

        public virtual List<SingleValue> DocumentInformation(string companyId, string branchId, string docType)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_tip_doc", docType));
            return DataAccess.ExecuteFunction<SingleValue>("finantial_invoice.confirm_doc", parameters, SingleValueMapper.Class);
        }

        public virtual List<ClientDefaultValues> ClientDefaultValues(string companyId, string branchId, string clientCode)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_codcli", clientCode));
            return DataAccess.ExecuteFunction<ClientDefaultValues>("finantial_invoice.confirm_client", parameters, ClientDefaultValueMapper.Class);
        }

        public virtual bool AddInvoiceDetail(
                                    string companyId, string branchId,
                                    string documentType, string documentId,
                                    string conceptId, string observacion,
                                    string cantidad, string unitValue,
                                    string taxId, string perception,
                                    string ccoId,string flgfin
                                                )
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_tipdoc", documentType));
            parameters.Add(O7Parameter.Make("p_nrodoc", documentId));
            parameters.Add(O7Parameter.Make("p_cod_concepto", conceptId));
            parameters.Add(O7Parameter.Make("p_observacion", observacion));
            parameters.Add(O7Parameter.Make("p_cantidad", cantidad));
            parameters.Add(O7Parameter.Make("p_val_unit", unitValue));
            parameters.Add(O7Parameter.Make("p_cod_imp", taxId));
            parameters.Add(O7Parameter.Make("p_perc", perception));
            parameters.Add(O7Parameter.Make("p_cen_cos", ccoId));
            parameters.Add(O7Parameter.Make("p_fin", flgfin));
            return DataAccess.ExecuteFunction<int>("finantial_invoice.insert_row_det_factura", parameters) == 1;
        }

        public virtual int AddInvoice(string companyId, string branchId,
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
                                       string guiRem, string addressId,
                                       string serieExtRef, string nroExtRef)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_tipo_doc", documentType));
            parameters.Add(O7Parameter.Make("p_serie_ext", serie));
            parameters.Add(O7Parameter.Make("p_moneda", currency));
            parameters.Add(O7Parameter.Make("p_fecha_doc", documentDate));
            parameters.Add(O7Parameter.Make("p_fecha_vto", documentExpiration));
            parameters.Add(O7Parameter.Make("p_codcli", clienteCode));
            parameters.Add(O7Parameter.Make("p_cod_imp_afec", codTax));
            parameters.Add(O7Parameter.Make("p_razon_social", clientName));
            parameters.Add(O7Parameter.Make("p_dir_fact", invoiceAddress));
            parameters.Add(O7Parameter.Make("p_nro_ruc", clientId));
            parameters.Add(O7Parameter.Make("p_glosa", glosa));
            parameters.Add(O7Parameter.Make("p_tipo_venta", sellType));
            parameters.Add(O7Parameter.Make("p_cod_idioma", language));
            parameters.Add(O7Parameter.Make("p_cond_venta", condSell));
            parameters.Add(O7Parameter.Make("p_forma_pago", payment));
            parameters.Add(O7Parameter.Make("p_linea_negocio", bussinessline));
            parameters.Add(O7Parameter.Make("p_cod_financiero", finantialcod));
            parameters.Add(O7Parameter.Make("p_nro_telefono", telephone));
            parameters.Add(O7Parameter.Make("p_cod_vendedor", seller));
            parameters.Add(O7Parameter.Make("p_cod_trabajador", employeeId));
            parameters.Add(O7Parameter.Make("p_doc_flag_out", "N"));
            parameters.Add(O7Parameter.Make("p_porc_perc", perception));
            parameters.Add(O7Parameter.Make("p_donacion", donate));
            parameters.Add(O7Parameter.Make("p_doc_ref_1", documentTypeRef));
            parameters.Add(O7Parameter.Make("p_doc_ref_2", documentIdRef));
            parameters.Add(O7Parameter.Make("p_nro_oc", documentOC));
            parameters.Add(O7Parameter.Make("p_nro_gui_rem", guiRem));
            parameters.Add(O7Parameter.Make("p_coddir", addressId));
            parameters.Add(O7Parameter.Make("p_serdoceref", serieExtRef));
            parameters.Add(O7Parameter.Make("p_nrodoceref", nroExtRef));
            return DataAccess.ExecuteFunction<int>("finantial_invoice.insert_cab_factura", parameters);
        }

    }
}