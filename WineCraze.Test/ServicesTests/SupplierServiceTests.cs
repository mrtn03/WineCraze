using Moq;
using WineCraze.Core.Contracts;
using WineCraze.Core.Models.Supplier;
using WineCraze.Core.Services;
using WineCraze.Infrastructure.Data.Common;
using WineCraze.Infrastructure.Data.Models;

namespace WineCraze.Test.ServicesTests
{
    [TestFixture]
    public class SupplierServiceTests
    {
        private ISupplierService _supplierService;
        private Mock<IRepository> _mockRepository;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository>();
            _supplierService = new SupplierService(_mockRepository.Object);
        }

        [Test]
        public void GetAllSuppliers_ReturnsAllSuppliers()
        {
            // Arrange
            var suppliers = new List<SupplierViewModel>
            {
                new SupplierViewModel { Id = 1, Name = "Supplier 1", ContactPerson = "John Doe", Email = "john@example.com", Phone = "123456789", Bulstat = 123456, Address = "123 Main St" },
                new SupplierViewModel { Id = 2, Name = "Supplier 2", ContactPerson = "Jane Doe", Email = "jane@example.com", Phone = "987654321", Bulstat = 654321, Address = "456 Elm St" }
            };
            _mockRepository.Setup(r => r.All<Supplier>()).Returns(suppliers.Select(s => new Supplier { Id = s.Id, Name = s.Name, ContactPerson = s.ContactPerson, Email = s.Email, Phone = s.Phone, Bulstat = s.Bulstat, Address = s.Address }).AsQueryable());

            // Act
            var result = _supplierService.GetAllSuppliers();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(suppliers.Count, result.Count());
        }

        [Test]
        public void GetSupplierById_ExistingId_ReturnsSupplier()
        {
            // Arrange
            var id = 1;
            var supplier = new SupplierViewModel { Id = id, Name = "Supplier 1", ContactPerson = "John Doe", Email = "john@example.com", Phone = "123456789", Bulstat = 123456, Address = "123 Main St" };
            _mockRepository.Setup(r => r.GetByIdAsync<Supplier>(id)).ReturnsAsync(new Supplier { Id = supplier.Id, Name = supplier.Name, ContactPerson = supplier.ContactPerson, Email = supplier.Email, Phone = supplier.Phone, Bulstat = supplier.Bulstat, Address = supplier.Address });

            // Act
            var result = _supplierService.GetSupplierById(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(supplier.Id, result.Id);
            Assert.AreEqual(supplier.Name, result.Name);
            Assert.AreEqual(supplier.ContactPerson, result.ContactPerson);
            Assert.AreEqual(supplier.Email, result.Email);
            Assert.AreEqual(supplier.Phone, result.Phone);
            Assert.AreEqual(supplier.Bulstat, result.Bulstat);
            Assert.AreEqual(supplier.Address, result.Address);
        }

        [Test]
        public void GetSupplierById_NonExistingId_ReturnsNull()
        {
            // Arrange
            var id = 100;
            _mockRepository.Setup(r => r.GetByIdAsync<Supplier>(id)).ReturnsAsync((Supplier)null);

            // Act
            var result = _supplierService.GetSupplierById(id);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void CreateSupplier_ValidSupplier_CreatesSupplier()
        {
            // Arrange
            var supplier = new SupplierViewModel { Id = 1, Name = "New Supplier", ContactPerson = "Jane Doe", Email = "jane@example.com", Phone = "987654321", Bulstat = 654321, Address = "456 Elm St" };

            // Act
            _supplierService.CreateSupplier(supplier);

            // Assert
            _mockRepository.Verify(r => r.AddAsync(It.IsAny<Supplier>()), Times.Once);
            _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public void UpdateSupplier_ValidSupplier_UpdatesSupplier()
        {
            // Arrange
            var supplier = new SupplierViewModel { Id = 1, Name = "Updated Supplier", ContactPerson = "Jane Doe", Email = "jane@example.com", Phone = "987654321", Bulstat = 654321, Address = "456 Elm St" };
            _mockRepository.Setup(r => r.GetByIdAsync<Supplier>(supplier.Id)).ReturnsAsync(new Supplier());

            // Act
            _supplierService.UpdateSupplier(supplier);

            // Assert
            _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public void DeleteSupplier_ExistingId_DeletesSupplier()
        {
            // Arrange
            var id = 1;
            _mockRepository.Setup(r => r.GetByIdAsync<Supplier>(id)).ReturnsAsync(new Supplier());

            // Act
            _supplierService.DeleteSupplier(id);

            // Assert
            _mockRepository.Verify(r => r.DeleteAsync<Supplier>(id), Times.Once);
            _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public void DeleteSupplier_NonExistingId_ThrowsArgumentException()
        {
            // Arrange
            var id = 100;
            _mockRepository.Setup(r => r.GetByIdAsync<Supplier>(id)).ReturnsAsync((Supplier)null);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _supplierService.DeleteSupplier(id));
        }
    }
}