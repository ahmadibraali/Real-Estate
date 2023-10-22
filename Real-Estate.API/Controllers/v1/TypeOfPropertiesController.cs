using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Real_Estate.Application.Features.Improvements.Commands.DeleteImprovementsById;
using Real_Estate.Application.Features.TypeOfProperties.Commands.CreateTypeOfProperties;
using Real_Estate.Application.Features.TypeOfProperties.Commands.DeleteTypeOfPropertiesById;
using Real_Estate.Application.Features.TypeOfProperties.Commands.UpdateTypeOfProperties;
using Real_Estate.Application.Features.TypeOfProperties.Queries.GetAllTypeOfProperties;
using Real_Estate.Application.Features.TypeOfProperties.Queries.GetTypeOfPropertiesById;
using Real_Estate.Application.Interfaces.Services;
using Real_Estate.Application.ViewModels.TypeOfProperties;
using Swashbuckle.AspNetCore.Annotations;

namespace Real_Estate.API.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Property type maintenance")]
    public class TypeOfPropertiesController : BaseApiController
    {
        [Authorize(Policy = "RequireOnlyAdminAndDeveloper")]
        [HttpGet]
        [SwaggerOperation(
           Summary = "List of property types",
           Description = "Gets all registered sales types."
        )]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TypeOfPropertiesViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> List()
        {
            try
            {
                var typeOfProperties = await Mediator.Send(new GetAllTypeOfPropertiesQuery());
                return Ok(typeOfProperties);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Policy = "RequireOnlyAdminAndDeveloper")]
        [HttpGet("{id}")]
        [SwaggerOperation(
           Summary = "Property Type by Id",
           Description = "Gets a property type using the id as a filter."
        )]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveTypeOfPropertiesViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var typeOfProperty = await Mediator.Send(new GetTypeOfPropertiesByIdQuery { Id = id});
                return Ok(typeOfProperty);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [SwaggerOperation(
          Summary = "Property type creation",
          Description = "Receive the necessary parameters for a new property type."
        )]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(CreateTypeOfPropertiesCommand command)
        {
            try
            {
                await Mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [SwaggerOperation(
               Summary = "Property type update",
               Description = "Receive the necessary parameters to modify an existing type of property."
        )]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveTypeOfPropertiesViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, UpdateTypeOfPropertiesCommand command)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                if (id != command.Id)
                {
                    return BadRequest();
                }
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete a type of property",
            Description = "Receive the necessary parameters to delete an existing type of property."
        )]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await Mediator.Send(new DeleteTypeOfPropertiesByIdCommand { Id = id });
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

