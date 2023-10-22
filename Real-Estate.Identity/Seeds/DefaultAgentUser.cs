using Microsoft.AspNetCore.Identity;
using Real_Estate.Application.Enums;
using Real_Estate.Identity.Entities;

namespace Real_Estate.Identity.Seeds
{
    public static class DefaultAgentUser
    {

        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser defaultUser = new();
            defaultUser.FirstName = "Frank";
            defaultUser.LastName = "Castle";
            defaultUser.UserName = "Punisher";
            defaultUser.Email = "punisher@agentuser.com";
            defaultUser.EmailConfirmed = true;
            defaultUser.PhoneNumber = "809-236-9698";
            defaultUser.PhoneNumberConfirmed = true;

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Agent.ToString());
                }
            }
        }
    }
}
