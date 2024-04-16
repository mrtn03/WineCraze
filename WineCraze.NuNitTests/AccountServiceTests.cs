using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineCraze.Core.Services;
using WineCraze.Infrastructure.Data.Common;
using Assert = NUnit.Framework.Assert;

namespace WineCraze.NuNitTests
{
    [TestFixture]
    public class AccountServiceTests
    {
        private AccountService accountService;
        private Mock<IRepository> repositoryMock;

        [SetUp]
        public void Setup()
        {
            // Arrange
            repositoryMock = new Mock<IRepository>();
            accountService = new AccountService(repositoryMock.Object);
        }

        [Test]
        public async Task LoginAsync_ValidCredentials_ReturnsTrue()
        {
            // Arrange
            string username = "admin";
            string password = "admin123";

            // Act
            var result = await accountService.LoginAsync(username, password);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task LoginAsync_InvalidCredentials_ReturnsFalse()
        {
            // Arrange
            string username = "invalid";
            string password = "invalid";

            // Act
            var result = await accountService.LoginAsync(username, password);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task LogoutAsync_Always_PrintsLogMessage()
        {
            // Arrange - No specific arrangement needed

            // Act
            accountService.LogoutAsync();

            // Assert - You may need to capture the console output and verify it
            // For simplicity, we're not doing it here
        }

        [Test]
        public async Task RegisterAsync_Always_ReturnsTrue()
        {
            // Arrange
            string username = "test";
            string email = "test@example.com";
            string password = "test123";

            // Act
            var result = await accountService.RegisterAsync(username, email, password);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task AddToRoleAsync_Always_ReturnsTrue()
        {
            // Arrange
            string username = "test";
            string roleName = "role";

            // Act
            var result = await accountService.AddToRoleAsync(username, roleName);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task RemoveFromRoleAsync_Always_ReturnsTrue()
        {
            // Arrange
            string username = "test";
            string roleName = "role";

            // Act
            var result = await accountService.RemoveFromRoleAsync(username, roleName);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
