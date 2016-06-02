using System.Data.Entity.Infrastructure;
using Autofac.Extras.Attributed;
using Kaftar.Core.Data.Models;

namespace Kaftar.Core.Data.DataContext
{
    public class ReadOnlyDataContext : IReadOnlyDataContext
    {
        private readonly DbContextBase _dbContext;

        public ReadOnlyDataContext([WithKey("assembly_name")]DbContextBase dbContext)
        {
            _dbContext = dbContext;
        }

        public DbQuery<TEntity> Set<TEntity>() where TEntity : Entity
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }
    }
}