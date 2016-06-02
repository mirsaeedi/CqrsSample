﻿using System.Threading.Tasks;
using Kaftar.Core.CQRS.QueryStack.Queries;
using Kaftar.Core.CQRS.QueryStack.QueryResults;

namespace Kaftar.Core.CQRS.QueryStack.QueryHandler
{
    public interface IQueryHandler<in TQuery, TQueryValueResult>
        where TQuery : CqrsQuery
        where TQueryValueResult : class
    {
        Task<CqrsQueryResult<TQueryValueResult>> Execute(TQuery query);
    }
}