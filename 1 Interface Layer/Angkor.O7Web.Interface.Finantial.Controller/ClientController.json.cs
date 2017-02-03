// O7ERP Web created by felix_dev
using System.Web.Mvc;
using Angkor.O7Framework.Web.WebResult;
using Angkor.O7Web.Comunication;

namespace Angkor.O7Web.Interface.Finantial.Controller
{
    public partial class ClientController
    {
        public JsonResult Index_PopulateClient(string filter)
        {
            var domain = ProxyDomain.Instance.ClientDomain(User.Identity.Name, User.Password);
            var response = domain.Clients(User.Company, User.Branch, filter);
            return new O7JsonResult(response);
        }

        public JsonResult AllRoute()
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);            
            var response = domain.AllRoute(User.Company, User.Branch);
            return new O7JsonResult(response);
        }

        public JsonResult AllPostales()
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.AllPostales();
            return new O7JsonResult(response);
        }

        public JsonResult AllClientZones(string countryId)
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.AllClientZones(countryId);
            return new O7JsonResult(response);
        }

        public JsonResult AllDepartments(string countryId)
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.AllDepartments(countryId);
            return new O7JsonResult(response);
        }

        public JsonResult AllProvinces(string countryId, string departmentId)
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.AllProvinces(countryId, departmentId);
            return new O7JsonResult(response);
        }

        public JsonResult AllDistricts(string countryId, string departmentId, string provinceId)
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.AllDistricts(countryId, departmentId, provinceId);
            return new O7JsonResult(response);
        }

        public JsonResult AllCountries()
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.AllCountries(User.Company, User.Branch);
            return new O7JsonResult(response);
        }

        public JsonResult ClientOrigins()
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.ClientOrigins();
            return new O7JsonResult(response);
        }

        public JsonResult ClientStates()
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.ClientStates();
            return new O7JsonResult(response);
        }

        public JsonResult DocumentType(string clientType)
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.DocumentType(clientType);
            return new O7JsonResult(response);
        }

        [HttpPost]
        public JsonResult ClientChangeState(string clientId)
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.ClientChangeState(User.Company, User.Branch, clientId);
            return new O7JsonResult(response);
        }

        public JsonResult ClientType()
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.ClientType();
            return new O7JsonResult(response);
        }

        public JsonResult InvoicerAddressPopulate(string clientId)
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.ViewAddressFact(User.Company, User.Branch, clientId);
            return new O7JsonResult(response);
        }

        public JsonResult EntryAddressPopulate(string clientId)
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.ViewAddressEntry(User.Company, User.Branch, clientId);
            return new O7JsonResult(response);
        }

        public JsonResult Client_Populate(string filter)
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.AllClients(User.Company, User.Branch, filter);
            return new O7JsonResult(response);
        }
    }
}