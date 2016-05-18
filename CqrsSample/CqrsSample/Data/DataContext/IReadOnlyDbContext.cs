using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using CqrsSample.Data.Models;


namespace CqrsSample.Data.DataContext
{
    public interface IReadOnlyDataContext
    {
        DbQuery<TEntity> Set<TEntity>() where TEntity : Entity;
    }
}