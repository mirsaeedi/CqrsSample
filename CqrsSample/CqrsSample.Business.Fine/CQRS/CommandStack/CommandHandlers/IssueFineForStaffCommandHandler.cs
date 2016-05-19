using System;
using System.Threading.Tasks;
using CqrsSample.Business.Fine.CQRS.CommandStack.Commands;
using CqrsSample.Business.Fine.Data.Models;
using CqrsSample.Business.Fine.Domain.Services;
using CqrsSample.Core.CQRS.CommandStack.CommandHandlers;
using CqrsSample.Core.CQRS.CommandStack.Commands;
using CqrsSample.Core.Data.DataContext;

namespace CqrsSample.Business.Fine.CQRS.CommandStack.CommandHandlers
{
    internal class IssueFineForStaffCommandHandler : CommandHandler<IssueFineForStaffCqrsCommand, CqrsCommandResult>
    {
        public IInspectorService InspectorService
        {
            get;
            set;
        }

        // اعتبار سنجی مرتبط با یوز کیس در این متد قرار می گیرد
        protected override CqrsCommandResult PreExecutionValidation(IssueFineForStaffCqrsCommand cqrsCommand)
        {
            throw new NotImplementedException();
        }

        // استفاده از اینترفیس ها می تواند در نظر گرفته شود
        protected override bool ActivityAuthorizationIsConfirmed(IssueFineForStaffCqrsCommand command)
        {
            return true;
        }

        protected override async Task Handle(IssueFineForStaffCqrsCommand cqrsCommand)
        {
            var staff = SetDataContext.Set<Staff>().Find(cqrsCommand.StaffId);
            var fine = SetDataContext.Set<Data.Models.Fine>().Find(cqrsCommand.FineId);

            fine.SetName(null);

            InspectorService.IssueFine(staff,fine,cqrsCommand.DateTime,cqrsCommand.Cost);
        }
    }
}