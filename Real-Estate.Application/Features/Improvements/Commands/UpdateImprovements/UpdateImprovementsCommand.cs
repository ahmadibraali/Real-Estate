using AutoMapper;
using MediatR;
using Real_Estate.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Features.Improvements.Commands.UpdateImprovements
{
    using Real_Estate.Domain.Entities;
    using Swashbuckle.AspNetCore.Annotations;
    using System.ComponentModel.DataAnnotations;

    public class UpdateImprovementsCommand : IRequest<UpdateImprovementsResponse>
    {
        public int Id { get; set; }
        [SwaggerParameter(Description = "Name of improvment")]
        [Required(ErrorMessage = "Name is required .")]
        public string Name { get; set; }
        [SwaggerParameter(Description = "Descripcion of improvment")]
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
    }

    public class UpdateImprovementsCommandHandler : IRequestHandler<UpdateImprovementsCommand, UpdateImprovementsResponse>
    {
        private readonly IImprovementsRepository _improvementsRepository;
        private readonly IMapper _mapper;
        public UpdateImprovementsCommandHandler(IImprovementsRepository improvementRepository, IMapper mapper)
        {
            _improvementsRepository = improvementRepository;
            _mapper = mapper;
        }
        public async Task<UpdateImprovementsResponse> Handle(UpdateImprovementsCommand command, CancellationToken cancellationToken)
        {
            var improvement = await _improvementsRepository.GetByIdAsync(command.Id);

            if (improvement == null) throw new Exception("Improvment was not found.");

            improvement = _mapper.Map<Improvements>(command);

            await _improvementsRepository.UpdateAsync(improvement, improvement.Id);

            var improvementResponse = _mapper.Map<UpdateImprovementsResponse>(improvement);

            return improvementResponse;
        }
    }
}
