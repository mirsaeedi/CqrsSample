﻿using System;
using CqrsSample.Core.Data.Models;

namespace CqrsSample.Business.Fine.Data.Models
{
    public class EmploymentHistory:Entity
    {
        public EmploymentHistory(Staff staff,DateTime beginDateTime,DateTime? EndDateTime=null, bool? isValid=false)
        {
            
        }

        public EmploymentStatusType EmploymentStatusType { get; set; }

        public bool IsValid { get; private set; }

        public DateTime BeginDateTime { get; private set; }

        public DateTime? EndDateTime { get; private set; }

        public int StaffId { get; private set; }
    }

    public enum EmploymentStatusType
    {
        Registred,
        Working,
        Retired,
        Resign
    }
}