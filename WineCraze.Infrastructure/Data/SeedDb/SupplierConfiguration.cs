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
                new Supplier { 
                    Id = 1, 
                    Name = "Supplier A", 
                    ContactPerson = "supplierA@example.com",
                    Bulstat = 130275868,
                    Email = "toshotosh@abv.bg", 
                    Phone = "123-634-3110", 
                    Address = "Sofia Nadezda ul.Budinci"},

                new Supplier
                {
                    Id = 2,
                    Name = "Supplier b",
                    ContactPerson = "supplierA@example.com",
                    Bulstat = 130985868,
                    Email = "abvabv@abv.bg",
                    Phone = "123-677-3110",
                    Address = "Sofia Nadezda ul.Rozehn"
                }
            );
        }
    }
}