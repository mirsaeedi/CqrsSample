using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CqrsSample.CommandStack.Commands;
using CqrsSample.Data.Models;

namespace CqrsSample.CQRS.CommandStack.Commands.CRUDCommands
{
    public class DeleteCqrsCommand<TEntity>:CqrsCommand
        where TEntity : Entity
    {
        public TEntity Entity { get; set; }
    }
}