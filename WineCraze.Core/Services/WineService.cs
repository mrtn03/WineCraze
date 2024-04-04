using Nest;
using WineCraze.Core.Contracts;
using WineCraze.Core.Models.InventoryOrWine;
using WineCraze.Infrastructure.Data.Common;
using WineCraze.Infrastructure.Data.Models;

namespace WineCraze.Core.Services
{
    public class WineService : IWineService
    {
        private readonly IRepository wines;

        public WineService(IRepository _wineRepository)
        {
            wines = _wineRepository;
        }

        public Task AddWineAsync(WineViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteWineAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WineViewModel>> GetAllWinesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<WineViewModel> GetWineByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateWineAsync(WineViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
   