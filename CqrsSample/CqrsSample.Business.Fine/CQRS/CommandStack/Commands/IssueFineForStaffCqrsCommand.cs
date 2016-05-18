using System;
using CqrsSample.Core.CQRS.CommandStack.Commands;

namespace CqrsSample.Business.Fine.CQRS.CommandStack.Commands
{
    public class IssueFineForStaffCqrsCommand:CqrsCommand
    {
        public int StaffId { get; set; }
        public int FineId { get; set; }
        public DateTime DateTime { get; set; }
        public int Cost { get; set; }
    }
}