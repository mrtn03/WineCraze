using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WineCraze.Infrastructure.Data.Models;

namespace WineCraze.Infrastructure.Data.SeedDb
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            
            builder.HasData(
                new Report { Id = 1, Title = 
                "Sales Report Q1 2023", Description = "This is the sales report for the first quarter of 2023." },

                new Report { Id = 2, Title = 
                "Inventory Report 2022", Description = "This is the inventory report for the year 2022." }
            );
        }
    }
}