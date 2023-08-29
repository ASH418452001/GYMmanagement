using GYMmanagement.Data;
using GYMmanagement.Interfaces;
using GYMmanagement.Services;
using Microsoft.EntityFrameworkCore;

namespace GYMmanagement.Extension
{
    public static class AppServicesExtension
    {
        public static IServiceCollection AddApplicationServises(this IServiceCollection services , IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });


            services.AddScoped<ITokenService, TokenServices>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
