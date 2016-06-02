using Kaftar.Core.Domain.AggregateRoots;

namespace Kaftar.Core.Data.Events.Handlers
{
    public interface IDeleteHandler<T> where T:Entity
    {
        void PreDelete(T entity);

        void PostDelete(T entity);
    }
}
