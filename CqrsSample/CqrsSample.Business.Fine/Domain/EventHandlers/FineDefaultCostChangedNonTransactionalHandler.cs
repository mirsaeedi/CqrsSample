using System;
using CqrsSample.Business.Fine.Domain.Events;
using CqrsSample.Core.Domain.Domain.Events.EventHandler;

namespace CqrsSample.Business.Fine.Domain.EventHandlers
{
    public class FineDefaultCostChangedNonTransactionalHandler : INonTransactionalHandler<FineDefaultCostChanged>
    {
        public void Execute(FineDefaultCostChanged @event)
        {
            throw new NotImplementedException();
        }
    }
}