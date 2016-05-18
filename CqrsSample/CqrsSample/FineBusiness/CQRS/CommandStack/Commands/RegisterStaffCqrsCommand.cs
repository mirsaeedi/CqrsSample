using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CqrsSample.CommandStack.Commands;
using CqrsSample.CQRS.CommandStack.Commands;

namespace CqrsSample.FineBusiness.CQRS.CommandStack.Commands
{
    public class RegisterStaffCqrsCommand:CqrsCommand
    {
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
    }
}