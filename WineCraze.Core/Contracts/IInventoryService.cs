using WineCraze.Core.Models.InventoryOrWine;

namespace WineCraze.Core.Contracts
{
    public interface IInventoryService
    {
        IEnumerable<WineViewModel> GetAllWines();
        WineViewModel GetWineById(int id);
        void CreateWine(WineViewModel viewModel);
        void UpdateWine(WineViewModel viewModel);
        void DeleteWine(int id);
    }
}
