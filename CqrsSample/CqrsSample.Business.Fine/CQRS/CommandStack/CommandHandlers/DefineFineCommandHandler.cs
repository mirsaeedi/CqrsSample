using System.Threading.Tasks;
using CqrsSample.Business.Fine.CQRS.CommandStack.Commands;
using CqrsSample.Core.CQRS.CommandStack.CommandHandlers;
using CqrsSample.Core.CQRS.CommandStack.Commands;
using CqrsSample.Core.Data.DataContext;

namespace CqrsSample.Business.Fine.CQRS.CommandStack.CommandHandlers
{
    public class DefineFineCommandHandler:CommandHandler<DefineFineCqrsCommand, CqrsCommandResult>
    {
        public DefineFineCommandHandler(IDataContext dataContext, bool parentOfChain = true) 
            : base(dataContext, parentOfChain)
        {

        }

        protected override  CqrsCommandResult PreExecutionValidation(DefineFineCqrsCommand cqrsCommand, int userId)
        {
            return OkResult(cqrsCommand);
        }

        protected override async Task Handle(DefineFineCqrsCommand cqrsCommand, int userId)
        {
            var fine = new Data.Models.Fine(cqrsCommand.Name,cqrsCommand.MinCost,cqrsCommand.MaxCost,cqrsCommand.DefaultCost);
            SetDataContext.Set<Data.Models.Fine>().Add(fine);
        }
    }
}