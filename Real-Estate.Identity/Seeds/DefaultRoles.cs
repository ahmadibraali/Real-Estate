using Microsoft.AspNetCore.Identity;
using Real_Estate.Application.Enums;
using Real_Estate.Identity.Entities;

namespace Real_Estate.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Developer.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Client.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Agent.ToString()));
        }
    }
}
