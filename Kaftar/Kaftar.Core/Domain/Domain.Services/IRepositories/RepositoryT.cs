using Kaftar.Core.Domain.AggregateRoots;

namespace Kaftar.Core.Domain.Domain.Services.IRepositories
{
    public class Repository<T> where T : AggregateRoot, new()
    {

        public void Save(AggregateRoot aggregate, int expectedVersion)
        {

        }
    }
}