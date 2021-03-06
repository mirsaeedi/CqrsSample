﻿using System.Threading.Tasks;
using Kaftar.Core.CQRS.CommandStack.Commands;
using Kaftar.Core.CQRS.CommandStack.Commands.CRUDCommands;
using Kaftar.Core.Data.DataContext;
using Kaftar.Core.Data.Models;

namespace Kaftar.Core.CQRS.CommandStack.CommandHandlers.CRUDCommandHandlers
{

    // در اینجا باید بتوانیم کل گراف را به صورت خودکار ذخیره کنیم
    internal class UpdateCommandHandler<TEntity> : CommandHandler<UpdateCqrsCommand<TEntity>, CqrsCommandResult>
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