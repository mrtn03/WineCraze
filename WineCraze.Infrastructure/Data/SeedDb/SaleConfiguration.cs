using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WineCraze.Infrastructure.Data.Models;

namespace WineCraze.Infrastructure.Data.SeedDb
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            
            builder.HasData(
                new Sale { Id = 1, SaleDate = DateTime.Now, CustomerId = 1, SupplierId = 1, 
                    WineId = 1, Quantity = 2, TotalPrice = 40.00m },

                new Sale { Id = 2, SaleDate = DateTime.Now, CustomerId = 2, SupplierId = 2,
                    WineId = 2, Quantity = 1, TotalPrice = 18.50m }
            );

            builder.HasOne(s => s.Customer)
            .WithMany()
            .HasForeignKey(s => s.CustomerId);

            builder.HasOne(s => s.Supplier)
                .WithMany()
                .HasForeignKey(s => s.SupplierId);

            builder.HasOne(s => s.Wine)
                .WithMany()
                .HasForeignKey(s => s.WineId);
        }
    }
}
