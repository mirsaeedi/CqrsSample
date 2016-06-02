using Kaftar.Core.Domain.AggregateRoots;

namespace Kaftar.Core.Data.Events.Handlers
{
    public interface IUpdateHandler<T> where T:Entity
    {
        void PreUpdate(T entity);

        void PostUpdate(T entity);
    }
}
