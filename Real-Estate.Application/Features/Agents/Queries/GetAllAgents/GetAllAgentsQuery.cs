﻿using AutoMapper;
using MediatR;
using Real_Estate.Application.Interfaces.Repositories;
using Real_Estate.Application.Interfaces.Services;
using Real_Estate.Application.ViewModels.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Features.Agents.Queries.GetAllAgents
{
    public class GetAllAgentsQuery : IRequest<IEnumerable<AgentsViewModel>>
    {
    }
    public class GetAllAgentsQueryHandler : IRequestHandler<GetAllAgentsQuery, IEnumerable<AgentsViewModel>>
    {
        private readonly IAccountService _accountService;
        private readonly IPropertiesRepository _propertiesRepository;
        private readonly IMapper _mapper;
        public GetAllAgentsQueryHandler(IAccountService accountService, IPropertiesRepository propertiesRepository, IMapper mapper)
        {
            _accountService = accountService;
            _propertiesRepository = propertiesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AgentsViewModel>> Handle(GetAllAgentsQuery query, CancellationToken cancellationToken)
        {
            var agents = await _accountService.GetAllAgents();
            if (agents.Count() == 0) throw new Exception("The properties do not exist.");
            var properties = await _propertiesRepository.GetAllAsync();
            foreach (var agent in agents)
            {
                agent.PropertiesQuantity = properties.Where(x => x.AgentId == agent.Id).Count();
            }
            return agents;

        }
    }
}
