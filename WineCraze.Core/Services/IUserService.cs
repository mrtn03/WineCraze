using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineCraze.Core.Services
{
    public interface IUserService
    {
        Task<bool> IsUser(string userId);
    }
}
