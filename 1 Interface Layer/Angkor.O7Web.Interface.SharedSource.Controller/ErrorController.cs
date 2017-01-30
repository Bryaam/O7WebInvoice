// Create by Felix A. Bueno

using System.Web.Mvc;

namespace Angkor.O7Web.Interface.SharedSource.Controller
{
    public class ErrorController : System.Web.Mvc.Controller
    {
        public ActionResult ServerError()
        {
            return View();
        }

        public ActionResult AuthorizationError()
        {
            return View();
        }

        public ActionResult UnfoundError()
        {
            return View();
        }
    }
}