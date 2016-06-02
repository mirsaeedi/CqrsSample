using System.Collections.Generic;
using Kaftar.Core.Domain.Domain.Events.Base;

namespace Kaftar.Core.Domain.AggregateRoots
{
    public class AggregateRoot:Entity
    {
        protected IList<IDomainEvent> Events=new List<IDomainEvent>(); 
    }
}