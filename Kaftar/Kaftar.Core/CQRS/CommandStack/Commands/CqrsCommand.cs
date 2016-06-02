using System;

namespace Kaftar.Core.CQRS.CommandStack.Commands
{
    public abstract class CqrsCommand : ICqrsMessage
    {
        public DateTime CqrsMessageCreateDateTime { get; set; }
        public Guid Guid { get; set; }
        public string IpAddress { get; set; }
        public int UserId { get; set; }
    }
}