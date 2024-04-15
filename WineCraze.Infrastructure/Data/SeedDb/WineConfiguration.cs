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
                new Wine { Id = 1, Name = "Red Wine", Type = "Red", CreatedOn = "2019", Region = "Vidrare",
                    Price = 20.00m,
                    Quantity = 20,
                    Country = "Italy"  },
                new Wine { Id = 2, Name = "White Wine", Type = "White", CreatedOn = "2020", Region = "Targovishte",
                    Price = 18.50m,
                    Quantity = 20,
                    Country = "Italy"  },
                new Wine { Id = 3, Name = "Rosé Wine", Type = "Rosé", CreatedOn = "2018", Region = "Shumen", Quantity = 20,
                    Price = 15.75m, Country = "Italy"  }
            );
        }
    }
}
