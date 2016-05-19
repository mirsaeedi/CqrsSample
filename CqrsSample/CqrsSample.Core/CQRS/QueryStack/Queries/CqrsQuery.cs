using System;

namespace CqrsSample.Core.CQRS.QueryStack.Queries
{
    public abstract class CqrsQuery: ICqrsMessage
    {
        public DateTime CqrsMessageCreateDateTime { get; set; }
        public Guid Guid { get; set; }
        public string IpAddress { get; set; }
        public int UserId { get; set; }
    }
}