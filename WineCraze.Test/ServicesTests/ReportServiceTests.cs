using Moq;
using WineCraze.Core.Contracts;
using WineCraze.Core.Models.Report;
using WineCraze.Core.Services;
using WineCraze.Infrastructure.Data.Common;
using WineCraze.Infrastructure.Data.Models;

namespace WineCraze.Test.ServicesTests
{
    [TestFixture]
    public class ReportServiceTests
    {
        private Mock<IRepository> _repositoryMock;
        private IReportService _reportService;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<IRepository>();
            _reportService = new ReportService(_repositoryMock.Object);
        }

        [Test]
        public async Task GetAllReportsAsync_ShouldReturnAllReports()
        {
            // Arrange
            var reports = new List<Report>
        {
            new Report { Id = 1, Title = "Report 1", Description = "Description 1", DateCreated = DateTime.UtcNow.ToString() },
            new Report { Id = 2, Title = "Report 2", Description = "Description 2", DateCreated = DateTime.UtcNow.ToString() }
        };
            _repositoryMock.Setup(repo => repo.All<Report>()).Returns(reports.AsQueryable());

            // Act
            var result = await _reportService.GetAllReportsAsync();

            // Assert
            Assert.AreEqual(reports.Count, result.Count());
        }

        [Test]
        public async Task GetReportByIdAsync_ShouldReturnReportWithGivenId()
        {
            // Arrange
            var reportId = 1;
            var currentDate = DateTime.UtcNow.ToString();
            var report = new Report { Id = reportId, Title = "Report", Description = "Description", DateCreated = currentDate };
            _repositoryMock.Setup(repo => repo.GetByIdAsync<Report>(reportId)).Returns(Task.FromResult(report));

            // Act
            var result = await _reportService.GetReportByIdAsync(reportId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(reportId, result.Id);
            Assert.AreEqual(currentDate, result.DateCreated);
        }

        [Test]
        public async Task CreateReportAsync_ShouldAddReportToRepository()
        {
            // Arrange
            var currentDate = DateTime.UtcNow.ToString();
            var viewModel = new ReportViewModel { Title = "Report", Description = "Description", DateCreated = currentDate };

            // Act
            await _reportService.CreateReportAsync(viewModel);

            // Assert
            _repositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Report>()), Times.Once);
            _repositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task UpdateReportAsync_ShouldUpdateReportInRepository()
        {
            // Arrange
            var reportId = 1;
            var currentDate = DateTime.UtcNow.ToString();
            var viewModel = new ReportViewModel { Id = reportId, Title = "Report", Description = "Description", DateCreated = currentDate };
            var report = new Report { Id = reportId, Title = "Old Report", Description = "Old Description", DateCreated = currentDate };
            _repositoryMock.Setup(repo => repo.GetByIdAsync<Report>(reportId)).Returns(Task.FromResult(report));

            // Act
            await _reportService.UpdateReportAsync(viewModel);

            // Assert
            _repositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task DeleteReportAsync_ShouldDeleteReportFromRepository()
        {
            // Arrange
            var reportId = 1;

            // Act
            await _reportService.DeleteReportAsync(reportId);

            // Assert
            _repositoryMock.Verify(repo => repo.DeleteAsync<Report>(It.IsAny<int>()), Times.Once);
            _repositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }
    }
}