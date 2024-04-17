using Moq;
using WineCraze.Core.Models.Customer;
using WineCraze.Core.Services;
using WineCraze.Infrastructure.Data.Common;
using WineCraze.Infrastructure.Data.Models;

namespace WineCraze.Test.ServicesTests
{
    [TestFixture]
    public class CustomerServiceTests
    {
        private Mock<IRepository> _repositoryMock;
        private CustomerService _customerService;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<IRepository>();
            _customerService = new CustomerService(_repositoryMock.Object);
        }

        [Test]
        public async Task GetAllCustomersAsync_ShouldReturnListOfCustomerViewModels()
        {
            // Arrange
            var mockRepository = new Mock<IRepository>();
            var customerService = new CustomerService(mockRepository.Object);

            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Customer1", Email = "customer1@example.com" },
                new Customer { Id = 2, Name = "Customer2", Email = "customer2@example.com" }
            };

            mockRepository.Setup(repo => repo.All<Customer>()).Returns(customers.AsQueryable());

            // Act
            var result = await customerService.GetAllCustomersAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<CustomerViewModel>>(result);
            Assert.AreEqual(2, result.Count()); // Assuming we have 2 customers in the list
        }

        [Test]
        public async Task GetCustomerByIdAsync_ShouldReturnCustomerViewModel()
        {
            // Arrange
            int customerId = 1;
            var customer = new Customer { Id = customerId, Name = "John", Email = "john@example.com", Address = "123 Main St", PhoneNumber = "123-456-7890" };
            _repositoryMock.Setup(repo => repo.GetByIdAsync<Customer>(customerId)).Returns(Task.FromResult(customer));

            // Act
            var result = await _customerService.GetCustomerByIdAsync(customerId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(customerId, result.Id);
        }

        [Test]
        public async Task AddCustomerAsync_ShouldAddCustomerToRepository()
        {
            // Arrange
            var viewModel = new CustomerViewModel
            {
                Name = "John",
                Email = "john@example.com",
                Address = "123 Main St",
                PhoneNumber = "123-456-7890"
            };

            // Act
            await _customerService.AddCustomerAsync(viewModel);

            // Assert
            _repositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Customer>()), Times.Once);
            _repositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task UpdateCustomerAsync_ShouldUpdateCustomerInRepository()
        {
            // Arrange
            int customerId = 1;
            var viewModel = new CustomerViewModel { Id = customerId, Name = "John", Email = "john@example.com", Address = "123 Main St", PhoneNumber = "123-456-7890" };
            var customer = new Customer { Id = customerId, Name = "John", Email = "john@example.com", Address = "123 Main St", PhoneNumber = "123-456-7890" };
            _repositoryMock.Setup(repo => repo.GetByIdAsync<Customer>(customerId)).Returns(Task.FromResult(customer));

            // Act
            await _customerService.UpdateCustomerAsync(viewModel);

            // Assert
            _repositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task DeleteCustomerAsync_ShouldDeleteCustomerFromRepository()
        {
            // Arrange
            int customerId = 1;
            var customer = new Customer { Id = customerId, Name = "John", Email = "john@example.com", Address = "123 Main St", PhoneNumber = "123-456-7890" };
            _repositoryMock.Setup(repo => repo.GetByIdAsync<Customer>(customerId)).Returns(Task.FromResult(customer));

            // Act
            await _customerService.DeleteCustomerAsync(customerId);

            // Assert
            _repositoryMock.Verify(repo => repo.DeleteAsync<Customer>(customerId), Times.Once);
            _repositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }
    }
}