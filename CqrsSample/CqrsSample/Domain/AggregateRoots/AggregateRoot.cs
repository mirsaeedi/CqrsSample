using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CqrsSample.Domain.Events;

namespace CqrsSample.Domain.AggregateRoots
{
    public class AggregateRoot:Entity
    {
        protected IList<DomainEvent> Events=new List<DomainEvent>(); 
    }
}