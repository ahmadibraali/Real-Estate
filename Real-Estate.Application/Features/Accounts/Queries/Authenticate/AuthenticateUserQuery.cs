﻿using AutoMapper;
using MediatR;
using Real_Estate.Application.DTOs.Account;
using Real_Estate.Application.Interfaces.Services;
using System.ComponentModel.DataAnnotations;

namespace Real_Estate.Application.Features.Accounts.Queries.Authenticate
{
    public class AuthenticateUserQuery : IRequest<AuthenticationResponse>
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
    public class AuthenticateUserQueryHandler : IRequestHandler<AuthenticateUserQuery, AuthenticationResponse>
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AuthenticateUserQueryHandler(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }
        public async Task<AuthenticationResponse> Handle(AuthenticateUserQuery query, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<AuthenticationRequest>(query);
            var response = await _accountService.AuthenticateAsync(data);

            if (response.HasError == false)
            {
                foreach (var rol in response.Roles)
                {
                    if (rol == "Agent" || rol == "Client") throw new Exception("You do not have permission to use the web api.");
                }
            }
            return response;
        }
    }
}
