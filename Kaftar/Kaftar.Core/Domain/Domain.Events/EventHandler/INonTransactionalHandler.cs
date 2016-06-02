using Kaftar.Core.Domain.Domain.Events.Base;

namespace Kaftar.Core.Domain.Domain.Events.EventHandler
{
    public interface INonTransactionalHandler<T> where T:IDomainEvent
    {
        void Execute(T @event);
    }
}