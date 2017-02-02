// O7ERP Web created by felix_dev
using System.Collections.Generic;
using System.Web.Mvc;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Web.Base;
using Angkor.O7Framework.Web.Utility;
using Angkor.O7Framework.Web.WebResult;
using Angkor.O7Web.Common.Finantial.Entity;
using Angkor.O7Web.Comunication;

namespace Angkor.O7Web.Interface.Finantial.Controller
{
    public partial class ClientController : O7Controller
    {
        public JsonResult ValidateCountryInvoicer(string countryId)
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.ValidateCountryInvoicer(countryId);
            return new O7JsonResult(response);            
        }

        public JsonResult ValidateCountryEntry(string countryId)
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.ValidateCountryEntry(countryId);
            return new O7JsonResult(response);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewDetail(string idClient)
        {
            ViewData["action"] = "3";
            ViewData["idClient"] = idClient;
            return View("Managment");
        }

        public ActionResult Insert()
        {
            ViewData["action"] = "1";
            return View("Managment");
        }

        public ActionResult Edit(string idClient)
        {
            ViewData["action"] = "2";
            ViewData["idClient"] = idClient;
            return View("Managment");
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditClient()
        {
            var values = Request.Form.ParametersValue("txtClientId", "chkOriginClient", "txtName", "chkpersonType", "chkClientState", "txtRucNumber", "txtDocumentNumber", "chkCountry",
                 "chkZone", "txtAddress", "chkPostale", "txtCity", "txtPhone", "dpckRegister", "txtEmail", "chkDepartment", "chkProvince", "chkDistrict", "chkDocumentType");

            var jAddressFact = InsertAddressFact();
            var jAddressEnt = InsertAddressEnt();


            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.UpdateClient(User.Company, User.Branch, values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7],
                values[8], values[9], values[10], values[11], values[12], values[13], values[14], values[15], values[16], values[17], values[18]);

            for (var i = 0; i < jAddressFact.Count; i++)
            {
                var entrega = jAddressFact[i];

                domain.UpdateAddressFact(User.Company, User.Branch, values[0], entrega.CodDir, null, null, entrega.Contact, entrega.Country,
                    entrega.Zone, entrega.Address, entrega.CodPostal, entrega.City, entrega.Phone, entrega.Department, entrega.Province,
                    entrega.District);

                if (i == 0)
                {
                    domain.SavePrincipalAddressFact(User.Company, User.Branch, values[0], entrega.Address);
                }
            }

            for (var i = 0; i < jAddressEnt.Count; i++)
            {
                var entrega = jAddressEnt[i];

                domain.UpdateAddressEntry(User.Company, User.Branch, values[0], entrega.CodDir, null, null, entrega.Contact, entrega.Country,
                    entrega.Zone, entrega.Address, entrega.CodPostal, entrega.City, entrega.Phone, entrega.Department, entrega.Province,
                    entrega.District);

                if (i == 0)
                {
                    domain.SavePrincipalAddressEnt(User.Company, User.Branch, values[0], entrega.Address);
                }
            }

            return View("Index");
        }

        [HttpPost]
        [ActionName("Insert")]
        public ActionResult InsertClient()
        {
            var values = Request.Form.ParametersValue("chkOriginClient", "txtName", "chkpersonType", "chkClientState", "txtRucNumber", "txtDocumentNumber",
                "dpckRegister", "txtEmail", "chkCountry", "chkZone", "txtAddress", "chkPostale", "txtCity", "txtPhone", "chkDepartment", "chkProvince", "chkDistrict", "chkDocumentType");
            var jAddressFact = InsertAddressFact();
            var jAddressEnt = InsertAddressEnt();
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.AddClient(User.Company, User.Branch, values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7],
                values[8], values[9], values[10], values[11], values[12], values[13], values[14], values[15], values[16], values[17]);

            var clientId = ((O7SuccessResponse<string>)response).Value1;

            clientId = clientId.Substring(1, clientId.Length - 2);

            for (var i = 0; i < jAddressFact.Count; i++)
            {
                var entrega = jAddressFact[i];

                domain.AddAddressFact(User.Company, User.Branch, clientId, entrega.Address,
                    entrega.CodPostal, entrega.Department, entrega.Province, entrega.District, entrega.Country, entrega.City,
                    entrega.Zone, entrega.Route, entrega.Phone, entrega.Fax, entrega.Contact);

                if (i == 0)
                {
                    domain.SavePrincipalAddressFact(User.Company, User.Branch, clientId, entrega.Address);
                }
            }

            for (var i = 0; i < jAddressEnt.Count; i++)
            {
                var entrega = jAddressEnt[i];

                domain.AddAddressEnt(User.Company, User.Branch, clientId, entrega.Address, entrega.CodPostal, entrega.Department, entrega.Province, entrega.District,
                    entrega.Country, entrega.City, entrega.Zone, entrega.Route, entrega.Phone, entrega.Fax, entrega.Contact);

                if (i == 0)
                {
                    domain.SavePrincipalAddressEnt(User.Company, User.Branch, clientId, entrega.Address);
                }
            }

            return View("Index");
        }

        private List<AddressEnt> InsertAddressEnt()
        {
            var keys = Request.Form.AllKeys;
            var count = -1;
            foreach (var key in keys)
            {
                if (key.Contains("txtReciberAddress_")) count++;
            }
            var result = new List<AddressEnt>();
            for (int i = 0; i <= count; i++)
            {
                result.Add(make_entity(i));
            }
            return result;
        }


        public List<AddressFact> InsertAddressFact()
        {
            var keys = Request.Form.AllKeys;
            var count = -1;
            foreach (var key in keys)
            {
                if (key.Contains("txtInvoicerAddress_")) count++;
            }
            var result = new List<AddressFact>();
            for (int i = 0; i <= count; i++)
            {
                result.Add(make_entity2(i));
            }
            return result;
        }

        private AddressFact make_entity2(int count)
        {
            return new AddressFact(Request.Form["txtInvoicerCode_" + count],
                Request.Form["txtInvoicerAddress_" + count],
                Request.Form["txtInvoicerPostal_" + count],
                Request.Form["txtInvoicerDepartmentId_" + count],
                Request.Form["txtInvoicerProvinceId_" + count],
                Request.Form["txtInvoicerDistrictId_" + count],
                Request.Form["txtInvoicerCity_" + count],
                Request.Form["txtInvoicerCountryId_" + count],
                Request.Form["txtInvoicerZoneId_" + count],
                Request.Form["txtInvoicerRoute_" + count],
                Request.Form["txtInvoicerPhone_" + count],
                Request.Form["txtInvoicerFax_" + count],
                Request.Form["txtInvoicerContact_" + count]);
        }

        private AddressEnt make_entity(int count)
        {
            return new AddressEnt(Request.Form["txtInvoicerCode_" + count],
                Request.Form["txtReciberAddress_" + count],
                Request.Form["txtReciberPostal_" + count],
                Request.Form["txtReciberDepartmentId_" + count],
                Request.Form["txtReciberProvinceId_" + count],
                Request.Form["txtReciberDistrictId_" + count],
                Request.Form["txtReciberCity_" + count],
                Request.Form["txtReciberCountryId_" + count],
                Request.Form["txtReciberZoneId_" + count],
                Request.Form["txtReciberRoute_" + count],
                Request.Form["txtReciberPhone_" + count],
                Request.Form["txtReciberFax_" + count],
                Request.Form["txtReciberContact_" + count]);
        }

        public JsonResult OneClient_Populate(string codClient)
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.ViewClient(User.Company, User.Branch, codClient);
            return new O7JsonResult(response);
        }

    }
}