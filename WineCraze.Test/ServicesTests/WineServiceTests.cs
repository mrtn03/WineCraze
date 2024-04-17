using Moq;
using WineCraze.Core.Contracts;
using WineCraze.Core.Exceptions;
using WineCraze.Core.Models.Inventory;
using WineCraze.Core.Services;
using WineCraze.Infrastructure.Data.Common;
using WineCraze.Infrastructure.Data.Models;

namespace WineCraze.Test.ServicesTests
{
    [TestFixture]
    public class WineServiceTests
    {
        private Mock<IRepository> _mockRepository;
        private IWineService _wineService;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository>();
            _wineService = new WineService(_mockRepository.Object);
        }

        [Test]
        public async Task GetAllWinesAsync_Returns_AllWines()
        {
            // Arrange
            var wines = new List<Wine>
            {
                new Wine { Id = 1, Name = "Wine1", Country = "Country1", Type = "Type1", Price = 10, CreatedOn = DateTime.Now, Region = "Region1", Quantity = 5 },
                new Wine { Id = 2, Name = "Wine2", Country = "Country2", Type = "Type2", Price = 20, CreatedOn = DateTime.Now, Region = "Region2", Quantity = 10 }
            };
            _mockRepository.Setup(repo => repo.All<Wine>()).Returns(wines.AsQueryable());

            // Act
            var result = await _wineService.GetAllWinesAsync();

            // Assert
            Assert.AreEqual(wines.Count, result.Count());
            Assert.AreEqual(wines[0].Name, result.ElementAt(0).Name);
            Assert.AreEqual(wines[1].Type, result.ElementAt(1).Type);
        }

        [Test]
        public async Task GetWineByIdAsync_Returns_Wine_IfFound()
        {
            // Arrange
            var wineId = 1;
            var wine = new Wine { Id = wineId, Name = "Wine1", Country = "Country1", Type = "Type1", Price = 10, CreatedOn = DateTime.Now, Region = "Region1", Quantity = 5 };
            _mockRepository.Setup(repo => repo.GetByIdAsync<Wine>(wineId)).ReturnsAsync(wine);

            // Act
            var result = await _wineService.GetWineByIdAsync(wineId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(wine.Id, result.Id);
            Assert.AreEqual(wine.Name, result.Name);
        }

        [Test]
        public async Task GetWineByIdAsync_Returns_Null_IfNotFound()
        {
            // Arrange
            var wineId = 1;
            _mockRepository.Setup(repo => repo.GetByIdAsync<Wine>(wineId)).ReturnsAsync((Wine)null);

            // Act
            var result = await _wineService.GetWineByIdAsync(wineId);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task AddWineAsync_Adds_New_Wine()
        {
            // Arrange
            var wineViewModel = new WineViewModel { Name = "Wine1", Country = "Country1", Type = "Type1", Price = 10, CreatedOn = DateTime.Now, Region = "Region1", Quantity = 5 };

            // Act
            await _wineService.AddWineAsync(wineViewModel);

            // Assert
            _mockRepository.Verify(repo => repo.AddAsync(It.IsAny<Wine>()), Times.Once);
            _mockRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task UpdateWineAsync_Throws_Exception_IfWineNotFound()
        {
            // Arrange
            var wineViewModel = new WineViewModel { Id = 1, Name = "Wine1", Country = "Country1", Type = "Type1", Price = 10, CreatedOn = DateTime.Now, Region = "Region1", Quantity = 5 };
            _mockRepository.Setup(repo => repo.GetByIdAsync<Wine>(1)).ReturnsAsync((Wine)null);

            // Act & Assert
            Assert.ThrowsAsync<WineUpdateException>(() => _wineService.UpdateWineAsync(wineViewModel));
        }

        [Test]
        public async Task DeleteWineAsync_Throws_Exception_IfWineNotFound()
        {
            // Arrange
            var wineId = 1;
            _mockRepository.Setup(repo => repo.GetByIdAsync<Wine>(wineId)).ReturnsAsync((Wine)null);

            // Act & Assert
            Assert.ThrowsAsync<WineNotFoundException>(() => _wineService.DeleteWineAsync(wineId));
        }

        [Test]
        public async Task DeleteWineAsync_Deletes_Wine()
        {
            // Arrange
            var wineId = 1;
            var wine = new Wine { Id = wineId, Name = "Wine1", Country = "Country1", Type = "Type1", Price = 10, CreatedOn = DateTime.Now, Region = "Region1", Quantity = 5 };
            _mockRepository.Setup(repo => repo.GetByIdAsync<Wine>(wineId)).ReturnsAsync(wine);

            // Act
            await _wineService.DeleteWineAsync(wineId);

            // Assert
            _mockRepository.Verify(repo => repo.DeleteAsync<Wine>(wineId), Times.Once);
            _mockRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task SearchWinesAsync_Returns_Filtered_Wines()
        {
            // Arrange
            var searchTerm = "Wine1";
            var wines = new List<Wine>
            {
                new Wine { Id = 1, Name = "Wine1", Country = "Country1", Type = "Type1", Price = 10, CreatedOn = DateTime.Now, Region = "Region1", Quantity = 5 },
                new Wine { Id = 2, Name = "Wine2", Country = "Country2", Type = "Type2", Price = 20, CreatedOn = DateTime.Now, Region = "Region2", Quantity = 10 }
            };
            _mockRepository.Setup(repo => repo.All<Wine>()).Returns(wines.AsQueryable());

            // Act
            var result = await _wineService.SearchWinesAsync(searchTerm);

            // Assert
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(wines[0].Name, result.ElementAt(0).Name);
        }
    }
}
