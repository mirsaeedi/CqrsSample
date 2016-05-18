using System.Data.Entity.Infrastructure;
using CqrsSample.Core.Data.Models;

namespace CqrsSample.Core.Data.DataContext
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