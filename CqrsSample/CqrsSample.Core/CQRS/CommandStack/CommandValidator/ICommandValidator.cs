using CqrsSample.Core.CQRS.CommandStack.Commands;

namespace CqrsSample.Core.CQRS.CommandStack.CommandValidator
{
    internal interface ICommandValidator<in TCommand>
        where TCommand : CqrsCommand
    {
        CqrsCommandResult IsValid(TCommand command, CqrsCommandResult commandResult);
    }
}
