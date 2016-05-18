using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CqrsSample.Data.Models;

namespace CqrsSample.Data.DataContext
{
    public interface ISetDataContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : Entity;
        void Update<TEntity>(TEntity entity) where TEntity : Entity;
    }
}