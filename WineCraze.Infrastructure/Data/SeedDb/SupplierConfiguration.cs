using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineCraze.Infrastructure.Data.Models;

namespace WineCraze.Infrastructure.Data.SeedDb
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            
            builder.HasData(
                new Supplier { Id = 1, Name = "Supplier A", Email = "supplierA@example.com", Phone = "123-456-7890" },
                new Supplier { Id = 2, Name = "Supplier B", Email = "supplierB@example.com", Phone = "987-654-3210" }
            );
        }
    }
}