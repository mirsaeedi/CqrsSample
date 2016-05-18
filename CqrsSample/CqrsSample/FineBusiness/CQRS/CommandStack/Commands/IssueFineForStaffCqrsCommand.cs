using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CqrsSample.CommandStack.Commands;
using CqrsSample.CQRS.CommandStack.Commands;

namespace CqrsSample.FineBusiness.CQRS.CommandStack.Commands
{
    public class IssueFineForStaffCqrsCommand:CqrsCommand
    {
        public int StaffId { get; set; }
        public int FineId { get; set; }
        public DateTime DateTime { get; set; }
        public int Cost { get; set; }
    }
}