using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avicenna.Domain.CQRS.CommandStack.Commands;
using Kaftar.Core.CQRS.CommandStack.CommandHandlers;
using Kaftar.Core.CQRS.CommandStack.Commands;

namespace Avicenna.Domain.CQRS.CommandStack.CommandHandlers
{
    internal class CreateVisitCommandHandler : CommandHandler<CreateVisitCommand, CqrsCommandResult>
    {
        protected override async Task Handle(CreateVisitCommand command)
        {
            
        }

        protected override CqrsCommandResult PreExecutionValidation(CreateVisitCommand command)
        {
            return OkResult(command);
        }
    }
}
