using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace WineCraze.Infrastructure.Data.SeedDb
{
    internal class ApplicationUserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            var data = new SeedData();

            //builder.HasData(new IdentityUser[] { data.AgentUser, data.GuestUser });
        }
    }
}
