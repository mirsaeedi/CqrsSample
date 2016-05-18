using System;
using CqrsSample.Core.Data.Events.Handlers;

namespace CqrsSample.Business.Fine.Data.EventHandlers
{
    public class FineCreateHandler : ICreateHandler<Models.Fine>
    {
        public void PostCreate(Models.Fine entity)
        {
            throw new NotImplementedException();
        }

        public void PreCreate(Models.Fine entity)
        {
            throw new NotImplementedException();
        }
    }
}