using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WineCraze.Infrastructure.Data.Models;

namespace WineCraze.Infrastructure.Data.SeedDb
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            
            builder.HasData(
                new Customer { Id = 1, Name = "John Doe", Email = "john@example.com", 
                    Address = "Apt. 490 23467 Vincenzo Lodge", PhoneNumber = "123-456-7890" },

                new Customer { Id = 2, Name = "Jane Smith", Email = "jane@example.com", Address = "32078 Waelchi Trafficway",
                PhoneNumber = "987-654-3210" },

                new Customer { Id = 3, Name = "Men Gos", Email = "men@example.com",
                    Address = "3 hoog Libberslaan 341b", PhoneNumber = "123-634-3110" },

                new Customer { Id = 4, Name = "Io Geo", Email = "Io@example.com", Address = "71 Glen Creek Streeylmar",
                    PhoneNumber = "987-123-3210" },

                new Customer { Id = 5, Name = "Len Dos", Email = "Len@example.com", Address = "837 Durham St.San Francisco",
                PhoneNumber = "456-789-3210" }
            );
        }
    }
}
