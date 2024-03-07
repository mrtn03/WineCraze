using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WineCraze.Data
{
    public class WineCrazeDbContext : IdentityDbContext
    {
        public WineCrazeDbContext(DbContextOptions<WineCrazeDbContext> options)
            : base(options)
        {
        }
    }
}