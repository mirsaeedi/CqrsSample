using System;
using CqrsSample.Core.CQRS.CommandStack.Commands;

namespace CqrsSample.Business.Fine.CQRS.CommandStack.Commands
{
    public class RegisterStaffCqrsCommand:CqrsCommand
    {
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
    }
}