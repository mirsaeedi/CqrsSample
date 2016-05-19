﻿using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CqrsSample.Core.CQRS.QueryStack.Queries.CRUDQueries;
using CqrsSample.Core.Data.DataContext;
using CqrsSample.Core.Data.Models;

namespace CqrsSample.Core.CQRS.QueryStack.QueryHandler.CRUDHandler
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