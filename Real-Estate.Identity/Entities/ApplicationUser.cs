using Microsoft.AspNetCore.Identity;

namespace Real_Estate.Identity.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? IDCard { get; set; }
        public string? ImagePath { get; set; }
    }
}
