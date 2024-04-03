using WineCraze.Core.Models.Sale;

namespace WineCraze.Core.Contracts
{
    public interface ISaleService
    {
        Task<IEnumerable<SaleViewModel>> GetAllSalesAsync();
        Task CreateSaleAsync(SaleViewModel saleViewModel);
        Task<SaleViewModel> GetSaleByIdAsync(int id);
        Task UpdateSaleAsync(SaleViewModel saleViewModel);
        Task DeleteSaleAsync(int id);
    }
}
