using System;

namespace Kaftar.Core.CQRS
{
    internal interface  ICqrsMessage
    {
        DateTime CqrsMessageCreateDateTime { get; set; }

        Guid Guid { get; set; }

        string IpAddress { get; set; }

        int UserId { get; set; }
    }
}