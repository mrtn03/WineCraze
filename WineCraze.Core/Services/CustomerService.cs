using WineCraze.Core.Contracts;
using WineCraze.Core.Models.Customer;
using WineCraze.Infrastructure.Data.Common;
using WineCraze.Infrastructure.Data.Models;

namespace WineCraze.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository customer;

        public CustomerService(IRepository _repository)
        {
            customer = _repository;
        }

        public Task AddCustomerAsync(CustomerViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCustomerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerViewModel>> GetAllCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerViewModel> GetCustomerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCustomerAsync(CustomerViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
