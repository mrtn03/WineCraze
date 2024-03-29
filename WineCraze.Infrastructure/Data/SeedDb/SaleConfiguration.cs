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
                    SaleDate = DateTime.Now.AddDays(-7),
                    WineId = 1, // Sample wine Id
                    CustomerId = 1, // Sample customer Id
                    SupplierId = 1, // Sample supplier Id
                    ReportId = 1 // Sample report Id
                },
                new Sale
                {
                    Id = 2,
                    Quantity = 10,
                    TotalPrice = 54.00M,
                    SaleDate = DateTime.Now.AddDays(-14),
                    WineId = 2, // Sample wine Id
                    CustomerId = 2, // Sample customer Id
                    SupplierId = 2, // Sample supplier Id
                    ReportId = 2 // Sample report Id
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
