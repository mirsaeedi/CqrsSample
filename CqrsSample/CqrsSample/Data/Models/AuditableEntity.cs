using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CqrsSample.Data.Models
{
    public class AuditableEntity:Entity
    {
        public long LastModifierId { get; internal set; }

        public DateTime LastModifiedDateTime { get; internal set; }

        public DateTime CreateDateTime { get; internal set; }
    }
}