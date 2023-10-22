using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Real_Estate.Application.Features.TypeOfProperties.Commands.DeleteTypeOfPropertiesById;
using Real_Estate.Application.Features.TypeOfSales.Commands.CreateTypeOfSales;
using Real_Estate.Application.Features.TypeOfSales.Commands.DeleteTypeOfSales;
using Real_Estate.Application.Features.TypeOfSales.Commands.UpdateTypeOfSales;
using Real_Estate.Application.Features.TypeOfSales.Queries.GetAllTypeOfSales;
using Real_Estate.Application.Features.TypeOfSales.Queries.GetTypeOfSalesById;
using Real_Estate.Application.Interfaces.Services;
using Real_Estate.Application.ViewModels.TypeOfSales;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace Real_Estate.API.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Mantenimiento de tipo de ventas")]
    public class TypeOfSalesController : BaseApiController
    {
        [Authorize(Policy = "RequireOnlyAdminAndDeveloper")]
        [HttpGet]
        [SwaggerOperation(
           Summary = "List of sales type ",
           Description = "Gets all registered sales types."
        )]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TypeOfSalesViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> List()
        {
            try
            {
                var typeOfProperties = await Mediator.Send(new GetAllTypeOfSalesQuery());

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
           Summary = "Sales type by ID",
           Description = "Gets a sale type using the id as a filter."
        )]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveTypeOfSalesViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var typeOfSale = await Mediator.Send(new GetTypeOfSalesByIdQuery { Id = id });
                return Ok(typeOfSale);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [SwaggerOperation(
          Summary = "Creation of sales type",
          Description = "Receive the necessary parameters for a new type of sale."
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(CreateTypeOfSalesCommand command)
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
               Summary = "Sales type update",
               Description = "Receive the necessary parameters to modify an existing type of sale."
        )]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveTypeOfSalesViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, TypeOfSalesUpdateCommand command)
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
            Summary = "Delete a type of sale",
            Description = "Receive the necessary parameters to delete an existing type of sale."
        )]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await Mediator.Send(new DeleteTypeOfSalesByIdCommand { Id = id });
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

