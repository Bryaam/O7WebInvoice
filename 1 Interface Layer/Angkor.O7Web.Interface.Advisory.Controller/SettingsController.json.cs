// Create by Felix A. Bueno

using System.Web.Mvc;
using Angkor.O7Framework.Web.WebResult;
using Angkor.O7Web.Domain.Advisory;

namespace Angkor.O7Web.Interface.Advisory.Controller
{
    public partial class SettingsController
    {
        [HttpPost]
        public JsonResult PeriodsAvalible()
        {
            //var domain = BasicFunction.InitialMethod<PeriodJsonDomain, FlowAdvisory>(User);
            //var domain = new PeriodJsonDomain(User);
            //return O7HttpResult.MakeJsonResult(domain.RecordedPeriods());
            return null;
        }

        [HttpPost]
        public JsonResult YearsAvalible()
        {
            //var domain = BasicFunction.InitialMethod<PeriodJsonDomain, FlowAdvisory>(User);
            //var domain = new PeriodJsonDomain(User);
            //return O7HttpResult.MakeJsonResult(domain.ListAvalibleYears());
            return null;
        }

        [HttpPost]
        public JsonResult OpenYear(string year)
        {
            //var domain = BasicFunction.InitialMethod<PeriodJsonDomain, FlowAdvisory>(User);
            //var domain = new PeriodJsonDomain(User);
            //return O7HttpResult.MakeJsonResult(domain.ActivateYear(year));
            return null;
        }

        [HttpPost]
        public JsonResult OpenPeriod(string periodId)
        {
            //var domain = BasicFunction.InitialMethod<PeriodJsonDomain, FlowAdvisory>(User);
            //var domain = new PeriodJsonDomain(User);
            //return O7HttpResult.MakeJsonResult(domain.OpenPeriod(periodId));
            return null;
        }

        [HttpPost]
        public JsonResult ClosePeriod(string periodId)
        {
            //var domain = BasicFunction.InitialMethod<PeriodJsonDomain, FlowAdvisory>(User);
            //var domain = new PeriodJsonDomain(User);
            //return O7HttpResult.MakeJsonResult(domain.ClosePeriod(periodId));
            return null;
        }
        
    }
}