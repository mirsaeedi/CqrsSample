﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CqrsSample.Data.Models;

namespace CqrsSample.Data.DataContext
{
    public class DataContext : IDataContext
    {
        private readonly DbContextBase _dbContext;

        public DataContext(DbContextBase dbContext)
        {
            _dbContext = dbContext;
        }
        public DbSet<TEntity> Set<TEntity>() where TEntity : Entity
        {
            return _dbContext.Set<TEntity>();
        }
        public void Update<TEntity>(TEntity entity) where TEntity : Entity
        {
            _dbContext.Set<TEntity>().Attach(entity);
            _dbContext.Entry<TEntity>(entity).State= EntityState.Modified;
        }
        public virtual int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
        public virtual Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }

}