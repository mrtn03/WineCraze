using WineCraze.Core.Models.Sale;

namespace WineCraze.Core.Contracts
{
    public interface ISaleService
    {
        Task<IEnumerable<SaleViewModel>> GetAllSalesAsync();
        Task<SaleViewModel> GetSaleByIdAsync(int id);
        Task CreateSaleAsync(SaleViewModel saleViewModel);
        Task UpdateSaleAsync(SaleViewModel saleViewModel);
        Task DeleteSaleAsync(int id);
    }
}


// Summary - Provides methods for managing sales.