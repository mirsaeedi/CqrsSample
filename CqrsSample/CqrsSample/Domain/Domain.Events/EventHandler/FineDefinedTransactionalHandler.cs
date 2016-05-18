using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CqrsSample.Data.DataContext;
using CqrsSample.Data.Models;

namespace CqrsSample.Domain.Events.EventHandler
{
    public class FineDefinedTransactionalHandler:ITransactionalHandler<FineDefined>
    {
        public void Execute(DataContext dataContext, FineDefined @event)
        {
            throw new NotImplementedException();
        }
    }

}