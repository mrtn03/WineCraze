﻿using WineCraze.Core.Contracts;

namespace WineCraze.Core.Services
{
    public class AccountService : IAccountService
    {

        public async Task<bool> LoginAsync(string username, string password)
        {
            if (username == "admin" && password == "admin123")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task LogoutAsync()
        {
            Console.WriteLine("User logged out.");
        }

        public async Task<bool> RegisterAsync(string username, string email, string password)
        {
            return true;
        }

        public async Task<bool> AddToRoleAsync(string username, string roleName)
        {
            return true;
        }

        public async Task<bool> RemoveFromRoleAsync(string username, string roleName)
        {
            return true;
        }
    }
}