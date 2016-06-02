using Kaftar.Core.Data.DataContext;
using Kaftar.Core.Domain.Domain.Events.Base;

namespace Kaftar.Core.Domain.Domain.Events.EventHandler
{
    public interface ITransactionalHandler<in T> where T : IDomainEvent
    {
        void Execute(DataContext dataContext, T @event);
    }
}