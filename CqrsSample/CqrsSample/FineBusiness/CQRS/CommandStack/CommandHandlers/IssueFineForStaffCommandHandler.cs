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
using CqrsSample.FineBusiness.Data.Models;


namespace CqrsSample.FineBusiness.CQRS.CommandStack.CommandHandlers
{
    internal class IssueFineForStaffCommandHandler : CommandHandler<IssueFineForStaffCqrsCommand, CqrsCommandResult>
    {
        public IInspectorService InspectorService
        {
            get;
            set;
        }


        public IssueFineForStaffCommandHandler(IDataContext dataContext, bool parentOfChain = true)
            : base(dataContext, parentOfChain)
        {

        }

        // اعتبار سنجی مرتبط با یوز کیس در این متد قرار می گیرد
        internal override CqrsCommandResult PreExecutionValidation(IssueFineForStaffCqrsCommand cqrsCommand, int userId)
        {
            throw new NotImplementedException();
        }

        // استفاده از اینترفیس ها می تواند در نظر گرفته شود
        protected override bool ActivityAuthorizationIsConfirmed(int userId)
        {
            return true;
        }

        internal override async Task Handle(IssueFineForStaffCqrsCommand cqrsCommand, int userId)
        {
            var staff = SetDataContext.Set<Staff>().Find(cqrsCommand.StaffId);
            var fine = SetDataContext.Set<Fine>().Find(cqrsCommand.FineId);

            fine.SetName(null);

            InspectorService.IssueFine(staff,fine,cqrsCommand.DateTime,cqrsCommand.Cost);
        }
    }
}