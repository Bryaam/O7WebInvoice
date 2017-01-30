// O7ERP Web created by felix_dev
using System.Web.Mvc;
using Angkor.O7Framework.Web.Base;
using Angkor.O7Framework.Web.WebResult;
using Angkor.O7Web.Comunication;

namespace Angkor.O7Web.Interface.Finantial.Controller
{
    public class SettingsController : O7Controller
    {
        public JsonResult InvoiceDocuments_Populate()
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.AllSeries(User.Company, User.Branch);
            return new O7JsonResult(response);
        }

        public JsonResult DocumentTypes()
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.DocumentTypes();
            return new O7JsonResult(response);
        }

        public JsonResult AddSeries(string documentType, string id, string current, string max, string min, 
            string @default, string prefix)
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.AddSeries(User.Company, User.Branch, documentType, id, current, max, min, @default, prefix);
            return new O7JsonResult(response);
        }

        public JsonResult UpdateSeries(string documentType, string id, string current, string max, string min, 
            string @default, string prefix, string idUpdate, string documentTypeUpdate)
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.UpdateSeries(User.Company, User.Branch, documentType, id, current, max, min, @default, prefix,
                idUpdate, documentTypeUpdate);
            return new O7JsonResult(response);
        }

        public ActionResult InvoiceDocuments()
        {
            return View();
        }
    }
}