using System;

namespace CqrsSample.Core.Data.Models
{
    public class AuditableEntity:Entity
    {
        public long LastModifierId { get; internal set; }

        public DateTime LastModifiedDateTime { get; internal set; }

        public DateTime CreateDateTime { get; internal set; }
    }
}