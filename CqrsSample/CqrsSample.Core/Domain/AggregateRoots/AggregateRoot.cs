using System.Collections.Generic;
using CqrsSample.Core.Domain.Domain.Events.Base;

namespace CqrsSample.Core.Domain.AggregateRoots
{
    public class AggregateRoot:Entity
    {
        protected IList<DomainEvent> Events=new List<DomainEvent>(); 
    }
}