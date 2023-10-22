using AutoMapper;
using MediatR;
using Real_Estate.Application.Features.Agents.Commands.ChangeStatusAgent;
using Real_Estate.Application.Interfaces.Services;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Features.Agents.Commands.CreateAgents
{
    public class ChangeStatusAgentCommand: IRequest<bool>
    {
        [SwaggerParameter(Description = "Agent ID")]
        public string Id { get; set; }
        [SwaggerParameter(Description = "The changed state")]
        public bool Status { get; set; }
    }
    public class ChangeStatusAgentCommandHandler : IRequestHandler<ChangeStatusAgentCommand, bool>
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        public ChangeStatusAgentCommandHandler(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }
        public async Task<bool> Handle(ChangeStatusAgentCommand command, CancellationToken cancellationToken)
        {
            var users = await _accountService.GetAllUsers();
            var user = users.FirstOrDefault(x => x.Id == command.Id);
            if (user is null) throw new Exception("Agent does not exist");
            var result = await _accountService.ChangesStatusUser(command.Id, command.Status);
            return result;
        }
    }
}
