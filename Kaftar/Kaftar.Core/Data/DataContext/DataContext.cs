using System.Data.Entity;
using System.Threading.Tasks;
using Autofac.Extras.Attributed;
using Kaftar.Core.Data.Models;

namespace Kaftar.Core.Data.DataContext
{
    public class DataContext : IDataContext
    {
        private readonly DbContextBase _dbContext;

        public DataContext([WithKey("assembly_name")]DbContextBase dbContext)
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