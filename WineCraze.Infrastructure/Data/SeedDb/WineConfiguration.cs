using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WineCraze.Infrastructure.Data.Models;

namespace WineCraze.Infrastructure.Data.SeedDb
{
    public class WineConfiguration : IEntityTypeConfiguration<Wine>
    {
        public void Configure(EntityTypeBuilder<Wine> builder)
        {

            builder.HasData(
                new Wine { Id = 1, Name = "Red Wine", Type = "Red",  CreatedOn = "2019" , Price = 20.00m },
                new Wine { Id = 2, Name = "White Wine", Type = "White", CreatedOn =  "2020", Price = 18.50m },
                new Wine { Id = 3, Name = "Rosé Wine", Type = "Rosé", CreatedOn = "2018" , Price = 15.75m }

            );
        }
    }
}
