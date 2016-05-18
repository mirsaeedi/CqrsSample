using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using CqrsSample.CommandStack.Commands;
using CqrsSample.CQRS.CommandStack.Commands;

namespace CqrsSample.CommandStack
{
    public interface ICommandDispatcher
    {
        Task<CqrsCommandResult> Dispatch<TCommand>(TCommand command, int userId, string ip) where TCommand : CqrsCommand;
    }
}