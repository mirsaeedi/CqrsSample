using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CqrsSample.CQRS;
using CqrsSample.CQRS.CommandStack.Commands;
using CqrsSample.QueryStack.Queries;

namespace CqrsSample.QueryStack
{
    public class CqrsQueryResult<T>
    {
        public T Value { get; set; }

        public CqrsMessageResultMetaData MetaData { get; private set; }

        public CqrsQueryResult(int resultCode, string description, CqrsQuery query, T value)
        {
            MetaData = new CqrsMessageResultMetaData(resultCode, description, DateTime.Now, query.Guid);

            Value = value;
        }

        public CqrsQueryResult(int resultCode, CqrsQuery query, T value)
            :this(resultCode,null,query,value)
        {
        }
    }
}