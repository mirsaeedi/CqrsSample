using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CqrsSample.Data.Events.Base;
using CqrsSample.Data.Models;

namespace CqrsSample.Data.Events
{
    public class FineCreateHandler : ICreateHandler<Fine>
    {
        public void Handle(Fine entity)
        {
            
        }

        public void PreCreate(Fine entity)
        {
            throw new NotImplementedException();
        }

        public void PostCreate(Fine entity)
        {
            throw new NotImplementedException();
        }
    }
}