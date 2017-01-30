// Create by Felix A. Bueno

using System.Web.Mvc;
using Angkor.O7Framework.Web.Base;
using Angkor.O7Framework.Web.WebResult;
using Angkor.O7Web.Domain.Advisory;

namespace Angkor.O7Web.Interface.Advisory.Controller
{
    public class ActivityController : O7Controller
    {
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult WorkerManagment()
        {
            return View();
        }

        [HttpPost]
        public JsonResult InsertActivity(string centerCostId, string periodId, string activityStart, string activityDescription)
        {
            //var domain = BasicFunction.InitialMethod<ActivityJsonDomain, FlowAdvisory>(User);
            //var domain = new ActivityJsonDomain(User);
            //return O7HttpResult.MakeJsonResult(domain.InsertActivity(centerCostId, periodId, activityStart, activityDescription));
            return null;
        }

        [HttpPost]
        public JsonResult ListCostCenter()
        {
            return null;
            //var domain = new ManagmentWebDomain(User);
            //return O7HttpResult.MakeJsonResult(domain.GetCentroCostos());
        }

        [HttpPost]
        public JsonResult ValidPeriod(string month, string year)
        {
            return null;
            //var domain = BasicFunction.InitialMethod<PeriodJsonDomain, FlowAdvisory>(User);
            //var domain = new PeriodJsonDomain(User);
            //return O7HttpResult.MakeJsonResult(domain.ValidPeriod(month, year));
        }

        [HttpPost]
        public JsonResult GetActivies(string startDate, string endDate)
        {
            return null;
            //var domain = BasicFunction.InitialMethod<ActivityJsonDomain, FlowAdvisory>(User);
            //var domain = new ActivityJsonDomain(User);
            //return O7HttpResult.MakeJsonResult(domain.GetActivies(startDate, endDate));
        }

        [HttpPost]
        public JsonResult GetReportActivities(string workerId, string workerName, string workerLastName,
            string workerSecondLastName, string costCenterId, string startActivity, string endActivity)
        {
            return null;
            //var domain = BasicFunction.InitialMethod<ActivityJsonDomain, FlowAdvisory>(User);
            //var domain = new ActivityJsonDomain(User);
            //var activities = domain.GetReportActivities(workerId, workerName, workerLastName,
            //workerSecondLastName, costCenterId, startActivity, endActivity);
            //return O7HttpResult.MakeJsonResult(activities);
        }
    }
}