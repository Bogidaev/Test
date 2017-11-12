using Castle.Windsor;
using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace PetStar.Factorys
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IWindsorContainer container;

        public WindsorControllerFactory(IWindsorContainer container)
        {
            this.container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            GlobalConfiguration.Configuration.DependencyResolver.BeginScope();
            return (IController)container.Resolve(controllerType);
        }
    }
}