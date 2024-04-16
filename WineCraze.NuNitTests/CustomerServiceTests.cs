using Moq;
using NUnit.Framework;
using WineCraze.Core.Models.Customer;
using WineCraze.Core.Services;
using WineCraze.Infrastructure.Data.Common;
using WineCraze.Infrastructure.Data.Models;
using Assert = NUnit.Framework.Assert;

namespace WineCraze.NuNitTests
{
    [TestFixture]
    public class CustomerServiceTests
    {
        private CustomerService customerService;
        private Mock<IRepository> repositoryMock;
        private List<Customer> customers;

        [SetUp]
        public void Setup()
        {
            // Arrange
            repositoryMock = new Mock<IRepository>();
            customerService = new CustomerService(repositoryMock.Object);
            customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Customer 1", Email = "customer1@example.com", Address = "Address 1", PhoneNumber = "1234567890" },
                new Customer { Id = 2, Name = "Customer 2", Email = "customer2@example.com", Address = "Address 2", PhoneNumber = "1234567890" },
                new Customer { Id = 3, Name = "Customer 3", Email = "customer3@example.com", Address = "Address 3", PhoneNumber = "1234567890" }
            };

            var customerDbSetMock = customers.AsQueryable()
                .BuildMockDbSet();
            repositoryMock.Setup(r => r.All<Customer>()).Returns(customerDbSetMock.Object);
        }

        [Test]
        public async Task GetAllCustomersAsync_ReturnsAllCustomers()
        {
            // Act
            var result = await customerService.GetAllCustomersAsync();

            // Assert
            Assert.AreEqual(customers.Count, result.Count());
        }

        [Test]
        public async Task GetCustomerByIdAsync_ExistingId_ReturnsCustomer()
        {
            // Arrange
            int id = 1;

            // Act
            var result = await customerService.GetCustomerByIdAsync(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
        }

        [Test]
        public async Task GetCustomerByIdAsync_NonExistingId_ReturnsNull()
        {
            // Arrange
            int id = 100;

            // Act
            var result = await customerService.GetCustomerByIdAsync(id);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task AddCustomerAsync_ValidCustomer_AddsCustomer()
        {
            // Arrange
            var viewModel = new CustomerViewModel
            {
                Name = "New Customer",
                Email = "newcustomer@example.com",
                Address = "New Address",
                PhoneNumber = "1234567890"
            };

            // Act
            await customerService.AddCustomerAsync(viewModel);

            // Assert
            repositoryMock.Verify(r => r.AddAsync(It.IsAny<Customer>()), Times.Once);
            repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task UpdateCustomerAsync_ExistingId_UpdatesCustomer()
        {
            // Arrange
            int id = 1;
            var viewModel = new CustomerViewModel
            {
                Id = id,
                Name = "Updated Customer",
                Email = "updatedcustomer@example.com",
                Address = "Updated Address",
                PhoneNumber = "1234567890"
            };

            // Act
            await customerService.UpdateCustomerAsync(viewModel);

            // Assert
            repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
            var customerToUpdate = customers.FirstOrDefault(c => c.Id == id);
            Assert.IsNotNull(customerToUpdate);
            Assert.AreEqual(viewModel.Name, customerToUpdate.Name);
            Assert.AreEqual(viewModel.Email, customerToUpdate.Email);
            Assert.AreEqual(viewModel.Address, customerToUpdate.Address);
            Assert.AreEqual(viewModel.PhoneNumber, customerToUpdate.PhoneNumber);
        }

        [Test]
        public async Task UpdateCustomerAsync_NonExistingId_ThrowsArgumentException()
        {
            // Arrange
            var viewModel = new CustomerViewModel
            {
                Id = 100, // Non-existing id
                Name = "Updated Customer",
                Email = "updatedcustomer@example.com",
                Address = "Updated Address",
                PhoneNumber = "1234567890"
            };

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await customerService.UpdateCustomerAsync(viewModel));
        }

        [Test]
        public async Task DeleteCustomerAsync_ExistingId_DeletesCustomer()
        {
            // Arrange
            int id = 1;

            // Act
            await customerService.DeleteCustomerAsync(id);

            // Assert
            repositoryMock.Verify(r => r.DeleteAsync<Customer>(id), Times.Once);
            repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task DeleteCustomerAsync_NonExistingId_ThrowsArgumentException()
        {
            // Arrange
            int id = 100; // Non-existing id

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await customerService.DeleteCustomerAsync(id));
        }
    }
}