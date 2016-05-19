using System.Threading.Tasks;
using CqrsSample.Core.CQRS.QueryStack.Queries;
using CqrsSample.Core.CQRS.QueryStack.QueryResults;

namespace CqrsSample.Core.CQRS.QueryStack
{
    public interface IQueryDispatcher
    {
        Task<CqrsQueryResult<TQueryValueResult>> Dispatch<TQuery, TQueryValueResult>(TQuery query, int userId, string ip)
            where TQuery : CqrsQuery
            where TQueryValueResult : class;
    }
}