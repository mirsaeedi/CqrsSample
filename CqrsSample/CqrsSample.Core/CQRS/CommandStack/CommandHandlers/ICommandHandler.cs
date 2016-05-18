using System.Threading.Tasks;
using CqrsSample.Core.CQRS.CommandStack.Commands;

namespace CqrsSample.Core.CQRS.CommandStack.CommandHandlers
{
    public interface ICommandHandler<in TCommand, TCommandResult>
          where TCommand : CqrsCommand
          where TCommandResult : CqrsCommandResult
    {
        Task<TCommandResult> Execute(TCommand command);
    }    
    
}