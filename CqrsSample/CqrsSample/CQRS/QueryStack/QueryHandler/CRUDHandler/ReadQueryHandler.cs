using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CqrsSample.CQRS.QueryStack.Queries.CRUDQueries;
using CqrsSample.Data.DataContext;
using CqrsSample.Data.Models;
using CqrsSample.QueryStack.QueryHandler;
using System.Data.Entity;

namespace CqrsSample.CQRS.QueryStack.QueryHandler.CRUDHandler
{
    public class ReadQueryHandler<TEntity>:QueryHandler<ReadCqrsQuery<TEntity>,TEntity[]>
        where TEntity:Entity
    {
        public ReadQueryHandler(IReadOnlyDataContext dataContext) : base(dataContext)
        {
            
            dataContext.Set<TEntity>().Include(e => e.Id);
        }

        internal override async Task<TEntity[]> GetResult(ReadCqrsQuery<TEntity> cqrsQuery, int userId)
        {

            var set = DataContext.Set<TEntity>();
            var configurationExpression = cqrsQuery.QueryConfiguration(set);

            return await set.Concat(configurationExpression)
                .ToArrayAsync();
        }
    }
}