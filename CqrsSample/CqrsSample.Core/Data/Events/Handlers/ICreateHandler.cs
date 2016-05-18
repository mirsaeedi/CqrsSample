using CqrsSample.Core.Data.Models;

namespace CqrsSample.Core.Data.Events.Handlers
{
    public interface ICreateHandler<T> where T:Entity
    {
        void PreCreate(T entity);

        void PostCreate(T entity);
    }
}
