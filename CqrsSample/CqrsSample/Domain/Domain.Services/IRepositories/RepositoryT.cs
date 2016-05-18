using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CqrsSample.Domain.AggregateRoots;

namespace CqrsSample.Domain.Services.IRepositories
{
    public class Repository<T> where T : AggregateRoot, new()
    {

        public void Save(AggregateRoot aggregate, int expectedVersion)
        {

        }
    }
}