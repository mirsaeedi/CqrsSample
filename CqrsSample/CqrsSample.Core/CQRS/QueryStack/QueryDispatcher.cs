using System;
using System.Threading.Tasks;
using Autofac;
using CqrsSample.Core.CQRS.QueryStack.Queries;
using CqrsSample.Core.CQRS.QueryStack.Queries.CRUDQueries;
using CqrsSample.Core.CQRS.QueryStack.QueryHandler;
using CqrsSample.Core.CQRS.QueryStack.QueryHandler.CRUDHandler;
using CqrsSample.Core.CQRS.QueryStack.QueryResults;
using CqrsSample.Core.Data.DataContext;

namespace CqrsSample.Core.CQRS.QueryStack
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IComponentContext _context;
        internal QueryDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public async Task<CqrsQueryResult<TValue>> Dispatch<TQuery, TValue>(TQuery query, int userId, string ip)
            where TQuery : CqrsQuery
        {

            if (query.GetType().GetGenericTypeDefinition() == typeof (ReadCqrsQuery<>))
            {
                var handlerType = typeof (ReadQueryHandler<>);
                return await HandlerCrudQuery<TQuery, TValue>(handlerType, query);
            }
            else
            {
                var handler = _context.Resolve<IQueryHandler<TQuery, TValue>>();
                return await handler.Execute(query);
            }
            
        }

        private async Task<CqrsQueryResult<TValue>> HandlerCrudQuery<TQuery, TValue>(Type handlerType, TQuery query)
        {
            Type[] typeArgs = { typeof(TQuery).GetGenericArguments()[0] };
            var genericHandlerType = handlerType.MakeGenericType(typeArgs);

            dynamic queryHandler = Activator.CreateInstance(genericHandlerType, _context.Resolve<IReadOnlyDataContext>());
            return await queryHandler.Execute(query);
        }
    }
}