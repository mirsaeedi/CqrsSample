using System;

namespace CqrsSample.Core.CQRS.CommandStack.Commands
{
    public class CqrsCommandResult
    {
        public CqrsMessageResultMetaData MetaData { get; private set; }

        public CqrsCommandResult(int resultCode, string description, CqrsCommand command)
        {
            MetaData = new CqrsMessageResultMetaData(resultCode, description, DateTime.Now, command.Guid);
        }

        public CqrsCommandResult(int resultCode, CqrsCommand command)
            :this(resultCode,null,command)
        {
        }
    }
}