using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CqrsSample.Domain.AggregateRoots;

namespace CqrsSample.Data.Events.Base
{
    interface IDeleteHandler<T> where T:Entity
    {
        void PreDelete(T entity);

        void PostDelete(T entity);
    }
}
