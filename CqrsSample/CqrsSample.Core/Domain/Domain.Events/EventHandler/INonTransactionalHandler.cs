using CqrsSample.Core.Domain.Domain.Events.Base;

namespace CqrsSample.Core.Domain.Domain.Events.EventHandler
{
    public interface INonTransactionalHandler<T> where T:DomainEvent
    {
        void Execute(T @event);
    }
}