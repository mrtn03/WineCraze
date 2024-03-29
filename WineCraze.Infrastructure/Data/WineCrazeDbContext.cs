using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WineCraze.Infrastructure.Data.Models;
using WineCraze.Infrastructure.Data.SeedDb;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>()
               .HasOne(s => s.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CustomerId)
                .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Supplier)
                .WithMany(su => su.Sales)
                .HasForeignKey(s => s.SupplierId)
                .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<Sale>()
             .HasOne(s => s.Wine)
             .WithMany(w => w.Sales)
             .HasForeignKey(s => s.WineId);

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new ReportConfiguration());
            modelBuilder.ApplyConfiguration(new SaleConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
            modelBuilder.ApplyConfiguration(new WineConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}