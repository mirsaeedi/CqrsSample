using System.Threading.Tasks;
using Kaftar.Core.CQRS.CommandStack.Commands;

namespace Kaftar.Core.CQRS.CommandStack.CommandHandlers
{
    public interface ICommandHandler<in TCommand, TCommandResult>
          where TCommand : CqrsCommand
          where TCommandResult : CqrsCommandResult
    {
        Task<TCommandResult> Execute(TCommand command);
    }    
    
}