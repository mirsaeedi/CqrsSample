using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CqrsSample.CommandStack;
using CqrsSample.CQRS.CommandStack.CommandHandlers;
using CqrsSample.CQRS.CommandStack.Commands;
using CqrsSample.Data.DataContext;
using CqrsSample.Data.Models;
using CqrsSample.FineBusiness.CQRS.CommandStack.Commands;

namespace CqrsSample.FineBusiness.CQRS.CommandStack.CommandHandlers
{
    public class RegisterStaffCommandHandler:CommandHandler<RegisterStaffCqrsCommand,CqrsCommandResult>
    {
        public RegisterStaffCommandHandler(IDataContext dataContext, bool parentOfChain = true)
            : base(dataContext, parentOfChain)
        {
        }

        internal override CqrsCommandResult PreExecutionValidation(RegisterStaffCqrsCommand cqrsCommand, int userId)
        {
            return OkResult(cqrsCommand);
        }

        internal override async Task Handle(RegisterStaffCqrsCommand cqrsCommand, int userId)
        {
            var staff=new Staff(cqrsCommand.Name,cqrsCommand.DateTime);
            SetDataContext.Set<Staff>().Add(staff);
        }
    }
}