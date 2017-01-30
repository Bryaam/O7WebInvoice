// O7ERP Web created by felix_dev
using Angkor.O7Framework.Infrastructure;
using Angkor.O7Web.Domain.Common;
using Angkor.O7Web.Domain.Finantial;
using Angkor.O7Web.Domain.Finantial.Base;
using Angkor.O7Web.Domain.Security;
using Angkor.O7Web.Domain.Security.Base;

namespace Angkor.O7Web.Comunication
{
    public class ProxyDomain
    {
        private static ProxyDomain _proxy;

        private ProxyDomain() { }

        public static ProxyDomain Instance 
            => _proxy ?? (_proxy = new ProxyDomain());

        public SecurityDomain SecurityDomain(string login, string password)
        {
            var argDomain = new object[] { login, password };
            var argFlow = new object[] { login };
            return O7DomainInstanceMaker.MakeInstance<SecurityFlow, BasicFlow>(argDomain, argFlow);
        }

        public FinantialDomain FinantialDomain(string login, string password)
        {
            var argDomain = new object[] { login, password };
            var argFlow = new object[] { login };
            return O7DomainInstanceMaker.MakeInstance<FinantialFlow, BasicFlow>(argDomain, argFlow);
        }

        public InvoiceDomain InvoiceDomain(string login, string password)
        {
            var argDomain = new object[] { login, password };
            var argFlow = new object[] { login };
            return O7DomainInstanceMaker.MakeInstance<InvoiceDomain, BasicFlow>(argDomain, argFlow);
        }


    }
}