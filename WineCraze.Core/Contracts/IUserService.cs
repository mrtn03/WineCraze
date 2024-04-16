using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineCraze.Core.Models.Account.User;

namespace WineCraze.Core.Contracts
{
    public interface IUserService
    {
        Task<string> UserFullNameAsync(string userId);

        Task<IEnumerable<UserServiceModel>> AllAsync();

        Task<bool> IsUser(string userId);
    }
}
