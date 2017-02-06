// O7ERP Web created by felix_dev
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Infrastructure;
using Angkor.O7Web.Data.Common;

namespace Angkor.O7Web.Domain.Common.Base
{
    public abstract class DeliverDomain
    {
        public DeliverDataService DeliverDataService { get; private set; }

        protected DeliverDomain(string login, string password)
        {
            DeliverDataService = O7DataInstanceMaker.MakeInstance<DeliverDataService>(new object[] { login, password });
        }

        public abstract O7Response Routes(string companyId, string branchId);
        
        public abstract O7Response Postals { get; }

        public abstract O7Response Zones(string countryId);

        public abstract O7Response Countries(string companyId, string branchId);

        public abstract O7Response Deparments(string countryId);

        public abstract O7Response Provinces(string countryId, string deparmentId);

        public abstract O7Response Districts(string countryId, string deparmentId, string provinceId);
    }
}