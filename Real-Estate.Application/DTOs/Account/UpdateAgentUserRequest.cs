using Microsoft.AspNetCore.Http;

namespace Real_Estate.Application.DTOs.Account
{
    public class UpdateAgentUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string? ImagePath { get; set; }
        public IFormFile? File { get; set; }

        public bool HasError { get; set; }
        public string? Error { get; set; }

        public string? UserName { get; set; }

    }
}
