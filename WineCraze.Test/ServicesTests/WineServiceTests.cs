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
        public async Task GetWineByIdAsync_Returns_Wine_When_Found()
        {
            // Arrange
            var wineId = 1;
            var wine = new Wine { Id = wineId, Name = "Wine1", Country = "Country1", Type = "Type1", Price = 10,  Region = "Region1", Quantity = 5 };

            _mockRepository.Setup(repo => repo.GetByIdAsync<Wine>(wineId))
                           .ReturnsAsync(wine);

            // Act
            var result = await _wineService.GetWineByIdAsync(wineId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(wineId, result.Id);
            Assert.AreEqual(wine.Name, result.Name);
            Assert.AreEqual(wine.Country, result.Country);
            Assert.AreEqual(wine.Type, result.Type);
            Assert.AreEqual(wine.Price, result.Price);
            Assert.AreEqual(wine.CreatedOn.ToString(), result.CreatedOn); // Convert DateTime to string
            Assert.AreEqual(wine.Region, result.Region);
            Assert.AreEqual(wine.Quantity, result.Quantity);
        }

        [Test]
        public async Task GetWineByIdAsync_Returns_Null_When_Not_Found()
        {
            // Arrange
            var wineId = 1;
            _mockRepository.Setup(repo => repo.GetByIdAsync<Wine>(wineId))
                           .ReturnsAsync((Wine)null);

            // Act
            var result = await _wineService.GetWineByIdAsync(wineId);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task AddWineAsync_Adds_New_Wine()
        {
            // Arrange
            var viewModel = new WineViewModel
            {
                Name = "NewWine",
                Country = "NewCountry",
                Type = "NewType",
                Price = 20,
                CreatedOn = DateTime.Now.ToString(), // Convert DateTime to string
                Region = "NewRegion",
                Quantity = 10
            };

            // Act
            await _wineService.AddWineAsync(viewModel);

            // Assert
            _mockRepository.Verify(repo => repo.AddAsync(It.IsAny<Wine>()), Times.Once);
            _mockRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        // Similar tests for other methods (UpdateWineAsync, DeleteWineAsync, SearchWinesAsync)...

        [Test]
        public void UpdateWineAsync_Throws_Exception_When_Wine_Not_Found()
        {
            // Arrange
            var viewModel = new WineViewModel { Id = 1 };

            _mockRepository.Setup(repo => repo.GetByIdAsync<Wine>(viewModel.Id))
                           .ReturnsAsync((Wine)null);

            // Act & Assert
            Assert.ThrowsAsync<WineUpdateException>(() => _wineService.UpdateWineAsync(viewModel));
        }

        [Test]
        public void DeleteWineAsync_Throws_Exception_When_Wine_Not_Found()
        {
            // Arrange
            var wineId = 1;

            _mockRepository.Setup(repo => repo.GetByIdAsync<Wine>(wineId))
                           .ReturnsAsync((Wine)null);

            // Act & Assert
            Assert.ThrowsAsync<WineNotFoundException>(() => _wineService.DeleteWineAsync(wineId));
        }

        [Test]
        public async Task SearchWinesAsync_Returns_Filtered_Wines()
        {
            // Arrange
            var searchTerm = "search";

            var wines = new List<Wine>
            {
                new Wine { Id = 1, Name = "Wine1", Country = "Country1", Type = "Type1", Price = 10,  Region = "Region1", Quantity = 5 },
                new Wine { Id = 2, Name = "Wine2", Country = "Country2", Type = "Type2", Price = 15,  Region = "Region2", Quantity = 8 }
            };

            _mockRepository.Setup(repo => repo.All<Wine>())
                           .Returns(wines.AsQueryable());

            // Act
            var result = await _wineService.SearchWinesAsync(searchTerm);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }
    }
}