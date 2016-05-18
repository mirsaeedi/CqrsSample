using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CqrsSample.Domain.Events;

namespace CqrsSample.Data.Models
{
    public abstract class Entity
    {
        public long Id { get; private set; }

        protected ICollection<DomainEvent> Events = new List<DomainEvent>();
    }
}