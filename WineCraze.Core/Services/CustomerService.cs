using WineCraze.Core.Contracts;
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

        public Task<bool> AddCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCustomerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
