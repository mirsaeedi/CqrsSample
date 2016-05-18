using System.Threading.Tasks;
using CqrsSample.Core.CQRS.CommandStack.Commands;

namespace CqrsSample.Core.CQRS.CommandStack
{
    public interface ICommandDispatcher
    {
        Task<CqrsCommandResult> Dispatch<TCommand>(TCommand command, int userId, string ip) where TCommand : CqrsCommand;
    }
}