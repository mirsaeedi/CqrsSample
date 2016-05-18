using System.Data.Entity.Infrastructure;
using CqrsSample.Core.Data.Models;

namespace CqrsSample.Core.Data.DataContext
{
    public interface IReadOnlyDataContext
    {
        DbQuery<TEntity> Set<TEntity>() where TEntity : Entity;
    }
}