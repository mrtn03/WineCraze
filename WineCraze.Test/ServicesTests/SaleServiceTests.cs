using Moq;
using WineCraze.Core.Contracts;
using WineCraze.Core.Models.Sale;
using WineCraze.Core.Services;
using WineCraze.Infrastructure.Data.Common;
using WineCraze.Infrastructure.Data.Models;

namespace WineCraze.Test.ServicesTests
{
    [TestFixture]
    public class SaleServiceTests
    {
        private Mock<IRepository> _repositoryMock;
        private ISaleService _saleService;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<IRepository>();
            _saleService = new SaleService(_repositoryMock.Object);
        }

        [Test]
        public async Task GetAllSalesAsync_ShouldReturnAllSales()
        {
            // Arrange
            var sales = new List<Sale>
        {
            new Sale 
            { 
                Id = 1,
                Quantity = 10, 
                TotalPrice = 100, 
                CustomerId = 1,
                WineId = 1 },

            new Sale 
            { 
                Id = 2,
                Quantity = 5, 
                TotalPrice = 50, 
                CustomerId = 2,
                WineId = 2 
            }
        };
            _repositoryMock.Setup(repo => repo.All<Sale>()).Returns(sales.AsQueryable());

            // Act
            var result = await _saleService.GetAllSalesAsync();

            // Assert
            Assert.AreEqual(sales.Count, result.Count());
        }

        [Test]
        public async Task GetSaleByIdAsync_ShouldReturnSaleWithGivenId()
        {
            // Arrange
            var saleId = 1;
            var sale = new Sale 
            { 
                Id = saleId, 
                Quantity = 10, 
                TotalPrice = 100,
                CustomerId = 1,
                WineId = 1 
            };

            _repositoryMock.Setup
                (repo => repo.GetByIdAsync<Sale>(saleId)).Returns(Task.FromResult(sale));

            // Act
            var result = await _saleService.GetSaleByIdAsync(saleId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(saleId, result.Id);
        }

        [Test]
        public async Task CreateSaleAsync_ShouldAddSaleToRepository()
        {
            // Arrange
            var viewModel = new SaleViewModel 
            { 
                Quantity = 10,
                TotalPrice = 100, 
                CustomerId = 1,
                WineId = 1 };

            // Act
            await _saleService.CreateSaleAsync(viewModel);

            // Assert
            _repositoryMock.Verify
                (repo => repo.AddAsync(It.IsAny<Sale>()), Times.Once);

            _repositoryMock.Verify
                (repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task UpdateSaleAsync_ShouldUpdateSaleInRepository()
        {
            // Arrange
            var saleId = 1;
            var viewModel = new SaleViewModel 
            { 
                Id = saleId,
                Quantity = 5, 
                TotalPrice = 50, 
                CustomerId = 2,
                WineId = 2 };

            var sale = new Sale 
            { 
                Id = saleId, 
                Quantity = 10, 
                TotalPrice = 100, 
                CustomerId = 1, 
                WineId = 1 };

            _repositoryMock.Setup
                (repo => repo.GetByIdAsync<Sale>(saleId)).Returns(Task.FromResult(sale));

            // Act
            await _saleService.UpdateSaleAsync(viewModel);

            // Assert
            _repositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task DeleteSaleAsync_ShouldDeleteSaleFromRepository()
        {
            // Arrange
            var saleId = 1;

            // Act
            await _saleService.DeleteSaleAsync(saleId);

            // Assert
            _repositoryMock.Verify
                (repo => repo.DeleteAsync<Sale>(It.IsAny<int>()), Times.Once);
            _repositoryMock.Verify
                (repo => repo.SaveChangesAsync(), Times.Once);
        }
    }
}
