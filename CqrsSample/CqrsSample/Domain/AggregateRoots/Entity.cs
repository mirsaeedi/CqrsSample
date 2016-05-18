using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CqrsSample.Domain.AggregateRoots
{
    public abstract class Entity
    {
        public long Id { get; set; }

        public EntityState EntityState { get; set; }
    }
}