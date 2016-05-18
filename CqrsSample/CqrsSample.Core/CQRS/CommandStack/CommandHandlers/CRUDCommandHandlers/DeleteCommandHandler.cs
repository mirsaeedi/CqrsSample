using System.Threading.Tasks;
using CqrsSample.Core.CQRS.CommandStack.Commands;
using CqrsSample.Core.CQRS.CommandStack.Commands.CRUDCommands;
using CqrsSample.Core.Data.DataContext;
using CqrsSample.Core.Data.Models;

namespace CqrsSample.Core.CQRS.CommandStack.CommandHandlers.CRUDCommandHandlers
{
    internal class DeleteCommandHandler<TEntity> : CommandHandler<UpdateCqrsCommand<TEntity>, CqrsCommandResult>
        where TEntity : Entity
    {

        public DeleteCommandHandler(IDataContext innerDataContext, bool parentOfChain = true) 
            : base(innerDataContext, parentOfChain)
        {
        }

        protected override CqrsCommandResult PreExecutionValidation(UpdateCqrsCommand<TEntity> cqrsCommand, int userId)
        {
            return OkResult(cqrsCommand);
        }

        protected override async Task Handle(UpdateCqrsCommand<TEntity> cqrsCommand, int userId)
        {
            SetDataContext.Update(cqrsCommand.Entity);
        }
    }
}