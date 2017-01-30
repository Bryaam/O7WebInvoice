// O7ERP Web created by felix_dev

using System;
using System.Web.Mvc;
using System.Web.Routing;
using Angkor.O7Web.Domain.Security;
using Angkor.O7Web.Domain.Security.Base;

namespace Angkor.O7Web.Interface.AppStart.Controller.Security
{
    public class AuthenticationStartController : DefaultControllerFactory
    {
        private SecurityDomain _domain;

        public AuthenticationStartController()
        {            
        }

        /// <summary>Retrieves the controller instance for the specified request context and controller type.</summary>
        /// <returns>The controller instance.</returns>
        /// <param name="requestContext">The context of the HTTP request, which includes the HTTP context and route data.</param>
        /// <param name="controllerType">The type of the controller.</param>
        /// <exception cref="T:System.Web.HttpException">
        /// <paramref name="controllerType" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="controllerType" /> cannot be assigned.</exception>
        /// <exception cref="T:System.InvalidOperationException">An instance of <paramref name="controllerType" /> cannot be created.</exception>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            
            return base.GetControllerInstance(requestContext, controllerType);
        }
    }
}