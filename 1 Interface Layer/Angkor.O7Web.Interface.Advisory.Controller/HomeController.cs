// Create by Felix A. Bueno

using System.Web.Mvc;
using Angkor.O7Framework.Web.Base;

namespace Angkor.O7Web.Interface.Advisory.Controller
{
    public class HomeController : O7Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}