using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CqrsSample.CQRS.CommandStack.CommandHandlers;
using CqrsSample.CQRS.CommandStack.Commands;
using CqrsSample.Data.DataContext;
using CqrsSample.Data.Models;
using CqrsSample.FineBusiness.CQRS.CommandStack.Commands;

namespace CqrsSample.CommandStack.Commands
{
    public class DefineFineCommandHandler:CommandHandler<DefineFineCqrsCommand, CqrsCommandResult>
    {
        public DefineFineCommandHandler(IDataContext dataContext, bool parentOfChain = true) 
            : base(dataContext, parentOfChain)
        {

        }

        internal override  CqrsCommandResult PreExecutionValidation(DefineFineCqrsCommand cqrsCommand, int userId)
        {
            return OkResult(cqrsCommand);
        }

        internal override async Task Handle(DefineFineCqrsCommand cqrsCommand, int userId)
        {
            var fine = new Fine(cqrsCommand.Name,cqrsCommand.MinCost,cqrsCommand.MaxCost,cqrsCommand.DefaultCost);
            SetDataContext.Set<Fine>().Add(fine);
        }
    }
}