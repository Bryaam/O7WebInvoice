// Create by Felix A. Bueno

using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Utility;
using Angkor.O7Framework.Web.Model;
using Angkor.O7Framework.Web.Security;
using Angkor.O7Web.Data.Advisory;

namespace Angkor.O7Web.Domain.Advisory
{
    public class ActivityJsonDomain
    {
        private readonly ActivityDataService _dataService;
        private readonly O7Principal _principal;

        public ActivityJsonDomain(O7Principal principal) 
            : this(principal.Identity.Name, principal.Password)
        {
            _principal = principal;
        }

        public ActivityJsonDomain(string login, string password)
        {
            _dataService = new ActivityDataService(login, password);
        }

        public virtual O7Response InsertActivity(string centerCostId, string periodId, string activityStart, string activityDescription)
        {
            var result = _dataService.InsertActivity(_principal.Company, _principal.Branch, centerCostId, periodId,
                activityStart, activityDescription);
            var resultSerialized = O7JsonSerealizer.Serialize(result);
            return O7SuccessResponse.MakeResponse(resultSerialized);
        }

        public virtual O7Response GetActivies(string startDate, string endDate)
        {
            var result = _dataService.ListActivities(_principal.Company, _principal.Branch, startDate, endDate);
            var resultSerialized = O7JsonSerealizer.Serialize(result);
            return O7SuccessResponse.MakeResponse(resultSerialized);
        }

        public  O7Response GetReportActivities(string workerId, string workerName, string workerLastName,
            string workerSecondLastName, string costCenterId, string startActivity, string endActivity)
        {
            var result = _dataService.ListActivityReports(_principal.Company, _principal.Branch, workerId, workerName,
                workerLastName, workerSecondLastName, costCenterId, startActivity, endActivity);
            var resultSerialized = O7JsonSerealizer.Serialize(result);
            return O7SuccessResponse.MakeResponse(resultSerialized);
        }
    }
}