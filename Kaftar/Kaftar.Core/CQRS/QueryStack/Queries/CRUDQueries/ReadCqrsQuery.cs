using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Kaftar.Core.Data.Models;

namespace Kaftar.Core.CQRS.QueryStack.Queries.CRUDQueries
{
    public class ReadCqrsQuery<TEntity>:CqrsQuery
        where TEntity:Entity
    {
        public ReadCqrsQuery()
        {
            // set default query
            QueryConfiguration = (query) => query;
        }
        public TEntity Entity { get; set; }

        public Func<DbQuery<TEntity>, IQueryable<TEntity>> QueryConfiguration;
    }

}
