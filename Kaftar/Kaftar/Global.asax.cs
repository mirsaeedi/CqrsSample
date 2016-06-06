using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Avicenna.Domain.Domain.Events;
using Kaftar;
using Kaftar.Core.Domain.Domain.Events.Base;
using Kaftar.Core.MessageBroker.Core;
using Kaftar.RuntimePolicyInjection.Core;

namespace Avicenna.Application
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            PolicyInjectionBootstrapper.DiscoverPolicies();

            CompositionRoot.Config();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }



}
