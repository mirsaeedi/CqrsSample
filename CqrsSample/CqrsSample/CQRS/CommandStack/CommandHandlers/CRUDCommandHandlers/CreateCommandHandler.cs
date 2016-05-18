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
    internal class CreateCommandHandler<TEntity> : CommandHandler<CreateCqrsCommand<TEntity>, CqrsCommandResult>
        where TEntity : Entity
    {

        public CreateCommandHandler(IDataContext innerDataContext, bool parentOfChain = true) 
            : base(innerDataContext, parentOfChain)
        {
        }

        internal override CqrsCommandResult PreExecutionValidation(CreateCqrsCommand<TEntity> cqrsCommand, int userId)
        {
            return OkResult(cqrsCommand);
        }

        internal override async Task Handle(CreateCqrsCommand<TEntity> cqrsCommand, int userId)
        {
            SetDataContext.Set<TEntity>().Add(cqrsCommand.Entity);
        }
    }
}