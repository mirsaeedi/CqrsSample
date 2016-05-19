﻿using System;

namespace CqrsSample.Core.Data.Models
{
    public interface IAuditableEntity
    {
        long LastModifierId { get;  set; }

        DateTime LastModifiedDateTime { get; set; }

        DateTime CreateDateTime { get;  set; }
    }
}