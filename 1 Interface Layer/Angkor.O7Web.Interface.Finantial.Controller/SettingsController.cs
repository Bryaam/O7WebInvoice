﻿// O7ERP Web created by felix_dev

using Angkor.O7Framework.Web.Base;
using Angkor.O7Framework.Web.WebResult;
using Angkor.O7Web.Comunication;
using System.Web.Mvc;

namespace Angkor.O7Web.Interface.Finantial.Controller
{
    public class SettingsController : O7Controller
    {

        public JsonResult Ccos_Populate()
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.AllSeries(User.Company, User.Branch);
            return new O7JsonResult(response);
        }

        

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

        public ActionResult TableofTables()
        {
            return View();
        }
        public ActionResult CostCenters()
        {
            return View();
        }

        public JsonResult GetHeads(string codTable)
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.GetTTHeads(codTable);
            return new O7JsonResult(response);
        }

        public JsonResult GetData(string primaryCode,string secondCode)
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.GetTTData(primaryCode, secondCode);
            return new O7JsonResult(response);
        }

        public JsonResult GetTTNames()
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.GetTTNames();
            return new O7JsonResult(response);
        }

        public JsonResult InsertTTData(string codtabl,string key,string dato)
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.InsertTTData(codtabl,key,dato);
            return new O7JsonResult(response);
        }

        public JsonResult UpdateTTData(string codtabl, string key, string keynew, string dato)
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.UpdateTTData(codtabl,key,keynew,dato);
            return new O7JsonResult(response);
        }

        public JsonResult DeleteTTData(string codtabl, string key)
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.DeleteTTData(codtabl, key);
            return new O7JsonResult(response);
        }

        public JsonResult GetCcos()
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.GetCcos(User.Company, User.Branch);
            return new O7JsonResult(response);
        }





    }
}