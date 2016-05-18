using CqrsSample.Core.Domain.AggregateRoots;

namespace CqrsSample.Core.Data.Events.Handlers
{
    public interface IDeleteHandler<T> where T:Entity
    {
        void PreDelete(T entity);

        void PostDelete(T entity);
    }
}
