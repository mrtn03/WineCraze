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
                CreatedOn = DateTime.Now.ToString(), 
                Region = "NewRegion",
                Quantity = 10
            };

            // Act
            await _wineService.AddWineAsync(viewModel);

            // Assert
            _mockRepository.Verify(repo => repo.AddAsync(It.IsAny<Wine>()), Times.Once);
            _mockRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }


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
    }
}