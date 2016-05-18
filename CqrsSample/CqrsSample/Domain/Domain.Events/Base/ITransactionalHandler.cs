using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CqrsSample.Data.DataContext;

namespace CqrsSample.Domain.Events
{
    public interface ITransactionalHandler<in T> where T : DomainEvent
    {
        void Execute(DataContext dataContext, T @event);
    }
}