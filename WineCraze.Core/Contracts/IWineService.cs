using WineCraze.Core.Models.Inventory;

namespace WineCraze.Core.Contracts
{
    public interface IWineService
    {
        Task<IEnumerable<WineViewModel>> GetAllWinesAsync();
        Task<WineViewModel?> GetWineByIdAsync(int id);
        Task AddWineAsync(WineViewModel viewModel);
        Task UpdateWineAsync(WineViewModel viewModel);
        Task DeleteWineAsync(int id);
        Task<IEnumerable<WineViewModel>> SearchWinesAsync(string searchTerm);
    }
}


// Summary - Provides methods for managing wines.