using System.Threading.Tasks;

namespace CqrsSample.Core.Data.DataContext
{
    public interface IDataContext:ISetDataContext
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}