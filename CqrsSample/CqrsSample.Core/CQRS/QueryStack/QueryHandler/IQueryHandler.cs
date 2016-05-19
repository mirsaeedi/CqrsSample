﻿using System.Threading.Tasks;
using CqrsSample.Core.CQRS.QueryStack.Queries;
using CqrsSample.Core.CQRS.QueryStack.QueryResults;

namespace CqrsSample.Core.CQRS.QueryStack.QueryHandler
{
    public interface IQueryHandler<in TQuery, TQueryValueResult>
        where TQuery : CqrsQuery
        where TQueryValueResult : class
    {
        Task<CqrsQueryResult<TQueryValueResult>> Execute(TQuery query);
    }
}