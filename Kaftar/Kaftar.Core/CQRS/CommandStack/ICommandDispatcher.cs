using System.Threading.Tasks;
using Kaftar.Core.CQRS.CommandStack.Commands;

namespace Kaftar.Core.CQRS.CommandStack
{
    public interface ICommandDispatcher
    {
        Task<CqrsCommandResult> Dispatch<TCommand>(TCommand command, int userId, string ip) where TCommand : CqrsCommand;
    }
}