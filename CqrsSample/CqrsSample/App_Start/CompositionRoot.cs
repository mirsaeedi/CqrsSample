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

            builder
                .RegisterType<QueryDispatcher>()
                .InstancePerRequest();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .AsClosedTypesOf(typeof(IQueryHandler<,>));

            builder
                .RegisterType<CommandDispatcher>()
                .InstancePerRequest();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .AsClosedTypesOf(typeof(ICommandHandler<,>));

            builder
                .Register((c) => {
                    var dbContext = new FineBusinessContext();
                    return dbContext;
                })
                .As<DbContextBase>()
                .InstancePerRequest();

            builder.RegisterType<DataContext>()
                .AsImplementedInterfaces();

            builder.RegisterType<ReadOnlyDataContext>()
                .AsImplementedInterfaces();

            builder.RegisterType<SetDataContext>()
                .AsImplementedInterfaces();



            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}