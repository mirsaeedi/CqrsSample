﻿using System;
using System.Threading.Tasks;
using Autofac;
using CqrsSample.CQRS.CommandStack.CommandHandlers.CRUDCommandHandlers;
using CqrsSample.CQRS.CommandStack.Commands.CRUDCommands;
using CqrsSample.CQRS.QueryStack.Queries.CRUDQueries;
using CqrsSample.CQRS.QueryStack.QueryHandler.CRUDHandler;
using CqrsSample.Data.DataContext;
using CqrsSample.QueryStack;
using CqrsSample.QueryStack.Queries;
using CqrsSample.QueryStack.QueryHandler;

namespace CqrsSample.CQRS.QueryStack
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IComponentContext _context;
        public QueryDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public async Task<CqrsQueryResult<TValue>> Dispatch<TQuery, TValue>(TQuery query, int userId, string ip)
            where TQuery : CqrsQuery
        {

            if (query.GetType().GetGenericTypeDefinition() == typeof (ReadCqrsQuery<>))
            {
                var handlerType = typeof (ReadQueryHandler<>);
                return await HandlerCrudQuery<TQuery, TValue>(handlerType, query, userId, ip);
            }
            else
            {
                var handler = _context.Resolve<IQueryHandler<TQuery, TValue>>();
                return await handler.Execute(query, userId, ip);
            }
            
        }

        private async Task<CqrsQueryResult<TValue>> HandlerCrudQuery<TQuery, TValue>(Type handlerType, TQuery command, int userId, string ip)
        {
            Type[] typeArgs = { typeof(TQuery).GetGenericArguments()[0] };
            var genericHandlerType = handlerType.MakeGenericType(typeArgs);

            dynamic queryHandler = Activator.CreateInstance(genericHandlerType, _context.Resolve<IReadOnlyDataContext>());
            return await queryHandler.Execute(command, userId, ip);
        }
    }
}