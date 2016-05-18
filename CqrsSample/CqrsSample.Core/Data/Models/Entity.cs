using System.Collections.Generic;
using CqrsSample.Core.Domain.Domain.Events.Base;

namespace CqrsSample.Core.Data.Models
{
    public abstract class Entity
    {
        public long Id { get; private set; }

        protected ICollection<DomainEvent> Events = new List<DomainEvent>();
    }
}