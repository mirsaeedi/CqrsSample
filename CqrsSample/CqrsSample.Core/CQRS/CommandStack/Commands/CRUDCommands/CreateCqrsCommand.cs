using CqrsSample.Core.Data.Models;

namespace CqrsSample.Core.CQRS.CommandStack.Commands.CRUDCommands
{
    public class CreateCqrsCommand<TEntity>:CqrsCommand
        where TEntity : Entity
    {
        public TEntity Entity { get; set; }
    }
}