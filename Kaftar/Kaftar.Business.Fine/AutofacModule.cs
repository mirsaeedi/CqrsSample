using System.Reflection;
using Autofac;
using Avicenna.Domain.Data;
using Kaftar.Core.CQRS.CommandStack.CommandHandlers;
using Kaftar.Core.CQRS.QueryStack.QueryHandler;
using Kaftar.Core.Data.DataContext;
using Module = Autofac.Module;

namespace Avicenna.Domain
{
    public class AutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assmeblyName = Assembly.GetExecutingAssembly().GetName();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsClosedTypesOf(typeof(IQueryHandler<,>))
                .PropertiesAutowired();


            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .AsClosedTypesOf(typeof(ICommandHandler<,>))
                   .PropertiesAutowired();

            builder
                .Register((c) => {
                    var dbContext = new AvicennaContext();
                    return dbContext;
                })
                .As<DbContextBase>()
                .InstancePerRequest()
                .WithMetadata("assembly_name", assmeblyName);
        }
    }
}
