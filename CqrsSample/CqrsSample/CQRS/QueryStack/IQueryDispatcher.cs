using System.Threading.Tasks;
using CqrsSample.QueryStack;
using CqrsSample.QueryStack.Queries;

namespace CqrsSample.CQRS.QueryStack
{
    public interface IQueryDispatcher
    {
        Task<CqrsQueryResult<TValue>> Dispatch<TQuery, TValue>(TQuery query, int userId, string ip) where TQuery : CqrsQuery;
    }
}