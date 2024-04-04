using Nest;
using WineCraze.Core.Contracts;
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

        public async Task<IEnumerable<Wine>> GetAllWinesAsync()
        {
            return await wines.GetAllWinesAsync();
        }

        public async Task<Wine> GetByIdAsync(int id)
        {
            return await wines.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Wine>> GetLastThreeWinesAsync()
        {
            // Implement logic to get the last three wines
            throw new NotImplementedException();
        }

        public async Task AddWineAsync(Wine wine)
        {
            await wines.AddAsync(wine);
        }

        public async Task UpdateWineAsync(Wine wine)
        {
            await wines.UpdateAsync(wine);
        }

        public async Task DeleteAsync(int id)
        {
            object value = await wines.DeleteAsync(id);
        }

        public Task<Wine> GetWineByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Wine>> GetLastThreeWineAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Wine wine)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Wine wine)
        {
            throw new NotImplementedException();
        }
    }
}
   