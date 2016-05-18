using System.Data.Entity;
using System.Threading.Tasks;
using CqrsSample.Data.Models;

namespace CqrsSample.Data.DataContext
{
    public interface IDataContext:ISetDataContext
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}