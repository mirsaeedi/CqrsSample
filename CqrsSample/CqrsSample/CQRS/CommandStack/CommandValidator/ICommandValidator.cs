using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CqrsSample.CommandStack.Commands;
using CqrsSample.CQRS.CommandStack.Commands;

namespace CqrsSample.CommandStack.CommandValidator
{
    internal interface ICommandValidator<in TCommand>
        where TCommand : CqrsCommand
    {
        CqrsCommandResult IsValid(TCommand command, CqrsCommandResult commandResult);
    }
}
