using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using CqrsSample.CommandStack;
using CqrsSample.CQRS.CommandStack;
using CqrsSample.CQRS.CommandStack.CommandHandlers;
using CqrsSample.CQRS.QueryStack;
using CqrsSample.Data.DataContext;
using CqrsSample.FineBusiness.Data;
using CqrsSample.QueryStack.QueryHandler;

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