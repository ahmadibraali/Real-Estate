
using AutoMapper;
using MediatR;
using Real_Estate.Application.DTOs.Account;
using Real_Estate.Application.Enums;
using Real_Estate.Application.Interfaces.Services;
using System.ComponentModel.DataAnnotations;

namespace Real_Estate.Application.Features.Accounts.Commands.RegisterAdminUser
{
    public class RegisterAdminUserCommand : IRequest<RegisterResponse>
    {
        [Required(ErrorMessage = "First name is required.")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Username is required.")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [Compare(nameof(Password), ErrorMessage = "Passwords must be matched.")]
        public string? ConfirmPassword { get; set; }
        public string? Phone { get; set; }
        public string? ImagePath { get; set; }
        public bool EmailConfirmed { get; set; }
    }

    public class RegisterAdminUserCommandHandler : IRequestHandler<RegisterAdminUserCommand, RegisterResponse>
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public RegisterAdminUserCommandHandler(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }
        public async Task<RegisterResponse> Handle(RegisterAdminUserCommand command, CancellationToken cancellationToken)
        {
            command.EmailConfirmed = true;
            var request = _mapper.Map<RegisterRequest>(command);
            return await _accountService.RegisterUserAsync(request, "", Roles.Admin);
        }
    }
}
