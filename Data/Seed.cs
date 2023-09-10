using GYMmanagement.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace GYMmanagement.Data
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<User> userManager, RoleManager<AppRole> roleManager)
        {
            if (await userManager.Users.AnyAsync()) return;
            var UserData = await File.ReadAllTextAsync("Data/UserSeedData.json");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var Users = JsonSerializer.Deserialize<List<User>>(UserData, options);

            var roles = new List<AppRole>
            {
                new AppRole{Name ="Member" },
                new AppRole{Name ="Employee" },
                new AppRole{Name ="Trainer" },




            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            foreach (var user in Users)
            {
                user.UserName = user.UserName.ToLower();

                await userManager.CreateAsync(user, "Pa$$w0rd");

                await userManager.AddToRoleAsync(user, "Member");

            }

            var manager = new User
            {
                UserName = "ameer"
            };

            await userManager.CreateAsync(manager, "Pa$$w0rd");
            await userManager.AddToRolesAsync(manager, new[] { "Trainer", "Employee" });
        }
    }
}
