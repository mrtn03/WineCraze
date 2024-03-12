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

        public DbSet<Wine> Wines { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Report> Reports { get; set; }

        //protected override void OnModelCreating( modelBuilder)
        //{
        //}
    }
}