using WineCraze.Infrastructure.Data.Models;

namespace WineCraze.Infrastructure.Data.Common
{
    public interface IWineRepository
    {
        IEnumerable<Wine> GetAll();
        Wine GetById(int id);
        void Add(Wine wine);
        void Update(Wine wine);
        void Delete(int id);
    }
}
