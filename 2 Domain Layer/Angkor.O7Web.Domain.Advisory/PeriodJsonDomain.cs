// Create by Felix A. Bueno

using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Utility;
using Angkor.O7Framework.Web.Model;
using Angkor.O7Framework.Web.Security;
using Angkor.O7Web.Data.Advisory;

namespace Angkor.O7Web.Domain.Advisory
{
    public class PeriodJsonDomain
    {
        private readonly PeriodDataService _dataService;
        private readonly O7Principal _principal;

        public PeriodJsonDomain(O7Principal principal) 
            : this(principal.Identity.Name, principal.Password)
        {
            _principal = principal;
        }

        public PeriodJsonDomain(string login, string password)
        {
            _dataService = new PeriodDataService(login, password); 
        }

        public virtual O7Response RecordedPeriods()
        {
            var periods = _dataService.ListPeriods(_principal.Company, _principal.Branch);
            var periodsSerialized = O7JsonSerealizer.Serialize(periods);
            return O7SuccessResponse.MakeResponse(periodsSerialized);
        }

        public virtual O7Response ListAvalibleYears()
        {
            var years = _dataService.ListAvalibleYears(_principal.Company, _principal.Branch);
            var yearsSerialized = O7JsonSerealizer.Serialize(years);
            return O7SuccessResponse.MakeResponse(yearsSerialized);
        }

        public virtual O7Response ActivateYear(string year)
        {
            var response = _dataService.ActivateYear(_principal.Company, _principal.Branch, year);
            var responseSerialized = O7JsonSerealizer.Serialize(response);
            return O7SuccessResponse.MakeResponse(responseSerialized);
        }

        public virtual O7Response OpenPeriod(string periodId)
        {
            var response = _dataService.OpenPeriod(_principal.Company, _principal.Branch, periodId);
            var responseSerialized = O7JsonSerealizer.Serialize(response);
            return O7SuccessResponse.MakeResponse(responseSerialized);
        }

        public virtual O7Response ValidPeriod(string month, string year)
        {
            var response = _dataService.ValidPeriod(_principal.Company, _principal.Branch, month, year);
            var responseSerialized = O7JsonSerealizer.Serialize(response);
            return O7SuccessResponse.MakeResponse(responseSerialized);
        }

        public virtual O7Response ClosePeriod(string periodId)
        {
            var response = _dataService.ClosePeriod(_principal.Company, _principal.Branch, periodId);
            var responseSerialized = O7JsonSerealizer.Serialize(response);
            return O7SuccessResponse.MakeResponse(responseSerialized);
        }
    }
}