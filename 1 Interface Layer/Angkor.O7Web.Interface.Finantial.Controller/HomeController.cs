// Create by Felix A. Bueno

using System.Web.Mvc;
using Angkor.O7Framework.Web.Attributes;
using Angkor.O7Framework.Web.Base;

namespace Angkor.O7Web.Interface.Finantial.Controller
{
    public class HomeController : O7Controller
    {
        [ExcludeFilter]
        public ActionResult Index()
        {
            return View();
        }
    }
}