using Microsoft.AspNetCore.Identity;
using Unlogy.Entities;
using Unlogy.Settings;

namespace Unlogy.Data.Seeders
{
    public class DatabaseSeeder
    {
        public static async Task SeedRolesAndAdmin(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

            var adminSettings = configuration.GetSection("AdminUser").Get<AdminUserSettings>();

            string[] roles = { "Admin", "Student", "Teacher" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var adminUser = await userManager.FindByEmailAsync(adminSettings.Email);
            if (adminUser == null)
            {
                var newAdmin = new AppUser
                {
                    UserName = adminSettings.UserName,
                    Email = adminSettings.Email
                };

                var result = await userManager.CreateAsync(newAdmin, adminSettings.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(newAdmin, "Admin");
                }
                else
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    throw new Exception($"Failed to create admin user: {errors}");
                }
            }
        }
    }
}
