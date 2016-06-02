using System.Threading.Tasks;
using Kaftar.Core.CQRS.QueryStack.Queries;
using Kaftar.Core.CQRS.QueryStack.QueryResults;

namespace Kaftar.Core.CQRS.QueryStack
{
    public interface IQueryDispatcher
    {
        Task<CqrsQueryResult<TQueryValueResult>> Dispatch<TQuery, TQueryValueResult>(TQuery query, int userId, string ip)
            where TQuery : CqrsQuery
            where TQueryValueResult : class;
    }
}