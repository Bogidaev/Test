using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using Castle.Windsor;
using PetStar.Factorys;
using PetStar.Installers;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PetStar
{
    public class WebApiApplication : HttpApplication
    {
        private readonly IWindsorContainer container;

        //public WebApiApplication()
        //{
        //    this.container = new WindsorContainer().Install(new WebWindsorInstaller());
        //}

        protected void Application_Start()
        {
            var container = ContainerFactory.GetCurrent();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));

            //GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(
            //    new QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));

            //GlobalConfiguration.Configuration.Formatters.XmlFormatter.MediaTypeMappings.Add(
            //    new QueryStringMapping("type", "xml", new MediaTypeHeaderValue("application/xml")));
        }
    }
}
