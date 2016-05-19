using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;

namespace CqrsSample
{
    public class CompositionRoot
    {
        public static void Config()
        {
            var builder = new ContainerBuilder();

            var config = GlobalConfiguration.Configuration;
            builder.RegisterWebApiFilterProvider(config);

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly())
                .PropertiesAutowired();

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}