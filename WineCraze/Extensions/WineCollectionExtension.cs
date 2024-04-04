using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WineCraze.Core.Contracts;
using WineCraze.Core.Services;
using WineCraze.Data;
using WineCraze.Infrastructure.Data.Common;

namespace WineCraze.Extensions
{
    public static class WineCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IWineService, WineService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<IReportService, ReportService>();


            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<WineCrazeDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();

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
