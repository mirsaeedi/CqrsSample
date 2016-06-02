using Kaftar.Core.Data.Models;

namespace Kaftar.Core.Data.Events.Handlers
{
    public interface ICreateHandler<T> where T:Entity
    {
        void PreCreate(T entity);

        void PostCreate(T entity);
    }
}
