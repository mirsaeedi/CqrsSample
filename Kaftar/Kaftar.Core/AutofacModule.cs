using System.Reflection;
using Autofac;
using Kaftar.Core.CQRS.CommandStack;
using Kaftar.Core.CQRS.CommandStack.CommandHandlers;
using Kaftar.Core.CQRS.QueryStack;
using Kaftar.Core.CQRS.QueryStack.QueryHandler;
using Kaftar.Core.Data.DataContext;
using Module = Autofac.Module;

namespace Kaftar.Core
{
    public class AutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<QueryDispatcher>();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .AsClosedTypesOf(typeof(IQueryHandler<,>))
                   .PropertiesAutowired();

            builder
                .RegisterType<CommandDispatcher>();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .AsClosedTypesOf(typeof(ICommandHandler<,>))
                   .PropertiesAutowired();

            builder.RegisterType<DataContext>()
                .AsImplementedInterfaces();

            builder.RegisterType<ReadOnlyDataContext>()
                .AsImplementedInterfaces();

            builder.RegisterType<SetDataContext>()
                .AsImplementedInterfaces();
        }
    }
}
