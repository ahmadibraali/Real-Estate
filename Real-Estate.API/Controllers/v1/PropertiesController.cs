using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Real_Estate.Application.Features.Properties.Queries.GetAllProperties;
using Real_Estate.Application.Features.Properties.Queries.GetPropertiesById;
using Real_Estate.Application.Interfaces.Services;
using Real_Estate.Application.ViewModels.Properties;
using Swashbuckle.AspNetCore.Annotations;

namespace Real_Estate.API.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [SwaggerTag("Properties Queries")]
    public class PropertiesController : BaseApiController
    {
       
        [Authorize(Policy = "RequireOnlyAdminAndDeveloper")]
        [HttpGet]
        [SwaggerOperation(
           Summary = "List of properties",
           Description = "Get all properties."
        )]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PropertiesViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> List()
        {
            try
            {
                var properties = await Mediator.Send(new GetAllPropertiesQuery());
                return Ok(properties);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Policy = "RequireOnlyAdminAndDeveloper")]
        [HttpGet("{id}")]
        [SwaggerOperation(
           Summary = "Property by Id",
           Description = "Gets the property using the id as a filter."
        )]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PropertiesViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var property = await Mediator.Send(new GetPropertiesByIdQuery { Id = id });
                return Ok(property);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Policy = "RequireOnlyAdminAndDeveloper")]
        [HttpGet("{code}")]
        [SwaggerOperation(
           Summary = "Property by code",
           Description = "Get the property using the code as a filter."
        )]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PropertiesViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByCode(string code)
        {
            try
            {
                var property = await Mediator.Send(new GetPropertiesByCodeQuery { Code = code });
                return Ok(property);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
