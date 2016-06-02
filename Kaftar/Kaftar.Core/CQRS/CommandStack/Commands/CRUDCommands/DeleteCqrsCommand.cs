using Kaftar.Core.Data.Models;

namespace Kaftar.Core.CQRS.CommandStack.Commands.CRUDCommands
{
    public class DeleteCqrsCommand<TEntity>:CqrsCommand
        where TEntity : Entity
    {
        public TEntity Entity { get; set; }
    }
}