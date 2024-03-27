using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WineCraze.Data;

namespace WineCraze.Extensions
{
    public static class WineCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //services.AddScoped<IHouseService, HouseService>();
            //services.AddScoped<IAgentService, AgentService>();
            //services.AddScoped<IStatisticService, StatisticService>();

            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<WineCrazeDbContext>(options =>
                options.UseSqlServer(connectionString));

            //services.AddScoped<IRepository, Repository>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddDefaultIdentity<IdentityUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = true;
                })
                .AddEntityFrameworkStores<WineCrazeDbContext>();

            return services;
        }
    }
}
