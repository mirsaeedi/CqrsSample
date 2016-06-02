using System.Collections.Generic;
using Kaftar.Core.Domain.Domain.Events.Base;

namespace Kaftar.Core.Data.Models
{
    public abstract class Entity
    {
        public long Id { get; private set; }

        protected ICollection<IDomainEvent> Events = new List<IDomainEvent>();
    }
}