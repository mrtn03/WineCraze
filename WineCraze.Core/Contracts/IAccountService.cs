namespace WineCraze.Core.Contracts
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(string username, string password);
        Task LogoutAsync();
        Task<bool> RegisterAsync(string username, string email, string password);
        Task<bool> AddToRoleAsync(string username, string roleName);
        Task<bool> RemoveFromRoleAsync(string username, string roleName);
    }
}

// Summary - Provides methods for user authentication and authorization.