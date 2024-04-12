using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<CustomerViewModel>> GetAllCustomersAsync()
        {
            var customerViewModels = await customer
                .All<Customer>()
                .Select(c => new CustomerViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Email = c.Email,
                    Address = c.Address,
                    PhoneNumber = c.PhoneNumber
                })
                .ToListAsync();

            return customerViewModels;
        }

        public async Task<CustomerViewModel> GetCustomerByIdAsync(int id)
        {
            var GetCustomer = await customer.GetByIdAsync<Customer>(id);

            if (customer == null)
            {
                return null;
            }

            var customerViewModel = new CustomerViewModel
            {
                Id = GetCustomer.Id,
                Name = GetCustomer.Name,
                Email = GetCustomer.Email,
                Address = GetCustomer.Address,
                PhoneNumber = GetCustomer.PhoneNumber
            };

            return customerViewModel;
        }

        public async Task AddAsync(CustomerViewModel viewModel)
        {
            var customer = new Customer
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Address = viewModel.Address,
                PhoneNumber = viewModel.PhoneNumber
            };

            await customer.AddAsync(customer);
            await customer.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(CustomerViewModel viewModel)
        {
            var UpCustomer = await customer.GetByIdAsync<Customer>(viewModel.Id);

            if (customer == null)
            {
                throw new ArgumentException("Customer not found.");
            }

            UpCustomer.Name = viewModel.Name;
            UpCustomer.Email = viewModel.Email;
            UpCustomer.Address = viewModel.Address;
            UpCustomer.PhoneNumber = viewModel.PhoneNumber;

            await customer.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var resCustomer = await customer.GetByIdAsync<Customer>(id);

            if (customer == null)
            {
                throw new ArgumentException("Customer not found.");
            }

            await customer.DeleteAsync<Customer>(id);
            await customer.SaveChangesAsync();
        }
    }
}
