﻿using System;

namespace CqrsSample.Core.CQRS
{
    public abstract class CqrsMessage
    {
        protected CqrsMessage()
        {
            Guid = Guid.NewGuid();
            CqrsMessageCreateDateTime = DateTime.Now;
        }

        public DateTime CqrsMessageCreateDateTime { get; private set; }

        public Guid Guid { get; private set; }

        public string IpAddress { get; set; }

        public int UserId { get; set; }
    }
}