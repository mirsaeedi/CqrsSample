using System.Threading.Tasks;
using CqrsSample.CQRS.CommandStack.Commands;

namespace CqrsSample.CQRS.CommandStack.CommandHandlers
{
    public interface ICommandHandler<in TCommand, TCommandResult>
          where TCommand : CqrsCommand
          where TCommandResult : CqrsCommandResult
    {
        Task<TCommandResult> Execute(TCommand command, int userId, string ip);
    }    
    
}