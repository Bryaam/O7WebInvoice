// O7ERP Web created by felix_dev
using System.Collections.Generic;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Framework.Infrastructure.Data;
using Angkor.O7Web.Data.Common.Entity;

namespace Angkor.O7Web.Data.Common
{
    public class DeliverDataService : O7AbstractData
    {
        public DeliverDataService(string user, string password) : base(user, password)
        {
        }

        public virtual List<BasicDbEntity> Routes(string companyId, string branchId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            return DataAccess.Execute<BasicDbEntity>("pkg_address_data.get_routes", parameters);
        }

        public virtual List<BasicDbEntity> Postals 
            => DataAccess.Execute<BasicDbEntity>("pkg_address_data.get_postals");

        public virtual List<BasicDbEntity> Zones(string countryId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_country", countryId));
            return DataAccess.Execute<BasicDbEntity>("pkg_address_data.get_zones", parameters);
        }

        public virtual List<BasicDbEntity> Countries(string companyId, string branchId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            return DataAccess.Execute<BasicDbEntity>("pkg_address_data.get_countries", parameters);
        }

        public virtual List<BasicDbEntity> Deparments(string countryId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_country", countryId));
            return DataAccess.Execute<BasicDbEntity>("pkg_address_data.get_departments", parameters);
        }

        public virtual List<BasicDbEntity> Provinces(string countryId, string deparmentId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_country", countryId));
            parameters.Add(O7Parameter.Make("p_department", deparmentId));
            return DataAccess.Execute<BasicDbEntity>("pkg_address_data.get_provinces", parameters);
        }

        public virtual List<BasicDbEntity> Districts(string countryId, string deparmentId, string provinceId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_country", countryId));
            parameters.Add(O7Parameter.Make("p_department", deparmentId));
            parameters.Add(O7Parameter.Make("p_province", provinceId));
            return DataAccess.Execute<BasicDbEntity>("pkg_address_data.get_districts", parameters);
        }
    }
}