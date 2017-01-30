// Create by Felix A. Bueno

using Angkor.O7Framework.Web.Model;
using Angkor.O7Framework.Web.Security;
using Angkor.O7Web.Data.Advisory;

namespace Angkor.O7Web.Domain.Advisory
{    
    public class PeriodWebDomain
    {
        private readonly PeriodDataService _dataService;
        private readonly O7Principal _principal;

        public PeriodWebDomain(O7Principal principal) 
            : this(principal.Identity.Name, principal.Password)
        {
            _principal = principal;
        }

        public PeriodWebDomain(string login, string password)
        {
            _dataService = new PeriodDataService(login, password);
        }        
    }
}