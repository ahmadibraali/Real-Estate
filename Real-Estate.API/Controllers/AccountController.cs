using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Real_Estate.Application.DTOs.Account;
using Real_Estate.Application.Enums;
using Real_Estate.Application.Features.Accounts.Commands.RegisterAdminUser;
using Real_Estate.Application.Features.Accounts.Commands.RegisterDeveloperUser;
using Real_Estate.Application.Features.Accounts.Queries.Authenticate;
using Real_Estate.Application.Interfaces.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Real_Estate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Servicios de cuentas")]
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Authenticate")]
        [SwaggerOperation(
           Summary = "Login de usuario",
           Description = "Obtiene todas la propiedades."
        )]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            try
            {
                return Ok(await Mediator.Send(new AuthenticateUserQuery { Email = request.Email, Password = request.Password }));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("RegisterAdminUser")]
        [SwaggerOperation(
           Summary = "Creacion de usuario con rol administrador",
           Description = "Recibe los parametros necesarios para crear un usuario con el rol administrador."
        )]
        public async Task<IActionResult> RegisterAdminAsync(RegisterAdminUserCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }  
        }

        [HttpPost("RegisterDeveloperUser")]
        [SwaggerOperation(
           Summary = "Creacion de usuario con rol desarrollador",
           Description = "Recibe los parametros necesarios para crear un usuario con el rol desarrollador."
        )]
        public async Task<IActionResult> RegisterDeveloperAsync(RegisterDeveloperUserCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
