using GYMmanagement.Data;
using GYMmanagement.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GYMmanagement.Extension
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;

            })
                .AddRoles<AppRole>()
                .AddRoleManager<RoleManager<AppRole>>()
                .AddEntityFrameworkStores<DataContext>();





            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //.AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey =
            //            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
            //        ValidateIssuer = false,
            //        ValidateAudience = false
            //    };


            //});





            //services.AddAuthorization(opt =>
            //{
            //    opt.AddPolicy("RequireEmployeeRole", policy => policy.RequireRole("Employee"));
            //    opt.AddPolicy("RequireManagerRole", policy => policy.RequireRole("Manager" , "Employee"));

            //});

            return services;
        }
    }
}
