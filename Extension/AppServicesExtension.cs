using GYMmanagement.Data;
using GYMmanagement.Interfaces;
using GYMmanagement.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

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
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });
            return services;
        }
    }
}
