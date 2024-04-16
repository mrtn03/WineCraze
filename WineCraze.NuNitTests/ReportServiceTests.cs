using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Models;
using Moq;
using NUnit.Framework;
using WineCraze.Core.Models.Report;
using WineCraze.Core.Services;
using WineCraze.Data;
using WineCraze.Infrastructure.Data.Common;

namespace WineCraze.NuNitTests
{
    [TestFixture]
    public class ReportServiceTests
    {
        [Test]
        public async Task GetAllReportsAsync_ShouldReturnAllReports()
        {
            // Arrange
            var reports = new List<Report>
            {
                new Report { Id = 1, Title = "Report 1", Description = "Description 1", DateCreated = "2024-04-11" },
                new Report { Id = 2, Title = "Report 2", Description = "Description 2", DateCreated = "2024-04-12" }
            }.AsQueryable();

            var mockDbSet = new Mock<DbSet<Report>>();
            mockDbSet.As<IAsyncEnumerable<Report>>().Setup(m => m.GetAsyncEnumerator(default)).Returns(new TestAsyncEnumerator<Report>(reports.GetEnumerator()));
            mockDbSet.As<IQueryable<Report>>().Setup(m => m.Provider).Returns(new TestAsyncQueryProvider<Report>(reports.Provider));
            mockDbSet.As<IQueryable<Report>>().Setup(m => m.Expression).Returns(reports.Expression);
            mockDbSet.As<IQueryable<Report>>().Setup(m => m.ElementType).Returns(reports.ElementType);
            mockDbSet.As<IQueryable<Report>>().Setup(m => m.GetEnumerator()).Returns(reports.GetEnumerator());

            var mockDbContext = new Mock<WineCrazeDbContext>();
            mockDbContext.Setup(c => c.Set<Report>()).Returns(mockDbSet.Object);

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.All<Report>()).Returns(mockDbContext.Object.Set<Report>());

            var reportService = new ReportService(mockRepository.Object);

            // Act
            var result = await reportService.GetAllReportsAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public async Task GetReportByIdAsync_ShouldReturnReport_WhenValidIdProvided()
        {
            // Arrange
            var reportId = 1;
            var report = new Report { Id = reportId, Title = "Report 1", Description = "Description 1", DateCreated = "2024-04-11" };

            var mockDbSet = new Mock<DbSet<Report>>();
            mockDbSet.Setup(m => m.FindAsync(reportId)).ReturnsAsync(report);

            var mockDbContext = new Mock<WineCrazeDbContext>();
            mockDbContext.Setup(c => c.Set<Report>()).Returns(mockDbSet.Object);

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.GetByIdAsync<Report>(reportId)).ReturnsAsync(report);

            var reportService = new ReportService(mockRepository.Object);

            // Act
            var result = await reportService.GetReportByIdAsync(reportId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(reportId, result.Id);
        }

        [Test]
        public async Task GetReportByIdAsync_ShouldReturnNull_WhenInvalidIdProvided()
        {
            // Arrange
            var invalidReportId = 999;

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.GetByIdAsync<Report>(invalidReportId)).ReturnsAsync((Report)null);

            var reportService = new ReportService(mockRepository.Object);

            // Act
            var result = await reportService.GetReportByIdAsync(invalidReportId);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task CreateReportAsync_ShouldAddReportToRepository()
        {
            // Arrange
            var newReport = new ReportViewModel { Title = "New Report", Description = "New Description", DateCreated = "2024-04-13" };

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.AddAsync(It.IsAny<Report>())).Returns(Task.CompletedTask);
            mockRepository.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);

            var reportService = new ReportService(mockRepository.Object);

            // Act
            await reportService.CreateReportAsync(newReport);

            // Assert
            mockRepository.Verify(r => r.AddAsync(It.IsAny<Report>()), Times.Once);
            mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public void CreateReportAsync_ShouldThrowException_WhenDateCreatedIsNullOrEmpty()
        {
            // Arrange
            var invalidDateReport = new ReportViewModel { Title = "Invalid Report", Description = "Invalid Description", DateCreated = null };

            var mockRepository = new Mock<IRepository>();
            var reportService = new ReportService(mockRepository.Object);

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await reportService.CreateReportAsync(invalidDateReport));
        }

        [Test]
        public async Task UpdateReportAsync_ShouldUpdateReport_WhenValidReportViewModelProvided()
        {
            // Arrange
            var existingReport = new Report { Id = 1, Title = "Report 1", Description = "Description 1", DateCreated = "2024-04-11" };
            var updatedReport = new ReportViewModel { Id = existingReport.Id, Title = "Updated Report", Description = "Updated Description", DateCreated = "2024-04-14" };

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.GetByIdAsync<Report>(existingReport.Id)).ReturnsAsync(existingReport);
            mockRepository.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);

            var reportService = new ReportService(mockRepository.Object);

            // Act
            await reportService.UpdateReportAsync(updatedReport);

            // Assert
            Assert.AreEqual(updatedReport.Title, existingReport.Title);
            Assert.AreEqual(updatedReport.Description, existingReport.Description);
            Assert.AreEqual(updatedReport.DateCreated, existingReport.DateCreated);
        }

        [Test]
        public void UpdateReportAsync_ShouldThrowException_WhenReportNotFound()
        {
            // Arrange
            var nonExistingReportId = 999;
            var updatedReport = new ReportViewModel { Id = nonExistingReportId, Title = "Updated Report", Description = "Updated Description", DateCreated = "2024-04-14" };

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.GetByIdAsync<Report>(nonExistingReportId)).ReturnsAsync((Report)null);

            var reportService = new ReportService(mockRepository.Object);

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await reportService.UpdateReportAsync(updatedReport));
        }

        [Test]
        public async Task DeleteReportAsync_ShouldDeleteReport_WhenValidIdProvided()
        {
            // Arrange
            var reportIdToDelete = 1;

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.DeleteAsync<Report>(reportIdToDelete)).Returns(Task.CompletedTask);
            mockRepository.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);

            var reportService = new ReportService(mockRepository.Object);

            // Act
            await reportService.DeleteReportAsync(reportIdToDelete);

            // Assert
            mockRepository.Verify(r => r.DeleteAsync<Report>(reportIdToDelete), Times.Once);
            mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }
    }
}
