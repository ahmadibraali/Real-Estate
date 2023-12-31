﻿using MediatR;
using Real_Estate.Application.Interfaces.Repositories;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Features.Improvements.Commands.DeleteImprovementsById
{
    public class DeleteImprovementsByIdCommand : IRequest<int>
    {
        [SwaggerParameter(Description = "Improvment to be deleted")]
        public int Id { get; set; }
    }

    public class DeleteImprovementsByIdCommandHandler : IRequestHandler<DeleteImprovementsByIdCommand, int>
    {
        private readonly IImprovementsRepository _improvementsRepository;
        private readonly IPropertiesRepository _propertiesRepository;
        private readonly IPropertiesImprovementsRepository _propertiesImprovementsRepository;
        public DeleteImprovementsByIdCommandHandler(IImprovementsRepository improvementsRepository, IPropertiesRepository propertiesRepository, IPropertiesImprovementsRepository propertiesImprovementsRepository)
        {
            _improvementsRepository = improvementsRepository;
            _propertiesRepository = propertiesRepository;
            _propertiesImprovementsRepository = propertiesImprovementsRepository;
        }
        public async Task<int> Handle(DeleteImprovementsByIdCommand command, CancellationToken cancellationToken)
        {
            var improvements = await _improvementsRepository.GetByIdAsync(command.Id);

            if (improvements == null) throw new Exception("Improvement was not found.");

            var improvementsProperties = await _propertiesImprovementsRepository.GetAllAsync();

            var improvementList = improvementsProperties.Where(x => x.ImprovementId == command.Id);

            if (improvementList is not null)
            {
                foreach (var improvement in improvementList)
                {
                    await _propertiesImprovementsRepository.DeleteAsync(improvement);
                }
            }

            await _improvementsRepository.DeleteAsync(improvements);

            return improvements.Id;
        }
    }
}
