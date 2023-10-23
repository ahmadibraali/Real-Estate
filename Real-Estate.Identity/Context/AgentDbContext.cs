using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Real_Estate.Identity.Entities;
using System.Reflection.Emit;

namespace Real_Estate.Identity.Context
{
    public class AgentDbContext : IdentityDbContext<ApplicationUser>
    {
        public AgentDbContext(DbContextOptions<AgentDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            
            builder.HasDefaultSchema("Identity");

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "Users");
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Roles");
            });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable(name: "UserRoles");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable(name: "UserLogins");
            });
            base.OnModelCreating(builder);
        }
    }
}
