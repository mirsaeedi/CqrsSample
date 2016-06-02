using System.Data.Entity.Infrastructure;
using Kaftar.Core.Data.Models;

namespace Kaftar.Core.Data.DataContext
{
    public interface IReadOnlyDataContext
    {
        DbQuery<TEntity> Set<TEntity>() where TEntity : Entity;
    }
}