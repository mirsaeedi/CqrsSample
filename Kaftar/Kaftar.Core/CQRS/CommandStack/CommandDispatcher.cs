﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Features.Metadata;
using Kaftar.Core.CQRS.CommandStack.CommandHandlers;
using Kaftar.Core.CQRS.CommandStack.CommandHandlers.CRUDCommandHandlers;
using Kaftar.Core.CQRS.CommandStack.Commands;
using Kaftar.Core.CQRS.CommandStack.Commands.CRUDCommands;
using Kaftar.Core.Data.DataContext;

namespace Kaftar.Core.CQRS.CommandStack
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

            command.IpAddress = ip;
            command.UserId = userId;

            var assmeblyName = typeof (TCommand).Assembly.GetName();

            var dataContext = _context.Resolve<IDataContext>();

            if (command.GetType().IsGenericType)
            {
                if (command.GetType().GetGenericTypeDefinition() == typeof(CreateCqrsCommand<>))
                {
                    var handlerType = typeof(CreateCommandHandler<>);
                    return await HandlerCrudCommands(handlerType, command, dataContext);
                }

                if (command.GetType().GetGenericTypeDefinition() == typeof(UpdateCqrsCommand<>))
                {
                    var handlerType = typeof(UpdateCqrsCommand<>);
                    return await HandlerCrudCommands(handlerType, command, dataContext);
                }

                if (command.GetType().GetGenericTypeDefinition() == typeof(DeleteCqrsCommand<>))
                {
                    var handlerType = typeof(DeleteCqrsCommand<>);
                    return await HandlerCrudCommands(handlerType, command, dataContext);
                }
            }

            var handler =
                _context.Resolve<CommandHandler<TCommand, CqrsCommandResult>>();
            handler.InnerDataContext = dataContext;
            return await handler.Execute(command);
        }

        private async Task<CqrsCommandResult> HandlerCrudCommands<TCommand>(Type handlerType, TCommand command,IDataContext dataContext)
        {
            Type[] typeArgs = { typeof(TCommand).GetGenericArguments()[0] };
            var genericHandlerType = handlerType.MakeGenericType(typeArgs);

            dynamic createHandler = Activator.CreateInstance(genericHandlerType, _context.Resolve<IDataContext>());
            createHandler.InnerDataContext = dataContext;
            return await createHandler.Execute(command);
        }
    }
}