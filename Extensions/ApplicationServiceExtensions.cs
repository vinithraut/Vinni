using VinniDatingApp.Data;
using VinniDatingApp.Interfaces;
using VinniDatingApp.Services;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace VinniDatingApp.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config) {
            services.AddControllersWithViews();

            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("SqlConn"));
            });

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
