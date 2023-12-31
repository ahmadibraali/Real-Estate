﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Real_Estate.Application.Features.Agents.Commands.CreateAgents;
using Real_Estate.Application.Features.Agents.Queries.GetAgentsById;
using Real_Estate.Application.Features.Agents.Queries.GetAllAgentProperties;
using Real_Estate.Application.Features.Agents.Queries.GetAllAgents;
using Real_Estate.Application.ViewModels.Agents;
using Real_Estate.Application.ViewModels.Properties;
using Swashbuckle.AspNetCore.Annotations;

namespace Real_Estate.API.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [SwaggerTag("Agent Queries")]
    public class AgentsController : BaseApiController
    {
        [Authorize(Policy = "RequireOnlyAdminAndDeveloper")]
        [HttpGet]
        [SwaggerOperation(
           Summary = "List of agents",
           Description = "Gets all registered sales types."
        )]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AgentsViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> List()
        {
            try
            {
                return Ok(await Mediator.Send(new GetAllAgentsQuery()));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Policy = "RequireOnlyAdminAndDeveloper")]
        [HttpGet("{id}")]
        [SwaggerOperation(
           Summary = "Agent by Id",
           Description = "Get the agent using the id as a filter."
        )]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AgentsViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var agent = await Mediator.Send(new GetAgentsByIdQuery { Id = id });
                return Ok(agent);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Policy = "RequireOnlyAdminAndDeveloper")]
        [HttpGet("{id}")]
        [SwaggerOperation(
           Summary = "Agent's Property Listing",
           Description = "Get all the agent properties using the id as a filter."
        )]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PropertiesViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAgentProperty(string id)
        {
            try
            {
                var agentProperties = await Mediator.Send(new GetAllAgentPropertiesQuery { Id = id });
                return Ok(agentProperties);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [SwaggerOperation(
           Summary = "Agent status change",
           Description = "Change the state of an agent."
        )]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PropertiesViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ChangeStatus(ChangeStatusAgentCommand command)
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
    }
}
