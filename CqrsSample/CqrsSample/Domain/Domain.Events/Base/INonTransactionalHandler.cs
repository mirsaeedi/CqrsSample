using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CqrsSample.Domain.Events
{
    public interface INonTransactionalHandler<T> where T:DomainEvent
    {
        void Execute(T @event);
    }
}