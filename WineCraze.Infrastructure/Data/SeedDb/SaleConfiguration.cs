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
                new Sale
                {
                    Id = 1,
                    Quantity = 5,
                    TotalPrice = 44.00M,
                    SaleDate = DateTime.Now,
                    WineId = 1,
                    CustomerId = 1,  
                },
                new Sale
                {
                    Id = 2,
                    Quantity = 10,
                    TotalPrice = 54.00M,
                    SaleDate = DateTime.Now,
                    WineId = 2,
                    CustomerId = 2, 
                }
            );

            builder.HasOne(s => s.Customer)
            .WithMany(x => x.Sales)
            .HasForeignKey(s => s.CustomerId);

            builder.HasOne(s => s.Supplier)
                .WithMany(x => x.Sales)
                .HasForeignKey(s => s.SupplierId);

            builder.HasOne(s => s.Wine)
                .WithMany(x => x.Sales)
                .HasForeignKey(s => s.WineId);

        }
    }
}
