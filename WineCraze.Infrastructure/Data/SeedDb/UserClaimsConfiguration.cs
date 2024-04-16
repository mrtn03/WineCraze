using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineCraze.Infrastructure.Data.SeedDb
{
    public class UserClaimsConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
        {
            var data = new SeedData();

            builder.HasData(data.GuestUserClaim, data.AdminUserClaim);
        }
    }
}
