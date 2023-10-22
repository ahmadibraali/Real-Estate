using AutoMapper;
using MediatR;
using Real_Estate.Application.Interfaces.Repositories;

namespace Real_Estate.Application.Features.TypeOfProperties.Commands.UpdateTypeOfProperties
{
    using Real_Estate.Domain.Entities;
    using Swashbuckle.AspNetCore.Annotations;
    using System.ComponentModel.DataAnnotations;

    public class UpdateTypeOfPropertiesCommand : IRequest<UpdateTypeOfPropertiesResponse>
    {
        public int Id { get; set; }
        [SwaggerParameter(Description = "Property Name")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [SwaggerParameter(Description = "Property description")]
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
    }

    public class UpdateTypeOfPropertiesCommandHandler : IRequestHandler<UpdateTypeOfPropertiesCommand, UpdateTypeOfPropertiesResponse>
    {
        private readonly ITypeOfPropertiesRepository _improvementsRepository;
        private readonly IMapper _mapper;
        public UpdateTypeOfPropertiesCommandHandler(ITypeOfPropertiesRepository improvementRepository, IMapper mapper)
        {
            _improvementsRepository = improvementRepository;
            _mapper = mapper;
        }
        public async Task<UpdateTypeOfPropertiesResponse> Handle(UpdateTypeOfPropertiesCommand command, CancellationToken cancellationToken)
        {
            var improvement = await _improvementsRepository.GetByIdAsync(command.Id);

            if (improvement == null) throw new Exception("Property type is not found.");

            improvement = _mapper.Map<TypeOfProperties>(command);

            await _improvementsRepository.UpdateAsync(improvement, improvement.Id);

            var improvementResponse = _mapper.Map<UpdateTypeOfPropertiesResponse>(improvement);

            return improvementResponse;
        }
    }

}
