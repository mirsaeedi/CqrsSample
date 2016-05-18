using System;
using CqrsSample.Data.Events.Base;
using CqrsSample.Data.Models;

namespace CqrsSample.FineBusiness.Data.Events
{
    public class FineCreateHandler : ICreateHandler<Fine>
    {
        public void PostCreate(Fine entity)
        {
            throw new NotImplementedException();
        }

        public void PreCreate(Fine entity)
        {
            throw new NotImplementedException();
        }
    }
}