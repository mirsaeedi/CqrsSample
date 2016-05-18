using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CqrsSample.CommandStack;
using CqrsSample.CQRS.CommandStack.Commands;
using CqrsSample.CQRS.CommandStack.Commands.CRUDCommands;
using CqrsSample.Data.DataContext;
using CqrsSample.Data.Models;

namespace CqrsSample.CQRS.CommandStack.CommandHandlers.CRUDCommandHandlers
{

    // در اینجا باید بتوانیم کل گراف را به صورت خودکار ذخیره کنیم
    internal class UpdateCommandHandler<TEntity> : CommandHandler<UpdateCqrsCommand<TEntity>, CqrsCommandResult>
        where TEntity : Entity
    {

        public UpdateCommandHandler(IDataContext innerDataContext, bool parentOfChain = true) 
            : base(innerDataContext, parentOfChain)
        {
        }

        internal override CqrsCommandResult PreExecutionValidation(UpdateCqrsCommand<TEntity> cqrsCommand, int userId)
        {
            return OkResult(cqrsCommand);
        }

        internal override async Task Handle(UpdateCqrsCommand<TEntity> cqrsCommand, int userId)
        {
            SetDataContext.Update(cqrsCommand.Entity);
        }
    }
}