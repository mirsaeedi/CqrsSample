using CqrsSample.Core.Data.DataContext;
using CqrsSample.Core.Domain.Domain.Events.Base;

namespace CqrsSample.Core.Domain.Domain.Events.EventHandler
{
    public interface ITransactionalHandler<in T> where T : DomainEvent
    {
        void Execute(DataContext dataContext, T @event);
    }
}