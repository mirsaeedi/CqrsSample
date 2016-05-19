using System.Threading.Tasks;
using CqrsSample.Business.Fine.CQRS.CommandStack.Commands;
using CqrsSample.Business.Fine.Data.Models;
using CqrsSample.Core.CQRS.CommandStack.CommandHandlers;
using CqrsSample.Core.CQRS.CommandStack.Commands;
using CqrsSample.Core.Data.DataContext;

namespace CqrsSample.Business.Fine.CQRS.CommandStack.CommandHandlers
{
    public class RegisterStaffCommandHandler:CommandHandler<RegisterStaffCqrsCommand,CqrsCommandResult>
    {
        protected override CqrsCommandResult PreExecutionValidation(RegisterStaffCqrsCommand cqrsCommand)
        {
            return OkResult(cqrsCommand);
        }

        protected override async Task Handle(RegisterStaffCqrsCommand cqrsCommand)
        {
            var staff=new Staff(cqrsCommand.Name,cqrsCommand.DateTime);
            SetDataContext.Set<Staff>().Add(staff);
        }
    }
}