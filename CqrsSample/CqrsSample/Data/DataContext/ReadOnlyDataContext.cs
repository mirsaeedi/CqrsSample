using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using CqrsSample.Data.Models;

namespace CqrsSample.Data.DataContext
{
    public class ReadOnlyDataContext : IReadOnlyDataContext
    {
        private readonly DbContextBase _dbContext;

        public ReadOnlyDataContext(DbContextBase dbContext)
        {
            _dbContext = dbContext;
        }

        public DbQuery<TEntity> Set<TEntity>() where TEntity : Entity
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }
    }
}