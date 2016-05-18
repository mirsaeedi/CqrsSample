using CqrsSample.Core.Domain.AggregateRoots;

namespace CqrsSample.Core.Data.Events.Handlers
{
    public interface IUpdateHandler<T> where T:Entity
    {
        void PreUpdate(T entity);

        void PostUpdate(T entity);
    }
}
