using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WineCraze.Infrastructure.Data.Models;

namespace WineCraze.Data
{
    public class WineCrazeDbContext : IdentityDbContext
    {
        public WineCrazeDbContext(DbContextOptions<WineCrazeDbContext> options)
           : base(options)
        {
        }

        public DbSet<Wine> Wines { get; set; } = null!;
        public DbSet<Sale> Sales { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Supplier> Suppliers { get; set; } = null!;
        public DbSet<Report> Reports { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}