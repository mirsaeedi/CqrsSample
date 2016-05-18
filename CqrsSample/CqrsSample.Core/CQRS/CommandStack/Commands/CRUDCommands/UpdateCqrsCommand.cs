using CqrsSample.Core.Data.Models;

namespace CqrsSample.Core.CQRS.CommandStack.Commands.CRUDCommands
{
    public class UpdateCqrsCommand<TEntity>:CqrsCommand
        where TEntity : Entity
    {
        public TEntity Entity { get; set; }
    }
}