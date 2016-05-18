using System.Threading.Tasks;
using CqrsSample.Core.CQRS.QueryStack.Queries;
using CqrsSample.Core.CQRS.QueryStack.QueryResults;

namespace CqrsSample.Core.CQRS.QueryStack
{
    public interface IQueryDispatcher
    {
        Task<CqrsQueryResult<TValue>> Dispatch<TQuery, TValue>(TQuery query, int userId, string ip) where TQuery : CqrsQuery;
    }
}