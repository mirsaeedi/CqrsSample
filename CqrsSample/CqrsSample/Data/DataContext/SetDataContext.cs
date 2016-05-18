using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using CqrsSample.Data.DataContext;
using CqrsSample.Data.Models;

namespace CqrsSample.Data.DataContext
{
    public class SetDataContext: ISetDataContext
    {
        private IDataContext DataContext { get; set; }

        internal SetDataContext(IDataContext dataContext)
        {
            DataContext = dataContext;
        }

        public DbSet<TEntity> Set<TEntity>() where TEntity : Entity
        {
            return DataContext.Set<TEntity>();
        }

        public void Update<TEntity>(TEntity entity) where TEntity : Entity
        {
            DataContext.Set<TEntity>().Attach(entity);
        }

    }
}