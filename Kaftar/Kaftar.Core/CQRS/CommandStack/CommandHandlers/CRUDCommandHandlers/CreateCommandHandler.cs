using System.Threading.Tasks;
using Kaftar.Core.CQRS.CommandStack.Commands;
using Kaftar.Core.CQRS.CommandStack.Commands.CRUDCommands;
using Kaftar.Core.Data.DataContext;
using Kaftar.Core.Data.Models;

namespace Kaftar.Core.CQRS.CommandStack.CommandHandlers.CRUDCommandHandlers
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