using System.Threading.Tasks;

namespace Kaftar.Core.Data.DataContext
{
    public interface IDataContext:ISetDataContext
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}