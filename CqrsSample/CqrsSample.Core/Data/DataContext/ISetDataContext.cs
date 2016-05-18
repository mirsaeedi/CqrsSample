using System.Data.Entity;
using CqrsSample.Core.Data.Models;

namespace CqrsSample.Core.Data.DataContext
{
    public interface ISetDataContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : Entity;
        void Update<TEntity>(TEntity entity) where TEntity : Entity;
    }
}