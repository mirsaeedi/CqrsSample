using System;
using CqrsSample.Business.Fine.Domain.Events;
using CqrsSample.Core.Data.DataContext;
using CqrsSample.Core.Domain.Domain.Events.EventHandler;

namespace CqrsSample.Business.Fine.Domain.EventHandlers
{
    public class FineDefinedTransactionalHandler:ITransactionalHandler<FineDefined>
    {
        public void Execute(DataContext dataContext, FineDefined @event)
        {
            throw new NotImplementedException();
        }
    }

}