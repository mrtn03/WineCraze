using WineCraze.Core.Models.Customer;
using WineCraze.Infrastructure.Data.Models;

namespace WineCraze.Core.Contracts
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerViewModel>> GetAllCustomersAsync();
        Task<CustomerViewModel> GetCustomerByIdAsync(int id);
        Task AddCustomerAsync(CustomerViewModel viewModel);
        Task UpdateCustomerAsync(CustomerViewModel viewModel);
        Task DeleteCustomerAsync(int id);
    }
}