using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CqrsSample.Data.Models;

namespace CqrsSample.Domain.Events.EventHandler
{
    public class FineDefaultCostChangedNonTransactionalHandler : INonTransactionalHandler<FineDefaultCostChanged>
    {
        public void Execute(FineDefaultCostChanged @event)
        {
            throw new NotImplementedException();
        }
    }
}