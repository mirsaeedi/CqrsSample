using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CqrsSample.QueryStack.Queries;

namespace CqrsSample.QueryStack.QueryHandler
{
    public interface IQueryHandler<in TQuery, TQueryValueResult>
        where TQuery : CqrsQuery
    {
        Task<CqrsQueryResult<TQueryValueResult>> Execute(TQuery query, int userId, string ip);
    }
}