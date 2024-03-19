using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
                .HasOne(s => s.Report)
               .WithMany(r => r.Sales)
                .HasForeignKey(s => s.ReportId)
                .OnDelete(DeleteBehavior.NoAction);
            

            //modelBuilder.Entity<Sale>()
            //    .HasOne(s => s.Customer)
            //    .WithMany(c => c.Sales)
            //    .HasForeignKey(s => s.CustomerId);

            //modelBuilder.Entity<Sale>()
            //    .HasOne(s => s.Supplier)
            //    .WithMany(su => su.Sales)
            //    .HasForeignKey(s => s.SupplierId);

            //modelBuilder.Entity<Sale>()
            //    .HasOne(s => s.Report)
            //    .WithMany(r => r.Sales)
            //    .HasForeignKey<Report>(r => r.SaleId);

            //modelBuilder.Entity<Sale>()
            //    .HasOne(s => s.Wine)
            //    .WithMany(w => w.Sales)
            //    .HasForeignKey(s => s.WineId);

            //modelBuilder.Entity<Customer>()
            //    .HasMany(c => c.Sales)
            //    .WithOne(s => s.Customer)
            //    .HasForeignKey(s => s.CustomerId);

            //modelBuilder.Entity<Supplier>()
            //    .HasMany(su => su.Sales)
            //    .WithOne(s => s.Supplier)
            //    .HasForeignKey(s => s.SupplierId);

            //modelBuilder.Entity<Wine>()
            //    .HasMany(w => w.Sales)
            //    .WithOne(s => s.Wine)
            //    .HasForeignKey(s => s.WineId);

        }
    }
}