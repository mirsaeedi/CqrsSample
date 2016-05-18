using System;
using System.Threading.Tasks;
using Autofac;
using CqrsSample.Core.CQRS.CommandStack.CommandHandlers;
using CqrsSample.Core.CQRS.CommandStack.CommandHandlers.CRUDCommandHandlers;
using CqrsSample.Core.CQRS.CommandStack.Commands;
using CqrsSample.Core.CQRS.CommandStack.Commands.CRUDCommands;
using CqrsSample.Core.Data.DataContext;

namespace CqrsSample.Core.CQRS.CommandStack
{
    public class CommandDispatcher: ICommandDispatcher
    {
        private readonly IComponentContext _context;

        public CommandDispatcher(IComponentContext context)
        {
            _context = context;
        }


        public async Task<CqrsCommandResult> Dispatch<TCommand>(TCommand command, int userId, string ip)
            where TCommand : CqrsCommand
        {
            try
            {
                if (command.GetType().GetGenericTypeDefinition() == typeof(CreateCqrsCommand<>))
                {
                    var handlerType = typeof(CreateCommandHandler<>);
                    return await HandlerCrudCommands(handlerType, command,userId,ip);
                }

                if (command.GetType().GetGenericTypeDefinition() == typeof(UpdateCqrsCommand<>))
                {
                    var handlerType = typeof(UpdateCqrsCommand<>);
                    return await HandlerCrudCommands(handlerType, command, userId, ip);
                }


                if (command.GetType().GetGenericTypeDefinition() == typeof (DeleteCqrsCommand<>))
                {
                    var handlerType = typeof(DeleteCqrsCommand<>);
                    return await HandlerCrudCommands(handlerType, command, userId, ip);
                }
                else
                {
                    var handler = _context.Resolve<ICommandHandler<TCommand, CqrsCommandResult>>(new NamedParameter("parentOfChain", true));
                    return await handler.Execute(command, userId, ip);
                }
            }
            catch (Exception e)
            {
                
                throw;
            }


        }

        private async Task<CqrsCommandResult> HandlerCrudCommands<TCommand>(Type handlerType, TCommand command,int userId, string ip)
        {
            Type[] typeArgs = { typeof(TCommand).GetGenericArguments()[0] };
            var genericHandlerType = handlerType.MakeGenericType(typeArgs);

            dynamic createHandler = Activator.CreateInstance(genericHandlerType, _context.Resolve<IDataContext>(), true);
            return await createHandler.Execute(command, userId, ip);
        }
    }
}