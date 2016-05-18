using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Http;
using CqrsSample.Data.Models;
using CqrsSample.QueryStack.Queries;

namespace CqrsSample.CQRS.QueryStack.Queries.CRUDQueries
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
