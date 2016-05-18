using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CqrsSample.Domain.AggregateRoots;

namespace CqrsSample.Data.Events.Base
{
    interface IUpdateHandler<T> where T:Entity
    {
        void PreUpdate(T entity);

        void PostUpdate(T entity);
    }
}
