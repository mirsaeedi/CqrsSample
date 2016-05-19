using System.Threading.Tasks;
using CqrsSample.Core.CQRS.CommandStack.Commands;
using CqrsSample.Core.CQRS.CommandStack.Commands.CRUDCommands;
using CqrsSample.Core.Data.DataContext;
using CqrsSample.Core.Data.Models;

namespace CqrsSample.Core.CQRS.CommandStack.CommandHandlers.CRUDCommandHandlers
{
    internal class CreateCommandHandler<TEntity> : CommandHandler<CreateCqrsCommand<TEntity>, CqrsCommandResult>
        where TEntity : Entity
    {

        protected override CqrsCommandResult PreExecutionValidation(CreateCqrsCommand<TEntity> cqrsCommand)
        {
            return OkResult(cqrsCommand);
        }

        protected override async Task Handle(CreateCqrsCommand<TEntity> cqrsCommand)
        {
            SetDataContext.Set<TEntity>().Add(cqrsCommand.Entity);
        }
    }
}