// O7ERP Web created by felix_dev

using System.Collections.Generic;
using System.Web.Mvc;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Utility;
using Angkor.O7Framework.Web.Base;
using Angkor.O7Framework.Web.WebResult;
using Angkor.O7Web.Common.Finantial.Entity;
using Angkor.O7Web.Comunication;

namespace Angkor.O7Web.Interface.Finantial.Controller
{
    public partial class ClientController : O7Controller
    {
        public ActionResult Index()
        {
            return View();
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
            var clientId = Request.Form["txtClientId"];
            var typeClient = Request.Form["chkOriginClient"];
            var businessName = Request.Form["txtName"];
            var person = Request.Form["chkpersonType"];
            var stateClient = Request.Form["chkClientState"];
            var ruc = Request.Form["txtRuc"];
            var dni = Request.Form["txtDocumentNumber"];
            var country = Request.Form["chkCountry"];
            var zone = Request.Form["chkZone"];
            var address = Request.Form["txtAddress"];
            var codPost = Request.Form["chkPostale"];
            var city = Request.Form["txtCity"];
            var phone = Request.Form["txtPhone"];
            var initialDate = Request.Form["dpckRegister"];
            var email = Request.Form["txtEmail"];
            var ubigeoDep = Request.Form["chkDepartment"];
            var ubigeoProv = Request.Form["chkProvince"];
            var ubigeoDist = Request.Form["chkDistrict"];
            var jAddressFact = InsertAddressFact();
            var jAddressEnt = InsertAddressEnt();

            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.UpdateClient(User.Company, User.Branch, clientId, typeClient, businessName, person,
                             stateClient, ruc, dni, country, zone, address, codPost, city, phone, initialDate, email, ubigeoDep,
                             ubigeoProv, ubigeoDist);            

            for (var i = 0; i < jAddressFact.Count; i++)
            {
                var entrega = jAddressFact[i];

                domain.UpdateAddressFact(User.Company, User.Branch, clientId, "codDir",entrega.Address,
                    entrega.CodPostal, entrega.Department, entrega.Province, entrega.District, entrega.Country, entrega.City,
                    entrega.Zone, entrega.Route, entrega.Phone, entrega.Fax, entrega.Contact);

                if (i == 0)
                {
                    domain.UpdatePrincipalAddressFact(User.Company, User.Branch, clientId, "codDir", entrega.Address,entrega.CodPostal, entrega.Department, 
                        entrega.Province, entrega.District, entrega.Country, entrega.City,entrega.Zone, entrega.Route, entrega.Phone, entrega.Fax, entrega.Contact);
                }
            }

            for (var i = 0; i < jAddressEnt.Count; i++)
            {
                var entrega = jAddressEnt[i];

                domain.UpdateAddressEntry(User.Company, User.Branch, clientId, "codDir", entrega.Address,entrega.CodPostal, entrega.Department, entrega.Province, 
                    entrega.District, entrega.Country, entrega.City,entrega.Zone, entrega.Route, entrega.Phone, entrega.Fax, entrega.Contact);

                if (i == 0)
                {
                    domain.UpdatePrincipalAddressEnt(User.Company, User.Branch, clientId, "codDir", entrega.Address, entrega.CodPostal, entrega.Department,
                        entrega.Province, entrega.District, entrega.Country, entrega.City, entrega.Zone, entrega.Route, entrega.Phone, entrega.Fax, entrega.Contact);
                }
            }

            return View("Index");
        }

        [HttpPost]
        [ActionName("Insert")]
        public ActionResult InsertClient()
        {
            var typeClient = Request.Form["chkOriginClient"];
            var businessName = Request.Form["txtName"];
            var person = Request.Form["chkpersonType"];
            var stateClient = Request.Form["chkClientState"];
            var ruc = Request.Form["txtRucNumber"];
            var dni = Request.Form["txtDocumentNumber"];
            var country = Request.Form["chkCountry"];
            var zone = Request.Form["chkZone"];
            var address = Request.Form["txtAddress"];
            var codPost = Request.Form["chkPostale"];
            var city = Request.Form["txtCity"];
            var phone = Request.Form["txtPhone"];
            var initialDate = Request.Form["dpckRegister"];
            var email = Request.Form["txtEmail"];
            var ubigeoDep = Request.Form["chkDepartment"];
            var ubigeoProv = Request.Form["chkProvince"];
            var ubigeoDist = Request.Form["chkDistrict"];
            var documentType = Request.Form["chkDocumentType"];
            var jAddressFact = InsertAddressFact();
            var jAddressEnt = InsertAddressEnt();
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.AddClient(User.Company, User.Branch, typeClient, businessName, person,
                             stateClient, ruc, dni, country, zone, address, codPost, city, phone, initialDate, email, ubigeoDep,
                             ubigeoProv, ubigeoDist, documentType);

            var clientId = ((O7SuccessResponse<string>) response).Value1;

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

                domain.AddAddressEnt(User.Company, User.Branch, clientId, entrega.Address,entrega.CodPostal, entrega.Department, entrega.Province, entrega.District, 
                    entrega.Country, entrega.City,entrega.Zone, entrega.Route, entrega.Phone, entrega.Fax, entrega.Contact);

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
            return new AddressFact(Request.Form["txtReciberAddress_" + count],
                Request.Form["txtReciberPostal_" + count],
                Request.Form["txtReciberDepartment_" + count],
                Request.Form["txtReciberProvince_" + count],
                Request.Form["txtReciberDistrict_" + count],
                Request.Form["txtReciberCity_" + count],
                Request.Form["txtReciberCountry_" + count],
                Request.Form["txtReciberZone_" + count],
                Request.Form["txtReciberRoute_" + count],
                Request.Form["txtReciberPhone_" + count],
                Request.Form["txtReciberFax_" + count],
                Request.Form["txtReciberContact_" + count]);
        }

        private AddressEnt make_entity(int count)
        {
            return new AddressEnt(Request.Form["txtReciberAddress_" + count], 
                Request.Form["txtReciberPostal_" + count], 
                Request.Form["txtReciberDepartment_" + count],
                Request.Form["txtReciberProvince_" + count], 
                Request.Form["txtReciberDistrict_" + count], 
                Request.Form["txtReciberCity_" + count], 
                Request.Form["txtReciberCountry_" + count], 
                Request.Form["txtReciberZone_" + count], 
                Request.Form["txtReciberRoute_" + count], 
                Request.Form["txtReciberPhone_" + count], 
                Request.Form["txtReciberFax_" + count], 
                Request.Form["txtReciberContact_" + count]);
        }
               
        public JsonResult OneClient_Populate(string codClient)
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.ViewClient(User.Company,User.Branch,codClient);
            return new O7JsonResult(response);
        }
        
    }
}