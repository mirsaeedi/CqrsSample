using System.Data.Entity;
using Kaftar.Core.Data.Models;

namespace Kaftar.Core.Data.DataContext
{
    public interface ISetDataContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : Entity;
        void Update<TEntity>(TEntity entity) where TEntity : Entity;
    }
}