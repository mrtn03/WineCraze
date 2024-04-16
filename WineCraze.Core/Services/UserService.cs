using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineCraze.Core.Models.Account.User;
using WineCraze.Infrastructure.Data.Common;
using WineCraze.Infrastructure.Data.Models;

namespace WineCraze.Core.Services
{
    public class UserService
    {
        private readonly IRepository repository;

        public UserService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<IEnumerable<UserServiceModel>> AllAsync()
        {
            return await repository.AllReadOnly<ApplicationUser>()
                .Include(u => u.Customer)
                .Select(u => new UserServiceModel()
                {
                    Email = u.Email,
                    FullName = $"{u.FirstName} {u.LastName}",
                    PhoneNumber = u.Customer != null ? u.Customer.PhoneNumber : null,
                    IsAgent = u.Customer != null
                })
                .ToListAsync();
        }

        public async Task<string> UserFullNameAsync(string userId)
        {
            string result = string.Empty;
            var user = await repository
                .GetByIdAsync<ApplicationUser>(userId);

            if (user != null)
            {
                result = $"{user.FirstName} {user.LastName}";
            }

            return result;
        }
    }
}
