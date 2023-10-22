using Microsoft.AspNetCore.Identity;
using Real_Estate.Application.Enums;
using Real_Estate.Identity.Entities;

namespace Real_Estate.Identity.Seeds
{
    public static class DefaultAdminUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            ApplicationUser defaultUser = new();
            defaultUser.UserName = "adminUser";
            defaultUser.Email = "admin@email.com";
            defaultUser.FirstName = "Admin FirstName";
            defaultUser.LastName = "Admin LastName";
            defaultUser.ImagePath = "/Images/profile.jpeg";
            defaultUser.EmailConfirmed = true;
            defaultUser.PhoneNumberConfirmed = true;

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                }
            }
        }
    }
}
