using Microsoft.AspNetCore.Identity;
using Real_Estate.Application.Enums;
using Real_Estate.Identity.Entities;

namespace Real_Estate.Identity.Seeds
{
    public static class DefaultDevUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            ApplicationUser defaultUser = new();
            defaultUser.UserName = "devUser";
            defaultUser.Email = "developer@email.com";
            defaultUser.FirstName = "Dev FirstName";
            defaultUser.LastName = "Dev LastName";
            defaultUser.EmailConfirmed = true;
            defaultUser.PhoneNumberConfirmed = true;

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Developer.ToString());
                }
            }
        }
    }
}
