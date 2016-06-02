using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Kaftar.Core.CQRS.QueryStack.Queries.CRUDQueries;
using Kaftar.Core.Data.DataContext;
using Kaftar.Core.Data.Models;

namespace Kaftar.Core.CQRS.QueryStack.QueryHandler.CRUDHandler
{
    public class ReadQueryHandler<TEntity>:QueryHandler<ReadCqrsQuery<TEntity>,TEntity[]>
        where TEntity:Entity
    {

        protected override async Task<TEntity[]> GetResult(ReadCqrsQuery<TEntity> cqrsQuery)
        {

            var set = DataContext.Set<TEntity>();
            var configurationExpression = cqrsQuery.QueryConfiguration(set);

            return await set.Concat(configurationExpression)
                .ToArrayAsync();
        }
    }
}