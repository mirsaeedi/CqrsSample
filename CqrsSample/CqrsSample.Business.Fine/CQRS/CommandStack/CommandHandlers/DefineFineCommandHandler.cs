using System.Threading.Tasks;
using CqrsSample.Business.Fine.CQRS.CommandStack.Commands;
using CqrsSample.Core.CQRS.CommandStack.CommandHandlers;
using CqrsSample.Core.CQRS.CommandStack.Commands;
using CqrsSample.Core.Data.DataContext;

namespace CqrsSample.Business.Fine.CQRS.CommandStack.CommandHandlers
{
    public class DefineFineCommandHandler:CommandHandler<DefineFineCqrsCommand, CqrsCommandResult>
    {
        protected override  CqrsCommandResult PreExecutionValidation(DefineFineCqrsCommand cqrsCommand)
        {
            return OkResult(cqrsCommand);
        }

        protected override async Task Handle(DefineFineCqrsCommand cqrsCommand)
        {
            var fine = new Data.Models.Fine(cqrsCommand.Name,cqrsCommand.MinCost,cqrsCommand.MaxCost,cqrsCommand.DefaultCost);
            SetDataContext.Set<Data.Models.Fine>().Add(fine);
        }
    }
}