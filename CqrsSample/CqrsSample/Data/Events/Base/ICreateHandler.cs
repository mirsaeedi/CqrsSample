using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CqrsSample.Data.Models;


namespace CqrsSample.Data.Events.Base
{
    interface ICreateHandler<T> where T:Entity
    {
        void PreCreate(T entity);

        void PostCreate(T entity);
    }
}
