using System.Threading.Tasks;
using Kaftar.Core.CQRS.CommandStack.Commands;
using Kaftar.Core.CQRS.CommandStack.Commands.CRUDCommands;
using Kaftar.Core.Data.DataContext;
using Kaftar.Core.Data.Models;

namespace Kaftar.Core.CQRS.CommandStack.CommandHandlers.CRUDCommandHandlers
{
    internal class DeleteCommandHandler<TEntity> : CommandHandler<UpdateCqrsCommand<TEntity>, CqrsCommandResult>
        where TEntity : Entity
    {


        protected override CqrsCommandResult PreExecutionValidation(UpdateCqrsCommand<TEntity> cqrsCommand)
        {
            return OkResult(cqrsCommand);
        }

        protected override async Task Handle(UpdateCqrsCommand<TEntity> cqrsCommand)
        {
            SetDataContext.Update(cqrsCommand.Entity);
        }
    }
}